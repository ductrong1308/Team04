using ExpenseLoggerApp.Resources;
using ExpenseLoggerBLL.Commands;
using ExpenseLoggerBLL.Queries;
using System.Windows.Forms;

namespace ExpenseLoggerApp.Forms
{
    /// <summary>
    /// This is base form class which will be used for declaring and initializing common services, settings
    /// for the whole application. Other forms will inherit from this base class for using common settings.
    /// </summary>
    public class ExpenseLoggerFormBase : Form
    {
        public ExpenseLoggerQueries appQueries;
        public ExpenseLoggerCommands appCommands;
        public ErrorProvider errorProvider;

        public ExpenseLoggerFormBase()
        {
            // ExpenseLoggerQueries using for getting data.
            this.appQueries = new ExpenseLoggerQueries();

            // ExpenseLoggerCommands: using for creating, updating and deleting data.
            this.appCommands = new ExpenseLoggerCommands();

            // Build-in error provider which will be used for data validation.
            errorProvider = new ErrorProvider();

            // This event is fired when form is loaded.
            this.Load += ExpenseLoggerFormBase_Load;
        }

        private void ExpenseLoggerFormBase_Load(object sender, System.EventArgs e)
        {
            // Clear all error existing in the errorProvider.
            errorProvider.Clear();

            // Display main application in the center of the sceen.
            this.CenterToScreen();

            // Set app name
            this.Text = AppResource.AppName;

            // Prevent users from changing form size
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }
    }
}
