using ExpenseLoggerApp.Helpers;
using ExpenseLoggerApp.Resources;
using ExpenseLoggerDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ExpenseLoggerApp.Forms.UserControls
{
    public partial class SettingsUserControl : BaseUserControl
    {
        List<Category> categoriesData;

        public SettingsUserControl()
        {
            InitializeComponent();
        }

        public override void LoadFormData()
        {
            this.LoadDataToComboBox();

            SetupCategoriesDataGridView();

            LoadDataToCategoryGridView();

            comboBoxCurrencies.SelectedIndexChanged += ComboBoxCurrencies_SelectedIndexChanged;
        }

        private void ComboBoxCurrencies_SelectedIndexChanged(object sender, EventArgs e)
        {
            string currency = comboBoxCurrencies.SelectedItem.ToString();

            // TODO
            this.parentForm.appCommands.AddOrUpdateCurrency(1, currency);
            LoginInfo.Currency = currency;
            LoginInfo.UserPreferenceCulture = CultureHelpers.UserPreferenceCulture(currency);

            MessageBox.Show(AppResource.DataSavedSuccessful);
        }

        public void LoadDataToComboBox()
        {
            List<string> appCurrencyList = new List<string>() { "$", "€", "£" };
            comboBoxCurrencies.DataSource = appCurrencyList;

            comboBoxCurrencies.SelectedIndex = 
                comboBoxCurrencies.FindStringExact(string.IsNullOrEmpty(LoginInfo.Currency) ? appCurrencyList.FirstOrDefault() : LoginInfo.Currency);
        }

        private void SetupCategoriesDataGridView()
        {
            // DataGridView settings
            dataGridViewExpensesCategories.ReadOnly = true;
            dataGridViewExpensesCategories.AllowUserToAddRows = false;
            dataGridViewExpensesCategories.MultiSelect = false;
            dataGridViewExpensesCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Adding DataGridView columns
            DataGridViewColumn[] columns = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn(){ Name = "No.", SortMode = DataGridViewColumnSortMode.NotSortable },
                new DataGridViewTextBoxColumn(){ Name = "Category Name", SortMode = DataGridViewColumnSortMode.NotSortable }
            };
        }

        private void LoadDataToCategoryGridView()
        {
            // TODO
            categoriesData = this.parentForm.appQueries.GetExpensesCategoriesByUserId(1);
            categoriesData.Select((x, i) => new string[] { i.ToString(), x.Name }) 
                .ToList().ForEach(x => dataGridViewExpensesCategories.Rows.Add(x));
        }
    }
}
