using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace Hxj.Tools.EntityDesign
{
    public partial class DatabaseSelect : Form
    {
        public DatabaseSelect()
        {
            InitializeComponent();
        }


        public static Dos.ORM.DatabaseType? DatabaseType = null;


        /// <summary>
        /// 选择数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.OK;
            if (rbSqlServer.Checked)
            {
                DatabaseType = Dos.ORM.DatabaseType.SqlServer;
            }
            else if (rbOledb.Checked)
            {
                DatabaseType = Dos.ORM.DatabaseType.MsAccess;
            }
            else if (rbOracle.Checked)
            {
                DatabaseType = Dos.ORM.DatabaseType.Oracle;
            }
            else if (rbSQLite.Checked)
            {
                DatabaseType = Dos.ORM.DatabaseType.Sqlite3;
            }
            else if (rbMySql.Checked)
            {
                DatabaseType = Dos.ORM.DatabaseType.MySql;
            }
            else if (rbMariaDB.Checked)
            {
                DatabaseType = Dos.ORM.DatabaseType.MySql;
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
