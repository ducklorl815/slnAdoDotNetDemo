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
        SqlCommandBuilder builder = new SqlCommandBuilder();
        SqlDataAdapter adapter;

        private int _postion = -1;
        public FrmProductList()
        {
            InitializeComponent();
        }

        private void btnReSet_Click(object sender, EventArgs e)
        {
            refresh();
        }
        private void setGridStyle()
        {
            dataProductList.Columns[0].Width = 50;
            dataProductList.Columns[1].Width = 350;
            dataProductList.Columns[2].Width = 80;
            dataProductList.Columns[3].Width = 100;
            dataProductList.Columns[4].Width = 100;
            dataProductList.Columns[5].Width = 300;

            bool isColorChanged = false;
            foreach (DataGridViewRow r in dataProductList.Rows)
            {
                isColorChanged = !isColorChanged;
                r.DefaultCellStyle.BackColor = Color.LightYellow;
                if (isColorChanged)
                    r.DefaultCellStyle.BackColor = Color.Wheat;
            }
             
        }
        private void refresh()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=dbDemo;Integrated Security=True";
            con.Open();
            adapter = new SqlDataAdapter("SELECT * FROM tProduct", con);/* where fActived = 0*/
            builder.DataAdapter = adapter;

            DataSet ds = new DataSet();
            adapter.Fill(ds);
            con.Close();
            dataProductList.DataSource = ds.Tables[0];
            setGridStyle();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            FrmProductEditor F = new FrmProductEditor();

            F.ShowDialog();
            if (!F.btnClickButtion == true)
                return;

            CProduct p = F.product;
            DataTable table = dataProductList.DataSource as DataTable;
            DataRow row = table.NewRow();

            //row["fId"] = F.product.id;

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

        private void dataProductList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            _postion = e.RowIndex;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_postion < 0)
                return;

            DataTable table = dataProductList.DataSource as DataTable;
            DataRow row = table.Rows[_postion];
            CProduct p = new CProduct()
            {
                id = (int)row["fId"],
                name = row["fName"].ToString(),
                qty = (int)row["fQty"],
                cost = (decimal)row["fCost"],
                price = (decimal)row["fPrice"],
            };

            FrmProductEditor F = new FrmProductEditor();
            F.product = p;                     //把P的資料用F.product秀出來

            F.ShowDialog();
            if (!F.btnClickButtion == true)
                return;
            
            row["fId"] = F.product.id;         //修改完後的F.product丟回row
            row["fName"] = F.product.name;
            row["fQty"] = F.product.qty;
            row["fCost"] = F.product.cost;
            row["fPrice"] = F.product.price;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_postion < 0)
                return;

            DataTable table = dataProductList.DataSource as DataTable;
            DataRow row = table.Rows[_postion];

            row["fActived"] = 1;
            //row.Delete();
        }

        private void FrmProductList_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataTable table = dataProductList.DataSource as DataTable;
            if(table.Rows.Count>0)
                 adapter.Update(table);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=dbDemo;Integrated Security=True";
            con.Open();
            adapter = new SqlDataAdapter("UPDATE tCustomer SET fActived=0", con);
            builder.DataAdapter = adapter;
            con.Close();

        }

        private void btnSerch_Click(object sender, EventArgs e)
        {
            Frm_keyword f = new Frm_keyword();


            f.ShowDialog();

            DataTable table = dataProductList.DataSource as DataTable;
            string sql = $" fName LIKE '%{f.keyword}%' " +
                         $" OR fCost = '{f.keyword}' " +
                         $" OR fQty = '{f.keyword}' " +
                         $" OR fPrice = '{f.keyword}' ";

            //string sql = " fName LIKE  '%" + f.keyword + "%'";
            //sql += "  OR fCost = '" + f.keyword + "'";
            //sql += "  OR fPrice = '" + f.keyword + "'";
            //sql += "  OR fQty = '" + f.keyword + "'";

            DataView dv = table.DefaultView;
            dv.RowFilter = sql;

            dataProductList.DataSource = dv;
            
            ////int a = dv;
            //dataProductList.Rows[0].Cells[1].Style.BackColor = Color.White;
            //DefaultCellStyle.BackColor

            //DataTable table = dataProductList.DataSource as DataTable;
            ////table = dataSet.Tables["Suppliers"];
            //table.Rows = PS.product.id;
            ////row["fId"] = PS.product.id;         //修改完後的F.product丟回row
            ////row["fName"] = PS.product.name;
            //row["fQty"] = PS.product.qty;
            //row["fCost"] = PS.product.cost;
            //row["fPrice"] = PS.product.price;

            //$"SELECT * FROM tCustomer WHERE fName LIKE @K_Key" +
            //    $" OR fPhone LIKE @K_Key" +
            //    $" OR fEmail LIKE @K_Key" +
            //    $" OR fAddress LIKE @K_Key";
        }


    }

}
