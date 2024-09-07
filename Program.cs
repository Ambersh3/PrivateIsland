using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrivateIsland_Client
{
    /// <summary>
    /// VIEW LICENSE.txt FOR LICENSE
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // Hook unhandled exceptions
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            // Create GUI instance
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainFrm(args));
        }

        /// <summary>
        /// Create an instance of the exception dialogue if an unhandled exception occurs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                new ExceptionFrm((Exception)e.ExceptionObject).ShowDialog();
            }
            catch { }
        }

        /// <summary>
        /// Create an instance of the exception dialogue if an unhandled exception occurs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            try
            {
                new ExceptionFrm(e.Exception).ShowDialog();
            }
            catch { }
        }
    }
}
