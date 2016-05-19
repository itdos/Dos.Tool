using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dos.Tools.Forms
{
    public partial class CheckVersion : Form
    {
        public CheckVersion(string Version = "")
        {
            InitializeComponent();
            label3.Text = "检测到新版本：" + Version;
            label2.Text = "您当前版本：v" + Application.ProductVersion;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.oschina.net/p/dos-tools-entitydesigner");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/itdos/Dos.Tool");
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://git.oschina.net/ITdos/Dos.Tools/blob/master/%E4%BB%A3%E7%A0%81%E7%94%9F%E6%88%90%E5%99%A8%E6%9B%B4%E6%96%B0%E6%97%A5%E5%BF%97.txt");
        }
    }
}
