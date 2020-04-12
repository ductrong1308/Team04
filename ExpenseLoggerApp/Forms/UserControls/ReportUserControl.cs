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
            base.LoadFormData();

            SetFormControlsToDefaultState();

            // Bind data to ComboBox
            comboBoxFilterBy.DataSource = AppDefaultValues.FiltersByDate;

            // DataGridView settings
            dataGridViewExpenses.ReadOnly = true;
            dataGridViewExpenses.AllowUserToAddRows = false;
            dataGridViewExpenses.MultiSelect = false;
            dataGridViewExpenses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Adding DataGridView columns
            DataGridViewColumn[] columns = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn(){ Name = "Category", SortMode = DataGridViewColumnSortMode.NotSortable },
                new DataGridViewTextBoxColumn(){ Name = "Amount", SortMode = DataGridViewColumnSortMode.NotSortable },
                new DataGridViewTextBoxColumn(){ Name = "Date", SortMode = DataGridViewColumnSortMode.NotSortable }
            };
            dataGridViewExpenses.Columns.AddRange(columns);

            // Display today's expense when users first visit this tab.
            QueryExpenseData();

            // Register buttons events
            buttonView.Click += ButtonView_Click;
            buttonEditExpense.Click += ButtonEditExpense_Click;
            buttonDeleteExpense.Click += ButtonDeleteExpense_Click;
            comboBoxFilterBy.SelectedIndexChanged += ComboBoxFilterBy_SelectedIndexChanged;
        }

        /// <summary>
        /// Based on what users selected to filter data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    // First day of this week.
                    dateTimePickerFromDate.Value = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Sunday);

                    // Last day of this week.
                    dateTimePickerToDate.Value = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Saturday);
                    break;

                case "This Month":
                    // First day of this month
                    var firstDayOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

                    // Last day of this month
                    var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

                    dateTimePickerFromDate.Value = firstDayOfMonth;
                    dateTimePickerToDate.Value = lastDayOfMonth;
                    break;

                case "This Year":
                    // First day of this year
                    var firstDayOfYear = new DateTime(DateTime.Today.Year, 1, 1);

                    // Last day of this year
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

        /// <summary>
        /// Query expenses data and show them on the dataGridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonView_Click(object sender, EventArgs e)
        {
            QueryExpenseData();
        }

        /// <summary>
        /// Edit an exisiting expense.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonEditExpense_Click(object sender, EventArgs e)
        {
            if (selectedExpense == null)
            {
                MessageBox.Show(AppResource.NoItemSelected);
            }
            else
            {
                // Show another form that lets user to edit the selected expese's data.
                ExpenseLoggerEditExpenseForm editExpenseForm = new ExpenseLoggerEditExpenseForm();
                var result = editExpenseForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // Set main form's data to default values
                    SetFormControlsToDefaultState();

                    // Query data after editing and display them on the dataGridView.
                    QueryExpenseData();
                }

                // If users don't make any changes.
                editExpenseForm.Hide();
            }
        }

        /// <summary>
        /// Delete an exisiting expense item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteExpense_Click(object sender, EventArgs e)
        {
            if (selectedExpense == null)
            {
                MessageBox.Show(AppResource.NoItemSelected);
                return;
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show(
                    AppResource.DeleteConfirmMessage, AppResource.DeleteExpense, MessageBoxButtons.OKCancel);

                if (dialogResult == DialogResult.OK)
                {
                    // Call to BLL to delete the selected Expense.
                    try
                    {
                        bool isItemDeleted = this.appCommands.DeleteSelectedExpense(selectedExpense);
                        if (isItemDeleted)
                        {
                            // Set main form's data to default values
                            SetFormControlsToDefaultState();

                            // Query data after editing and display them on the dataGridView.
                            QueryExpenseData();
                        }
                        else
                        {
                            MessageBox.Show(AppResource.SelectedExpenseNotFound);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Get selected expense item on the dataGridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewExpenses_SelectionChanged(object sender, EventArgs e)
        {
            // Check if users selected the whole row or just a cell
            var rowIndex = dataGridViewExpenses.SelectedRows.Count > 0
                ? dataGridViewExpenses.SelectedRows[0].Index
                : dataGridViewExpenses.SelectedCells.Count > 0
                    ? dataGridViewExpenses.SelectedCells[0].RowIndex : -1;

            if (rowIndex > -1)
            {
                // Store the selected expense to a variable, which will be used later on.
                selectedExpense = expensesData[rowIndex];
            }
        }

        /// <summary>
        /// Call service in BLL to get expenses data and show them on the dataGridView.
        /// </summary>
        private void QueryExpenseData()
        {
            if (dateTimePickerFromDate.Value.Date > dateTimePickerToDate.Value.Date)
            {
                MessageBox.Show(AppResource.InvalidDateRange);
            }
            else
            {
                // Call service in BLL
                expensesData = this.appQueries.FilterExpensesByDate(
                    UserIdentity.Instance.UserId, dateTimePickerFromDate.Value.Date, dateTimePickerToDate.Value.Date);

                if (!expensesData.Any())
                {
                    MessageBox.Show(AppResource.NoExpenseDataFound);
                }
                else
                {
                    // Display data.
                    DisplayExpensesData(expensesData);
                }
            }
        }

        /// <summary>
        /// Display data on dataGridViewExpenses
        /// </summary>
        /// <param name="expenses"></param>
        private void DisplayExpensesData(List<Expense> expenses)
        {
            // De-register dataGridView selectionChanged event before rebinding data to the grid.
            dataGridViewExpenses.SelectionChanged -= DataGridViewExpenses_SelectionChanged;

            dataGridViewExpenses.Rows.Clear();

            expenses.Select(x => new string[] { x.CategoryName, x.Amount.ToString("C", UserIdentity.Instance.UserPreferenceCulture), x.CreatedDate.ToString("MMM/dd/yyyy H:mm tt") })
                .ToList().ForEach(x => dataGridViewExpenses.Rows.Add(x));

            // Format data before showing.
            labelTotalItemCountValue.Text = expenses.Count.ToString("n0");
            labelTotalMoneyValue.Text = expenses.Sum(x => x.Amount).ToString("C", UserIdentity.Instance.UserPreferenceCulture);

            // Using LINQ to retrieve some useful information and display on the summary section.
            var spentMostOnItem = expenses.GroupBy(x => x.CategoryName).Select(x => new
            {
                GroupName = x.Key,
                TotalExpenses = x.Sum(y => y.Amount)
            }).ToList().OrderByDescending(x => x.TotalExpenses).FirstOrDefault();

            if (spentMostOnItem != null)
            {
                labelSpentMostValue.Text = spentMostOnItem.GroupName;
            }

            selectedExpense = expensesData.FirstOrDefault();

            // Register datagridview selection changed event after data rendered.
            dataGridViewExpenses.SelectionChanged += DataGridViewExpenses_SelectionChanged;
        }

        /// <summary>
        /// Set form's control and variable to default values.
        /// </summary>
        private void SetFormControlsToDefaultState()
        {
            // Set data to default
            expensesData = null;
            selectedExpense = null;

            // De-register grid view selection changed event
            dataGridViewExpenses.SelectionChanged -= DataGridViewExpenses_SelectionChanged;
        }
    }
}