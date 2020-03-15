using ExpenseLoggerApp.Forms.UserControls;
using ExpenseLoggerApp.Resources;
using ExpenseLoggerBLL.Commands;
using ExpenseLoggerBLL.Queries;
using ExpenseLoggerDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseLoggerApp.Forms
{
    public partial class ExpenseLoggerEditExpenseForm : ExpenseLoggerFormBase
    {

        public ExpenseLoggerEditExpenseForm()
        {
            InitializeComponent();

            this.Load += ExpenseLoggerEditExpenseForm_Load;

            buttonUpdateCurrentExpense.Click += ButtonUpdateCurrentExpense_Click;
            buttonCancel.Click += ButtonCancel_Click;
        }

        private void ExpenseLoggerEditExpenseForm_Load(object sender, EventArgs e)
        {
            Expense expense = ReportUserControl.selectedExpense;
            if (expense != null)
            {
                // TODO: replace 1 = LoginInfo.UserId
                List<string> expenseCategories = this.appQueries.GetExpenseCategories(1);
                comboBoxCategories.DataSource = expenseCategories;
                comboBoxCategories.SelectedIndex = comboBoxCategories.FindStringExact(expense.CategoryName);

                textBoxAmount.Text = expense.Amount.ToString();
                dateTimePickerCreatedDate.Value = expense.CreatedDate;
            }
            else
            {
                MessageBox.Show(AppResource.ErrorHasOccurred);
            }
        }

        private void ButtonUpdateCurrentExpense_Click(object sender, EventArgs e)
        {
            decimal amount;
            if (!decimal.TryParse(textBoxAmount.Text, out amount))
            {
                MessageBox.Show(AppResource.InvalidAmount);
            }
            else
            {
                var expense = ReportUserControl.selectedExpense;
                expense.CategoryName = comboBoxCategories.SelectedItem.ToString();
                expense.Amount = amount;
                expense.CreatedDate = dateTimePickerCreatedDate.Value;

                appCommands.UpdateExistingExpense(expense);
            }

            this.DialogResult = DialogResult.OK;
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
