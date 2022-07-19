using prjAdoDotNetDemo.Module;
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
        #region
        //string _Name;
        //string Name
        //{
        //    get
        //    {
        //        return _Name = txtName.Text;
        //    }
        //    set
        //    {
        //        txtName.Text = value;
        //    }
        //}
        #endregion
        CProduct _product = new CProduct();

        public CProduct product
        {
            get
            {
                _product.id = Convert.ToInt32(txtfID.Text);
                _product.name = txtName.Text;
                _product.qty = Convert.ToInt32(txtQty.Text);
                _product.cost = Convert.ToDecimal(txtCost.Text);
                _product.price = Convert.ToDecimal(txtPrice.Text);
                return _product;
                #region
                //try
                //{
                //}
                //catch
                //{
                //    return null;
                //}
                #endregion
            }
            set
            {
                _product = value;
                txtfID.Text = _product.id.ToString();
                txtName.Text = _product.name;
                txtQty.Text = _product.qty.ToString();
                txtCost.Text = _product.cost.ToString("0.0");
                txtPrice.Text = _product.price.ToString("0.0");
            }
        }

        bool _btnClickOK = false;
        public bool btnClickButtion
        {  
            get { return _btnClickOK; }
            set { _btnClickOK = value; }
        }
        bool isDataValidated()
        {
            string message = "";
            if (txtName.Text == "")
                message += "\r\n名稱必須填寫";
            if (txtQty.Text == "")
                message += "\r\n庫存必須填寫";
            if (txtCost.Text == "")
                message += "\r\n成本必須填寫";
            if (txtPrice.Text == "")
                message += "\r\n價格必須填寫";
            if (message != "")
                MessageBox.Show(message);
            return message == "";
        }

        private void btnAccess_Click(object sender, EventArgs e)
        {
            if(!isDataValidated())
                return;
            //if (product == null)
            // { return; }
            _btnClickOK = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
