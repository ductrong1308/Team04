using ExpenseLoggerApp.Helpers;
using ExpenseLoggerApp.Models;
using ExpenseLoggerApp.Resources;
using ExpenseLoggerDAL;
using ExpenseLoggerDAL.BackupRestore;
using System;
using System.Collections.Generic;
using System.Data;
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

            // Initialize ExpenseLoggerBackupRestore, which is responsible for doing backup and restore functions.
            expenseLoggerBackupRestore = new ExpenseLoggerBackupRestore();

            // Register button event.
            buttonBackup.Click += ButtonBackup_Click;
            buttonRestore.Click += ButtonRestore_Click;
        }

        /// <summary>
        /// This function will create DB backup and store data to XML.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonBackup_Click(object sender, EventArgs e)
        {
            try
            {
                // Only establish connection when using this feature instead of putting this in LoadFormData
                // Because users may not user this feature frequently.

                // This Connection for Backup and Restore DB
                this.EstablishDBConnection();

                // Initialize dataset which will be used to store all datatable.
                this.InitializeDataSet();

                expenseLoggerBackupRestore.BackupDataSetToXML(expenseLoggerDataSet);
                MessageBox.Show(AppResource.BackupDone);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // make sure that connection to db will be closed in any cases.
                expenseLoggerBackupRestore.CloseConnection();
            }
        }

        /// <summary>
        /// Restore DB from XML data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRestore_Click(object sender, EventArgs e)
        {
            try
            {
                // Only establish connection when using this feature instead of putting this in LoadFormData
                // Because users may not user this feature frequently.

                // This Connection for Backup and Restore DB
                this.EstablishDBConnection();

                // Initialize dataset which will be used to store all datatable.
                this.InitializeDataSet();

                // Check if the backup file' existence.
                string xmlFileName = expenseLoggerDataSet.DataSetName + ".xml";
                if (File.Exists(xmlFileName))
                {
                    // Calling restore function in expenseLoggerBackupRestore class.
                    // This will clear all the data in the DB
                    expenseLoggerBackupRestore.RestoreDataSetFromBackup(expenseLoggerDataSet);

                    // This will help to insert all the data in the dataset to DB.
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
                // Enable action buttons after all.
                buttonBackup.Enabled = true;
                buttonRestore.Enabled = true;

                // make sure that connection to db will be closed in any cases.
                expenseLoggerBackupRestore.CloseConnection();
            }
        }

        // Adding cell value = -1 when users want to add a new row within the dataGridView.
        private void DataGridViewExpensesCategories_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[0].Value = -1;
        }

        /// <summary>
        /// Add or  Update data when users made changes on the dataGridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewExpensesCategories_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Check if user add or update data.
            bool isNewRow = e.RowIndex == categoriesData.Count;
            string newCategoryValue = dataGridViewExpensesCategories.Rows[e.RowIndex].Cells[1].Value?.ToString();

            if (string.IsNullOrEmpty(newCategoryValue))
            {
                MessageBox.Show(AppResource.CategoryIsRequired);

                // Reload data.
                LoadDataToCategoryGridView();
            }
            else
            {
                if (isNewRow)
                {
                    // Adding a new category to DB.
                    parentForm.appCommands.AddCategory(UserIdentity.Instance.UserId, newCategoryValue);
                    LoadDataToCategoryGridView();
                }
                else
                {
                    // Retrieve the cureent category.
                    Category editingCategory = categoriesData[e.RowIndex];

                    if (editingCategory.Name != newCategoryValue)
                    {
                        // Updating exising category in the DB.
                        parentForm.appCommands.UpdateCategory(UserIdentity.Instance.UserId, editingCategory.Id, newCategoryValue);
                        LoadDataToCategoryGridView();
                    }
                }
            }
        }

        /// <summary>
        /// Changing Currency
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxCurrencies_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Each item in the comboBox will have Text and Value
            // Text is used to show the name, value is the actual thing which will be stored in the DB.
            string currency = (comboBoxCurrencies.SelectedItem as ComboBoxItem).Value.ToString();

            // Make a change when users selected an item in the comboBox.
            this.parentForm.appCommands.AddOrUpdateCurrency(UserIdentity.Instance.UserId, currency);

            // Storing data to the shared class.
            UserIdentity.Instance.Currency = currency;
            UserIdentity.Instance.UserPreferenceCulture = CultureHelper.UserPreferenceCulture(currency);

            // Show message to indicate updating successfully.
            MessageBox.Show(AppResource.DataSavedSuccessful);
        }

        /// <summary>
        /// Create a connection to the DB.
        /// </summary>
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

        /// <summary>
        /// Initialize dataset, getting tables and store them in the dataset.
        /// </summary>
        private void InitializeDataSet()
        {
            // Get Data Table
            List<string> tables = new List<string>() { "Users", "Categories", "Expenses", "Settings" };
            foreach (var tableName in tables)
            {
                // Get table
                DataTable dataTable = expenseLoggerBackupRestore.GetDataTable(tableName);

                // Store table in the dataset.
                expenseLoggerDataSet.Tables.Add(dataTable);
            }
        }

        /// <summary>
        /// This function is used to insert data to DB when users used restore function.
        /// </summary>
        private void ProcessRestoreData()
        {
            // Disable actions button when the fuction is in processing.
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

            // Show message to show the restore process has been successfully.
            MessageBox.Show(AppResource.RestoreDone);
        }

        public void LoadDataToComboBox()
        {
            // Set datasource for comboBoxCurrencies
            comboBoxCurrencies.DataSource = AppDefaultValues.Currencies;

            if (string.IsNullOrEmpty(UserIdentity.Instance.Currency))
            {
                // Store the currency info to the shared class.
                UserIdentity.Instance.Currency = AppDefaultValues.Currencies.FirstOrDefault().Value.ToString();
            }

            // Default select user preference currency.
            comboBoxCurrencies.SelectedIndex =
                AppDefaultValues.Currencies.FindIndex(x => x.Value.ToString() == UserIdentity.Instance.Currency);

            // Register events after the data has been loaded.
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

            // Adding columns to the dataGridView.
            dataGridViewExpensesCategories.Columns.AddRange(columns);
        }

        /// <summary>
        /// Loading data to the datagridView
        /// </summary>
        private void LoadDataToCategoryGridView()
        {
            // Clear data before binding a new.
            dataGridViewExpensesCategories.Rows.Clear();

            // Loop through the data list and bind data to each row of the dataGridView.
            categoriesData = this.parentForm.appQueries.GetExpensesCategoriesByUserId(UserIdentity.Instance.UserId);
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
