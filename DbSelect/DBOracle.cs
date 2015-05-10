using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;

namespace Hxj.Tools.EntityDesign.DbSelect
{
    public partial class DBOracle : Form
    {
        public DBOracle()
        {
            InitializeComponent();
        }

        Hxj.IDBO.IDbObject dbObject;

        /// <summary>
        /// 测试连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (chbConnectString.Checked)
            {
                if (string.IsNullOrEmpty(txtConnectString.Text))
                {
                    MessageBox.Show("请填写连接字符串!");
                    return;
                }

                dbObject = new Hxj.DbObjects.Oracle.DbObject(txtConnectString.Text);
            }
            else
            {
                if (string.IsNullOrEmpty(cbbServer.Text))
                {
                    MessageBox.Show("请填写服务!");
                    return;
                }

                if (string.IsNullOrEmpty(txtUserName.Text))
                {
                    MessageBox.Show("请填写用户名!");
                    return;
                }

                dbObject = new Hxj.DbObjects.Oracle.DbObject(false, cbbServer.Text, txtUserName.Text, txtPassword.Text);
            }

            try
            {


                using (OracleConnection connect = new OracleConnection(dbObject.DbConnectStr))
                {
                    connect.Open();
                }


                MessageBox.Show("连接成功!");
                isConnection = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show("连接失败!\n\r" + ex.Message);
                isConnection = false;

            }

        }

        bool isConnection = false;


        /// <summary>
        /// 确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            button1_Click(null, null);

            if (!isConnection)
            {
                return;
            }


            Model.Connection connectionModel = new Hxj.Tools.EntityDesign.Model.Connection();
            connectionModel.Database = cbbServer.Text;
            connectionModel.ID = Guid.NewGuid();
            connectionModel.Name = cbbServer.Text+"(Oracle)";
            connectionModel.ConnectionString = dbObject.DbConnectStr;
            connectionModel.DbType = Dos.ORM.DatabaseType.Oracle.ToString();
            Utils.AddConnection(connectionModel);

            this.DialogResult = DialogResult.OK;

            this.Close();
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
        /// 连接字符串
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbConnectString_CheckedChanged(object sender, EventArgs e)
        {
            if (chbConnectString.Checked)
            {
                panelServer.Enabled = false;
                txtConnectString.Enabled = true;
            }
            else
            {
                panelServer.Enabled = true;
                txtConnectString.Enabled = false;
            }

        }
    }
}
