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


        private void My_execute(string sql,List<SqlParameter> paras)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=dbDemo;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand();

            if (paras != null)
                cmd.Parameters.AddRange(paras.ToArray());

            #region
            //foreach(SqlParameter X in paras)
            //{
            //    cmd.Parameters.Add(X);
            //}

            //cmd.Parameters.Add(para[0]);
            //cmd.Parameters.Add(para[1]);
            //cmd.Parameters.Add(para[2]);
            //cmd.Parameters.Add(para[3]);
            //cmd.Parameters.Add(para[4]);
            #endregion
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sql = $"UPDATE tCustomer SET fActived=1 WHERE fId=@F_fId";
            //string sql= $"DELETE FROM tCustomer WHERE fId= " + txtfID.Text;
            SqlParameter Dele = new SqlParameter("F_fId",txtfID.Text);

            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(Dele);

            My_execute(sql,paras);
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

            sql += "@K_Name,";
            sql += "@K_Phone,";   //要新增欄位加這順位第二
            sql += "@K_Email,";
            sql += "@K_Address,";
            sql += "@K_Password,";   //要新增欄位加這倒數第二
            sql += "'0')";
            #region
            //sql += "'" + txtName.Text + "',";
            //sql += "'" + txtPhone.Text + "',";   //要新增欄位加這順位第二
            //sql += "'" + txtEmail.Text + "',";
            //sql += "'" + txtAddress.Text + "',";
            //sql += "'" + txtPassword.Text + "',";   //要新增欄位加這倒數第二
            //sql += "'0')";
            #endregion
            List<SqlParameter> paras = new List<SqlParameter>();

            //SqlParameter name = new SqlParameter("K_Name", (object)txtName.Text));
            //paras.Add(name)

            paras.Add(new SqlParameter("K_Name", (object)txtName.Text));
            paras.Add(new SqlParameter("K_Phone", (object)txtPhone.Text));
            paras.Add(new SqlParameter("K_Email", (object)txtEmail.Text));
            paras.Add(new SqlParameter("K_Address", (object)txtAddress.Text));
            paras.Add(new SqlParameter("K_Password", (object)txtPassword.Text));

            My_execute(sql,paras);
            MessageBox.Show("新增資料成功");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string sql = "Update tCustomer SET ";
            sql += "fName=@K_Name,";
            sql += "fPhone=@K_Phone,";
            sql += "fEmail=@K_Email,";
            sql += "fAddress=@K_Address,";
            sql += "fPassword=@K_Password";
            sql += " WHERE fId=@K_Fid";

            List<SqlParameter> paras = new List<SqlParameter>();

            paras.Add(new SqlParameter("K_Fid", (object)txtfID.Text));
            paras.Add(new SqlParameter("K_Name", (object)txtName.Text));
            paras.Add(new SqlParameter("K_Phone", (object)txtPhone.Text));
            paras.Add(new SqlParameter("K_Email", (object)txtEmail.Text));
            paras.Add(new SqlParameter("K_Address", (object)txtAddress.Text));
            paras.Add(new SqlParameter("K_Password", (object)txtPassword.Text));


            My_execute(sql,paras);
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
            cmd.CommandText = "SELECT * FROM tCustomer WHERE fActived=0";
            SqlDataReader Reader = cmd.ExecuteReader();
            listState.Items.Clear();
            while (Reader.Read())
            {
                pks.Add((int)Reader["fId"]);//todo 重要!!  把fId存進去的重點
                listState.Items.Add(Reader["fId"]+" "+Reader["fName".ToString()]);
            }
            con.Close();
        }
        #region  
        //多重執行序 也可以做出displaySql(string sql) 與 displaySql(string sql,List<SqlParameter> paras)

        //private void displaySql(string sql)
        //{
        //    SqlConnection con = new SqlConnection();
        //    con.ConnectionString = @"Data Source=.;Initial Catalog=dbDemo;Integrated Security=True";

        //    con.Open();
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = con;

        //    cmd.CommandText = sql; //下面顯示誰 選到什麼!!!
        //    SqlDataReader Reader = cmd.ExecuteReader();


        //    if (Reader.Read())//下面顯示誰 選到什麼!!!
        //    {
        //        txtfID.Text = Reader["fId"].ToString();
        //        txtName.Text = Reader["fName"].ToString();
        //        txtPhone.Text = Reader["fPhone"].ToString();
        //        txtEmail.Text = Reader["fEmail"].ToString();
        //        txtAddress.Text = Reader["fAddress"].ToString();
        //        txtPassword.Text = Reader["fPassword"].ToString();//顯示誰 看WHERE fId選到什麼!!!
        //    }
        //    con.Close();
        //}
        #endregion
        private void displaySql(string sql,List<SqlParameter> paras)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=dbDemo;Integrated Security=True";

            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            if (paras != null)
                cmd.Parameters.AddRange(paras.ToArray());

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

            string sql = "SELECT * FROM tCustomer WHERE fId=@PK";
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("PK",(object)pk));

            displaySql(sql, paras);

            //displaySql("SELECT * FROM tCustomer WHERE fId=" + pk);
            //cmd.CommandText = "SELECT * FROM tCustomer WHERE fId=" + pk;
        }


        private void btnSerch_Click(object sender, EventArgs e)
        {
            Frm_keyword f = new Frm_keyword();
            f.Text = "關鍵字作業";
            f.ShowDialog();
 

            if (f.isOkClickButton)
            {
                List<SqlParameter> paras = new List<SqlParameter>();
                string sql = $"SELECT * FROM tCustomer WHERE fName LIKE @K_Key" +
                $" OR fPhone LIKE @K_Key" +
                $" OR fEmail LIKE @K_Key" +
                $" OR fAddress LIKE @K_Key";

                paras.Add(new SqlParameter("K_Key", (object)$"%{f.keyword}%"));
                displaySql(sql,paras);
            }
        }
    }
}
