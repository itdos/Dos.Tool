namespace Hxj.Tools.EntityDesign
{
    partial class BatchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BatchForm));
            this.label1 = new System.Windows.Forms.Label();
            this.lbleft = new System.Windows.Forms.ListBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.llServer = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.llDatabaseName = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panelbtns = new System.Windows.Forms.Panel();
            this.chbView = new System.Windows.Forms.CheckBox();
            this.btnallto = new System.Windows.Forms.Button();
            this.btnallback = new System.Windows.Forms.Button();
            this.btnto = new System.Windows.Forms.Button();
            this.btnback = new System.Windows.Forms.Button();
            this.lbright = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbToupperFrstword = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtNamaspace = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.pbar = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelbtns.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(338, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "数据库:";
            // 
            // lbleft
            // 
            this.lbleft.FormattingEnabled = true;
            this.lbleft.ItemHeight = 12;
            this.lbleft.Location = new System.Drawing.Point(30, 20);
            this.lbleft.Name = "lbleft";
            this.lbleft.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbleft.Size = new System.Drawing.Size(201, 208);
            this.lbleft.TabIndex = 1;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(111, 76);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(328, 21);
            this.txtPath.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(171, 457);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "导出";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.llServer);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.llDatabaseName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(596, 62);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据库";
            // 
            // llServer
            // 
            this.llServer.AutoSize = true;
            this.llServer.Location = new System.Drawing.Point(63, 29);
            this.llServer.Name = "llServer";
            this.llServer.Size = new System.Drawing.Size(0, 12);
            this.llServer.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "服务器:";
            // 
            // llDatabaseName
            // 
            this.llDatabaseName.AutoSize = true;
            this.llDatabaseName.Location = new System.Drawing.Point(405, 29);
            this.llDatabaseName.Name = "llDatabaseName";
            this.llDatabaseName.Size = new System.Drawing.Size(0, 12);
            this.llDatabaseName.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panelbtns);
            this.groupBox2.Controls.Add(this.lbright);
            this.groupBox2.Controls.Add(this.lbleft);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(596, 244);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "表选择";
            // 
            // panelbtns
            // 
            this.panelbtns.Controls.Add(this.chbView);
            this.panelbtns.Controls.Add(this.btnallto);
            this.panelbtns.Controls.Add(this.btnallback);
            this.panelbtns.Controls.Add(this.btnto);
            this.panelbtns.Controls.Add(this.btnback);
            this.panelbtns.Location = new System.Drawing.Point(252, 20);
            this.panelbtns.Name = "panelbtns";
            this.panelbtns.Size = new System.Drawing.Size(90, 208);
            this.panelbtns.TabIndex = 16;
            // 
            // chbView
            // 
            this.chbView.AutoSize = true;
            this.chbView.Location = new System.Drawing.Point(17, 4);
            this.chbView.Name = "chbView";
            this.chbView.Size = new System.Drawing.Size(72, 16);
            this.chbView.TabIndex = 16;
            this.chbView.Text = "加载视图";
            this.chbView.UseVisualStyleBackColor = true;
            this.chbView.CheckedChanged += new System.EventHandler(this.chbView_CheckedChanged);
            // 
            // btnallto
            // 
            this.btnallto.Location = new System.Drawing.Point(15, 40);
            this.btnallto.Name = "btnallto";
            this.btnallto.Size = new System.Drawing.Size(75, 23);
            this.btnallto.TabIndex = 12;
            this.btnallto.Text = ">>";
            this.btnallto.UseVisualStyleBackColor = true;
            this.btnallto.Click += new System.EventHandler(this.btnallto_Click);
            // 
            // btnallback
            // 
            this.btnallback.Location = new System.Drawing.Point(15, 171);
            this.btnallback.Name = "btnallback";
            this.btnallback.Size = new System.Drawing.Size(75, 23);
            this.btnallback.TabIndex = 15;
            this.btnallback.Text = "<<";
            this.btnallback.UseVisualStyleBackColor = true;
            this.btnallback.Click += new System.EventHandler(this.btnallback_Click);
            // 
            // btnto
            // 
            this.btnto.Location = new System.Drawing.Point(15, 82);
            this.btnto.Name = "btnto";
            this.btnto.Size = new System.Drawing.Size(75, 23);
            this.btnto.TabIndex = 13;
            this.btnto.Text = ">";
            this.btnto.UseVisualStyleBackColor = true;
            this.btnto.Click += new System.EventHandler(this.btnto_Click);
            // 
            // btnback
            // 
            this.btnback.Location = new System.Drawing.Point(15, 131);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(75, 23);
            this.btnback.TabIndex = 14;
            this.btnback.Text = "<";
            this.btnback.UseVisualStyleBackColor = true;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // lbright
            // 
            this.lbright.FormattingEnabled = true;
            this.lbright.ItemHeight = 12;
            this.lbright.Location = new System.Drawing.Point(362, 20);
            this.lbright.Name = "lbright";
            this.lbright.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbright.Size = new System.Drawing.Size(201, 208);
            this.lbright.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbToupperFrstword);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.txtNamaspace);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtPath);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 306);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(596, 118);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "参数设置";
            // 
            // cbToupperFrstword
            // 
            this.cbToupperFrstword.AutoSize = true;
            this.cbToupperFrstword.Location = new System.Drawing.Point(364, 34);
            this.cbToupperFrstword.Name = "cbToupperFrstword";
            this.cbToupperFrstword.Size = new System.Drawing.Size(84, 16);
            this.cbToupperFrstword.TabIndex = 10;
            this.cbToupperFrstword.Text = "首字母大写";
            this.cbToupperFrstword.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(445, 74);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "请选择…";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtNamaspace
            // 
            this.txtNamaspace.Location = new System.Drawing.Point(111, 32);
            this.txtNamaspace.Name = "txtNamaspace";
            this.txtNamaspace.Size = new System.Drawing.Size(154, 21);
            this.txtNamaspace.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 12);
            this.label3.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "命名空间:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(405, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 12);
            this.label6.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "导出文件夹:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(330, 457);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "取消";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pbar
            // 
            this.pbar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbar.Location = new System.Drawing.Point(0, 498);
            this.pbar.Name = "pbar";
            this.pbar.Size = new System.Drawing.Size(596, 23);
            this.pbar.TabIndex = 12;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // BatchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 521);
            this.Controls.Add(this.pbar);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BatchForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "批量生成";
            this.Load += new System.EventHandler(this.BatchForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panelbtns.ResumeLayout(false);
            this.panelbtns.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbleft;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label llServer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label llDatabaseName;
        private System.Windows.Forms.ListBox lbright;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtNamaspace;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnallback;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Button btnto;
        private System.Windows.Forms.Button btnallto;
        private System.Windows.Forms.ProgressBar pbar;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panelbtns;
        private System.Windows.Forms.CheckBox chbView;
        private System.Windows.Forms.CheckBox cbToupperFrstword;
    }
}