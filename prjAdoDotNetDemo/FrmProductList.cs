using prjAdoDotNetDemo.Module;
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
        private int postion = -1;
        public FrmProductList()
        {
            InitializeComponent();
        }

        private void btnReSet_Click(object sender, EventArgs e)
        {
            refresh();

        }

        private void refresh()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=dbDemo;Integrated Security=True";
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM tProduct", con);
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
            if (!F.btnClickButtion == true)
                return;

            CProduct p = F.product;
            DataTable table = dataProductList.DataSource as DataTable;
            DataRow row = table.NewRow();
            row["fId"] = F.product.id;

            row["fId"] = p.id;
            row["fName"] = p.name;
            row["fCost"] = p.cost;
            row["fQty"] = p.qty;
            row["fPrice"] = p.price;
            table.Rows.Add(row);

        }

        private void FrmProductList_Load(object sender, EventArgs e)
        {
            refresh();
        }
    }
}
