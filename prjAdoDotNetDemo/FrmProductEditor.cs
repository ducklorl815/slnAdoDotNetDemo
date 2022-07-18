using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjAdoDotNetDemo
{
    public partial class FrmProductEditor : Form
    {
        public FrmProductEditor()
        {
            InitializeComponent();
        }
        //private string _FID;
        //public string FID
        //{
        //    get { return _FID; }
        //    set { _FID = value; }
        //}
        public string FID { get; set; }
        public string Names { get; set; }
        public string Qty { get; set; }
        public string Cost { get; set; }
        public string Price { get; set; }

        bool _btnClickOK = false;
        public bool btnClickButtion
        {
            get { return _btnClickOK; }
            set { _btnClickOK = value; }
        }

        private void btnAccess_Click(object sender, EventArgs e)
        {
            _btnClickOK = true;
            FID = txtfID.Text;
            Names = txtName.Text;
            Qty = txtQty.Text;
            Cost = txtCost.Text;
            Price = txtPrice.Text;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
