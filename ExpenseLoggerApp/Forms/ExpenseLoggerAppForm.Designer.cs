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
            this.buttonHome = new System.Windows.Forms.Button();
            this.buttonReport = new System.Windows.Forms.Button();
            this.buttonStatistics = new System.Windows.Forms.Button();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.panelFooterMenu = new System.Windows.Forms.Panel();
            this.panelTopMenuBar = new System.Windows.Forms.Panel();
            this.panelMainContent = new System.Windows.Forms.Panel();
            this.panelFooterMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonHome
            // 
            this.buttonHome.Location = new System.Drawing.Point(102, 14);
            this.buttonHome.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(167, 37);
            this.buttonHome.TabIndex = 0;
            this.buttonHome.Text = "Home";
            this.buttonHome.UseVisualStyleBackColor = true;
            // 
            // buttonReport
            // 
            this.buttonReport.Location = new System.Drawing.Point(291, 14);
            this.buttonReport.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonReport.Name = "buttonReport";
            this.buttonReport.Size = new System.Drawing.Size(157, 37);
            this.buttonReport.TabIndex = 1;
            this.buttonReport.Text = "Report";
            this.buttonReport.UseVisualStyleBackColor = true;
            // 
            // buttonStatistics
            // 
            this.buttonStatistics.Location = new System.Drawing.Point(470, 14);
            this.buttonStatistics.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonStatistics.Name = "buttonStatistics";
            this.buttonStatistics.Size = new System.Drawing.Size(157, 37);
            this.buttonStatistics.TabIndex = 2;
            this.buttonStatistics.Text = "Statistics";
            this.buttonStatistics.UseVisualStyleBackColor = true;
            // 
            // buttonSettings
            // 
            this.buttonSettings.Location = new System.Drawing.Point(649, 14);
            this.buttonSettings.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(164, 37);
            this.buttonSettings.TabIndex = 3;
            this.buttonSettings.Text = "Settings";
            this.buttonSettings.UseVisualStyleBackColor = true;
            // 
            // panelFooterMenu
            // 
            this.panelFooterMenu.Controls.Add(this.buttonHome);
            this.panelFooterMenu.Controls.Add(this.buttonSettings);
            this.panelFooterMenu.Controls.Add(this.buttonReport);
            this.panelFooterMenu.Controls.Add(this.buttonStatistics);
            this.panelFooterMenu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooterMenu.Location = new System.Drawing.Point(0, 510);
            this.panelFooterMenu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelFooterMenu.Name = "panelFooterMenu";
            this.panelFooterMenu.Size = new System.Drawing.Size(937, 63);
            this.panelFooterMenu.TabIndex = 4;
            // 
            // panelTopMenuBar
            // 
            this.panelTopMenuBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopMenuBar.Location = new System.Drawing.Point(0, 0);
            this.panelTopMenuBar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelTopMenuBar.Name = "panelTopMenuBar";
            this.panelTopMenuBar.Size = new System.Drawing.Size(937, 22);
            this.panelTopMenuBar.TabIndex = 5;
            // 
            // panelMainContent
            // 
            this.panelMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainContent.Location = new System.Drawing.Point(0, 22);
            this.panelMainContent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelMainContent.Name = "panelMainContent";
            this.panelMainContent.Size = new System.Drawing.Size(937, 488);
            this.panelMainContent.TabIndex = 6;
            // 
            // ExpenseLoggerAppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 573);
            this.Controls.Add(this.panelMainContent);
            this.Controls.Add(this.panelTopMenuBar);
            this.Controls.Add(this.panelFooterMenu);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ExpenseLoggerAppForm";
            this.Text = "Form1";
            this.panelFooterMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Button buttonReport;
        private System.Windows.Forms.Button buttonStatistics;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Panel panelFooterMenu;
        private System.Windows.Forms.Panel panelTopMenuBar;
        private System.Windows.Forms.Panel panelMainContent;
    }
}

