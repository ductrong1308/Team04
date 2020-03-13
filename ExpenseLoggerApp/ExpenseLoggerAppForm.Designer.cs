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
            this.buttonHome.Location = new System.Drawing.Point(28, 25);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(306, 69);
            this.buttonHome.TabIndex = 0;
            this.buttonHome.Text = "Home";
            this.buttonHome.UseVisualStyleBackColor = true;
            // 
            // buttonReport
            // 
            this.buttonReport.Location = new System.Drawing.Point(370, 25);
            this.buttonReport.Name = "buttonReport";
            this.buttonReport.Size = new System.Drawing.Size(287, 69);
            this.buttonReport.TabIndex = 1;
            this.buttonReport.Text = "Report";
            this.buttonReport.UseVisualStyleBackColor = true;
            // 
            // buttonStatistics
            // 
            this.buttonStatistics.Location = new System.Drawing.Point(689, 25);
            this.buttonStatistics.Name = "buttonStatistics";
            this.buttonStatistics.Size = new System.Drawing.Size(288, 69);
            this.buttonStatistics.TabIndex = 2;
            this.buttonStatistics.Text = "Statistics";
            this.buttonStatistics.UseVisualStyleBackColor = true;
            // 
            // buttonSettings
            // 
            this.buttonSettings.Location = new System.Drawing.Point(1032, 25);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(300, 69);
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
            this.panelFooterMenu.Location = new System.Drawing.Point(0, 802);
            this.panelFooterMenu.Name = "panelFooterMenu";
            this.panelFooterMenu.Size = new System.Drawing.Size(1385, 116);
            this.panelFooterMenu.TabIndex = 4;
            // 
            // panelTopMenuBar
            // 
            this.panelTopMenuBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopMenuBar.Location = new System.Drawing.Point(0, 0);
            this.panelTopMenuBar.Name = "panelTopMenuBar";
            this.panelTopMenuBar.Size = new System.Drawing.Size(1385, 57);
            this.panelTopMenuBar.TabIndex = 5;
            // 
            // panelMainContent
            // 
            this.panelMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainContent.Location = new System.Drawing.Point(0, 57);
            this.panelMainContent.Name = "panelMainContent";
            this.panelMainContent.Size = new System.Drawing.Size(1385, 745);
            this.panelMainContent.TabIndex = 6;
            // 
            // ExpenseLoggerAppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1385, 918);
            this.Controls.Add(this.panelMainContent);
            this.Controls.Add(this.panelTopMenuBar);
            this.Controls.Add(this.panelFooterMenu);
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

