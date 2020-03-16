namespace ExpenseLoggerApp.Forms.UserControls
{
    partial class ReportUserControl
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
            this.labelExpenseReport = new System.Windows.Forms.Label();
            this.labelBy = new System.Windows.Forms.Label();
            this.comboBoxFilterBy = new System.Windows.Forms.ComboBox();
            this.dateTimePickerFromDate = new System.Windows.Forms.DateTimePicker();
            this.labelFrom = new System.Windows.Forms.Label();
            this.groupBoxFilter = new System.Windows.Forms.GroupBox();
            this.buttonView = new System.Windows.Forms.Button();
            this.labelTo = new System.Windows.Forms.Label();
            this.dateTimePickerToDate = new System.Windows.Forms.DateTimePicker();
            this.dataGridViewExpenses = new System.Windows.Forms.DataGridView();
            this.groupBoxSummaryInfo = new System.Windows.Forms.GroupBox();
            this.labelSpentMostValue = new System.Windows.Forms.Label();
            this.labelTotalMoneyValue = new System.Windows.Forms.Label();
            this.labelTotalItemCountValue = new System.Windows.Forms.Label();
            this.labelSpentMost = new System.Windows.Forms.Label();
            this.labelTotalMoney = new System.Windows.Forms.Label();
            this.labelTotalItemCount = new System.Windows.Forms.Label();
            this.buttonEditExpense = new System.Windows.Forms.Button();
            this.buttonDeleteExpense = new System.Windows.Forms.Button();
            this.groupBoxFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExpenses)).BeginInit();
            this.groupBoxSummaryInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelExpenseReport
            // 
            this.labelExpenseReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExpenseReport.Location = new System.Drawing.Point(620, 0);
            this.labelExpenseReport.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelExpenseReport.Name = "labelExpenseReport";
            this.labelExpenseReport.Size = new System.Drawing.Size(455, 63);
            this.labelExpenseReport.TabIndex = 2;
            this.labelExpenseReport.Text = "Expenses Report";
            // 
            // labelBy
            // 
            this.labelBy.AutoSize = true;
            this.labelBy.Location = new System.Drawing.Point(62, 68);
            this.labelBy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBy.Name = "labelBy";
            this.labelBy.Size = new System.Drawing.Size(35, 25);
            this.labelBy.TabIndex = 0;
            this.labelBy.Text = "By";
            // 
            // comboBoxFilterBy
            // 
            this.comboBoxFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFilterBy.FormattingEnabled = true;
            this.comboBoxFilterBy.Location = new System.Drawing.Point(117, 61);
            this.comboBoxFilterBy.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxFilterBy.Name = "comboBoxFilterBy";
            this.comboBoxFilterBy.Size = new System.Drawing.Size(261, 32);
            this.comboBoxFilterBy.TabIndex = 1;
            // 
            // dateTimePickerFromDate
            // 
            this.dateTimePickerFromDate.Location = new System.Drawing.Point(491, 65);
            this.dateTimePickerFromDate.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerFromDate.Name = "dateTimePickerFromDate";
            this.dateTimePickerFromDate.Size = new System.Drawing.Size(367, 29);
            this.dateTimePickerFromDate.TabIndex = 2;
            // 
            // labelFrom
            // 
            this.labelFrom.AutoSize = true;
            this.labelFrom.Location = new System.Drawing.Point(427, 68);
            this.labelFrom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(57, 25);
            this.labelFrom.TabIndex = 4;
            this.labelFrom.Text = "From";
            // 
            // groupBoxFilter
            // 
            this.groupBoxFilter.Controls.Add(this.buttonView);
            this.groupBoxFilter.Controls.Add(this.labelTo);
            this.groupBoxFilter.Controls.Add(this.labelFrom);
            this.groupBoxFilter.Controls.Add(this.dateTimePickerToDate);
            this.groupBoxFilter.Controls.Add(this.dateTimePickerFromDate);
            this.groupBoxFilter.Controls.Add(this.comboBoxFilterBy);
            this.groupBoxFilter.Controls.Add(this.labelBy);
            this.groupBoxFilter.Location = new System.Drawing.Point(22, 98);
            this.groupBoxFilter.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxFilter.Name = "groupBoxFilter";
            this.groupBoxFilter.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxFilter.Size = new System.Drawing.Size(1692, 144);
            this.groupBoxFilter.TabIndex = 3;
            this.groupBoxFilter.TabStop = false;
            this.groupBoxFilter.Text = "Filters";
            // 
            // buttonView
            // 
            this.buttonView.Location = new System.Drawing.Point(1397, 61);
            this.buttonView.Margin = new System.Windows.Forms.Padding(6);
            this.buttonView.Name = "buttonView";
            this.buttonView.Size = new System.Drawing.Size(227, 48);
            this.buttonView.TabIndex = 6;
            this.buttonView.Text = "View";
            this.buttonView.UseVisualStyleBackColor = true;
            // 
            // labelTo
            // 
            this.labelTo.AutoSize = true;
            this.labelTo.Location = new System.Drawing.Point(924, 68);
            this.labelTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(36, 25);
            this.labelTo.TabIndex = 5;
            this.labelTo.Text = "To";
            // 
            // dateTimePickerToDate
            // 
            this.dateTimePickerToDate.Location = new System.Drawing.Point(972, 65);
            this.dateTimePickerToDate.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerToDate.Name = "dateTimePickerToDate";
            this.dateTimePickerToDate.Size = new System.Drawing.Size(367, 29);
            this.dateTimePickerToDate.TabIndex = 3;
            // 
            // dataGridViewExpenses
            // 
            this.dataGridViewExpenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExpenses.Location = new System.Drawing.Point(22, 281);
            this.dataGridViewExpenses.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridViewExpenses.Name = "dataGridViewExpenses";
            this.dataGridViewExpenses.Size = new System.Drawing.Size(1052, 511);
            this.dataGridViewExpenses.TabIndex = 4;
            // 
            // groupBoxSummaryInfo
            // 
            this.groupBoxSummaryInfo.Controls.Add(this.labelSpentMostValue);
            this.groupBoxSummaryInfo.Controls.Add(this.labelTotalMoneyValue);
            this.groupBoxSummaryInfo.Controls.Add(this.labelTotalItemCountValue);
            this.groupBoxSummaryInfo.Controls.Add(this.labelSpentMost);
            this.groupBoxSummaryInfo.Controls.Add(this.labelTotalMoney);
            this.groupBoxSummaryInfo.Controls.Add(this.labelTotalItemCount);
            this.groupBoxSummaryInfo.Location = new System.Drawing.Point(1104, 281);
            this.groupBoxSummaryInfo.Margin = new System.Windows.Forms.Padding(6);
            this.groupBoxSummaryInfo.Name = "groupBoxSummaryInfo";
            this.groupBoxSummaryInfo.Padding = new System.Windows.Forms.Padding(6);
            this.groupBoxSummaryInfo.Size = new System.Drawing.Size(614, 338);
            this.groupBoxSummaryInfo.TabIndex = 5;
            this.groupBoxSummaryInfo.TabStop = false;
            this.groupBoxSummaryInfo.Text = "Summary";
            // 
            // labelSpentMostValue
            // 
            this.labelSpentMostValue.AutoSize = true;
            this.labelSpentMostValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSpentMostValue.Location = new System.Drawing.Point(359, 257);
            this.labelSpentMostValue.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelSpentMostValue.Name = "labelSpentMostValue";
            this.labelSpentMostValue.Size = new System.Drawing.Size(17, 25);
            this.labelSpentMostValue.TabIndex = 5;
            this.labelSpentMostValue.Text = " ";
            // 
            // labelTotalMoneyValue
            // 
            this.labelTotalMoneyValue.AutoSize = true;
            this.labelTotalMoneyValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalMoneyValue.Location = new System.Drawing.Point(359, 159);
            this.labelTotalMoneyValue.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelTotalMoneyValue.Name = "labelTotalMoneyValue";
            this.labelTotalMoneyValue.Size = new System.Drawing.Size(17, 25);
            this.labelTotalMoneyValue.TabIndex = 4;
            this.labelTotalMoneyValue.Text = " ";
            // 
            // labelTotalItemCountValue
            // 
            this.labelTotalItemCountValue.AutoSize = true;
            this.labelTotalItemCountValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalItemCountValue.Location = new System.Drawing.Point(359, 68);
            this.labelTotalItemCountValue.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelTotalItemCountValue.Name = "labelTotalItemCountValue";
            this.labelTotalItemCountValue.Size = new System.Drawing.Size(17, 25);
            this.labelTotalItemCountValue.TabIndex = 3;
            this.labelTotalItemCountValue.Text = " ";
            // 
            // labelSpentMost
            // 
            this.labelSpentMost.AutoSize = true;
            this.labelSpentMost.Location = new System.Drawing.Point(92, 257);
            this.labelSpentMost.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelSpentMost.Name = "labelSpentMost";
            this.labelSpentMost.Size = new System.Drawing.Size(217, 25);
            this.labelSpentMost.TabIndex = 2;
            this.labelSpentMost.Text = "Most Money Spent For:";
            // 
            // labelTotalMoney
            // 
            this.labelTotalMoney.AutoSize = true;
            this.labelTotalMoney.Location = new System.Drawing.Point(136, 162);
            this.labelTotalMoney.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelTotalMoney.Name = "labelTotalMoney";
            this.labelTotalMoney.Size = new System.Drawing.Size(184, 25);
            this.labelTotalMoney.TabIndex = 1;
            this.labelTotalMoney.Text = "Total Money Spent:";
            // 
            // labelTotalItemCount
            // 
            this.labelTotalItemCount.AutoSize = true;
            this.labelTotalItemCount.Location = new System.Drawing.Point(205, 68);
            this.labelTotalItemCount.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelTotalItemCount.Name = "labelTotalItemCount";
            this.labelTotalItemCount.Size = new System.Drawing.Size(114, 25);
            this.labelTotalItemCount.TabIndex = 0;
            this.labelTotalItemCount.Text = "Total Items:";
            // 
            // buttonEditExpense
            // 
            this.buttonEditExpense.Location = new System.Drawing.Point(1137, 744);
            this.buttonEditExpense.Margin = new System.Windows.Forms.Padding(6);
            this.buttonEditExpense.Name = "buttonEditExpense";
            this.buttonEditExpense.Size = new System.Drawing.Size(227, 48);
            this.buttonEditExpense.TabIndex = 7;
            this.buttonEditExpense.Text = "Edit";
            this.buttonEditExpense.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteExpense
            // 
            this.buttonDeleteExpense.Location = new System.Drawing.Point(1419, 744);
            this.buttonDeleteExpense.Margin = new System.Windows.Forms.Padding(6);
            this.buttonDeleteExpense.Name = "buttonDeleteExpense";
            this.buttonDeleteExpense.Size = new System.Drawing.Size(227, 48);
            this.buttonDeleteExpense.TabIndex = 8;
            this.buttonDeleteExpense.Text = "Delete";
            this.buttonDeleteExpense.UseVisualStyleBackColor = true;
            // 
            // ReportUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonDeleteExpense);
            this.Controls.Add(this.buttonEditExpense);
            this.Controls.Add(this.groupBoxSummaryInfo);
            this.Controls.Add(this.dataGridViewExpenses);
            this.Controls.Add(this.groupBoxFilter);
            this.Controls.Add(this.labelExpenseReport);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ReportUserControl";
            this.Size = new System.Drawing.Size(1718, 901);
            this.groupBoxFilter.ResumeLayout(false);
            this.groupBoxFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExpenses)).EndInit();
            this.groupBoxSummaryInfo.ResumeLayout(false);
            this.groupBoxSummaryInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelExpenseReport;
        private System.Windows.Forms.Label labelBy;
        private System.Windows.Forms.ComboBox comboBoxFilterBy;
        private System.Windows.Forms.DateTimePicker dateTimePickerFromDate;
        private System.Windows.Forms.Label labelFrom;
        private System.Windows.Forms.GroupBox groupBoxFilter;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerToDate;
        private System.Windows.Forms.DataGridView dataGridViewExpenses;
        private System.Windows.Forms.Button buttonView;
        private System.Windows.Forms.GroupBox groupBoxSummaryInfo;
        private System.Windows.Forms.Label labelSpentMostValue;
        private System.Windows.Forms.Label labelTotalMoneyValue;
        private System.Windows.Forms.Label labelTotalItemCountValue;
        private System.Windows.Forms.Label labelSpentMost;
        private System.Windows.Forms.Label labelTotalMoney;
        private System.Windows.Forms.Label labelTotalItemCount;
        private System.Windows.Forms.Button buttonEditExpense;
        private System.Windows.Forms.Button buttonDeleteExpense;
    }
}
