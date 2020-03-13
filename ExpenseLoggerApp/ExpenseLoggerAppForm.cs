using ExpenseLoggerApp.Helpers;
using ExpenseLoggerApp.Resources;
using ExpenseLoggerBLL.Commands;
using ExpenseLoggerBLL.Queries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseLoggerApp
{
    public partial class ExpenseLoggerAppForm : Form
    {
        private ExpenseLoggerQueries appQueries;
        private ExpenseLoggerCommands appCommands;

        public ExpenseLoggerAppForm()
        {
            InitializeComponent();
            this.appQueries = new ExpenseLoggerQueries();
            this.appCommands = new ExpenseLoggerCommands();

            DoFormCustomSettings();

            tabMainExpenseLogger.SelectedIndexChanged += TabMainExpenseLogger_SelectedIndexChanged;
        }

        private void TabMainExpenseLogger_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabMainExpenseLogger.SelectedTab.Name)
            {
                case "tabDailyExpense":
                    break;

                case "tabReport":
                    break;

                case "tabExpenseStatistics":
                    break;

                case "tabSettings":
                    break;
            }
        }

        private void DoFormCustomSettings()
        {
            this.CenterToScreen();
            this.Text = AppResource.AppName;

            // Prevent users from changing form size
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void LoadDailyExpense()
        {

        }

        private void ViewExpenseReport()
        {

        }

        private void ViewExpenseStatistics()
        {

        }

        private void ViewExpenseLoggerAppSettings()
        {

        }
    }
}
