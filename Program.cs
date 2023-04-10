using System;
using System.Windows.Forms;

namespace APF_3._0
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MessageBoxManager.Yes = "Ano";
            MessageBoxManager.No = "Ne";
            MessageBoxManager.Cancel = "Zrušit";
            MessageBoxManager.Abort = "Ano";
            MessageBoxManager.Retry = "Ne";
            MessageBoxManager.Ignore = "Vybrat ručně";
            MessageBoxManager.Register();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(ExceptionHandler);
            
            Application.Run(new Form1());
        }

        static void ExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show(((Exception)e.ExceptionObject).Message, "Došlo k neošetřené výjimce - for now, we crash", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
        }
    }
}
