using ExpenseLoggerApp.Resources;
using ExpenseLoggerDAL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExpenseLoggerApp.Forms.UserControls
{
    public partial class HomeUserControl : BaseUserControl
    {
        private List<string> expenseCategories;

        public HomeUserControl()
        {
            InitializeComponent();
        }

        public override void LoadFormData()
        {
            buttonAddNewExpense.Click += ButtonAddNewExpense_Click;
            buttonClear.Click += ButtonClear_Click;

            // TODO: replace 1 = LoginInfo.UserId
            expenseCategories = this.parentForm.appQueries.GetExpenseCategories(1);
            comboBoxCategories.DataSource = expenseCategories;
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            this.ClearFormData();
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

                bool isDataSavedSuccessful = this.parentForm.appCommands.AddNewExpense(new Expense()
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

        private void ClearFormData()
        {
            dateTimePickerCreatedDate.Value = DateTime.Now;
            textBoxAmount.Text = string.Empty;
            comboBoxCategories.SelectedIndex = 0;
            comboBoxCategories.Focus();
        }
    }
}
