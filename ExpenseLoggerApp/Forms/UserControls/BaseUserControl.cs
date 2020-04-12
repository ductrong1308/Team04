using ExpenseLoggerApp.Forms.UserControls.Interfaces;
using ExpenseLoggerBLL.Commands;
using ExpenseLoggerBLL.Queries;
using System;
using System.Windows.Forms;

namespace ExpenseLoggerApp.Forms.UserControls
{
    public class BaseUserControl : UserControl, IUserControlLoaded
    {
        public ExpenseLoggerQueries appQueries;
        public ExpenseLoggerCommands appCommands;

        public BaseUserControl()
        {
            // This event will fire when the userControl is fully loaded.
            this.Load += BaseUserControl_Load;
        }

        /// <summary>
        /// This method aims to load and get some services available in ExpenseLoggerAppForm
        /// So the child forms can use the same services with its parents forms.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BaseUserControl_Load(object sender, EventArgs e)
        {
            // Access to parent form and store it to a variable which will be shared cross derived class
            ExpenseLoggerAppForm parentForm = this.Parent?.Parent as ExpenseLoggerAppForm;
            if(parentForm != null)
            {
                appQueries = parentForm.appQueries;
                appCommands = parentForm.appCommands;
            }
            else
            {
                appQueries = new ExpenseLoggerQueries();
                appCommands = new ExpenseLoggerCommands();
            }

            this.LoadFormData();
        }

        /// <summary>
        /// The method is used to load some common things for UserControl
        /// This must be overridden by derived classes
        /// </summary>
        public virtual void LoadFormData() {
            this.AutoSizeMode = AutoSizeMode.GrowOnly;
        }
    }
}
