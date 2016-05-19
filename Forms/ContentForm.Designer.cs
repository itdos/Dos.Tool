namespace Dos.Tools
{
    partial class ContentForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContentForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tp1 = new System.Windows.Forms.TabPage();
            this.tplContent = new System.Windows.Forms.RichTextBox();
            this.contextMenuStripSave = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tplComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbEntityTableName = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cbToupperFrstword = new System.Windows.Forms.CheckBox();
            this.btnRemovePrimarykey = new System.Windows.Forms.Button();
            this.btnAddPrimarykey = new System.Windows.Forms.Button();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtnamespace = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbPrimarykey = new System.Windows.Forms.ComboBox();
            this.gridColumns = new System.Windows.Forms.DataGridView();
            this.tp2 = new System.Windows.Forms.TabPage();
            this.txtContent = new System.Windows.Forms.RichTextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.saveEntity = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1.SuspendLayout();
            this.tp1.SuspendLayout();
            this.contextMenuStripSave.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridColumns)).BeginInit();
            this.tp2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tp1);
            this.tabControl1.Controls.Add(this.tp2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(875, 665);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tp1
            // 
            this.tp1.Controls.Add(this.tplContent);
            this.tp1.Controls.Add(this.groupBox1);
            this.tp1.Controls.Add(this.gridColumns);
            this.tp1.ImageIndex = 0;
            this.tp1.Location = new System.Drawing.Point(4, 4);
            this.tp1.Name = "tp1";
            this.tp1.Padding = new System.Windows.Forms.Padding(3);
            this.tp1.Size = new System.Drawing.Size(867, 638);
            this.tp1.TabIndex = 0;
            this.tp1.Text = "生成设置";
            this.tp1.UseVisualStyleBackColor = true;
            // 
            // tplContent
            // 
            this.tplContent.ContextMenuStrip = this.contextMenuStripSave;
            this.tplContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tplContent.Location = new System.Drawing.Point(3, 325);
            this.tplContent.Margin = new System.Windows.Forms.Padding(0);
            this.tplContent.Name = "tplContent";
            this.tplContent.Size = new System.Drawing.Size(861, 310);
            this.tplContent.TabIndex = 8;
            this.tplContent.Text = "";
            // 
            // contextMenuStripSave
            // 
            this.contextMenuStripSave.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存ToolStripMenuItem});
            this.contextMenuStripSave.Name = "contextMenuStripSave";
            this.contextMenuStripSave.Size = new System.Drawing.Size(145, 26);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.保存ToolStripMenuItem.Text = "保存";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tplComboBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbEntityTableName);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cbToupperFrstword);
            this.groupBox1.Controls.Add(this.btnRemovePrimarykey);
            this.groupBox1.Controls.Add(this.btnAddPrimarykey);
            this.groupBox1.Controls.Add(this.txtClassName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtnamespace);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbPrimarykey);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 225);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(861, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "生成配置";
            // 
            // tplComboBox
            // 
            this.tplComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tplComboBox.FormattingEnabled = true;
            this.tplComboBox.Location = new System.Drawing.Point(78, 26);
            this.tplComboBox.Name = "tplComboBox";
            this.tplComboBox.Size = new System.Drawing.Size(209, 20);
            this.tplComboBox.TabIndex = 9;
            this.tplComboBox.SelectedIndexChanged += new System.EventHandler(this.tplComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "模板：";
            // 
            // cbEntityTableName
            // 
            this.cbEntityTableName.AutoSize = true;
            this.cbEntityTableName.Checked = true;
            this.cbEntityTableName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEntityTableName.Location = new System.Drawing.Point(684, 11);
            this.cbEntityTableName.Name = "cbEntityTableName";
            this.cbEntityTableName.Size = new System.Drawing.Size(174, 16);
            this.cbEntityTableName.TabIndex = 7;
            this.cbEntityTableName.Text = "生成v1.10.3及以上版本实体";
            this.cbEntityTableName.UseVisualStyleBackColor = true;
            this.cbEntityTableName.Visible = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.Location = new System.Drawing.Point(642, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "生成代码";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbToupperFrstword
            // 
            this.cbToupperFrstword.AutoSize = true;
            this.cbToupperFrstword.Location = new System.Drawing.Point(549, 66);
            this.cbToupperFrstword.Name = "cbToupperFrstword";
            this.cbToupperFrstword.Size = new System.Drawing.Size(84, 16);
            this.cbToupperFrstword.TabIndex = 6;
            this.cbToupperFrstword.Text = "首字母大写";
            this.cbToupperFrstword.UseVisualStyleBackColor = true;
            // 
            // btnRemovePrimarykey
            // 
            this.btnRemovePrimarykey.Location = new System.Drawing.Point(642, 24);
            this.btnRemovePrimarykey.Name = "btnRemovePrimarykey";
            this.btnRemovePrimarykey.Size = new System.Drawing.Size(75, 23);
            this.btnRemovePrimarykey.TabIndex = 3;
            this.btnRemovePrimarykey.Text = "删除主键";
            this.btnRemovePrimarykey.UseVisualStyleBackColor = true;
            this.btnRemovePrimarykey.Click += new System.EventHandler(this.btnRemovePrimarykey_Click);
            // 
            // btnAddPrimarykey
            // 
            this.btnAddPrimarykey.Location = new System.Drawing.Point(549, 24);
            this.btnAddPrimarykey.Name = "btnAddPrimarykey";
            this.btnAddPrimarykey.Size = new System.Drawing.Size(75, 23);
            this.btnAddPrimarykey.TabIndex = 2;
            this.btnAddPrimarykey.Text = "添加主键";
            this.btnAddPrimarykey.UseVisualStyleBackColor = true;
            this.btnAddPrimarykey.Click += new System.EventHandler(this.btnAddPrimarykey_Click);
            // 
            // txtClassName
            // 
            this.txtClassName.Location = new System.Drawing.Point(345, 62);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(178, 21);
            this.txtClassName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(302, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "类名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "命名空间：";
            // 
            // txtnamespace
            // 
            this.txtnamespace.Location = new System.Drawing.Point(78, 63);
            this.txtnamespace.Name = "txtnamespace";
            this.txtnamespace.Size = new System.Drawing.Size(209, 21);
            this.txtnamespace.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(302, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "主键：";
            // 
            // cbPrimarykey
            // 
            this.cbPrimarykey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPrimarykey.FormattingEnabled = true;
            this.cbPrimarykey.Location = new System.Drawing.Point(345, 25);
            this.cbPrimarykey.Name = "cbPrimarykey";
            this.cbPrimarykey.Size = new System.Drawing.Size(178, 20);
            this.cbPrimarykey.TabIndex = 1;
            // 
            // gridColumns
            // 
            this.gridColumns.AllowUserToAddRows = false;
            this.gridColumns.AllowUserToDeleteRows = false;
            this.gridColumns.AllowUserToOrderColumns = true;
            this.gridColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridColumns.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridColumns.Location = new System.Drawing.Point(3, 3);
            this.gridColumns.Name = "gridColumns";
            this.gridColumns.RowTemplate.Height = 23;
            this.gridColumns.Size = new System.Drawing.Size(861, 222);
            this.gridColumns.TabIndex = 0;
            // 
            // tp2
            // 
            this.tp2.Controls.Add(this.txtContent);
            this.tp2.ImageIndex = 1;
            this.tp2.Location = new System.Drawing.Point(4, 4);
            this.tp2.Name = "tp2";
            this.tp2.Padding = new System.Windows.Forms.Padding(3);
            this.tp2.Size = new System.Drawing.Size(867, 638);
            this.tp2.TabIndex = 1;
            this.tp2.Text = "生成代码";
            this.tp2.UseVisualStyleBackColor = true;
            // 
            // txtContent
            // 
            this.txtContent.ContextMenuStrip = this.contextMenuStripSave;
            this.txtContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtContent.Location = new System.Drawing.Point(3, 3);
            this.txtContent.Margin = new System.Windows.Forms.Padding(0);
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(861, 632);
            this.txtContent.TabIndex = 0;
            this.txtContent.Text = "";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "pz.ICO");
            this.imageList1.Images.SetKeyName(1, "cs.ICO");
            // 
            // ContentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 665);
            this.Controls.Add(this.tabControl1);
            this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document;
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "ContentForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ContentForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tp1.ResumeLayout(false);
            this.contextMenuStripSave.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridColumns)).EndInit();
            this.tp2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tp1;
        private System.Windows.Forms.TabPage tp2;
        private System.Windows.Forms.RichTextBox txtContent;
        private System.Windows.Forms.DataGridView gridColumns;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbPrimarykey;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtnamespace;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddPrimarykey;
        private System.Windows.Forms.Button btnRemovePrimarykey;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripSave;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveEntity;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.CheckBox cbToupperFrstword;
        private System.Windows.Forms.CheckBox cbEntityTableName;
        private System.Windows.Forms.RichTextBox tplContent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox tplComboBox;
    }
}