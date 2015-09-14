using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dos.Tools.EntityDesign.Forms
{
    public partial class CheckVersion : Form
    {
        public CheckVersion()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://git.oschina.net/ITdos/Dos.Tools.EntityDesign");   
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/itdos/Dos.Tools.EntityDesign");
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://git.oschina.net/ITdos/Dos.Tools.EntityDesign/blob/master/%E5%AE%9E%E4%BD%93%E7%94%9F%E6%88%90%E5%99%A8%E6%9B%B4%E6%96%B0%E6%97%A5%E5%BF%97.txt");
        }
    }
}
