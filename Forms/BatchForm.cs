using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Dos.DbObjects;

namespace Dos.Tools
{
    public partial class BatchForm : Form
    {
        public BatchForm()
        {
            InitializeComponent();
        }


        private string databaseName;
        public string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }

        private Model.Connection connectionModel;
        public Model.Connection ConnectionModel
        {
            get { return connectionModel; }
            set { connectionModel = value; }
        }

        IDbObject dbObject;

        Model.Sysconfig sysconfigModel;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BatchForm_Load(object sender, EventArgs e)
        {
            sysconfigModel = Utils.GetSysconfigModel();
            txtNamaspace.Text = sysconfigModel.Namespace;

            llServer.Text = connectionModel.Name;
            llDatabaseName.Text = DatabaseName;
            txtPath.Text = sysconfigModel.BatchDirectoryPath;


            DataTable tablesDT = null;
            if (ConnectionModel.DbType.Equals(Dos.ORM.DatabaseType.MsAccess.ToString()))
            {
                dbObject = new Dos.DbObjects.OleDb.DbObject(ConnectionModel.ConnectionString);
            }
            else if (ConnectionModel.DbType.Equals(Dos.ORM.DatabaseType.SqlServer.ToString()))
            {
                dbObject = new Dos.DbObjects.SQL2000.DbObject(ConnectionModel.ConnectionString);
            }
            else if (ConnectionModel.DbType.Equals(Dos.ORM.DatabaseType.SqlServer9.ToString()))
            {
                dbObject = new Dos.DbObjects.SQL2005.DbObject(ConnectionModel.ConnectionString);
            }
            else if (ConnectionModel.DbType.Equals(Dos.ORM.DatabaseType.Oracle.ToString()))
            {
                dbObject = new Dos.DbObjects.Oracle.DbObject(ConnectionModel.ConnectionString);
            }
            else if (ConnectionModel.DbType.Equals(Dos.ORM.DatabaseType.Sqlite3.ToString()))
            {
                dbObject = new Dos.DbObjects.SQLite.DbObject(ConnectionModel.ConnectionString);
            }
            else if (ConnectionModel.DbType.Equals(Dos.ORM.DatabaseType.MySql.ToString()))
            {
                dbObject = new Dos.DbObjects.MySQL.DbObject(ConnectionModel.ConnectionString);
            }

            tablesDT = dbObject.GetTables(DatabaseName);
            DataRow[] drs = tablesDT.Select("", "name asc");
            if (null != drs && drs.Length > 0)
            {
                foreach (DataRow dr in drs)
                {
                    lbleft.Items.Add(dr[0]);
                    tableview.Add(dr[0].ToString(), false);
                }
            }

        }


        Dictionary<string, bool> tableview = new Dictionary<string, bool>();

        /// <summary>
        /// 文件选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                txtPath.Text = folderBrowserDialog1.SelectedPath;

        }


        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 全部to
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnallto_Click(object sender, EventArgs e)
        {
            foreach (object o in lbleft.Items)
            {
                lbright.Items.Add(o);
            }

            lbleft.Items.Clear();
        }

        /// <summary>
        /// to
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnto_Click(object sender, EventArgs e)
        {
            if (lbleft.SelectedIndex != -1)
            {
                List<object> list = new List<object>();

                foreach (object o in lbleft.SelectedItems)
                {
                    lbright.Items.Add(o);

                    list.Add(o);
                }

                foreach (object o in list)
                {
                    lbleft.Items.Remove(o);
                }


            }
        }

        /// <summary>
        /// back
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnback_Click(object sender, EventArgs e)
        {
            if (lbright.SelectedIndex != -1)
            {
                List<object> list = new List<object>();

                foreach (object o in lbright.SelectedItems)
                {
                    lbleft.Items.Add(o);

                    list.Add(o);
                }

                foreach (object o in list)
                {
                    lbright.Items.Remove(o);
                }


            }
        }

        /// <summary>
        /// allback
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnallback_Click(object sender, EventArgs e)
        {
            foreach (object o in lbright.Items)
            {
                lbleft.Items.Add(o);
            }

            lbright.Items.Clear();
        }


        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNamaspace.Text))
            {
                MessageBox.Show("命名空间不能为空!");
                return;
            }
            if (string.IsNullOrEmpty(txtPath.Text))
            {
                MessageBox.Show("请先选择要导出的文件夹!");
                return;
            }
            if (!Directory.Exists(txtPath.Text))
            {
                MessageBox.Show("该文件夹路径不存在!");
                return;
            }

            if (lbright.Items.Count == 0)
            {
                MessageBox.Show("请先选择表!");
                return;
            }



            pbar.Maximum = lbright.Items.Count;


            button1.Enabled = false;
            panelbtns.Enabled = false;

            backgroundWorker1.RunWorkerAsync();

        }


        /// <summary>
        /// 开始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            EntityBuilder builder;

            foreach (string o in lbright.Items)
            {
                var ro = !string.IsNullOrWhiteSpace(txtTableStar.Text.Trim())
                    ? o.Trim().Replace(' ', '_').Replace(txtTableStar.Text.Trim(), "")
                    : o.Trim().Replace(' ', '_');
                //var wjj = string.IsNullOrWhiteSpace(txt_wjj.Text.Trim()) ? "" : "." + txt_wjj.Text.Trim();
                //修改原因：需要生成简写表名,同时类名也需要改 例 Com_aa 需要Com文件夹 aa类  命名空间Com.aa
                //修改后效果：根据txtTableStar文本框所填内容来识别去除内容  by kelyljk 2016-2-2
                builder = new EntityBuilder(o, txtNamaspace.Text, //+ wjj
                    ro,
                    Utils.GetColumnInfos(dbObject.GetColumnInfoList(DatabaseName, o)),
                    tableview[o],
                    cbToupperFrstword.Checked,
                    ConnectionModel.DbType,
                    cbEntityTableName.Checked);
                var path = txtPath.Text + "\\" + txt_wjj.Text.Trim();
                //修改后效果：自动生成路劲文件夹 by kelyljk 2016-2-2
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                //修改原因：需要生成简写表名 例 Com_aa 需要Com文件夹 aa类
                //修改后效果：根据txtTableStar文本框所填内容来识别去除内容  by kelyljk 2016-2-2
                using (StreamWriter sw = new StreamWriter(Path.Combine(path,
                    ro + ".cs"),
                    false,
                    Encoding.UTF8))
                {
                    sw.Write(builder.Builder());
                    sw.Close();
                }

                backgroundWorker1.ReportProgress(1);

                System.Threading.Thread.Sleep(1);

            }


        }

        /// <summary>
        /// 报告进度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (pbar.Maximum > pbar.Value)
                pbar.Value += 1;
        }

        /// <summary>
        /// 完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button1.Enabled = true;
            panelbtns.Enabled = true;
            sysconfigModel.BatchDirectoryPath = txtPath.Text;
            sysconfigModel.Namespace = txtNamaspace.Text;
            Utils.WriteNamespace(txtNamaspace.Text);
            Utils.WriteBatchDirectoryPath(txtPath.Text);
            MessageBox.Show("生成成功!");
        }


        /// <summary>
        /// 加载视图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbView_CheckedChanged(object sender, EventArgs e)
        {
            chbView.Enabled = false;


            DataTable tablesDT = dbObject.GetVIEWs(DatabaseName);
            DataRow[] drs = tablesDT.Select("", "name asc");
            if (null != drs && drs.Length > 0)
            {
                foreach (DataRow dr in drs)
                {
                    lbleft.Items.Add(dr[0]);
                    tableview.Add(dr[0].ToString(), true);
                }
            }
        }



        ///修改原因：无法双击列表快速添加表
        ///修改后效果：双击列表中的表 实现快速添加进右边的列表
        ///by kelyljk 2016-2-2
        /// <summary>
        /// 左边双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbleft_DoubleClick(object sender, EventArgs e)
        {
            if (lbleft.SelectedIndex != -1)
            {
                List<object> list = new List<object>();

                foreach (object o in lbleft.SelectedItems)
                {
                    lbright.Items.Add(o);

                    list.Add(o);
                }

                foreach (object o in list)
                {
                    lbleft.Items.Remove(o);
                }


            }
        }

        ///修改原因：无法双击列表快速去除表
        ///修改后效果：双击列表中的表 实现快速添加进左边的列表
        ///by kelyljk 2016-2-2
        /// <summary>
        /// 右边双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbright_DoubleClick(object sender, EventArgs e)
        {
            if (lbright.SelectedIndex != -1)
            {
                List<object> list = new List<object>();

                foreach (object o in lbright.SelectedItems)
                {
                    lbleft.Items.Add(o);

                    list.Add(o);
                }

                foreach (object o in list)
                {
                    lbright.Items.Remove(o);
                }


            }
        }
    }
}
