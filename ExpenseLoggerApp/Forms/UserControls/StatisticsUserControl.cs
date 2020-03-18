using ExpenseLoggerApp.Helpers;
using ExpenseLoggerApp.Resources;
using ExpenseLoggerDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;

namespace ExpenseLoggerApp.Forms.UserControls
{
    public partial class StatisticsUserControl : BaseUserControl
    {
        public StatisticsUserControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loading form's data when the user control loaded.
        /// </summary>
        public override void LoadFormData()
        {
            // Loading data to the comboBoxYears
            int currentYear = DateTime.Today.Year;
            LoadComboBoxData(currentYear);

            // Display data on chart.
            DisplayChartData(currentYear);

            // Register events.
            comboBoxYears.SelectedIndexChanged += ComboBoxYears_SelectedIndexChanged;
            comboBoxChartType.SelectedIndexChanged += ComboBoxChartType_SelectedIndexChanged;
        }

        /// <summary>
        /// There are three types of chart which can be used to display user's data.
        /// This function is used to switch chart type when users select an item in the chartType ComboBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedChartType = comboBoxChartType.SelectedItem.ToString();
            switch (selectedChartType)
            {
                // Column chart.
                case "Column":
                    chartExpenseStatistics.Series["Expenses"].ChartType = SeriesChartType.Column;
                    break;

                // Line chart.
                case "Line":
                    chartExpenseStatistics.Series["Expenses"].ChartType = SeriesChartType.Line;
                    break;

                // Pie chart.
                case "Pie":
                    chartExpenseStatistics.Series["Expenses"].ChartType = SeriesChartType.Pie;
                    break;
            }
        }

        /// <summary>
        /// Filter data by year.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxYears_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedYear = int.Parse(comboBoxYears.SelectedItem.ToString());
            DisplayChartData(selectedYear);
        }

        /// <summary>
        /// Loading data to the comboBoxYears and comboBoxChartType
        /// </summary>
        /// <param name="year"></param>
        private void LoadComboBoxData(int year)
        {
            // Combobox years
            for (int i = 2019; i <= year; i++)
            {
                comboBoxYears.Items.Add(i);
            }

            comboBoxYears.SelectedIndex = comboBoxYears.FindStringExact(year.ToString());

            // Combobox Chart Type
            comboBoxChartType.DataSource = AppDefaultValues.ChartTypes;
            comboBoxChartType.SelectedIndex = comboBoxChartType.FindStringExact(AppDefaultValues.ChartTypes.FirstOrDefault());
        }

        /// <summary>
        /// Showing data on the chart.
        /// </summary>
        /// <param name="year"></param>
        private void DisplayChartData(int year)
        {
            // If a year is selected, we will need to filter data from the first day of the year to the last day of the year.
            var firstDayOfYear = new DateTime(year, 1, 1);
            var lastDayOfYear = firstDayOfYear.AddYears(1).AddDays(-1);

            // Calling service in the BLL to get the data.
            List<Expense> expensesData = this.parentForm.appQueries
                .FilterExpensesByDate(UserIdentity.Instance.UserId, firstDayOfYear, lastDayOfYear);

            // Grouping data by month.
            var groupedExpensesData = expensesData.GroupBy(x => x.CreatedDate.Month).Select(x => new
            {
                MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(x.Key),
                TotalMoneySpent = x.ToList().Sum(y => y.Amount)
            }).ToList();

            // Clear chart data before binding.
            foreach (var series in chartExpenseStatistics.Series)
            {
                series.Points.Clear();
            }

            // Also clear the chart title.
            chartExpenseStatistics.Titles.Clear();

            if (!groupedExpensesData.Any())
            {
                // Showing info which indicates that nothing is found.
                chartExpenseStatistics.Titles.Add(AppResource.NoDataFound);
            }
            else
            {
                // Setup and display data on the chart.
                chartExpenseStatistics.Titles
                    .Add(AppResource.TotalSpent + groupedExpensesData.Sum(x => x.TotalMoneySpent)
                    .ToString("C", UserIdentity.Instance.UserPreferenceCulture));

                foreach (var groupExpense in groupedExpensesData)
                {
                    chartExpenseStatistics.Series["Expenses"]
                        .Points.AddXY(groupExpense.MonthName, groupExpense.TotalMoneySpent);
                }
            }
        }
    }
}