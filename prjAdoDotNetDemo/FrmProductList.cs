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
            this.Dock = DockStyle.Fill;
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
            Color bgColor; // 準備設定 要強制回復想要的基本初始背景色
            foreach (DataGridViewRow r in dataProductList.Rows) //搜尋每一ROW
            {
                isColorChanged = !isColorChanged; //2.察覺改色觸動往下走
                bgColor = Color.PapayaWhip; //設定想要的初始色
                if (isColorChanged)
                    bgColor = Color.LightSteelBlue; //設定想要的初始色
                foreach (DataGridViewCell c in r.Cells)
                {
                    c.Style.BackColor = bgColor; //1.強制改色 去發動條件 isColorChanged 
                }
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

            DataView dv = new DataView();
            dv.Table= ds.Tables[0];
            dataProductList.DataSource = dv;

            //dataProductList.DataSource = ds.Tables[0];

            cboColumn.Items.Clear();
            foreach (DataColumn c in ds.Tables[0].Columns) 
            {
                cboColumn.Items.Add(c.ColumnName);
            }

            setGridStyle();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            FrmProductEditor F = new FrmProductEditor();

            F.ShowDialog();
            if (!F.btnClickButtion == true)
                return;

            CProduct p = F.product;
            DataView dv = dataProductList.DataSource as DataView;
            DataRow row = dv.Table.NewRow();

            //row["fId"] = F.product.id;

            row["fId"] = p.id;
            row["fName"] = p.name;
            row["fCost"] = p.cost;
            row["fQty"] = p.qty;
            row["fPrice"] = p.price;
            dv.Table.Rows.Add(row);
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

            DataView dv = dataProductList.DataSource as DataView;
            DataRow row = dv.Table.Rows[_postion];
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

            DataView dv = dataProductList.DataSource as DataView;
            DataRow row = dv.Table.Rows[_postion];

            row["fActived"] = 1;
            //row.Delete();
        }

        private void FrmProductList_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataView dv = dataProductList.DataSource as DataView;
            if(dv.Count>0)
                 adapter.Update(dv.Table);
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "鹹酥雞資料檔|*.xml";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                DataView dv = dataProductList.DataSource as DataView;

                MessageBox.Show("OK");

                DataTable tExport = new DataTable("tExportOnlyForUeberEat.com");
                tExport.Columns.Add("品名");
                tExport.Columns.Add("數量");
                tExport.Columns.Add("售價");
                foreach (DataRow r in dv.Table.Rows)
                {
                    DataRow row = tExport.NewRow();
                    row["品名"] = r["fName"].ToString();
                    row["數量"] = 1 +"份";
                    decimal price = (decimal)r["fPrice"];
                    row["售價"] = (price * 1.3M).ToString("0") + " 元";
                    tExport.Rows.Add(row);
                }

                tExport.WriteXml(saveFileDialog1.FileName);

            }
        }

        private void btnSerch_Click(object sender, EventArgs e)
        {
            Frm_keyword f = new Frm_keyword();
            f.ShowDialog();

            if (f.isOkClickButton)
            {
                setGridStyle();
                foreach (DataGridViewRow r in dataProductList.Rows)//每個ROW
                {
                    foreach (DataGridViewCell c in r.Cells)//每一格
                    {
                        if (c.Value == null)//沒找到 
                            continue; //繼續找
                        if (c.Value.ToString().ToUpper().Contains(f.keyword.ToUpper().ToString()))
                        {//Value 是object 要轉型字串 指令才會有反應   //Contains 模糊比對
                            c.Style.BackColor = Color.Yellow;
                        }
                    }
                }
            }
            //之前寫的
            #region 
            //DataTable table = dataProductList.DataSource as DataTable;
            //string sql = $" fName LIKE '%{f.keyword}%' " +
            //             $" OR fCost = '{f.keyword}' " +
            //             $" OR fQty = '{f.keyword}' " +
            //             $" OR fPrice = '{f.keyword}' ";

            //DataView dv = table.DefaultView;

            //dv.RowFilter = sql;

            //dataProductList.DataSource = dv;

            //List<object> rowid = new List<object>();

            //foreach (DataRowView row in dv)
            //{
            //    rowid.Add(row["fId"]);

            //}

            //foreach (object id in rowid)
            //{
            //    //使用指定的 DataTable、RowFilter、Sort 和 DataViewRowState，初始化 DataView 類別的新執行個體。
            //    DataView dv2 = new DataView(table, sql, "fId", DataViewRowState.CurrentRows);
            //    int index = dv2.Find(id);
            //    dataProductList.Rows[index].DefaultCellStyle.BackColor = Color.Yellow;
            //}
            #endregion
        }

        private void cboColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView dv = dataProductList.DataSource as DataView;
            dv.Sort=cboColumn.Text+" DESC";
            setGridStyle();
        }
    }

}
