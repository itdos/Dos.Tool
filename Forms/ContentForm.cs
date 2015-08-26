using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Hxj.Tools.EntityDesign
{
    public partial class ContentForm : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public ContentForm()
        {
            InitializeComponent();
        }

        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        private string content;


        private Model.Connection connectionModel;

        public Model.Connection ConnectionModel
        {
            set { connectionModel = value; }
            get { return connectionModel; }
        }

        private string tableName;
        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }

        private bool isView = false;
        public bool IsView
        {
            get { return isView; }
            set { isView = value; }
        }

        private string databaseName;
        public string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContentForm_Load(object sender, EventArgs e)
        {
            Hxj.IDBO.IDbObject dbObject = null;
            if (ConnectionModel.DbType.Equals(Dos.ORM.DatabaseType.SqlServer.ToString()))
            {
                dbObject = new Hxj.DbObjects.SQL2000.DbObject(ConnectionModel.ConnectionString);
            }
            else if (ConnectionModel.DbType.Equals(Dos.ORM.DatabaseType.SqlServer9.ToString()))
            {
                dbObject = new Hxj.DbObjects.SQL2005.DbObject(ConnectionModel.ConnectionString);
            }
            else if (ConnectionModel.DbType.Equals(Dos.ORM.DatabaseType.MsAccess.ToString()))
            {
                dbObject = new Hxj.DbObjects.OleDb.DbObject(ConnectionModel.ConnectionString);
            }
            else if (ConnectionModel.DbType.Equals(Dos.ORM.DatabaseType.Oracle.ToString()))
            {
                dbObject = new Hxj.DbObjects.Oracle.DbObject(ConnectionModel.ConnectionString);
            }
            else if (ConnectionModel.DbType.Equals(Dos.ORM.DatabaseType.Sqlite3.ToString()))
            {
                dbObject = new Hxj.DbObjects.SQLite.DbObject(ConnectionModel.ConnectionString);
            }
            else if (ConnectionModel.DbType.Equals(Dos.ORM.DatabaseType.MySql.ToString()))
            {
                dbObject = new Hxj.DbObjects.MySQL.DbObject(ConnectionModel.ConnectionString);
            }
            else
            {
                MessageBox.Show("未知数据库类型!");
                return;
            }
            columnsdt = dbObject.GetColumnInfoList(DatabaseName, TableName);

            gridColumns.DataSource = columnsdt;

            DataTable primarykeydt = dbObject.GetKeyName(DatabaseName, TableName);

            cbPrimarykey.Items.Clear();

            if (null != primarykeydt && primarykeydt.Rows.Count > 0)
            {
                foreach (DataRow dr in primarykeydt.Rows)
                {
                    cbPrimarykey.Items.Add(dr["ColumnName"].ToString());
                }

                cbPrimarykey.SelectedIndex = 0;
            }

            txtClassName.Text = TableName.Trim().Replace(' ', '_');
            txtnamespace.Text = Utils.ReadNamespace();

        }

        DataTable columnsdt = null;

        /// <summary>
        /// 添加主键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddPrimarykey_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = gridColumns.SelectedRows;
            if (null != rows && rows.Count > 0)
            {
                foreach (DataGridViewRow row in rows)
                {
                    object temp = row.Cells[1].Value;

                    if (!cbPrimarykey.Items.Contains(temp))
                    {
                        cbPrimarykey.Items.Add(temp);
                    }
                }

                cbPrimarykey.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 删除主键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemovePrimarykey_Click(object sender, EventArgs e)
        {
            if (cbPrimarykey.SelectedIndex >= 0)
            {
                cbPrimarykey.Items.RemoveAt(cbPrimarykey.SelectedIndex);
            }

            if (cbPrimarykey.Items.Count > 0)
                cbPrimarykey.SelectedIndex = 0;
        }


        /// <summary>
        /// 代码生成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtnamespace.Text))
            {
                MessageBox.Show("命名空间不能为空!");
                return;
            }
            if (string.IsNullOrEmpty(txtClassName.Text))
            {
                MessageBox.Show("类名不能为空!");
                return;
            }

            Utils.WriteNamespace(txtnamespace.Text);

            List<Model.ColumnInfo> columns = Utils.GetColumnInfos(columnsdt);

            foreach (Model.ColumnInfo col in columns)
            {

                col.IsPK = false;

                foreach (object o in cbPrimarykey.Items)
                {
                    if (col.ColumnName.Equals(o.ToString()))
                    {
                        col.IsPK = true;
                        break;
                    }
                }
            }

            EntityBuilder builder = new EntityBuilder(TableName, txtnamespace.Text, txtClassName.Text, columns, IsView, cbToupperFrstword.Checked, ConnectionModel.DbType);

            txtContent.Text = builder.Builder();

            tabControl1.SelectedIndex = 1;
        }


        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveEntity.FileName = txtClassName.Text;
            saveEntity.Filter = "CS 文件|*.cs";

            if (saveEntity.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveEntity.FileName, false, Encoding.UTF8))
                {
                    sw.Write(txtContent.Text);
                    sw.Close();
                }
            }

        }



    }
}
