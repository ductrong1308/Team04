using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExpenseLoggerApp.Resources;
using ExpenseLoggerBLL.Queries;
using ExpenseLoggerBLL.Commands;
using ExpenseLoggerDAL;
using ExpenseLoggerApp.Forms.UserControls.Interfaces;

namespace ExpenseLoggerApp.Forms.UserControls
{
    public partial class ReportUserControl : BaseUserControl
    {
        private List<string> filterBy;
        List<Expense> expenses;

        private int selectedRowId = -1;

        private ExpenseLoggerQueries appQueries;
        private ExpenseLoggerCommands appCommands;

        public static Expense selectedExpense;

        public ReportUserControl()
        {
            InitializeComponent();

            filterBy = new List<string>()
            {
                "Today", "This Week", "This Month", "This Year", "Date Range"
            };


            appQueries = new ExpenseLoggerQueries();
            appCommands = new ExpenseLoggerCommands();

            comboBoxFilterBy.DataSource = filterBy;

            buttonView.Click += ButtonView_Click;
            buttonEditExpense.Click += ButtonEditExpense_Click;
            buttonDeleteExpense.Click += ButtonDeleteExpense_Click;

            buttonEditExpense.Enabled = false;
            buttonDeleteExpense.Enabled = false;

            dataGridViewExpenses.ReadOnly = true;
            dataGridViewExpenses.AllowUserToAddRows = false;
            dataGridViewExpenses.MultiSelect = false;
            dataGridViewExpenses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewColumn[] columns = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn(){ Name = "Money Spent For", SortMode = DataGridViewColumnSortMode.NotSortable },
                new DataGridViewTextBoxColumn(){ Name = "Amount", SortMode = DataGridViewColumnSortMode.NotSortable },
                new DataGridViewTextBoxColumn(){ Name = "Date", SortMode = DataGridViewColumnSortMode.NotSortable }
            };
            dataGridViewExpenses.Columns.AddRange(columns);
        }

        public override void LoadFormData()
        {

        }

        private void ButtonDeleteExpense_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(
                AppResource.DeleteConfirmMessage, AppResource.DeleteExpense, MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                dataGridViewExpenses.SelectionChanged -= DataGridViewExpenses_SelectionChanged;
                appCommands.DeleteSelectedExpense(selectedRowId);

                expenses = null;
                selectedRowId = -1;
                buttonEditExpense.Enabled = false;
                buttonDeleteExpense.Enabled = false;

                QueryExpenseData();
            }
        }

        private void ButtonEditExpense_Click(object sender, EventArgs e)
        {
            selectedExpense = expenses[selectedRowId];
            ExpenseLoggerEditExpenseForm editExpenseForm = new ExpenseLoggerEditExpenseForm();
            var result = editExpenseForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                dataGridViewExpenses.SelectionChanged -= DataGridViewExpenses_SelectionChanged;

                expenses = null;
                selectedRowId = -1;
                buttonEditExpense.Enabled = false;
                buttonDeleteExpense.Enabled = false;

                QueryExpenseData();
            }

            editExpenseForm.Hide();
        }

        private void DataGridViewExpenses_SelectionChanged(object sender, EventArgs e)
        {
            var rowIndex = dataGridViewExpenses.SelectedRows.Count > 0
                ? dataGridViewExpenses.SelectedRows[0].Index : dataGridViewExpenses.SelectedCells[0].RowIndex;

            if (rowIndex > -1)
            {
                selectedRowId = rowIndex;
                buttonEditExpense.Enabled = true;
                buttonDeleteExpense.Enabled = true;
            }
        }

        private void ButtonView_Click(object sender, EventArgs e)
        {
            QueryExpenseData();
        }

        private void QueryExpenseData()
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
                    break;
            }

            if (dateTimePickerFromDate.Value > dateTimePickerToDate.Value)
            {
                MessageBox.Show(AppResource.InvalidDateRange);
            }
            else
            {
                expenses = appQueries.FilterExpensesByDate(dateTimePickerFromDate.Value, dateTimePickerToDate.Value);
                DisplayExpensesData(expenses);
            }
        }

        private void DisplayExpensesData(List<Expense> expenses)
        {
            dataGridViewExpenses.Rows.Clear();

            expenses.Select(x => new string[] { x.CategoryName, x.Amount.ToString(), x.CreatedDate.ToString("MMM/dd/yyyy H:mm tt") })
                .ToList().ForEach(x => dataGridViewExpenses.Rows.Add(x));

            labelTotalItemCountValue.Text = expenses.Count.ToString("n0");
            labelTotalMoneyValue.Text = expenses.Sum(x => x.Amount).ToString("c");
            var spentMostOnItem = expenses.GroupBy(x => x.CategoryName).Select(x => new
            {
                GroupName = x.Key,
                TotalExpenses = x.Sum(y => y.Amount)
            }).ToList().OrderByDescending(x => x.TotalExpenses).FirstOrDefault();

            labelSpentMostValue.Text = spentMostOnItem.GroupName;

            dataGridViewExpenses.SelectionChanged += DataGridViewExpenses_SelectionChanged;
        }
    }
}
