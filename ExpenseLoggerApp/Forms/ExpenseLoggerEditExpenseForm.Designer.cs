namespace ExpenseLoggerApp.Forms
{
    partial class ExpenseLoggerEditExpenseForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonUpdateCurrentExpense = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.dateTimePickerCreatedDate = new System.Windows.Forms.DateTimePicker();
            this.labelDate = new System.Windows.Forms.Label();
            this.textBoxAmount = new System.Windows.Forms.TextBox();
            this.comboBoxCategories = new System.Windows.Forms.ComboBox();
            this.labelAmount = new System.Windows.Forms.Label();
            this.labelCategory = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonUpdateCurrentExpense
            // 
            this.buttonUpdateCurrentExpense.Location = new System.Drawing.Point(296, 344);
            this.buttonUpdateCurrentExpense.Margin = new System.Windows.Forms.Padding(4);
            this.buttonUpdateCurrentExpense.Name = "buttonUpdateCurrentExpense";
            this.buttonUpdateCurrentExpense.Size = new System.Drawing.Size(152, 54);
            this.buttonUpdateCurrentExpense.TabIndex = 9;
            this.buttonUpdateCurrentExpense.Text = "Update";
            this.buttonUpdateCurrentExpense.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(501, 344);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(152, 54);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerCreatedDate
            // 
            this.dateTimePickerCreatedDate.Location = new System.Drawing.Point(296, 235);
            this.dateTimePickerCreatedDate.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerCreatedDate.Name = "dateTimePickerCreatedDate";
            this.dateTimePickerCreatedDate.Size = new System.Drawing.Size(354, 29);
            this.dateTimePickerCreatedDate.TabIndex = 13;
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(147, 235);
            this.labelDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(53, 25);
            this.labelDate.TabIndex = 12;
            this.labelDate.Text = "Date";
            // 
            // textBoxAmount
            // 
            this.textBoxAmount.Location = new System.Drawing.Point(296, 144);
            this.textBoxAmount.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.Size = new System.Drawing.Size(354, 29);
            this.textBoxAmount.TabIndex = 10;
            // 
            // comboBoxCategories
            // 
            this.comboBoxCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategories.FormattingEnabled = true;
            this.comboBoxCategories.Location = new System.Drawing.Point(296, 52);
            this.comboBoxCategories.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxCategories.Name = "comboBoxCategories";
            this.comboBoxCategories.Size = new System.Drawing.Size(354, 32);
            this.comboBoxCategories.TabIndex = 8;
            // 
            // labelAmount
            // 
            this.labelAmount.AutoSize = true;
            this.labelAmount.Location = new System.Drawing.Point(147, 141);
            this.labelAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(80, 25);
            this.labelAmount.TabIndex = 7;
            this.labelAmount.Text = "Amount";
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Location = new System.Drawing.Point(147, 61);
            this.labelCategory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(92, 25);
            this.labelCategory.TabIndex = 6;
            this.labelCategory.Text = "Category";
            // 
            // ExpenseLoggerEditExpenseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonUpdateCurrentExpense);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.dateTimePickerCreatedDate);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.textBoxAmount);
            this.Controls.Add(this.comboBoxCategories);
            this.Controls.Add(this.labelAmount);
            this.Controls.Add(this.labelCategory);
            this.Name = "ExpenseLoggerEditExpenseForm";
            this.Text = "ExpenseLoggerEditExpenseForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonUpdateCurrentExpense;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.DateTimePicker dateTimePickerCreatedDate;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.TextBox textBoxAmount;
        private System.Windows.Forms.ComboBox comboBoxCategories;
        private System.Windows.Forms.Label labelAmount;
        private System.Windows.Forms.Label labelCategory;
    }
}