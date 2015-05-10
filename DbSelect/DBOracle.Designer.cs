namespace Hxj.Tools.EntityDesign.DbSelect
{
    partial class DBOracle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBOracle));
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cbbServer = new System.Windows.Forms.ComboBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chbConnectString = new System.Windows.Forms.CheckBox();
            this.txtConnectString = new System.Windows.Forms.TextBox();
            this.panelServer = new System.Windows.Forms.Panel();
            this.panelServer.SuspendLayout();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(304, 289);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "取消";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(185, 289);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "确定";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(79, 116);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(214, 21);
            this.txtPassword.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 24;
            this.label5.Text = "口  令:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 23;
            this.label4.Text = "用户名:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(34, 289);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "连接/连接测试";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbbServer
            // 
            this.cbbServer.FormattingEnabled = true;
            this.cbbServer.Location = new System.Drawing.Point(79, 23);
            this.cbbServer.Name = "cbbServer";
            this.cbbServer.Size = new System.Drawing.Size(214, 20);
            this.cbbServer.TabIndex = 1;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(79, 68);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(214, 21);
            this.txtUserName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "服  务:";
            // 
            // chbConnectString
            // 
            this.chbConnectString.AutoSize = true;
            this.chbConnectString.Location = new System.Drawing.Point(73, 199);
            this.chbConnectString.Name = "chbConnectString";
            this.chbConnectString.Size = new System.Drawing.Size(84, 16);
            this.chbConnectString.TabIndex = 4;
            this.chbConnectString.Text = "连接字符串";
            this.chbConnectString.UseVisualStyleBackColor = true;
            this.chbConnectString.CheckedChanged += new System.EventHandler(this.chbConnectString_CheckedChanged);
            // 
            // txtConnectString
            // 
            this.txtConnectString.Enabled = false;
            this.txtConnectString.Location = new System.Drawing.Point(73, 232);
            this.txtConnectString.Name = "txtConnectString";
            this.txtConnectString.Size = new System.Drawing.Size(280, 21);
            this.txtConnectString.TabIndex = 5;
            // 
            // panelServer
            // 
            this.panelServer.Controls.Add(this.cbbServer);
            this.panelServer.Controls.Add(this.txtUserName);
            this.panelServer.Controls.Add(this.txtPassword);
            this.panelServer.Controls.Add(this.label1);
            this.panelServer.Controls.Add(this.label5);
            this.panelServer.Controls.Add(this.label4);
            this.panelServer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelServer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panelServer.Location = new System.Drawing.Point(60, 12);
            this.panelServer.Name = "panelServer";
            this.panelServer.Size = new System.Drawing.Size(319, 158);
            this.panelServer.TabIndex = 32;
            // 
            // DBOracle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 346);
            this.Controls.Add(this.txtConnectString);
            this.Controls.Add(this.chbConnectString);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panelServer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DBOracle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "连接到服务器";
            this.panelServer.ResumeLayout(false);
            this.panelServer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbbServer;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chbConnectString;
        private System.Windows.Forms.TextBox txtConnectString;
        private System.Windows.Forms.Panel panelServer;
    }
}