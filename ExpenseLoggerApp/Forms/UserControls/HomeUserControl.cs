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
using ExpenseLoggerApp.Forms.UserControls.Interfaces;

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
            ExpenseLoggerFormBase frm;     //frm_main is your main form which user control is on it
            frm = (ExpenseLoggerFormBase)this.FindForm();
            var abc = this.Parent;

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
    }
}
