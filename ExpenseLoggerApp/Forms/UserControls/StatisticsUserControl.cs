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

        public override void LoadFormData()
        {
            int currentYear = DateTime.Today.Year;
            LoadComboBoxData(currentYear);
            DisplayChartData(currentYear);

            comboBoxYears.SelectedIndexChanged += ComboBoxYears_SelectedIndexChanged;
            comboBoxChartType.SelectedIndexChanged += ComboBoxChartType_SelectedIndexChanged;
        }

        private void ComboBoxChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedChartType = comboBoxChartType.SelectedItem.ToString();
            switch (selectedChartType)
            {
                case "Column":
                    chartExpenseStatistics.Series["Expenses"].ChartType = SeriesChartType.Column;
                    break;

                case "Line":
                    chartExpenseStatistics.Series["Expenses"].ChartType = SeriesChartType.Line;
                    break;

                case "Pie":
                    chartExpenseStatistics.Series["Expenses"].ChartType = SeriesChartType.Pie;
                    break;
            }
        }

        private void ComboBoxYears_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedYear = int.Parse(comboBoxYears.SelectedItem.ToString());
            DisplayChartData(selectedYear);
        }

        private void LoadComboBoxData(int year)
        {
            // Combobox years
            for (int i = 2019; i <= year; i++)
            {
                comboBoxYears.Items.Add(i);
            }

            comboBoxYears.SelectedIndex = comboBoxYears.FindStringExact(year.ToString());

            // Combobox Chart Type
            List<string> chartTypes = new List<string>() { "Column", "Line", "Pie" };
            comboBoxChartType.DataSource = chartTypes;
            comboBoxChartType.SelectedIndex = comboBoxChartType.FindStringExact(chartTypes.First());
        }

        private void DisplayChartData(int year)
        {
            var firstDayOfYear = new DateTime(year, 1, 1);
            var lastDayOfYear = firstDayOfYear.AddYears(1).AddDays(-1);

            List<Expense> expensesData = this.parentForm.appQueries
                .FilterExpensesByDate(LoginInfo.UserId, firstDayOfYear, lastDayOfYear);
            var groupedExpensesData = expensesData.GroupBy(x => x.CreatedDate.Month).Select(x => new
            {
                MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(x.Key),
                TotalMoneySpent = x.ToList().Sum(y => y.Amount)
            }).ToList();

            foreach (var series in chartExpenseStatistics.Series)
            {
                series.Points.Clear();
            }

            chartExpenseStatistics.Titles.Clear();

            if (!groupedExpensesData.Any())
            {
                chartExpenseStatistics.Titles.Add(AppResource.NoDataFound);
            }
            else
            {
                chartExpenseStatistics.Titles
                    .Add("Total Spent: " + groupedExpensesData.Sum(x => x.TotalMoneySpent).ToString("C", LoginInfo.UserPreferenceCulture));

                foreach (var groupExpense in groupedExpensesData)
                {
                    chartExpenseStatistics.Series["Expenses"]
                        .Points.AddXY(groupExpense.MonthName, groupExpense.TotalMoneySpent);
                }
            }
        }
    }
}