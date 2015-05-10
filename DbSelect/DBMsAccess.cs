using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Hxj.Tools.EntityDesign.DbSelect
{
    public partial class DBMsAccess : Form
    {
        public DBMsAccess()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 文件选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            fileDialog.FileName = string.Empty;
            fileDialog.Filter = "Access 文件|*.mdb;*.accdb;";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                txtfilepath.Text = fileDialog.FileName;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbdatabaseselect_CheckedChanged(object sender, EventArgs e)
        {
            if (rbdatabaseselect.Checked)
            {
                panelDB.Enabled = true;
                txtConnectionString.Enabled = false;
            }
            else
            {
                panelDB.Enabled = false;
                txtConnectionString.Enabled = true;
            }
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
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (rbconnstring.Checked)
            {
                if (string.IsNullOrEmpty(txtConnectionString.Text))
                {
                    MessageBox.Show("请填写连接字符串!");
                    return;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(txtfilepath.Text))
                {
                    MessageBox.Show("请选择Access文件!");
                    return;
                }

            }

            Model.Connection connModel = new Hxj.Tools.EntityDesign.Model.Connection();

            if (rbdatabaseselect.Checked)
            {

                StringBuilder cstring = new StringBuilder();

                string exstension = txtfilepath.Text.Substring(txtfilepath.Text.LastIndexOf('.') + 1);
                if (exstension.ToLower().Equals("mdb"))
                {
                    cstring.Append("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=");
                }
                else if (exstension.ToLower().Equals("accdb"))
                {
                    cstring.Append("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=");
                }

                cstring.Append(txtfilepath.Text);
                cstring.Append(";");
                if (!string.IsNullOrEmpty(txtPassword.Text))
                {
                    cstring.Append("User Id=");
                    cstring.Append(txtUserName.Text);
                    cstring.Append(";Password=");
                    cstring.Append(txtPassword.Text);
                    cstring.Append(";");
                }

                connModel.ConnectionString = cstring.ToString();
                connModel.Name = txtfilepath.Text;
                connModel.Database = connModel.Name.Substring(connModel.Name.LastIndexOf('\\') + 1);
            }
            else
            {
                connModel.ConnectionString = txtConnectionString.Text;


                string constring = txtConnectionString.Text;
                string templeftstring = string.Empty;
                string temprightstring = string.Empty;
                if (constring.IndexOf('/') > 0)
                {
                    templeftstring = constring.Substring(0, constring.LastIndexOf('/'));
                    temprightstring = constring.Substring(constring.LastIndexOf('/') + 1);
                }
                else if (constring.IndexOf('\\') > 0)
                {
                    templeftstring = constring.Substring(0, constring.LastIndexOf('\\'));
                    temprightstring = constring.Substring(constring.LastIndexOf('\\') + 1);
                }
                else
                {
                    MessageBox.Show("连接字符串格式不正确!");
                    return;
                }

                if (temprightstring.IndexOf(';') > 0)
                {
                    temprightstring = temprightstring.Substring(0, temprightstring.IndexOf(';'));
                }

                templeftstring = templeftstring.Substring(templeftstring.IndexOf('=') + 1);


                connModel.Name = templeftstring + temprightstring;
                connModel.Database = temprightstring;
            }

            try
            {

                using (OleDbConnection oledbConn = new OleDbConnection(connModel.ConnectionString))
                {
                    oledbConn.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接失败!\n\r" + ex.Message);
                return;

            }

            connModel.DbType = Dos.ORM.DatabaseType.MsAccess.ToString();
            connModel.ID = Guid.NewGuid();

            Utils.AddConnection(connModel);

            this.DialogResult = DialogResult.OK;

            this.Close();
        }
    }
}
