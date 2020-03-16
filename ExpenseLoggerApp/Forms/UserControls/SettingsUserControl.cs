using ExpenseLoggerApp.Helpers;
using ExpenseLoggerApp.Models;
using ExpenseLoggerApp.Resources;
using ExpenseLoggerDAL;
using ExpenseLoggerDAL.BackupRestore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ExpenseLoggerApp.Forms.UserControls
{
    public partial class SettingsUserControl : BaseUserControl
    {
        List<Category> categoriesData;

        // field to keep the Backup and Restore layer
        private ExpenseLoggerBackupRestore expenseLoggerBackupRestore;

        // dataset will hold all tables being used
        private DataSet expenseLoggerDataSet;

        public SettingsUserControl()
        {
            InitializeComponent();
        }

        public override void LoadFormData()
        {
            this.LoadDataToComboBox();

            SetupCategoriesDataGridView();

            LoadDataToCategoryGridView();

            expenseLoggerBackupRestore = new ExpenseLoggerBackupRestore();

            this.EstablishDBConnection();

            this.InitializeDataSet();

            buttonBackup.Click += ButtonBackup_Click;
            buttonRestore.Click += ButtonRestore_Click;

            // ensure that the connection to the db is closed
            this.parentForm.FormClosing += (s, e) => expenseLoggerBackupRestore.CloseConnection();
            this.HandleDestroyed += (s, e) => expenseLoggerBackupRestore.CloseConnection();
        }

        private void ButtonBackup_Click(object sender, EventArgs e)
        {
            try
            {
                expenseLoggerBackupRestore.BackupDataSetToXML(expenseLoggerDataSet);
                MessageBox.Show(AppResource.BackupDone);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonRestore_Click(object sender, EventArgs e)
        {
            try
            {
                string xmlFileName = expenseLoggerDataSet.DataSetName + ".xml";
                if (File.Exists(xmlFileName))
                {
                    expenseLoggerBackupRestore.RestoreDataSetFromBackup(expenseLoggerDataSet);
                    ProcessRestoreData();
                }
                else
                {
                    MessageBox.Show(AppResource.BackupDataDoesNotExist);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                buttonBackup.Enabled = true;
                buttonRestore.Enabled = true;
            }
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
            string currency = (comboBoxCurrencies.SelectedItem as ComboboxItem).Value.ToString();

            this.parentForm.appCommands.AddOrUpdateCurrency(LoginInfo.UserId, currency);

            LoginInfo.Currency = currency;
            LoginInfo.UserPreferenceCulture = CultureHelper.UserPreferenceCulture(currency);

            MessageBox.Show(AppResource.DataSavedSuccessful);
        }

        private void EstablishDBConnection()
        {
            // Get and open connection to the DB
            string connectionString = expenseLoggerBackupRestore.GetConnectionString("ExpenseLoggerConnection");
            expenseLoggerBackupRestore.OpenConnection(connectionString);

            expenseLoggerDataSet = new DataSet()
            {
                // must be named for backup purposes
                DataSetName = "ExpenseLoggerDataSet",
            };
        }

        private void InitializeDataSet()
        {
            // Get Data Table
            List<string> tables = new List<string>() { "Users", "Categories", "Expenses", "Settings" };
            foreach (var tableName in tables)
            {
                DataTable dataTable = expenseLoggerBackupRestore.GetDataTable(tableName);
                expenseLoggerDataSet.Tables.Add(dataTable);
            }
        }

        private void ProcessRestoreData()
        {
            buttonBackup.Enabled = false;
            buttonRestore.Enabled = false;

            for (int i = 0; i < expenseLoggerDataSet.Tables.Count; i++)
            {
                DataTable table = expenseLoggerDataSet.Tables[i];
                foreach (DataRow row in table.Rows)
                {
                    expenseLoggerBackupRestore.InsertTableRow(row);
                }
            }

            // De-register grid and combobox events.
            comboBoxCurrencies.SelectedIndexChanged -= ComboBoxCurrencies_SelectedIndexChanged;
            dataGridViewExpensesCategories.CellValueChanged -= DataGridViewExpensesCategories_CellValueChanged;
            dataGridViewExpensesCategories.DefaultValuesNeeded -= DataGridViewExpensesCategories_DefaultValuesNeeded;

            // Reload data to the combobox
            LoadDataToComboBox();

            // Reload data to the dataGridView.
            LoadDataToCategoryGridView();

            MessageBox.Show(AppResource.RestoreDone);
        }

        public void LoadDataToComboBox()
        {
            List<ComboboxItem> appCurrencyList = new List<ComboboxItem>()
            {
                new ComboboxItem() { Text = "Canadian Dollar", Value = "CAD" },
                new ComboboxItem() { Text = "US Dollar", Value = "USD" },
                new ComboboxItem() { Text = "Euro", Value = "EUR" },
                new ComboboxItem() { Text = "Pound Sterling", Value = "GBP" },
                new ComboboxItem() { Text = "Yuan", Value = "CNY" },
                new ComboboxItem() { Text = "Yen", Value = "JPY" },
            };

            comboBoxCurrencies.DataSource = appCurrencyList;

            if (string.IsNullOrEmpty(LoginInfo.Currency))
            {
                LoginInfo.Currency = appCurrencyList.FirstOrDefault().Value.ToString();
            }

            comboBoxCurrencies.SelectedIndex = appCurrencyList.FindIndex(x => x.Value.ToString() == LoginInfo.Currency);
            comboBoxCurrencies.SelectedIndexChanged += ComboBoxCurrencies_SelectedIndexChanged;

        }

        /// <summary>
        /// Default settings for CategoriesDataGridView
        /// and adding columns to the grid.
        /// </summary>
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

        /// <summary>
        /// Loading data to the datagridView
        /// </summary>
        private void LoadDataToCategoryGridView()
        {
            dataGridViewExpensesCategories.Rows.Clear();

            categoriesData = this.parentForm.appQueries.GetExpensesCategoriesByUserId(LoginInfo.UserId);
            categoriesData.Select((x, i) => new string[] { (i + 1).ToString(), x.Name })
                .ToList().ForEach(x => dataGridViewExpensesCategories.Rows.Add(x));

            // Make column No read only. 
            // This is auto generated No
            dataGridViewExpensesCategories.Columns["No."].ReadOnly = true;

            // Register grid's events.
            dataGridViewExpensesCategories.CellValueChanged += DataGridViewExpensesCategories_CellValueChanged;
            dataGridViewExpensesCategories.DefaultValuesNeeded += DataGridViewExpensesCategories_DefaultValuesNeeded;
        }
    }
}
