using System.Windows.Forms;
using System;
using System.Threading;

namespace WindowsFormsApp1
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += Application_ThreadException;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static  void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Exception ex = e.Exception;
            MessageBox.Show(string.Format("exception:{0}\r\n message:{1}\r\n stack:{2}", ex.GetType(), ex.Message, ex.StackTrace));
        }
    }
}
