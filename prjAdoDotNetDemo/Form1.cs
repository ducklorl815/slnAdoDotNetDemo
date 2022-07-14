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
        Random rnd = new Random();
        private void button1_Click(object sender, EventArgs e)
        {
            string[] firstname = { "趙", "錢", "孫", "李", "周", "吳", "鄭", "王", "馮", "陳", "褚", "衛", "蔣", "沈", "韓", "楊" };
            string[] lastname = { "家豪", "志明", "俊傑", "建宏", "俊宏", "志豪", "志偉", "文雄", "金龍", "志強", "淑芬", "淑惠", "美玲", "雅婷", "美惠", "麗華", "淑娟", "淑貞", "怡君", "淑華" };
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=dbDemo;Integrated Security=True";
            con.Open();
            string name = firstname[rnd.Next(0, firstname.Length)] + lastname[rnd.Next(0, lastname.Length)];
            string sql = "INSERT INTO tCustomer(fName,fPhone,fEmail,fAdress,fPassword,fActived) VALUES";
            sql += $"('{name}'," +
                "'0912031980'," +
                "'arduous815@hotmail.com'," +
                "'NewTaipei'," +
                "'123feqwf'," +
                "'0')";

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
            cmd.CommandText = "DELETE FROM tCustomer";
            //cmd.CommandText = "DELETE FROM tCustomer WHERE fName='Duck'";
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
            //MessageBox.Show(Reader.VisibleFieldCount.ToString());

            labSelect.Text = "";
            string s = "";
            for (int i = 0; i < int.Parse(txrNum.Text); i++)
            {
                //Reader.Read();
                if (Reader.Read())
                {                                       //fName,fPhone,fEmail,fAdress,fPassword,fActived
                    //s = Reader["fName"].ToString() +"\n"+ Reader["fPhone"].ToString()+" / "+Reader["fEmail"].ToString();
                    s +=($"{Reader["fName"]}  " +
                         $"{Reader["fPhone"]}  " +
                         $"{Reader["fEmail"]}  " +
                         $"{Reader["fAdress"]}  \n");
                }
                else
                {
                    labSelect.Text = "沒有資料";
                }
            }
            labSelect.Text = s;


            //if (Reader.Read())
            //{                                       //fName,fPhone,fEmail,fAdress,fPassword,fActived
            //    labSelect.Text = "";
            //    //s = Reader["fName"].ToString() +"\n"+ Reader["fPhone"].ToString()+" / "+Reader["fEmail"].ToString();
            //    s = $"{Reader["fName"]}  " +
            //        $"{Reader["fPhone"]}  " +
            //        $"{Reader["fEmail"]}  " +
            //        $"{Reader["fAdress"]}  ";
            //}
            con.Close();



            //MessageBox.Show($"查詢資料為: {s}");
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            (new FrmCustomerEditor()).Show();
        }
    }
}
