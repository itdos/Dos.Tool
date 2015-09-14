using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Threading;
using Dos.Common;
using Dos.Tools.EntityDesign.Forms;

namespace Hxj.Tools.EntityDesign
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            #region 检查最新版
            try
            {
                var serverVersion = HttpHelper.Get("http://123.57.75.168:8001/DosToolsEntityDesign.txt", "", 2);
                string thisVersion = Application.ProductVersion;
                if (Convert.ToInt32(serverVersion.Replace("v", "").Replace(".", "")) > Convert.ToInt32(thisVersion.Replace(".", "")))
                {
                    var cv = new CheckVersion();
                    cv.ShowDialog();
                }
            }
            catch (Exception)
            {
            }
            #endregion
            Application.Run(new MainForm());
        }


        /// <summary>
        /// 记录错误
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message + "\r\n 详情请查看日志!", "出错啦!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (!Directory.Exists(errorpath))
            {
                Directory.CreateDirectory(errorpath);
            }

            string errorDayPath = Path.Combine(errorpath, DateTime.Now.ToString("yyyyMM") + ".txt");

            StringBuilder error = new StringBuilder();

            error.Append("DateTime:");
            error.Append(DateTime.Now.ToString());
            error.Append("\r\n");
            error.Append("Message:");
            error.Append(e.Exception.Message);
            error.Append("\r\n");
            error.Append("Source:");
            error.Append(e.Exception.Source);
            error.Append("\r\n");
            error.Append("StackTrace:");
            error.Append(e.Exception.StackTrace);
            error.Append("\r\n--------------------------------------------------------------\r\n");
            File.AppendAllText(errorDayPath, error.ToString());
        }

        public static string errorpath = Path.Combine(Application.StartupPath, "log");
    }
}
