using System;
using System.Windows.Forms;

namespace ExpenseLoggerApp
{
    static class ExpenseLoggerAppProgram
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ExpenseLoggerAppForm());
        }
    }
}
