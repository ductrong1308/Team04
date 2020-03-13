namespace ExpenseLoggerApp
{
    partial class ExpenseLoggerAppForm
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
            this.tabMainExpenseLogger = new System.Windows.Forms.TabControl();
            this.tabDailyExpense = new System.Windows.Forms.TabPage();
            this.tabReport = new System.Windows.Forms.TabPage();
            this.tabExpenseStatistics = new System.Windows.Forms.TabPage();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.tabMainExpenseLogger.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMainExpenseLogger
            // 
            this.tabMainExpenseLogger.Controls.Add(this.tabDailyExpense);
            this.tabMainExpenseLogger.Controls.Add(this.tabReport);
            this.tabMainExpenseLogger.Controls.Add(this.tabExpenseStatistics);
            this.tabMainExpenseLogger.Controls.Add(this.tabSettings);
            this.tabMainExpenseLogger.Location = new System.Drawing.Point(-1, 9);
            this.tabMainExpenseLogger.Name = "tabMainExpenseLogger";
            this.tabMainExpenseLogger.SelectedIndex = 0;
            this.tabMainExpenseLogger.Size = new System.Drawing.Size(1531, 900);
            this.tabMainExpenseLogger.TabIndex = 0;
            // 
            // tabDailyExpense
            // 
            this.tabDailyExpense.Location = new System.Drawing.Point(4, 33);
            this.tabDailyExpense.Name = "tabDailyExpense";
            this.tabDailyExpense.Padding = new System.Windows.Forms.Padding(3);
            this.tabDailyExpense.Size = new System.Drawing.Size(1523, 863);
            this.tabDailyExpense.TabIndex = 0;
            this.tabDailyExpense.Text = "Daily Expense Logging";
            this.tabDailyExpense.UseVisualStyleBackColor = true;
            // 
            // tabReport
            // 
            this.tabReport.Location = new System.Drawing.Point(4, 33);
            this.tabReport.Name = "tabReport";
            this.tabReport.Padding = new System.Windows.Forms.Padding(3);
            this.tabReport.Size = new System.Drawing.Size(1523, 863);
            this.tabReport.TabIndex = 1;
            this.tabReport.Text = "Expense Report";
            this.tabReport.UseVisualStyleBackColor = true;
            // 
            // tabExpenseStatistics
            // 
            this.tabExpenseStatistics.Location = new System.Drawing.Point(4, 33);
            this.tabExpenseStatistics.Name = "tabExpenseStatistics";
            this.tabExpenseStatistics.Padding = new System.Windows.Forms.Padding(3);
            this.tabExpenseStatistics.Size = new System.Drawing.Size(1523, 863);
            this.tabExpenseStatistics.TabIndex = 2;
            this.tabExpenseStatistics.Text = "Expense Statistics";
            this.tabExpenseStatistics.UseVisualStyleBackColor = true;
            // 
            // tabSettings
            // 
            this.tabSettings.Location = new System.Drawing.Point(4, 33);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(1523, 863);
            this.tabSettings.TabIndex = 3;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // ExpenseLoggerAppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1553, 918);
            this.Controls.Add(this.tabMainExpenseLogger);
            this.Name = "ExpenseLoggerAppForm";
            this.Text = "Form1";
            this.tabMainExpenseLogger.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMainExpenseLogger;
        private System.Windows.Forms.TabPage tabDailyExpense;
        private System.Windows.Forms.TabPage tabReport;
        private System.Windows.Forms.TabPage tabExpenseStatistics;
        private System.Windows.Forms.TabPage tabSettings;
    }
}

