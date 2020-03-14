using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExpenseLoggerBLL.Queries;
using ExpenseLoggerBLL.Commands;
using ExpenseLoggerApp.Helpers;
using ExpenseLoggerDAL;
using ExpenseLoggerApp.Resources;

namespace ExpenseLoggerApp.Forms.UserControls
{
    public partial class HomeUserControl : UserControl
    {
        private ExpenseLoggerQueries appQueries;
        private ExpenseLoggerCommands appCommands;

        private List<string> expenseCategories;

        public HomeUserControl()
        {
            InitializeComponent();

            InitializeFormEventsAndData();
        }


        private void InitializeFormEventsAndData()
        {
            this.appQueries = new ExpenseLoggerQueries();
            this.appCommands = new ExpenseLoggerCommands();

            buttonAddNewExpense.Click += ButtonAddNewExpense_Click;
            buttonClear.Click += ButtonClear_Click;

            // TODO: replace 1 = LoginInfo.UserId
            expenseCategories = this.appQueries.GetExpenseCategories(1);

            comboBoxCategories.DataSource = expenseCategories;
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            this.ClearFormData();
        }

        private void ClearFormData()
        {
            dateTimePickerCreatedDate.Value = DateTime.Now;
            textBoxAmount.Text = string.Empty;
            comboBoxCategories.SelectedIndex = 0;
            comboBoxCategories.Focus();
        }

        private void ButtonAddNewExpense_Click(object sender, EventArgs e)
        {
            decimal amount;
            if (!decimal.TryParse(textBoxAmount.Text, out amount))
            {
                MessageBox.Show(AppResource.InvalidAmount);
            }
            else
            {
                string category = expenseCategories[comboBoxCategories.SelectedIndex];
                DateTime expensesCreatedDate = dateTimePickerCreatedDate.Value;

                bool isDataSavedSuccessful = appCommands.AddNewExpense(new Expense()
                {
                    Amount = amount,
                    CategoryName = category,
                    CreatedDate = expensesCreatedDate,
                    // TODO
                    UserID = 1
                });

                if (isDataSavedSuccessful)
                {
                    MessageBox.Show(AppResource.DataSavedSuccessful);
                    this.ClearFormData();
                }
                else
                {
                    MessageBox.Show(AppResource.ErrorHasOccurred);
                }
            }
        }
    }
}
