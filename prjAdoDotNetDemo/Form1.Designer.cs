
namespace prjAdoDotNetDemo
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Button btnDelete;
            System.Windows.Forms.Button btnUpdate;
            System.Windows.Forms.Button btnSelect;
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.txrNum = new System.Windows.Forms.TextBox();
            this.labSelect = new System.Windows.Forms.Label();
            btnDelete = new System.Windows.Forms.Button();
            btnUpdate = new System.Windows.Forms.Button();
            btnSelect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(465, 32);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(112, 55);
            this.btnInsert.TabIndex = 0;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDelete
            // 
            btnDelete.Location = new System.Drawing.Point(465, 125);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(112, 55);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new System.Drawing.Point(465, 225);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new System.Drawing.Size(112, 55);
            btnUpdate.TabIndex = 2;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnSelect
            // 
            btnSelect.Location = new System.Drawing.Point(465, 319);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new System.Drawing.Size(112, 55);
            btnSelect.TabIndex = 3;
            btnSelect.Text = "Select";
            btnSelect.UseVisualStyleBackColor = true;
            btnSelect.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.Location = new System.Drawing.Point(605, 32);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(112, 55);
            this.btnAdmin.TabIndex = 4;
            this.btnAdmin.Text = "管理者";
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // txrNum
            // 
            this.txrNum.Location = new System.Drawing.Point(623, 337);
            this.txrNum.Name = "txrNum";
            this.txrNum.Size = new System.Drawing.Size(69, 22);
            this.txrNum.TabIndex = 5;
            this.txrNum.Text = "10";
            // 
            // labSelect
            // 
            this.labSelect.AutoSize = true;
            this.labSelect.Location = new System.Drawing.Point(23, 19);
            this.labSelect.Name = "labSelect";
            this.labSelect.Size = new System.Drawing.Size(33, 12);
            this.labSelect.TabIndex = 6;
            this.labSelect.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labSelect);
            this.Controls.Add(this.txrNum);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(btnSelect);
            this.Controls.Add(btnUpdate);
            this.Controls.Add(btnDelete);
            this.Controls.Add(this.btnInsert);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.TextBox txrNum;
        private System.Windows.Forms.Label labSelect;
    }
}

