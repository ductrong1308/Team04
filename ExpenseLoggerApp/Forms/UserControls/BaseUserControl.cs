﻿using ExpenseLoggerApp.Forms.UserControls.Interfaces;
using System;
using System.Windows.Forms;

namespace ExpenseLoggerApp.Forms.UserControls
{
    public class BaseUserControl : UserControl, IUserControlLoaded
    {
        public ExpenseLoggerAppForm parentForm;

        public BaseUserControl()
        {
            this.Load += BaseUserControl_Load;
        }

        private void BaseUserControl_Load(object sender, EventArgs e)
        {
            parentForm = (ExpenseLoggerAppForm)this.Parent.Parent;
            this.LoadFormData();
        }

        public virtual void LoadFormData()
        {
            throw new NotImplementedException();
        }
    }
}
