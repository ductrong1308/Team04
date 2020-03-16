using ExpenseLoggerApp.Helpers;
using ExpenseLoggerApp.Resources;
using ExpenseLoggerDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ExpenseLoggerApp.Forms.UserControls
{
    public partial class ReportUserControl : BaseUserControl
    {
        // This variable is used to storing selected expense data 
        // so that child forms can access and do editing.
        public static Expense selectedExpense;

        // List to store expenses data.
        List<Expense> expensesData;

        public ReportUserControl()
        {
            InitializeComponent();
        }

        public override void LoadFormData()
        {
            SetFormControlsToDefaultState();

            // Bind data to ComboBox
            comboBoxFilterBy.DataSource = new List<string>()
            {
                "Today", "This Week", "This Month", "This Year", "Date Range"
            };

            // DataGridView settings
            dataGridViewExpenses.ReadOnly = true;
            dataGridViewExpenses.AllowUserToAddRows = false;
            dataGridViewExpenses.MultiSelect = false;
            dataGridViewExpenses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Adding DataGridView columns
            DataGridViewColumn[] columns = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn(){ Name = "Money Spent For", SortMode = DataGridViewColumnSortMode.NotSortable },
                new DataGridViewTextBoxColumn(){ Name = "Amount", SortMode = DataGridViewColumnSortMode.NotSortable },
                new DataGridViewTextBoxColumn(){ Name = "Date", SortMode = DataGridViewColumnSortMode.NotSortable }
            };
            dataGridViewExpenses.Columns.AddRange(columns);

            // Register buttons events
            buttonView.Click += ButtonView_Click;
            buttonEditExpense.Click += ButtonEditExpense_Click;
            buttonDeleteExpense.Click += ButtonDeleteExpense_Click;
            comboBoxFilterBy.SelectedIndexChanged += ComboBoxFilterBy_SelectedIndexChanged;
        }

        private void ComboBoxFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFilter = comboBoxFilterBy.SelectedItem.ToString();
            switch (selectedFilter)
            {
                case "Today":
                    dateTimePickerFromDate.Value = DateTime.Today;
                    dateTimePickerToDate.Value = DateTime.Today;
                    break;

                case "This Week":
                    dateTimePickerFromDate.Value = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Sunday);
                    dateTimePickerToDate.Value = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Saturday);
                    break;

                case "This Month":
                    var firstDayOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                    var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                    dateTimePickerFromDate.Value = firstDayOfMonth;
                    dateTimePickerToDate.Value = lastDayOfMonth;
                    break;

                case "This Year":
                    var firstDayOfYear = new DateTime(DateTime.Today.Year, 1, 1);
                    var lastDayOfYear = firstDayOfYear.AddYears(1).AddDays(-1);
                    dateTimePickerFromDate.Value = firstDayOfYear;
                    dateTimePickerToDate.Value = lastDayOfYear;
                    break;

                case "Date Range":
                    dateTimePickerFromDate.Value = DateTime.Today;
                    dateTimePickerToDate.Value = DateTime.Today;
                    break;
            }
        }

        private void ButtonView_Click(object sender, EventArgs e)
        {
            QueryExpenseData();
        }

        private void ButtonEditExpense_Click(object sender, EventArgs e)
        {
            if (selectedExpense == null)
            {
                MessageBox.Show(AppResource.NoExpenseItemSelected);
            }
            else
            {
                ExpenseLoggerEditExpenseForm editExpenseForm = new ExpenseLoggerEditExpenseForm();
                var result = editExpenseForm.ShowDialog();
                if (result == DialogResult.OK)
                {

                    SetFormControlsToDefaultState();
                    QueryExpenseData();
                }

                editExpenseForm.Hide();
            }
        }

        private void ButtonDeleteExpense_Click(object sender, EventArgs e)
        {
            if (selectedExpense == null)
            {
                MessageBox.Show(AppResource.NoExpenseItemSelected);
                return;
            }
            else
            {
                DialogResult dialogResult =
                    MessageBox.Show(AppResource.DeleteConfirmMessage, AppResource.DeleteExpense, MessageBoxButtons.OKCancel);

                if (dialogResult == DialogResult.OK)
                {
                    this.parentForm.appCommands.DeleteSelectedExpense(selectedExpense);

                    SetFormControlsToDefaultState();
                    QueryExpenseData();
                }
            }
        }

        private void DataGridViewExpenses_SelectionChanged(object sender, EventArgs e)
        {
            var rowIndex = dataGridViewExpenses.SelectedRows.Count > 0
                ? dataGridViewExpenses.SelectedRows[0].Index
                : dataGridViewExpenses.SelectedCells.Count > 0
                    ? dataGridViewExpenses.SelectedCells[0].RowIndex : -1;

            if (rowIndex > -1)
            {
                selectedExpense = expensesData[rowIndex];
                buttonEditExpense.Enabled = true;
                buttonDeleteExpense.Enabled = true;
            }
        }

        private void QueryExpenseData()
        {
            if (dateTimePickerFromDate.Value.Date > dateTimePickerToDate.Value.Date)
            {
                MessageBox.Show(AppResource.InvalidDateRange);
            }
            else
            {
                expensesData = this.parentForm.appQueries.FilterExpensesByDate(
                    dateTimePickerFromDate.Value.Date, dateTimePickerToDate.Value.Date);
                DisplayExpensesData(expensesData);
            }
        }

        private void DisplayExpensesData(List<Expense> expenses)
        {
            dataGridViewExpenses.Rows.Clear();

            expenses.Select(x => new string[] { x.CategoryName, x.Amount.ToString("C", LoginInfo.UserPreferenceCulture), x.CreatedDate.ToString("MMM/dd/yyyy H:mm tt") })
                .ToList().ForEach(x => dataGridViewExpenses.Rows.Add(x));

            labelTotalItemCountValue.Text = expenses.Count.ToString("n0");
            labelTotalMoneyValue.Text = expenses.Sum(x => x.Amount).ToString("C", LoginInfo.UserPreferenceCulture);

            var spentMostOnItem = expenses.GroupBy(x => x.CategoryName).Select(x => new
            {
                GroupName = x.Key,
                TotalExpenses = x.Sum(y => y.Amount)
            }).ToList().OrderByDescending(x => x.TotalExpenses).FirstOrDefault();

            if (spentMostOnItem != null)
            {
                labelSpentMostValue.Text = spentMostOnItem.GroupName;
            }

            // Register datagridview selection changed event after data rendered.
            dataGridViewExpenses.SelectionChanged += DataGridViewExpenses_SelectionChanged;
        }

        private void SetFormControlsToDefaultState()
        {
            buttonEditExpense.Enabled = false;
            buttonDeleteExpense.Enabled = false;

            // Set data to default
            expensesData = null;
            selectedExpense = null;

            // De-register grid view selection changed event
            dataGridViewExpenses.SelectionChanged -= DataGridViewExpenses_SelectionChanged;
        }
    }
}