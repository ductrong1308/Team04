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
        // This variable is used to storing selected category data 
        // so that child forms can access and do editing.
        public static Category selectedCategory;

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
            base.LoadFormData();

            this.LoadDataToComboBox();

            SetupCategoriesDataGridView();

            LoadDataToCategoryGridView();

            // Initialize ExpenseLoggerBackupRestore, which is responsible for doing backup and restore functions.
            expenseLoggerBackupRestore = new ExpenseLoggerBackupRestore();

            // Register button event.
            buttonBackup.Click += ButtonBackup_Click;
            buttonRestore.Click += ButtonRestore_Click;
            buttonEditCategory.Click += ButtonEditCategory_Click;
            buttonDeleteCategory.Click += ButtonDeleteCategory_Click;
        }

        private void ButtonDeleteCategory_Click(object sender, EventArgs e)
        {
            if (selectedCategory == null)
            {
                MessageBox.Show(AppResource.NoItemSelected);
                return;
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show(
                    AppResource.DeleteCategoryConfirmMessage, AppResource.DeleteCategory, MessageBoxButtons.OKCancel);

                if (dialogResult == DialogResult.OK)
                {
                    try
                    {
                        // Call to BLL to delete the selected Category.
                        bool isItemDeleted = this.appCommands.DeleteSelectedCategory(selectedCategory);
                        if (isItemDeleted)
                        {
                            // Set main form's data to default values
                            SetFormControlsToDefaultState();

                            // Query data after editing and display them on the dataGridView.
                            LoadDataToCategoryGridView();
                        }
                        else
                        {
                            MessageBox.Show(AppResource.SelectedCategoryNotFound);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void ButtonEditCategory_Click(object sender, EventArgs e)
        {
            if (selectedCategory == null)
            {
                MessageBox.Show(AppResource.NoItemSelected);
            }
            else
            {
                // Show another form that lets user to edit the selected expese's data.
                ExpenseLoggerEditCategoryForm editExpenseCategoryForm = new ExpenseLoggerEditCategoryForm();
                var result = editExpenseCategoryForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // Set main form's data to default values
                    SetFormControlsToDefaultState();

                    // Query data after editing and display them on the dataGridView.
                    LoadDataToCategoryGridView();
                }

                // If users don't make any changes.
                editExpenseCategoryForm.Hide();
            }
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
            try
            {
                this.appCommands.AddOrUpdateCurrency(UserIdentity.Instance.UserId, currency);
                // Storing data to the shared class.
                UserIdentity.Instance.Currency = currency;
                UserIdentity.Instance.UserPreferenceCulture = CultureHelper.UserPreferenceCulture(currency);

                // Show message to indicate updating successfully.
                MessageBox.Show(AppResource.DataSavedSuccessful);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            dataGridViewExpensesCategories.ReadOnly = true;
            dataGridViewExpensesCategories.AllowUserToAddRows = false;
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
            categoriesData = this.appQueries.GetExpensesCategoriesByUserId(UserIdentity.Instance.UserId);
            categoriesData.Select((x, i) => new string[] { (i + 1).ToString(), x.Name })
                .ToList().ForEach(x => dataGridViewExpensesCategories.Rows.Add(x));

            selectedCategory = categoriesData.FirstOrDefault();

            // Register user selection changed.
            dataGridViewExpensesCategories.SelectionChanged += DataGridViewExpensesCategories_SelectionChanged;
        }

        /// <summary>
        /// Set form's control and variable to default values.
        /// </summary>
        private void SetFormControlsToDefaultState()
        {
            // Set data to default
            categoriesData = null;
            selectedCategory = null;

            // De-register grid view selection changed event
            dataGridViewExpensesCategories.SelectionChanged -= DataGridViewExpensesCategories_SelectionChanged;
        }

        /// <summary>
        /// Get selected expense item on the dataGridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewExpensesCategories_SelectionChanged(object sender, EventArgs e)
        {
            // Check if users selected the whole row or just a cell
            var rowIndex = dataGridViewExpensesCategories.SelectedRows.Count > 0
                ? dataGridViewExpensesCategories.SelectedRows[0].Index
                : dataGridViewExpensesCategories.SelectedCells.Count > 0
                    ? dataGridViewExpensesCategories.SelectedCells[0].RowIndex : -1;

            if (rowIndex > -1)
            {
                // Store the selected expense to a variable, which will be used later on.
                selectedCategory = categoriesData[rowIndex];
            }
        }
    }
}
