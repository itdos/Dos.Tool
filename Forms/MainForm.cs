using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Dos.Common;
using Dos.Tools.EntityDesign.Forms;

namespace Hxj.Tools.EntityDesign
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        #region 打开数据库视图

        private void MainForm_Load(object sender, EventArgs e)
        {
            showSJKST();

        }

        LeftPanel lp = new LeftPanel();

        /// <summary>
        /// 
        /// </summary>
        private void showSJKST()
        {
            lp.newcontentForm += new LeftPanel.NewContentForm(lp_newcontentForm);
            lp.Show(dpleft);
            lp.DockTo(dpleft, DockStyle.Left);

        }

        /// <summary>
        /// 创建生成
        /// </summary>
        /// <param name="conModel"></param>
        /// <param name="tableName"></param>
        void lp_newcontentForm(Hxj.Tools.EntityDesign.Model.Connection conModel, string tableName, string databaseName, bool isView)
        {
            ContentForm s = new ContentForm();
            s.Text = "(" + databaseName + ")" + tableName;
            s.TableName = tableName;
            s.DatabaseName = databaseName;
            s.IsView = isView;
            s.ConnectionModel = conModel;
            s.Show(dpleft);
        }

        /// <summary>
        /// 数据库视图打开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 数据库视图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lp.Show();
        }

        #endregion

        #region 关闭程序

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            Application.Exit();
        }

        #endregion

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About ab = new About();
            ab.ShowDialog();
        }

        private void 日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogShow ls = new LogShow();
            ls.ShowDialog();
        }

    }
}
