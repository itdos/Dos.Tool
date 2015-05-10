namespace Hxj.Tools.EntityDesign.DbSelect
{
    partial class DbSqlite
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DbSqlite));
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panelDB = new System.Windows.Forms.Panel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtfilepath = new System.Windows.Forms.TextBox();
            this.rbdatabaseselect = new System.Windows.Forms.RadioButton();
            this.rbconnstring = new System.Windows.Forms.RadioButton();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panelDB.SuspendLayout();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(260, 257);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "取消";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(134, 257);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "确定";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panelDB
            // 
            this.panelDB.Controls.Add(this.txtPassword);
            this.panelDB.Controls.Add(this.button1);
            this.panelDB.Controls.Add(this.txtfilepath);
            this.panelDB.Location = new System.Drawing.Point(111, 17);
            this.panelDB.Name = "panelDB";
            this.panelDB.Size = new System.Drawing.Size(314, 127);
            this.panelDB.TabIndex = 15;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(23, 73);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(188, 21);
            this.txtPassword.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(218, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "请选择";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtfilepath
            // 
            this.txtfilepath.Location = new System.Drawing.Point(23, 25);
            this.txtfilepath.Name = "txtfilepath";
            this.txtfilepath.ReadOnly = true;
            this.txtfilepath.Size = new System.Drawing.Size(188, 21);
            this.txtfilepath.TabIndex = 2;
            // 
            // rbdatabaseselect
            // 
            this.rbdatabaseselect.AutoSize = true;
            this.rbdatabaseselect.Checked = true;
            this.rbdatabaseselect.Location = new System.Drawing.Point(39, 47);
            this.rbdatabaseselect.Name = "rbdatabaseselect";
            this.rbdatabaseselect.Size = new System.Drawing.Size(65, 16);
            this.rbdatabaseselect.TabIndex = 1;
            this.rbdatabaseselect.TabStop = true;
            this.rbdatabaseselect.Text = "数据库:";
            this.rbdatabaseselect.UseVisualStyleBackColor = true;
            this.rbdatabaseselect.CheckedChanged += new System.EventHandler(this.rbdatabaseselect_CheckedChanged);
            // 
            // rbconnstring
            // 
            this.rbconnstring.AutoSize = true;
            this.rbconnstring.Location = new System.Drawing.Point(39, 208);
            this.rbconnstring.Name = "rbconnstring";
            this.rbconnstring.Size = new System.Drawing.Size(89, 16);
            this.rbconnstring.TabIndex = 5;
            this.rbconnstring.Text = "连接字符串:";
            this.rbconnstring.UseVisualStyleBackColor = true;
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Enabled = false;
            this.txtConnectionString.Location = new System.Drawing.Point(134, 208);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(273, 21);
            this.txtConnectionString.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "密码:";
            // 
            // fileDialog
            // 
            this.fileDialog.FileName = "*.mdb";
            // 
            // DbSqlite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 297);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panelDB);
            this.Controls.Add(this.rbdatabaseselect);
            this.Controls.Add(this.rbconnstring);
            this.Controls.Add(this.txtConnectionString);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DbSqlite";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sqlite连接";
            this.panelDB.ResumeLayout(false);
            this.panelDB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panelDB;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtfilepath;
        private System.Windows.Forms.RadioButton rbdatabaseselect;
        private System.Windows.Forms.RadioButton rbconnstring;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog fileDialog;

    }
}