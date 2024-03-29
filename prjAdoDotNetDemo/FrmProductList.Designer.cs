﻿
namespace prjAdoDotNetDemo
{
    partial class FrmProductList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Button btnSerch;
            System.Windows.Forms.Button btnUpdate;
            System.Windows.Forms.Button btnDelete;
            System.Windows.Forms.Button btnOut;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button4 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboColumn = new System.Windows.Forms.ComboBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.dataProductList = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            btnSerch = new System.Windows.Forms.Button();
            btnUpdate = new System.Windows.Forms.Button();
            btnDelete = new System.Windows.Forms.Button();
            btnOut = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataProductList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSerch
            // 
            btnSerch.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            btnSerch.Location = new System.Drawing.Point(20, 265);
            btnSerch.Name = "btnSerch";
            btnSerch.Size = new System.Drawing.Size(100, 45);
            btnSerch.TabIndex = 8;
            btnSerch.Text = "查詢";
            btnSerch.UseVisualStyleBackColor = true;
            btnSerch.Click += new System.EventHandler(this.btnSerch_Click);
            // 
            // btnUpdate
            // 
            btnUpdate.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            btnUpdate.Location = new System.Drawing.Point(20, 143);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new System.Drawing.Size(100, 45);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "修改";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            btnDelete.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            btnDelete.Location = new System.Drawing.Point(20, 82);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(100, 45);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "刪除";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnOut
            // 
            btnOut.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            btnOut.Location = new System.Drawing.Point(20, 385);
            btnOut.Name = "btnOut";
            btnOut.Size = new System.Drawing.Size(100, 45);
            btnOut.TabIndex = 9;
            btnOut.Text = "匯出";
            btnOut.UseVisualStyleBackColor = true;
            btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button4.Location = new System.Drawing.Point(20, 204);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 45);
            this.button4.TabIndex = 7;
            this.button4.Text = "重整";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnReSet_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboColumn);
            this.panel1.Controls.Add(btnOut);
            this.panel1.Controls.Add(btnSerch);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.btnInsert);
            this.panel1.Controls.Add(btnUpdate);
            this.panel1.Controls.Add(btnDelete);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(783, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(135, 491);
            this.panel1.TabIndex = 2;
            // 
            // cboColumn
            // 
            this.cboColumn.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.cboColumn.FormattingEnabled = true;
            this.cboColumn.Location = new System.Drawing.Point(20, 331);
            this.cboColumn.Name = "cboColumn";
            this.cboColumn.Size = new System.Drawing.Size(100, 32);
            this.cboColumn.TabIndex = 10;
            this.cboColumn.SelectedIndexChanged += new System.EventHandler(this.cboColumn_SelectedIndexChanged);
            // 
            // btnInsert
            // 
            this.btnInsert.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnInsert.Location = new System.Drawing.Point(20, 21);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(100, 45);
            this.btnInsert.TabIndex = 4;
            this.btnInsert.Text = "新增";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // dataProductList
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            this.dataProductList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataProductList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Thistle;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataProductList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataProductList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataProductList.EnableHeadersVisualStyles = false;
            this.dataProductList.Location = new System.Drawing.Point(0, 0);
            this.dataProductList.Name = "dataProductList";
            this.dataProductList.RowTemplate.Height = 24;
            this.dataProductList.Size = new System.Drawing.Size(783, 491);
            this.dataProductList.TabIndex = 3;
            this.dataProductList.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataProductList_RowEnter);
            // 
            // FrmProductList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 491);
            this.Controls.Add(this.dataProductList);
            this.Controls.Add(this.panel1);
            this.Name = "FrmProductList";
            this.Text = "FrmProductList";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmProductList_FormClosed);
            this.Load += new System.EventHandler(this.FrmProductList_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataProductList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.DataGridView dataProductList;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox cboColumn;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}