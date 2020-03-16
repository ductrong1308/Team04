using ExpenseLoggerApp.Forms.UserControls.Interfaces;
using System;
using System.Windows.Forms;

namespace ExpenseLoggerApp.Forms.UserControls
{
    public class BaseUserControl : UserControl, IUserControlLoaded
    {
        public ExpenseLoggerAppForm parentForm;

        public BaseUserControl()
        {
            // This event will fire when the userControl is fully loaded.
            this.Load += BaseUserControl_Load;
        }

        private void BaseUserControl_Load(object sender, EventArgs e)
        {
            // Access to parent form and store it to a variable which will be shared cross derived class
            parentForm = this.Parent?.Parent as ExpenseLoggerAppForm;
            this.LoadFormData();
        }

        /// <summary>
        /// The method is used to load some common things for UserControl
        /// This can be override by derived classes
        /// </summary>
        public virtual void LoadFormData()
        {
        }
    }
}
