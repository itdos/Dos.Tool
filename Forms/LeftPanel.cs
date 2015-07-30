using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Hxj.Tools.EntityDesign
{
    public partial class LeftPanel : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public LeftPanel()
        {
            InitializeComponent();
            tview.ExpandAll();
        }

        public delegate void NewContentForm(Model.Connection conModel, string tableName, string databaseName, bool isView);

        public event NewContentForm newcontentForm;

        /// <summary>
        /// 新建数据库连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            showDbSelect();
        }

        /// <summary>
        /// 获取服务器列表
        /// </summary>
        private void showDbSelect()
        {
            DatabaseSelect dbSelect = new DatabaseSelect();

            if (dbSelect.ShowDialog() == DialogResult.OK)
            {
                DialogResult dia = DialogResult.No;

                switch (DatabaseSelect.DatabaseType)
                {
                    case Dos.ORM.DatabaseType.SqlServer:
                        DbSelect.DBSqlServer dbsqlserver = new Hxj.Tools.EntityDesign.DbSelect.DBSqlServer();
                        dia = dbsqlserver.ShowDialog();
                        break;
                    case Dos.ORM.DatabaseType.MsAccess:
                        DbSelect.DBMsAccess dbMsAccess = new Hxj.Tools.EntityDesign.DbSelect.DBMsAccess();
                        dia = dbMsAccess.ShowDialog();
                        break;
                    case Dos.ORM.DatabaseType.Oracle:
                        DbSelect.DBOracle dbOracle = new Hxj.Tools.EntityDesign.DbSelect.DBOracle();
                        dia = dbOracle.ShowDialog();
                        break;
                    case Dos.ORM.DatabaseType.Sqlite3:
                        DbSelect.DbSqlite dbSqlite = new Hxj.Tools.EntityDesign.DbSelect.DbSqlite();
                        dia = dbSqlite.ShowDialog();
                        break;
                    case Dos.ORM.DatabaseType.MySql:
                        DbSelect.DBMySql dbMySql = new Hxj.Tools.EntityDesign.DbSelect.DBMySql();
                        dia = dbMySql.ShowDialog();
                        break;
                    default:
                        break;
                }

                if (dia == DialogResult.OK)
                {
                    refreshConnectionList();
                }
            }
        }

        /// <summary>
        /// 连接
        /// </summary>
        List<Model.Connection> list;

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LeftPanel_Load(object sender, EventArgs e)
        {

            this.CloseButtonVisible = false;


            getServers();


           
        }

        #region top servers


        /// <summary>
        /// 获取服务器列表
        /// </summary>
        private void getServers()
        {
            tview.Nodes.Clear();

            tview.Nodes.Add("服务器", "服务器", 0);

            list = Utils.GetConnectionList();

            TreeNode node = tview.Nodes[0];

            node.ContextMenuStrip = contextMenuStripTop;
            foreach (Model.Connection connection in list)
            {
                TreeNode nnode = new TreeNode(connection.Name, 0, 0);
                nnode.ContextMenuStrip = contextMenuStripDatabase;
                nnode.Tag = connection.ID.ToString();
                node.Nodes.Add(nnode);
            }

            tview.ExpandAll();
        }

        /// <summary>
        /// 右击选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tview_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ((TreeView)sender).SelectedNode = e.Node;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showDbSelect();
        }

        /// <summary>
        /// 刷新服务器
        /// </summary>
        private void refreshConnectionList()
        {
            List<Model.Connection> connList = Utils.GetConnectionList();

            foreach (Model.Connection conn in connList)
            {
                Model.Connection tempconn = list.Find(delegate(Model.Connection connin) { return conn.ID.ToString().Equals(connin.ID.ToString()); });
                if (null == tempconn)
                {
                    TreeNode nnode = new TreeNode(conn.Name, 0, 0);
                    nnode.ContextMenuStrip = contextMenuStripDatabase;
                    nnode.Tag = conn.ID.ToString();
                    tview.Nodes[0].Nodes.Add(nnode);
                }
            }

            list = connList;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            refreshConnectionList();
        }
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string stringid = tview.SelectedNode.Tag.ToString();
            Utils.DeleteConnection(stringid);
            Model.Connection tempconn = list.Find(delegate(Model.Connection conn) { return conn.ID.ToString().Equals(stringid); });
            if (null != tempconn)
                list.Remove(tempconn);
            tview.Nodes.Remove(tview.SelectedNode);
        }

        #endregion

        #region database

        private void 连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = tview.SelectedNode;
            node.Nodes.Clear();

            getDatabaseinfo();
        }



        private void 刷新ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TreeNode node = tview.SelectedNode;
            node.Nodes.Clear();

            getDatabaseinfo();
        }


        /// <summary>
        /// 
        /// </summary>
        private void getDatabaseinfo()
        {
            TreeNode node = tview.SelectedNode;

            Model.Connection conModel = list.Find(delegate(Model.Connection con) { return con.ID.ToString().Equals(node.Tag.ToString()); });

            IDBO.IDbObject dbObject;

            if (conModel.DbType.Equals(Dos.ORM.DatabaseType.MsAccess.ToString()))
            {
                dbObject = new Hxj.DbObjects.OleDb.DbObject(conModel.ConnectionString);

                TreeNode tnode = new TreeNode(conModel.Database, 1, 1);
                tnode.Tag = conModel.ConnectionString;
                tnode.ContextMenuStrip = contextMenuStripOneDataBase;
                node.Nodes.Add(tnode);



                gettables(tnode, dbObject.GetTables(""), dbObject.GetVIEWs(""));


            }
            else if (conModel.DbType.Equals(Dos.ORM.DatabaseType.Sqlite3.ToString()))
            {
                dbObject = new Hxj.DbObjects.SQLite.DbObject(conModel.ConnectionString);

                TreeNode tnode = new TreeNode(conModel.Database, 1, 1);
                tnode.Tag = conModel.ConnectionString;
                tnode.ContextMenuStrip = contextMenuStripOneDataBase;
                node.Nodes.Add(tnode);

                gettables(tnode, dbObject.GetTables(""), dbObject.GetVIEWs(""));

            }
            else if (conModel.DbType.Equals(Dos.ORM.DatabaseType.SqlServer.ToString()) || conModel.DbType.Equals(Dos.ORM.DatabaseType.SqlServer9.ToString()))
            {
                if (conModel.DbType.Equals(Dos.ORM.DatabaseType.SqlServer.ToString()))
                    dbObject = new Hxj.DbObjects.SQL2000.DbObject(conModel.ConnectionString);
                else
                    dbObject = new Hxj.DbObjects.SQL2005.DbObject(conModel.ConnectionString);

                if (conModel.Database.Equals("all"))
                {
                    DataTable dt = dbObject.GetDBList();

                    foreach (DataRow dr in dt.Rows)
                    {
                        TreeNode tnode = new TreeNode(dr[0].ToString(), 1, 1);
                        tnode.Tag = conModel.ConnectionString.Replace("master", dr[0].ToString());
                        tnode.ContextMenuStrip = contextMenuStripOneDataBase;
                        node.Nodes.Add(tnode);

                        gettables(tnode, dbObject.GetTables(tnode.Text), dbObject.GetVIEWs(tnode.Text));
                    }

                }
                else
                {
                    TreeNode tnode = new TreeNode(conModel.Database, 1, 1);
                    tnode.Tag = conModel.ConnectionString;
                    tnode.ContextMenuStrip = contextMenuStripOneDataBase;
                    node.Nodes.Add(tnode);

                    gettables(tnode, dbObject.GetTables(tnode.Text), dbObject.GetVIEWs(tnode.Text));
                }
            }
            else if (conModel.DbType.Equals(Dos.ORM.DatabaseType.Oracle.ToString()))
            {
                dbObject = new Hxj.DbObjects.Oracle.DbObject(conModel.ConnectionString);

                TreeNode tnode = new TreeNode(conModel.Database, 1, 1);
                tnode.Tag = conModel.ConnectionString;
                tnode.ContextMenuStrip = contextMenuStripOneDataBase;
                node.Nodes.Add(tnode);

                gettables(tnode, dbObject.GetTables(tnode.Text), dbObject.GetVIEWs(tnode.Text));
            }
            else if (conModel.DbType.Equals(Dos.ORM.DatabaseType.MySql.ToString()))
            {
                dbObject = new Hxj.DbObjects.MySQL.DbObject(conModel.ConnectionString);

                if (conModel.Database.Equals("all"))
                {
                    DataTable dt = dbObject.GetDBList();

                    foreach (DataRow dr in dt.Rows)
                    {
                        TreeNode tnode = new TreeNode(dr[0].ToString(), 1, 1);
                        tnode.Tag = conModel.ConnectionString.Replace("master", dr[0].ToString());
                        tnode.ContextMenuStrip = contextMenuStripOneDataBase;
                        node.Nodes.Add(tnode);

                        gettables(tnode, dbObject.GetTables(tnode.Text), dbObject.GetVIEWs(tnode.Text));
                    }

                }
                else
                {
                    TreeNode tnode = new TreeNode(conModel.Database, 1, 1);
                    tnode.Tag = conModel.ConnectionString;
                    tnode.ContextMenuStrip = contextMenuStripOneDataBase;
                    node.Nodes.Add(tnode);

                    gettables(tnode, dbObject.GetTables(tnode.Text), dbObject.GetVIEWs(tnode.Text));
                }
            }
        }

        private void gettables(TreeNode databaseNodel, DataTable tables, DataTable views)
        {
            TreeNode tableNode = new TreeNode("表", 2, 3);
            if (null != tables && tables.Rows.Count > 0)
            {
                DataRow[] tablesdrs = tables.Select("", "name asc");

                foreach (DataRow tablesDR in tablesdrs)
                {
                    TreeNode tnode = new TreeNode(tablesDR[0].ToString(), 4, 4);
                    tnode.Tag = "T";
                    tnode.ContextMenuStrip = contextMenuStripTable;
                    tableNode.Nodes.Add(tnode);
                }
            }
            databaseNodel.Nodes.Add(tableNode);

            TreeNode viewNode = new TreeNode("视图", 2, 3);
            if (null != views && views.Rows.Count > 0)
            {
                 DataRow[] viewsdrs = views.Select("", "name asc");

                 foreach (DataRow viewsDR in viewsdrs)
                {
                    TreeNode tnode = new TreeNode(viewsDR[0].ToString(), 4, 4);
                    tnode.Tag = "V";
                    tnode.ContextMenuStrip = contextMenuStripTable;
                    viewNode.Nodes.Add(tnode);
                }
            }
            databaseNodel.Nodes.Add(viewNode);
        }


        #endregion



        /// <summary>
        /// 代码生成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 生成代码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null != newcontentForm)
            {
                Model.Connection conModel = list.Find(delegate(Model.Connection con) { return con.ID.ToString().Equals(tview.SelectedNode.Parent.Parent.Parent.Tag.ToString()); });
                conModel.ConnectionString = tview.SelectedNode.Parent.Parent.Tag.ToString();
                newcontentForm(conModel, tview.SelectedNode.Text, tview.SelectedNode.Parent.Parent.Text, tview.SelectedNode.Tag.ToString().Equals("V"));
            }
        }


        /// <summary>
        /// 刷新数据库表和视图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 刷新ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            TreeNode node = tview.SelectedNode;

            node.Nodes.Clear();

            Model.Connection conModel = list.Find(delegate(Model.Connection con) { return con.ID.ToString().Equals(node.Parent.Tag.ToString()); });

            IDBO.IDbObject dbObject;

            if (conModel.DbType.Equals(Dos.ORM.DatabaseType.MsAccess.ToString()))
            {
                dbObject = new Hxj.DbObjects.OleDb.DbObject(conModel.ConnectionString);
                gettables(node, dbObject.GetTables(""), dbObject.GetVIEWs(""));
            }
            else if (conModel.DbType.Equals(Dos.ORM.DatabaseType.SqlServer.ToString()))
            {
                dbObject = new Hxj.DbObjects.SQL2000.DbObject(conModel.ConnectionString);
                gettables(node, dbObject.GetTables(node.Text), dbObject.GetVIEWs(node.Text));
            }
            else if (conModel.DbType.Equals(Dos.ORM.DatabaseType.SqlServer9.ToString()))
            {
                dbObject = new Hxj.DbObjects.SQL2005.DbObject(conModel.ConnectionString);
                gettables(node, dbObject.GetTables(node.Text), dbObject.GetVIEWs(node.Text));
            }
            else if (conModel.DbType.Equals(Dos.ORM.DatabaseType.Oracle.ToString()))
            {
                dbObject = new Hxj.DbObjects.Oracle.DbObject(conModel.ConnectionString);
                gettables(node, dbObject.GetTables(node.Text), dbObject.GetVIEWs(node.Text));
            }
            else if (conModel.DbType.Equals(Dos.ORM.DatabaseType.MySql.ToString()))
            {
                dbObject = new Hxj.DbObjects.Oracle.DbObject(conModel.ConnectionString);
                gettables(node, dbObject.GetTables(node.Text), dbObject.GetVIEWs(node.Text));
            }
        }


        /// <summary>
        /// 批量生成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 批量生成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = tview.SelectedNode;

            Model.Connection conModel = list.Find(delegate(Model.Connection con) { return con.ID.ToString().Equals(node.Parent.Tag.ToString()); });

            BatchForm bf = new BatchForm();
            bf.DatabaseName = node.Text;
            bf.ConnectionModel = conModel;
            bf.ShowDialog();

        }






    }
}
