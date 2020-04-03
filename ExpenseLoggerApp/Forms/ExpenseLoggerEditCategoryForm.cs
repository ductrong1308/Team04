using ExpenseLoggerApp.Forms.UserControls;
using ExpenseLoggerApp.Resources;
using ExpenseLoggerDAL;
using System;
using System.Windows.Forms;

namespace ExpenseLoggerApp.Forms
{
    public partial class ExpenseLoggerEditCategoryForm : ExpenseLoggerFormBase
    {

        public ExpenseLoggerEditCategoryForm()
        {
            InitializeComponent();

            // Register events
            this.Load += ExpenseLoggerEditCategoryForm_Load;
            buttonUpdateCurrentCategory.Click += ButtonUpdateCurrentCategory_Click;
            buttonCancel.Click += ButtonCancel_Click;
        }

        /// <summary>
        /// Loading data to the form when user want to edit an category item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExpenseLoggerEditCategoryForm_Load(object sender, EventArgs e)
        {
            Category category = SettingsUserControl.selectedCategory;
            if (category != null)
            {
                // Display the data on the controls.
                textBoxCategory.Text = category.Name;
            }
            else
            {
                // Show error message when the data cannot be loaded.
                MessageBox.Show(AppResource.ErrorHasOccurred);
            }
        }

        /// <summary>
        /// User do nothing, closing the popup or cancel the process.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Update a selected category.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdateCurrentCategory_Click(object sender, EventArgs e)
        {
            // Validate amount data to make sure that users inputted a correct number.
            string editedCategoryName = textBoxCategory.Text.Trim();
            if (string.IsNullOrEmpty(editedCategoryName))
            {
                MessageBox.Show(AppResource.CategoryIsRequired);
            }
            else
            {
                // Update new data to the selected expense and save it to DB>
                var category = SettingsUserControl.selectedCategory;
                category.Name = editedCategoryName;

                appCommands.UpdateExistingCategory(category);
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}
