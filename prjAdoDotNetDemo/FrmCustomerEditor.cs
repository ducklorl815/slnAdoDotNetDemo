using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjAdoDotNetDemo
{
    public partial class FrmCustomerEditor : Form
    {
    
        public FrmCustomerEditor()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sql= $"DELETE FROM tCustomer WHERE fId= " + txtfID.Text;
            My_execute(sql);
            MessageBox.Show("刪除資料成功");
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO tCustomer(";
            sql += "fName,";
            sql += "fPhone,";  //要新增欄位加這順位第二
            sql += "fEmail,";
            sql += "fAddress,";
            sql += "fPassword,";  //要新增欄位加這倒數第二
            sql += "fActived";

            sql += ") VALUES(";     //----------------------

            sql += "'"+txtName.Text+"',";
            sql += "'"+txtPhone.Text+"',";   //要新增欄位加這順位第二
            sql += "'"+txtEmail.Text+"',";
            sql += "'"+txtAddress.Text+"',";
            sql += "'"+txtPassword.Text+"',";   //要新增欄位加這倒數第二
            sql += "'0')";

            My_execute(sql);
            MessageBox.Show("新增資料成功");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string sql = "Update tCustomer SET ";
            sql += "fName='" + txtName.Text + "',";
            sql += "fPhone='" + txtPhone.Text + "',";
            sql += "fEmail='" + txtEmail.Text + "',";
            sql += "fAddress='" + txtAddress.Text + "',";
            sql += "fPassword='" + txtPassword.Text + "'";
            sql += "WHERE fId=" + txtfID.Text;

            My_execute(sql);
            MessageBox.Show("修改資料成功");
        }

        List<int> pks = new List<int>(); //todo 重要!!  把fId存進去的重點
        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=dbDemo;Integrated Security=True";

            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM tCustomer";
            SqlDataReader Reader = cmd.ExecuteReader();
            listState.Items.Clear();
            while (Reader.Read())
            {
                pks.Add((int)Reader["fId"]);//todo 重要!!  把fId存進去的重點
                listState.Items.Add(Reader["fName".ToString()]);
            }
            con.Close();
        }

        private void displaySql(string sql)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=dbDemo;Integrated Security=True";

            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = sql; //下面顯示誰 選到什麼!!!
            SqlDataReader Reader = cmd.ExecuteReader();

            if (Reader.Read())//下面顯示誰 選到什麼!!!
            {
                txtfID.Text = Reader["fId"].ToString();
                txtName.Text = Reader["fName"].ToString();
                txtPhone.Text = Reader["fPhone"].ToString();
                txtEmail.Text = Reader["fEmail"].ToString();
                txtAddress.Text = Reader["fAddress"].ToString();
                txtPassword.Text = Reader["fPassword"].ToString();//顯示誰 看WHERE fId選到什麼!!!
            }
            con.Close();
        }
        private void listState_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = listState.SelectedIndex;
            int pk = pks[i];
            displaySql("SELECT * FROM tCustomer WHERE fId=" + pk);
            //cmd.CommandText = "SELECT * FROM tCustomer WHERE fId=" + pk;

        }
        private void My_execute(string sql)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=dbDemo;Integrated Security=True";

            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();

            con.Close();
        }

        private void btnSerch_Click(object sender, EventArgs e)
        {
            Frm_keyword f = new Frm_keyword();
            f.Text = "關鍵字作業";
            f.ShowDialog();

            if (f.isOkClickButton)
            {
                string sql = "SELECT * FROM tCustomer WHERE fName LIKE '%" + f.keyword + "%'";
                sql += "OR fPhone LIKE '%" + f.keyword + "%'";
                sql += "OR fEmail LIKE '%" + f.keyword + "%'";
                sql += "OR fAddress LIKE '%" + f.keyword + "%'";
                displaySql(sql);
            }
        }
    }
}
