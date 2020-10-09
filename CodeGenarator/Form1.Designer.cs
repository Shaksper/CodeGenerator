namespace CodeGenarator
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cbdbtype = new System.Windows.Forms.ComboBox();
            this.lblip = new System.Windows.Forms.Label();
            this.lblport = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.lblpw = new System.Windows.Forms.Label();
            this.txtip = new System.Windows.Forms.TextBox();
            this.txtport = new System.Windows.Forms.TextBox();
            this.txtuname = new System.Windows.Forms.TextBox();
            this.txtpwd = new System.Windows.Forms.TextBox();
            this.btnconnect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbdb = new System.Windows.Forms.ComboBox();
            this.btngene = new System.Windows.Forms.Button();
            this.lblstatus = new System.Windows.Forms.Label();
            this.lblnamespace = new System.Windows.Forms.Label();
            this.txtnamespace = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGetTables = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.tableListBox = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(79, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 99;
            this.label1.Text = "数据库类型：";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cbdbtype
            // 
            this.cbdbtype.BackColor = System.Drawing.Color.Teal;
            this.cbdbtype.Enabled = false;
            this.cbdbtype.ForeColor = System.Drawing.Color.White;
            this.cbdbtype.FormattingEnabled = true;
            this.cbdbtype.Items.AddRange(new object[] {
            "MYSQL",
            "SQLSERVER",
            "ORACLE",
            "SQLITE"});
            this.cbdbtype.Location = new System.Drawing.Point(162, 29);
            this.cbdbtype.Name = "cbdbtype";
            this.cbdbtype.Size = new System.Drawing.Size(160, 20);
            this.cbdbtype.TabIndex = 1;
            this.cbdbtype.Text = "请选择数据库类型";
            // 
            // lblip
            // 
            this.lblip.AutoSize = true;
            this.lblip.Location = new System.Drawing.Point(79, 62);
            this.lblip.Name = "lblip";
            this.lblip.Size = new System.Drawing.Size(29, 12);
            this.lblip.TabIndex = 2;
            this.lblip.Text = "ip：";
            // 
            // lblport
            // 
            this.lblport.AutoSize = true;
            this.lblport.Location = new System.Drawing.Point(79, 92);
            this.lblport.Name = "lblport";
            this.lblport.Size = new System.Drawing.Size(41, 12);
            this.lblport.TabIndex = 3;
            this.lblport.Text = "端口：";
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Location = new System.Drawing.Point(79, 120);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(53, 12);
            this.lblname.TabIndex = 4;
            this.lblname.Text = "用户名：";
            // 
            // lblpw
            // 
            this.lblpw.AutoSize = true;
            this.lblpw.Location = new System.Drawing.Point(79, 147);
            this.lblpw.Name = "lblpw";
            this.lblpw.Size = new System.Drawing.Size(41, 12);
            this.lblpw.TabIndex = 5;
            this.lblpw.Text = "密码：";
            // 
            // txtip
            // 
            this.txtip.BackColor = System.Drawing.Color.Teal;
            this.txtip.ForeColor = System.Drawing.Color.White;
            this.txtip.Location = new System.Drawing.Point(162, 59);
            this.txtip.Name = "txtip";
            this.txtip.Size = new System.Drawing.Size(160, 21);
            this.txtip.TabIndex = 6;
            this.txtip.Text = "127.0.0.1";
            // 
            // txtport
            // 
            this.txtport.BackColor = System.Drawing.Color.Teal;
            this.txtport.ForeColor = System.Drawing.Color.White;
            this.txtport.Location = new System.Drawing.Point(162, 89);
            this.txtport.Name = "txtport";
            this.txtport.Size = new System.Drawing.Size(160, 21);
            this.txtport.TabIndex = 7;
            this.txtport.Text = "3306";
            // 
            // txtuname
            // 
            this.txtuname.BackColor = System.Drawing.Color.Teal;
            this.txtuname.ForeColor = System.Drawing.Color.White;
            this.txtuname.Location = new System.Drawing.Point(162, 117);
            this.txtuname.Name = "txtuname";
            this.txtuname.Size = new System.Drawing.Size(160, 21);
            this.txtuname.TabIndex = 8;
            this.txtuname.Text = "zs";
            // 
            // txtpwd
            // 
            this.txtpwd.BackColor = System.Drawing.Color.Teal;
            this.txtpwd.ForeColor = System.Drawing.Color.White;
            this.txtpwd.Location = new System.Drawing.Point(162, 144);
            this.txtpwd.Name = "txtpwd";
            this.txtpwd.PasswordChar = '*';
            this.txtpwd.Size = new System.Drawing.Size(160, 21);
            this.txtpwd.TabIndex = 9;
            this.txtpwd.Text = "123456";
            // 
            // btnconnect
            // 
            this.btnconnect.BackColor = System.Drawing.Color.Teal;
            this.btnconnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnconnect.ForeColor = System.Drawing.Color.White;
            this.btnconnect.Location = new System.Drawing.Point(81, 236);
            this.btnconnect.Name = "btnconnect";
            this.btnconnect.Size = new System.Drawing.Size(84, 31);
            this.btnconnect.TabIndex = 10;
            this.btnconnect.Text = "测试|连接";
            this.btnconnect.UseVisualStyleBackColor = false;
            this.btnconnect.Click += new System.EventHandler(this.btnconnect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "选择数据库：";
            // 
            // cbdb
            // 
            this.cbdb.BackColor = System.Drawing.Color.Teal;
            this.cbdb.ForeColor = System.Drawing.Color.White;
            this.cbdb.FormattingEnabled = true;
            this.cbdb.Location = new System.Drawing.Point(162, 171);
            this.cbdb.Name = "cbdb";
            this.cbdb.Size = new System.Drawing.Size(160, 20);
            this.cbdb.TabIndex = 12;
            // 
            // btngene
            // 
            this.btngene.BackColor = System.Drawing.Color.Teal;
            this.btngene.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btngene.ForeColor = System.Drawing.Color.White;
            this.btngene.Location = new System.Drawing.Point(238, 236);
            this.btngene.Name = "btngene";
            this.btngene.Size = new System.Drawing.Size(84, 31);
            this.btngene.TabIndex = 13;
            this.btngene.Text = "生成Model";
            this.btngene.UseVisualStyleBackColor = false;
            this.btngene.Visible = false;
            this.btngene.Click += new System.EventHandler(this.btngene_Click);
            // 
            // lblstatus
            // 
            this.lblstatus.AutoSize = true;
            this.lblstatus.Location = new System.Drawing.Point(253, 270);
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.Size = new System.Drawing.Size(0, 12);
            this.lblstatus.TabIndex = 14;
            // 
            // lblnamespace
            // 
            this.lblnamespace.AutoSize = true;
            this.lblnamespace.Location = new System.Drawing.Point(79, 208);
            this.lblnamespace.Name = "lblnamespace";
            this.lblnamespace.Size = new System.Drawing.Size(113, 12);
            this.lblnamespace.TabIndex = 15;
            this.lblnamespace.Text = "输入命名空间名称：";
            this.lblnamespace.Visible = false;
            // 
            // txtnamespace
            // 
            this.txtnamespace.BackColor = System.Drawing.Color.Teal;
            this.txtnamespace.ForeColor = System.Drawing.Color.White;
            this.txtnamespace.Location = new System.Drawing.Point(201, 205);
            this.txtnamespace.Name = "txtnamespace";
            this.txtnamespace.Size = new System.Drawing.Size(121, 21);
            this.txtnamespace.TabIndex = 16;
            this.txtnamespace.Text = "CodeGenarator";
            this.txtnamespace.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(236, 303);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "Code by shaksper in 1 Nov 2018.";
            // 
            // btnGetTables
            // 
            this.btnGetTables.BackColor = System.Drawing.Color.Teal;
            this.btnGetTables.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGetTables.ForeColor = System.Drawing.Color.White;
            this.btnGetTables.Location = new System.Drawing.Point(368, 24);
            this.btnGetTables.Name = "btnGetTables";
            this.btnGetTables.Size = new System.Drawing.Size(242, 31);
            this.btnGetTables.TabIndex = 18;
            this.btnGetTables.Text = "获取数据库表";
            this.btnGetTables.UseVisualStyleBackColor = false;
            this.btnGetTables.Click += new System.EventHandler(this.btnGetTables_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.Teal;
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(368, 236);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(242, 31);
            this.btnExport.TabIndex = 19;
            this.btnExport.Text = "导出所选表数据";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // tableListBox
            // 
            this.tableListBox.BackColor = System.Drawing.Color.Teal;
            this.tableListBox.ForeColor = System.Drawing.Color.White;
            this.tableListBox.FormattingEnabled = true;
            this.tableListBox.Location = new System.Drawing.Point(368, 65);
            this.tableListBox.Name = "tableListBox";
            this.tableListBox.Size = new System.Drawing.Size(242, 164);
            this.tableListBox.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(633, 324);
            this.Controls.Add(this.tableListBox);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnGetTables);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtnamespace);
            this.Controls.Add(this.lblnamespace);
            this.Controls.Add(this.lblstatus);
            this.Controls.Add(this.btngene);
            this.Controls.Add(this.cbdb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnconnect);
            this.Controls.Add(this.txtpwd);
            this.Controls.Add(this.txtuname);
            this.Controls.Add(this.txtport);
            this.Controls.Add(this.txtip);
            this.Controls.Add(this.lblpw);
            this.Controls.Add(this.lblname);
            this.Controls.Add(this.lblport);
            this.Controls.Add(this.lblip);
            this.Controls.Add(this.cbdbtype);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CodeGenarator&Export";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Black;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbdbtype;
        private System.Windows.Forms.Label lblip;
        private System.Windows.Forms.Label lblport;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Label lblpw;
        private System.Windows.Forms.TextBox txtip;
        private System.Windows.Forms.TextBox txtport;
        private System.Windows.Forms.TextBox txtuname;
        private System.Windows.Forms.TextBox txtpwd;
        private System.Windows.Forms.Button btnconnect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbdb;
        private System.Windows.Forms.Button btngene;
        private System.Windows.Forms.Label lblstatus;
        private System.Windows.Forms.Label lblnamespace;
        private System.Windows.Forms.TextBox txtnamespace;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGetTables;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.CheckedListBox tableListBox;
    }
}

