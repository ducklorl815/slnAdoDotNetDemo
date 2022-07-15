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
            string[] company = { "gmail", "hotmail", "outlook", "yahoo" };
            string[] place = { "台北", "台中", "新北", "新竹", "苗栗", "嘉義", "台南", "雲林", "宜蘭", "花蓮", "屏東", "高雄" };
            string phone = "";
            string email = "";
            string password = "";
            string name = "";

            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=dbDemo;Integrated Security=True";
            con.Open();

            for (int j = 0; j < int.Parse(txrNum.Text); j++)
            {

                name = firstname[rnd.Next(0, firstname.Length)] + lastname[rnd.Next(0, lastname.Length)];

                phone = "";
                for (int i = 0; i < 8; i++)
                {
                    phone += rnd.Next(0, 9).ToString();
                }
                phone = "09" + phone;

                email = "";
                for (int i = 0; i < rnd.Next(7, 12); i++)
                {
                    email += (char)rnd.Next(97, 122);
                }
                email = email + "@" + company[rnd.Next(0, company.Length)] + ".com.tw";
                password = "";
                for (int i = 0; i < rnd.Next(7, 12); i++)
                {
                    password += (char)rnd.Next(97, 122);
                }

                string sql = "INSERT INTO tCustomer(";
                sql += "fName,";
                sql += "fPhone,";  //要新增欄位加這順位第二
                sql += "fEmail,";
                sql += "fAddress,";
                sql += "fPassword,";  //要新增欄位加這倒數第二
                sql += "fActived";

                sql += ") VALUES (";

                sql += "'" + name + "',";
                sql += "'" + phone + "',";
                sql += "'" + email + "',";
                sql += "'" + place[rnd.Next(0, place.Length)] + "',";
                sql += "'" + password + "',";
                sql += "'0')";

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

            }
            con.Close();
            MessageBox.Show("新增資料成功");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = $"UPDATE tCustomer SET fActived=0";
            My_execute(sql);
            MessageBox.Show("資料重整");
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
            listName.Items.Clear();
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
                         $"{Reader["fAddress"]}  \n");
                    listName.Items.Add(Reader["fName"]);
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
