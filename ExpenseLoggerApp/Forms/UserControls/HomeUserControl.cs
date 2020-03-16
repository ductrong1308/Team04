using ExpenseLoggerApp.Helpers;
using ExpenseLoggerApp.Resources;
using ExpenseLoggerDAL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExpenseLoggerApp.Forms.UserControls
{
    public partial class HomeUserControl : BaseUserControl
    {
        // This list is used to store expense categories, which will be used to bind to comboBoxCategories
        private List<string> expenseCategories;

        public HomeUserControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load data and bind to the user control.
        /// </summary>
        public override void LoadFormData()
        {
            // Register events
            buttonAddNewExpense.Click += ButtonAddNewExpense_Click;
            buttonClear.Click += ButtonClear_Click;

            // Getting data and bind data to comboBox
            expenseCategories = this.parentForm.appQueries.GetExpenseCategories(LoginInfo.UserId);
            comboBoxCategories.DataSource = expenseCategories;
        }

        /// <summary>
        /// Clear all control's data within HomeUserControl.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClear_Click(object sender, EventArgs e)
        {
            this.ClearFormData();
        }

        /// <summary>
        /// Add a new expense.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddNewExpense_Click(object sender, EventArgs e)
        {
            decimal amount;
            if (!decimal.TryParse(textBoxAmount.Text, out amount))
            {
                MessageBox.Show(AppResource.InvalidAmount);
            }
            else
            {
                // User selected a category.
                string category = expenseCategories[comboBoxCategories.SelectedIndex];

                // User picked a datae
                // By default, the datetimepicker will display today.date
                DateTime expensesCreatedDate = dateTimePickerCreatedDate.Value;

                // Save data to the DB.
                bool isDataSavedSuccessful = this.parentForm.appCommands.AddNewExpense(new Expense()
                {
                    Amount = amount,
                    CategoryName = category,
                    CreatedDate = expensesCreatedDate,
                    UserID = LoginInfo.UserId
                });

                // Check if data is saved successfully or not.
                if (isDataSavedSuccessful)
                {
                    MessageBox.Show(AppResource.DataSavedSuccessful);
                    this.ClearFormData();
                }
                else
                {
                    // Show error message when errors occur.
                    MessageBox.Show(AppResource.ErrorHasOccurred);
                }
            }
        }

        /// <summary>
        /// Clear form control's data to default values.
        /// </summary>
        private void ClearFormData()
        {
            dateTimePickerCreatedDate.Value = DateTime.Now;
            textBoxAmount.Text = string.Empty;
            comboBoxCategories.SelectedIndex = 0;

            // Set focus to comboBoxCategories
            comboBoxCategories.Focus();
        }
    }
}
