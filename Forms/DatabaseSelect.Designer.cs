namespace Hxj.Tools.EntityDesign
{
    partial class DatabaseSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseSelect));
            this.rbSqlServer = new System.Windows.Forms.RadioButton();
            this.rbOracle = new System.Windows.Forms.RadioButton();
            this.rbOledb = new System.Windows.Forms.RadioButton();
            this.rbMySql = new System.Windows.Forms.RadioButton();
            this.rbSQLite = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.rbMariaDB = new System.Windows.Forms.RadioButton();
            this.rbPostgreSql = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // rbSqlServer
            // 
            this.rbSqlServer.AutoSize = true;
            this.rbSqlServer.Checked = true;
            this.rbSqlServer.Location = new System.Drawing.Point(47, 45);
            this.rbSqlServer.Name = "rbSqlServer";
            this.rbSqlServer.Size = new System.Drawing.Size(83, 16);
            this.rbSqlServer.TabIndex = 0;
            this.rbSqlServer.TabStop = true;
            this.rbSqlServer.Text = "SQL Server";
            this.rbSqlServer.UseVisualStyleBackColor = true;
            // 
            // rbOracle
            // 
            this.rbOracle.AutoSize = true;
            this.rbOracle.Location = new System.Drawing.Point(47, 95);
            this.rbOracle.Name = "rbOracle";
            this.rbOracle.Size = new System.Drawing.Size(59, 16);
            this.rbOracle.TabIndex = 1;
            this.rbOracle.Text = "Oracle";
            this.rbOracle.UseVisualStyleBackColor = true;
            // 
            // rbOledb
            // 
            this.rbOledb.AutoSize = true;
            this.rbOledb.Location = new System.Drawing.Point(186, 95);
            this.rbOledb.Name = "rbOledb";
            this.rbOledb.Size = new System.Drawing.Size(71, 16);
            this.rbOledb.TabIndex = 2;
            this.rbOledb.Text = "MsAccess";
            this.rbOledb.UseVisualStyleBackColor = true;
            // 
            // rbMySql
            // 
            this.rbMySql.AutoSize = true;
            this.rbMySql.Location = new System.Drawing.Point(186, 45);
            this.rbMySql.Name = "rbMySql";
            this.rbMySql.Size = new System.Drawing.Size(53, 16);
            this.rbMySql.TabIndex = 3;
            this.rbMySql.Text = "MySql";
            this.rbMySql.UseVisualStyleBackColor = true;
            // 
            // rbSQLite
            // 
            this.rbSQLite.AutoSize = true;
            this.rbSQLite.Location = new System.Drawing.Point(314, 95);
            this.rbSQLite.Name = "rbSQLite";
            this.rbSQLite.Size = new System.Drawing.Size(59, 16);
            this.rbSQLite.TabIndex = 4;
            this.rbSQLite.Text = "SQLite";
            this.rbSQLite.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(127, 205);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "下一步";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(236, 205);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // rbMariaDB
            // 
            this.rbMariaDB.AutoSize = true;
            this.rbMariaDB.Location = new System.Drawing.Point(314, 45);
            this.rbMariaDB.Name = "rbMariaDB";
            this.rbMariaDB.Size = new System.Drawing.Size(65, 16);
            this.rbMariaDB.TabIndex = 7;
            this.rbMariaDB.Text = "MariaDB";
            this.rbMariaDB.UseVisualStyleBackColor = true;
            // 
            // rbPostgreSql
            // 
            this.rbPostgreSql.AutoSize = true;
            this.rbPostgreSql.Enabled = false;
            this.rbPostgreSql.Location = new System.Drawing.Point(47, 147);
            this.rbPostgreSql.Name = "rbPostgreSql";
            this.rbPostgreSql.Size = new System.Drawing.Size(83, 16);
            this.rbPostgreSql.TabIndex = 8;
            this.rbPostgreSql.Text = "PostgreSql";
            this.rbPostgreSql.UseVisualStyleBackColor = true;
            // 
            // DatabaseSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 256);
            this.Controls.Add(this.rbPostgreSql);
            this.Controls.Add(this.rbMariaDB);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rbSQLite);
            this.Controls.Add(this.rbMySql);
            this.Controls.Add(this.rbOledb);
            this.Controls.Add(this.rbOracle);
            this.Controls.Add(this.rbSqlServer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DatabaseSelect";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择数据库类型";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbSqlServer;
        private System.Windows.Forms.RadioButton rbOracle;
        private System.Windows.Forms.RadioButton rbOledb;
        private System.Windows.Forms.RadioButton rbMySql;
        private System.Windows.Forms.RadioButton rbSQLite;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton rbMariaDB;
        private System.Windows.Forms.RadioButton rbPostgreSql;
    }
}