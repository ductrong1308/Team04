using ExpenseLoggerApp.Models;
using ExpenseLoggerDAL;
using System.Collections.Generic;

namespace ExpenseLoggerApp.Helpers
{
    public class AppDefaultValues
    {
        public static List<Category> ExpenseCategories
        {
            get
            {
                return new List<Category>()
                {
                    new Category(){ Name = "Meals" },
                    new Category(){ Name = "Transportation" },
                    new Category(){ Name = "Housing" },
                    new Category(){ Name = "Entertainment" },
                    new Category(){ Name = "Medical" },
                    new Category(){ Name = "Pets" },
                    new Category(){ Name = "Education" }
                };
            }
        }

        public static List<ComboBoxItem> Currencies
        {
            get
            {
                return new List<ComboBoxItem>()
                {
                    new ComboBoxItem() { Text = "Canadian Dollar", Value = "CAD" },
                    new ComboBoxItem() { Text = "US Dollar", Value = "USD" },
                    new ComboBoxItem() { Text = "Euro", Value = "EUR" },
                    new ComboBoxItem() { Text = "Pound Sterling", Value = "GBP" },
                    new ComboBoxItem() { Text = "Yuan", Value = "CNY" },
                    new ComboBoxItem() { Text = "Yen", Value = "JPY" }
                };
            }
        }

        public static List<string> FiltersByDate
        {
            get
            {
                return new List<string>()
                {
                    "Today", "This Week", "This Month", "This Year", "Date Range"
                };
            }
        }

        public static List<string> ChartTypes
        {
            get
            {
                return new List<string>()
                {
                    "Column", "Line", "Pie"
                };
            }
        }
    }
}
