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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        bool isClosed = true;
        private void btnClick_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=dbDemo;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand();
            string sql = $"SELECT * FROM tEmployee WHERE fEmployee = '{txtAccount.Text}'" +
            $"AND fPassword = '{txtPassword.Text}'";

            cmd.Connection = con;
            cmd.CommandText = sql;

            SqlDataReader Reader = cmd.ExecuteReader();

            if (Reader.Read())
            {
                isClosed = false;
                Close();
                con.Close();
                return;
            }
            MessageBox.Show("帳號與密碼不符");
            con.Close();
        }

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = isClosed;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            isClosed = false;
            Application.Exit();
        }

        private void btnNewEmp_Click(object sender, EventArgs e)
        {
            (new FrmCustomerEditor()).ShowDialog();
        }
    }
}
