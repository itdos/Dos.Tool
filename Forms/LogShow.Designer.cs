namespace Hxj.Tools.EntityDesign
{
    partial class LogShow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogShow));
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.cbmerrorlist = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(0, 0);
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(646, 446);
            this.txtLog.TabIndex = 0;
            this.txtLog.Text = "";
            // 
            // cbmerrorlist
            // 
            this.cbmerrorlist.Dock = System.Windows.Forms.DockStyle.Right;
            this.cbmerrorlist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbmerrorlist.FormattingEnabled = true;
            this.cbmerrorlist.Location = new System.Drawing.Point(525, 0);
            this.cbmerrorlist.Name = "cbmerrorlist";
            this.cbmerrorlist.Size = new System.Drawing.Size(121, 20);
            this.cbmerrorlist.TabIndex = 1;
            this.cbmerrorlist.SelectedIndexChanged += new System.EventHandler(this.cbmerrorlist_SelectedIndexChanged);
            // 
            // LogShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 446);
            this.Controls.Add(this.cbmerrorlist);
            this.Controls.Add(this.txtLog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LogShow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "日志查看";
            this.Load += new System.EventHandler(this.LogShow_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.ComboBox cbmerrorlist;
    }
}