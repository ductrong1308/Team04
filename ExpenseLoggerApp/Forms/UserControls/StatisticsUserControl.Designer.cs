namespace ExpenseLoggerApp.Forms.UserControls
{
    partial class StatisticsUserControl
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartExpenseStatistics = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelYear = new System.Windows.Forms.Label();
            this.comboBoxYears = new System.Windows.Forms.ComboBox();
            this.labelChartType = new System.Windows.Forms.Label();
            this.comboBoxChartType = new System.Windows.Forms.ComboBox();
            this.labelExpenseStatistics = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartExpenseStatistics)).BeginInit();
            this.SuspendLayout();
            // 
            // chartExpenseStatistics
            // 
            chartArea1.Name = "ChartArea1";
            this.chartExpenseStatistics.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartExpenseStatistics.Legends.Add(legend1);
            this.chartExpenseStatistics.Location = new System.Drawing.Point(33, 155);
            this.chartExpenseStatistics.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chartExpenseStatistics.Name = "chartExpenseStatistics";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Expenses";
            this.chartExpenseStatistics.Series.Add(series1);
            this.chartExpenseStatistics.Size = new System.Drawing.Size(1654, 716);
            this.chartExpenseStatistics.TabIndex = 0;
            // 
            // labelYear
            // 
            this.labelYear.AutoSize = true;
            this.labelYear.Location = new System.Drawing.Point(350, 96);
            this.labelYear.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new System.Drawing.Size(53, 25);
            this.labelYear.TabIndex = 3;
            this.labelYear.Text = "Year";
            // 
            // comboBoxYears
            // 
            this.comboBoxYears.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxYears.FormattingEnabled = true;
            this.comboBoxYears.Location = new System.Drawing.Point(409, 89);
            this.comboBoxYears.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxYears.Name = "comboBoxYears";
            this.comboBoxYears.Size = new System.Drawing.Size(156, 32);
            this.comboBoxYears.TabIndex = 4;
            // 
            // labelChartType
            // 
            this.labelChartType.AutoSize = true;
            this.labelChartType.Location = new System.Drawing.Point(33, 96);
            this.labelChartType.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelChartType.Name = "labelChartType";
            this.labelChartType.Size = new System.Drawing.Size(110, 25);
            this.labelChartType.TabIndex = 5;
            this.labelChartType.Text = "Chart Type";
            // 
            // comboBoxChartType
            // 
            this.comboBoxChartType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChartType.FormattingEnabled = true;
            this.comboBoxChartType.Location = new System.Drawing.Point(150, 90);
            this.comboBoxChartType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxChartType.Name = "comboBoxChartType";
            this.comboBoxChartType.Size = new System.Drawing.Size(156, 32);
            this.comboBoxChartType.TabIndex = 6;
            // 
            // labelExpenseStatistics
            // 
            this.labelExpenseStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExpenseStatistics.Location = new System.Drawing.Point(612, 0);
            this.labelExpenseStatistics.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelExpenseStatistics.Name = "labelExpenseStatistics";
            this.labelExpenseStatistics.Size = new System.Drawing.Size(537, 70);
            this.labelExpenseStatistics.TabIndex = 2;
            this.labelExpenseStatistics.Text = "Expenses Statistics";
            // 
            // StatisticsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBoxChartType);
            this.Controls.Add(this.labelChartType);
            this.Controls.Add(this.comboBoxYears);
            this.Controls.Add(this.labelYear);
            this.Controls.Add(this.labelExpenseStatistics);
            this.Controls.Add(this.chartExpenseStatistics);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "StatisticsUserControl";
            this.Size = new System.Drawing.Size(1718, 901);
            ((System.ComponentModel.ISupportInitialize)(this.chartExpenseStatistics)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartExpenseStatistics;
        private System.Windows.Forms.Label labelYear;
        private System.Windows.Forms.ComboBox comboBoxYears;
        private System.Windows.Forms.Label labelChartType;
        private System.Windows.Forms.ComboBox comboBoxChartType;
        private System.Windows.Forms.Label labelExpenseStatistics;
    }
}
