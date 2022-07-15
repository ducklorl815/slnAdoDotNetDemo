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
    public partial class Frm_keyword : Form
    {
        bool _isOkClick = false;
        public Frm_keyword()
        {
            InitializeComponent();
        }

        public string keyword 
        { 
            get 
            {
                return txtKeyword.Text;    //把輸入的值 回傳到 keyword 上
                                           //抓到keyword的鍵值 然後再加以使用
            }
            set 
            {
                txtKeyword.Text = value;
            }
        }

        public bool isOkClickButton
        {
            get
            {
                return _isOkClick;    
            }
        }
        private void btnAccess_Click(object sender, EventArgs e)
        {
            _isOkClick = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
