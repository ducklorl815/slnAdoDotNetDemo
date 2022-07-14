using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace prjAdoDotNetDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=dbDemo;Integrated Security=True";
            con.Open();

            string sql = "INSERT INTO tCustomer(fName,fPhone,fEmail,fAdress,fPassword,fActived) VALUES";
            sql += "('Duck','0912031980','arduous815@hotmail.com','NewTaipei','123feqwf','0')";

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("新增資料成功");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=dbDemo;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;
            cmd.CommandText = "DELETE FROM tCustomer WHERE fName='Duck'";
            cmd.ExecuteNonQuery();


            con.Close();

            MessageBox.Show("刪除資料成功");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=dbDemo;Integrated Security=True";
            con.Open();

            string sql = "Update tCustomer SET fPhone='0909958887',fEmail='ducklorl815@gmail.com' WHERE fName='Duck'";
            

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("修改資料成功");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=dbDemo;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM tCustomer";

            SqlDataReader Reader = cmd.ExecuteReader();

            Reader.Read();

            string s = "沒有資料";

            if (Reader.Read())
            {
                //s = Reader["fName"].ToString() +"\n"+ Reader["fPhone"].ToString()+" / "+Reader["fEmail"].ToString();
                s = $"{Reader["fName"]}\n{Reader["fPhone"]} / {Reader["fEmail"]}";
            }

            con.Close();
            MessageBox.Show($"查詢資料為: {s}");
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            (new FrmCustomerEditor()).Show();
        }
    }
}
