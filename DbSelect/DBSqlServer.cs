using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hxj.Tools.EntityDesign.DbSelect
{
    public partial class DBSqlServer : Form
    {
        public DBSqlServer()
        {
            InitializeComponent();
        }

        private void DBSqlServer_Load(object sender, EventArgs e)
        {
            cbbServerType.SelectedIndex = 0;
            cbbShenFenRZ.SelectedIndex = 0;
            cbbDatabase.SelectedIndex = 0;
        }

        /// <summary>
        /// 取消 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 身份认证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbbShenFenRZ_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbShenFenRZ.SelectedIndex == 0)
            {
                txtPassword.Enabled = false;
                txtUserName.Enabled = false;
            }
            else
            {
                txtUserName.Enabled = true;
                txtPassword.Enabled = true;
            }
        }


        /// <summary>
        /// 连接  测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbbServer.Text))
            {
                MessageBox.Show("服务器不能为空!");
                return;
            }

            if (cbbShenFenRZ.SelectedIndex == 1 && string.IsNullOrEmpty(txtUserName.Text))
            {
                MessageBox.Show("登陆名不能为空!");
                return;
            }

            try
            {
                Hxj.IDBO.IDbObject dbObejct = new Hxj.DbObjects.SQL2000.DbObject(cbbShenFenRZ.SelectedIndex == 0, cbbServer.Text, txtUserName.Text, txtPassword.Text);
                DataTable DBNameTable = dbObejct.GetDBList();
                cbbDatabase.Items.Clear();
                cbbDatabase.Items.Add("全部");
                foreach (DataRow dr in DBNameTable.Rows)
                {
                    cbbDatabase.Items.Add(dr[0].ToString());
                }

                cbbDatabase.Enabled = true;
                cbbDatabase.SelectedIndex = 0;
                MessageBox.Show("连接成功!");

            }
            catch (Exception ex)
            {

                MessageBox.Show("连接失败!\n\r" + ex.Message);
                cbbDatabase.Enabled = false;

            }

        }

        /// <summary>
        /// 创建数据库连接
        /// </summary>
        /// <returns></returns>
        private string createConnectionString(string database)
        {
            StringBuilder connstring = new StringBuilder();
            connstring.Append("Data Source=");
            connstring.Append(cbbServer.Text);
            connstring.Append(";Initial Catalog=");
            connstring.Append(database);
            connstring.Append(";");
            if (cbbShenFenRZ.SelectedIndex == 0)
            {
                connstring.Append("Integrated Security=True");
            }
            else
            {
                connstring.Append("User Id=");
                connstring.Append(txtUserName.Text);
                connstring.Append(";Password=");
                connstring.Append(txtPassword.Text);
            }

            return connstring.ToString();
            //Data Source=ricci\hu;Initial Catalog=master;Integrated Security=True
            //User Id=myUsername;Password=myPassword;
        }




        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbbServer.Text))
            {
                MessageBox.Show("服务器不能为空!");
                return;
            }

            if (cbbShenFenRZ.SelectedIndex == 1 && string.IsNullOrEmpty(txtUserName.Text))
            {
                MessageBox.Show("登陆名不能为空!");
                return;
            }

            string tempconnectionstring = createConnectionString(cbbDatabase.SelectedIndex == 0 ? "master" : cbbDatabase.Text);

            try
            {
                using (SqlConnection conn = new SqlConnection(tempconnectionstring))
                {
                    conn.Open();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("连接失败!\n\r" + ex.Message);
                return;

            }



            Model.Connection connectionModel = new Hxj.Tools.EntityDesign.Model.Connection();
            connectionModel.Database = cbbDatabase.SelectedIndex == 0 ? "all" : cbbDatabase.Text;
            connectionModel.ID = Guid.NewGuid();
            connectionModel.Name = cbbServer.Text + "(" + cbbServerType.Text + ")[" + connectionModel.Database + "]";
            if (cbbServerType.SelectedIndex == 0)
            {
                connectionModel.DbType = Dos.ORM.DatabaseType.SqlServer.ToString();
            }
            else
            {
                connectionModel.DbType = Dos.ORM.DatabaseType.SqlServer9.ToString();
            }
            connectionModel.ConnectionString = tempconnectionstring;

            Utils.AddConnection(connectionModel);

            this.DialogResult = DialogResult.OK;

            this.Close();
        }
    }
}
