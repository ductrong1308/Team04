namespace ExpenseLoggerApp.Forms.UserControls
{
    partial class HomeUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelDailyExpense = new System.Windows.Forms.Label();
            this.groupBoxNewTransaction = new System.Windows.Forms.GroupBox();
            this.buttonAddNewExpense = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.dateTimePickerCreatedDate = new System.Windows.Forms.DateTimePicker();
            this.labelDate = new System.Windows.Forms.Label();
            this.textBoxAmount = new System.Windows.Forms.TextBox();
            this.comboBoxCategories = new System.Windows.Forms.ComboBox();
            this.labelAmount = new System.Windows.Forms.Label();
            this.labelCategory = new System.Windows.Forms.Label();
            this.groupBoxNewTransaction.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelDailyExpense
            // 
            this.labelDailyExpense.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDailyExpense.Location = new System.Drawing.Point(352, 0);
            this.labelDailyExpense.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDailyExpense.Name = "labelDailyExpense";
            this.labelDailyExpense.Size = new System.Drawing.Size(248, 38);
            this.labelDailyExpense.TabIndex = 1;
            this.labelDailyExpense.Text = "Daily Expenses";
            // 
            // groupBoxNewTransaction
            // 
            this.groupBoxNewTransaction.Controls.Add(this.buttonAddNewExpense);
            this.groupBoxNewTransaction.Controls.Add(this.buttonClear);
            this.groupBoxNewTransaction.Controls.Add(this.dateTimePickerCreatedDate);
            this.groupBoxNewTransaction.Controls.Add(this.labelDate);
            this.groupBoxNewTransaction.Controls.Add(this.textBoxAmount);
            this.groupBoxNewTransaction.Controls.Add(this.comboBoxCategories);
            this.groupBoxNewTransaction.Controls.Add(this.labelAmount);
            this.groupBoxNewTransaction.Controls.Add(this.labelCategory);
            this.groupBoxNewTransaction.Location = new System.Drawing.Point(242, 103);
            this.groupBoxNewTransaction.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxNewTransaction.Name = "groupBoxNewTransaction";
            this.groupBoxNewTransaction.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxNewTransaction.Size = new System.Drawing.Size(437, 290);
            this.groupBoxNewTransaction.TabIndex = 2;
            this.groupBoxNewTransaction.TabStop = false;
            this.groupBoxNewTransaction.Text = "New Expense";
            // 
            // buttonAddNewExpense
            // 
            this.buttonAddNewExpense.Location = new System.Drawing.Point(134, 222);
            this.buttonAddNewExpense.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddNewExpense.Name = "buttonAddNewExpense";
            this.buttonAddNewExpense.Size = new System.Drawing.Size(83, 29);
            this.buttonAddNewExpense.TabIndex = 3;
            this.buttonAddNewExpense.Text = "Add";
            this.buttonAddNewExpense.UseVisualStyleBackColor = true;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(246, 222);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(2);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(83, 29);
            this.buttonClear.TabIndex = 4;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerCreatedDate
            // 
            this.dateTimePickerCreatedDate.Location = new System.Drawing.Point(134, 163);
            this.dateTimePickerCreatedDate.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerCreatedDate.Name = "dateTimePickerCreatedDate";
            this.dateTimePickerCreatedDate.Size = new System.Drawing.Size(195, 20);
            this.dateTimePickerCreatedDate.TabIndex = 5;
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(53, 163);
            this.labelDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(30, 13);
            this.labelDate.TabIndex = 4;
            this.labelDate.Text = "Date";
            // 
            // textBoxAmount
            // 
            this.textBoxAmount.Location = new System.Drawing.Point(134, 114);
            this.textBoxAmount.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.Size = new System.Drawing.Size(195, 20);
            this.textBoxAmount.TabIndex = 3;
            // 
            // comboBoxCategories
            // 
            this.comboBoxCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategories.FormattingEnabled = true;
            this.comboBoxCategories.Location = new System.Drawing.Point(134, 64);
            this.comboBoxCategories.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxCategories.Name = "comboBoxCategories";
            this.comboBoxCategories.Size = new System.Drawing.Size(195, 21);
            this.comboBoxCategories.TabIndex = 2;
            // 
            // labelAmount
            // 
            this.labelAmount.AutoSize = true;
            this.labelAmount.Location = new System.Drawing.Point(53, 112);
            this.labelAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(43, 13);
            this.labelAmount.TabIndex = 1;
            this.labelAmount.Text = "Amount";
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Location = new System.Drawing.Point(53, 69);
            this.labelCategory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(49, 13);
            this.labelCategory.TabIndex = 0;
            this.labelCategory.Text = "Category";
            // 
            // HomeUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxNewTransaction);
            this.Controls.Add(this.labelDailyExpense);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "HomeUserControl";
            this.Size = new System.Drawing.Size(937, 488);
            this.groupBoxNewTransaction.ResumeLayout(false);
            this.groupBoxNewTransaction.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label labelDailyExpense;
        private System.Windows.Forms.GroupBox groupBoxNewTransaction;
        private System.Windows.Forms.Label labelAmount;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.DateTimePicker dateTimePickerCreatedDate;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.TextBox textBoxAmount;
        private System.Windows.Forms.ComboBox comboBoxCategories;
        private System.Windows.Forms.Button buttonAddNewExpense;
        private System.Windows.Forms.Button buttonClear;
    }
}
