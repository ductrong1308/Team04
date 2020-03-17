using ExpenseLoggerApp.Forms.UserControls;
using ExpenseLoggerApp.Helpers;
using ExpenseLoggerApp.Resources;
using ExpenseLoggerDAL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExpenseLoggerApp.Forms
{
    public partial class ExpenseLoggerEditExpenseForm : ExpenseLoggerFormBase
    {

        public ExpenseLoggerEditExpenseForm()
        {
            InitializeComponent();

            // Register events.
            this.Load += ExpenseLoggerEditExpenseForm_Load;
            buttonUpdateCurrentExpense.Click += ButtonUpdateCurrentExpense_Click;
            buttonCancel.Click += ButtonCancel_Click;
        }

        /// <summary>
        /// Loading data to the form when user want to edit an expense item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExpenseLoggerEditExpenseForm_Load(object sender, EventArgs e)
        {
            Expense expense = ReportUserControl.selectedExpense;
            if (expense != null)
            {
                // Display the data on the controls.
                List<string> expenseCategories = this.appQueries.GetExpenseCategories(LoginInfo.UserId);
                comboBoxCategories.DataSource = expenseCategories;
                comboBoxCategories.SelectedIndex = comboBoxCategories.FindStringExact(expense.CategoryName);

                textBoxAmount.Text = expense.Amount.ToString();
                dateTimePickerCreatedDate.Value = expense.CreatedDate;
            }
            else
            {
                // Show error message when the data cannot be loaded.
                MessageBox.Show(AppResource.ErrorHasOccurred);
            }
        }

        /// <summary>
        /// Update a selected expense.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdateCurrentExpense_Click(object sender, EventArgs e)
        {
            // Validate amount data to make sure that users inputted a correct number.
            decimal amount;
            if (!decimal.TryParse(textBoxAmount.Text, out amount))
            {
                MessageBox.Show(AppResource.InvalidAmount);
            }
            else
            {
                // Update new data to the selected expense and save it to DB>
                var expense = ReportUserControl.selectedExpense;
                expense.CategoryName = comboBoxCategories.SelectedItem.ToString();
                expense.Amount = amount;
                expense.CreatedDate = dateTimePickerCreatedDate.Value;

                appCommands.UpdateExistingExpense(expense);
            }

            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// User do nothing, closign the popup or cancel the process.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
