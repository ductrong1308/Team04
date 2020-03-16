namespace ExpenseLoggerApp.Forms.UserControls
{
    partial class SettingsUserControl
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
            this.labelAppSettings = new System.Windows.Forms.Label();
            this.groupBoxDefaultAppCurrency = new System.Windows.Forms.GroupBox();
            this.comboBoxCurrencies = new System.Windows.Forms.ComboBox();
            this.labelCurrency = new System.Windows.Forms.Label();
            this.groupBoxBackupRestore = new System.Windows.Forms.GroupBox();
            this.buttonRestore = new System.Windows.Forms.Button();
            this.buttonBackup = new System.Windows.Forms.Button();
            this.groupBoxExpensesCategory = new System.Windows.Forms.GroupBox();
            this.dataGridViewExpensesCategories = new System.Windows.Forms.DataGridView();
            this.buttonEditCategory = new System.Windows.Forms.Button();
            this.buttonDeleteCategory = new System.Windows.Forms.Button();
            this.groupBoxDefaultAppCurrency.SuspendLayout();
            this.groupBoxBackupRestore.SuspendLayout();
            this.groupBoxExpensesCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExpensesCategories)).BeginInit();
            this.SuspendLayout();
            // 
            // labelAppSettings
            // 
            this.labelAppSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAppSettings.Location = new System.Drawing.Point(682, 0);
            this.labelAppSettings.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAppSettings.Name = "labelAppSettings";
            this.labelAppSettings.Size = new System.Drawing.Size(537, 70);
            this.labelAppSettings.TabIndex = 3;
            this.labelAppSettings.Text = "Application Settings";
            // 
            // groupBoxDefaultAppCurrency
            // 
            this.groupBoxDefaultAppCurrency.Controls.Add(this.comboBoxCurrencies);
            this.groupBoxDefaultAppCurrency.Controls.Add(this.labelCurrency);
            this.groupBoxDefaultAppCurrency.Location = new System.Drawing.Point(78, 186);
            this.groupBoxDefaultAppCurrency.Name = "groupBoxDefaultAppCurrency";
            this.groupBoxDefaultAppCurrency.Size = new System.Drawing.Size(701, 281);
            this.groupBoxDefaultAppCurrency.TabIndex = 4;
            this.groupBoxDefaultAppCurrency.TabStop = false;
            this.groupBoxDefaultAppCurrency.Text = "App Currency";
            // 
            // comboBoxCurrencies
            // 
            this.comboBoxCurrencies.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCurrencies.FormattingEnabled = true;
            this.comboBoxCurrencies.Location = new System.Drawing.Point(245, 100);
            this.comboBoxCurrencies.Name = "comboBoxCurrencies";
            this.comboBoxCurrencies.Size = new System.Drawing.Size(347, 32);
            this.comboBoxCurrencies.TabIndex = 1;
            // 
            // labelCurrency
            // 
            this.labelCurrency.AutoSize = true;
            this.labelCurrency.Location = new System.Drawing.Point(94, 109);
            this.labelCurrency.Name = "labelCurrency";
            this.labelCurrency.Size = new System.Drawing.Size(92, 25);
            this.labelCurrency.TabIndex = 0;
            this.labelCurrency.Text = "Currency";
            // 
            // groupBoxBackupRestore
            // 
            this.groupBoxBackupRestore.Controls.Add(this.buttonRestore);
            this.groupBoxBackupRestore.Controls.Add(this.buttonBackup);
            this.groupBoxBackupRestore.Location = new System.Drawing.Point(78, 516);
            this.groupBoxBackupRestore.Name = "groupBoxBackupRestore";
            this.groupBoxBackupRestore.Size = new System.Drawing.Size(701, 307);
            this.groupBoxBackupRestore.TabIndex = 5;
            this.groupBoxBackupRestore.TabStop = false;
            this.groupBoxBackupRestore.Text = "Backup && Restore";
            // 
            // buttonRestore
            // 
            this.buttonRestore.Location = new System.Drawing.Point(390, 118);
            this.buttonRestore.Name = "buttonRestore";
            this.buttonRestore.Size = new System.Drawing.Size(237, 78);
            this.buttonRestore.TabIndex = 1;
            this.buttonRestore.Text = "Restore";
            this.buttonRestore.UseVisualStyleBackColor = true;
            // 
            // buttonBackup
            // 
            this.buttonBackup.Location = new System.Drawing.Point(57, 118);
            this.buttonBackup.Name = "buttonBackup";
            this.buttonBackup.Size = new System.Drawing.Size(237, 78);
            this.buttonBackup.TabIndex = 0;
            this.buttonBackup.Text = "Backup";
            this.buttonBackup.UseVisualStyleBackColor = true;
            // 
            // groupBoxExpensesCategory
            // 
            this.groupBoxExpensesCategory.Controls.Add(this.buttonDeleteCategory);
            this.groupBoxExpensesCategory.Controls.Add(this.buttonEditCategory);
            this.groupBoxExpensesCategory.Controls.Add(this.dataGridViewExpensesCategories);
            this.groupBoxExpensesCategory.Location = new System.Drawing.Point(825, 186);
            this.groupBoxExpensesCategory.Name = "groupBoxExpensesCategory";
            this.groupBoxExpensesCategory.Size = new System.Drawing.Size(834, 637);
            this.groupBoxExpensesCategory.TabIndex = 7;
            this.groupBoxExpensesCategory.TabStop = false;
            this.groupBoxExpensesCategory.Text = "Expense Categories";
            // 
            // dataGridViewExpensesCategories
            // 
            this.dataGridViewExpensesCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExpensesCategories.Location = new System.Drawing.Point(35, 64);
            this.dataGridViewExpensesCategories.Name = "dataGridViewExpensesCategories";
            this.dataGridViewExpensesCategories.RowTemplate.Height = 31;
            this.dataGridViewExpensesCategories.Size = new System.Drawing.Size(762, 462);
            this.dataGridViewExpensesCategories.TabIndex = 0;
            // 
            // buttonEditCategory
            // 
            this.buttonEditCategory.Location = new System.Drawing.Point(146, 561);
            this.buttonEditCategory.Margin = new System.Windows.Forms.Padding(6);
            this.buttonEditCategory.Name = "buttonEditCategory";
            this.buttonEditCategory.Size = new System.Drawing.Size(227, 48);
            this.buttonEditCategory.TabIndex = 7;
            this.buttonEditCategory.Text = "Edit";
            this.buttonEditCategory.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteCategory
            // 
            this.buttonDeleteCategory.Location = new System.Drawing.Point(454, 561);
            this.buttonDeleteCategory.Margin = new System.Windows.Forms.Padding(6);
            this.buttonDeleteCategory.Name = "buttonDeleteCategory";
            this.buttonDeleteCategory.Size = new System.Drawing.Size(227, 48);
            this.buttonDeleteCategory.TabIndex = 8;
            this.buttonDeleteCategory.Text = "Delete";
            this.buttonDeleteCategory.UseVisualStyleBackColor = true;
            // 
            // SettingsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxExpensesCategory);
            this.Controls.Add(this.groupBoxBackupRestore);
            this.Controls.Add(this.groupBoxDefaultAppCurrency);
            this.Controls.Add(this.labelAppSettings);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SettingsUserControl";
            this.Size = new System.Drawing.Size(1718, 901);
            this.groupBoxDefaultAppCurrency.ResumeLayout(false);
            this.groupBoxDefaultAppCurrency.PerformLayout();
            this.groupBoxBackupRestore.ResumeLayout(false);
            this.groupBoxExpensesCategory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExpensesCategories)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelAppSettings;
        private System.Windows.Forms.GroupBox groupBoxDefaultAppCurrency;
        private System.Windows.Forms.ComboBox comboBoxCurrencies;
        private System.Windows.Forms.Label labelCurrency;
        private System.Windows.Forms.GroupBox groupBoxBackupRestore;
        private System.Windows.Forms.Button buttonRestore;
        private System.Windows.Forms.Button buttonBackup;
        private System.Windows.Forms.GroupBox groupBoxExpensesCategory;
        private System.Windows.Forms.DataGridView dataGridViewExpensesCategories;
        private System.Windows.Forms.Button buttonDeleteCategory;
        private System.Windows.Forms.Button buttonEditCategory;
    }
}
