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
    public partial class FrmProductList : Form
    {
        public FrmProductList()
        {
            InitializeComponent();
        }

        private void btnReSet_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=dbDemo;Integrated Security=True";
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM tProduct",con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            con.Close();

            dataProductList.DataSource = ds.Tables[0];

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            FrmProductEditor F = new FrmProductEditor();
            F.Text = "關鍵字作業";
            F.ShowDialog();
            if (F.btnClickButtion == true)
            {
                DataTable table = dataProductList.DataSource as DataTable;
                DataRow row = table.NewRow();
                row["fId"] = int.Parse(F.FID);
                row["fName"] = F.Names;
                row["fCost"] = F.Price;
                row["fQty"] = F.Qty;
                row["fPrice"] = F.Price;
                table.Rows.Add(row);
            }
        }
    }
}
