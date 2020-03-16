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

            dataGridViewExpensesCategories.CellValueChanged += DataGridViewExpensesCategories_CellValueChanged;
            dataGridViewExpensesCategories.DefaultValuesNeeded += DataGridViewExpensesCategories_DefaultValuesNeeded;
        }

        private void DataGridViewExpensesCategories_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[0].Value = -1;
        }

        private void DataGridViewExpensesCategories_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            bool isNewRow = e.RowIndex == categoriesData.Count;
            string newCategoryValue = dataGridViewExpensesCategories.Rows[e.RowIndex].Cells[1].Value?.ToString();

            if (isNewRow)
            {
                if (!string.IsNullOrEmpty(newCategoryValue))
                {
                    parentForm.appCommands.AddCategory(LoginInfo.UserId, newCategoryValue);
                    LoadDataToCategoryGridView();
                }
            }
            else
            {
                Category editingCategory = categoriesData[e.RowIndex];

                if (editingCategory.Name != newCategoryValue)
                {
                    parentForm.appCommands.UpdateCategory(LoginInfo.UserId, editingCategory.Id, newCategoryValue);
                    LoadDataToCategoryGridView();
                }
            }
        }

        private void ComboBoxCurrencies_SelectedIndexChanged(object sender, EventArgs e)
        {
            string currency = comboBoxCurrencies.SelectedItem.ToString();
            this.parentForm.appCommands.AddOrUpdateCurrency(LoginInfo.UserId, currency);

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
            dataGridViewExpensesCategories.ReadOnly = false;
            dataGridViewExpensesCategories.AllowUserToAddRows = true;
            dataGridViewExpensesCategories.MultiSelect = false;
            dataGridViewExpensesCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Adding DataGridView columns
            DataGridViewColumn[] columns = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn()
                {
                    Name = "No.",
                    SortMode = DataGridViewColumnSortMode.NotSortable,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                    Width = 50
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "Category Name",
                    SortMode = DataGridViewColumnSortMode.NotSortable
                }
            };

            dataGridViewExpensesCategories.Columns.AddRange(columns);
        }

        private void LoadDataToCategoryGridView()
        {
            dataGridViewExpensesCategories.Rows.Clear();

            categoriesData = this.parentForm.appQueries.GetExpensesCategoriesByUserId(LoginInfo.UserId);
            categoriesData.Select((x, i) => new string[] { (i + 1).ToString(), x.Name })
                .ToList().ForEach(x => dataGridViewExpensesCategories.Rows.Add(x));

            // Make column No read only. 
            // This is auto generated No
            dataGridViewExpensesCategories.Columns["No."].ReadOnly = true;
        }
    }
}
