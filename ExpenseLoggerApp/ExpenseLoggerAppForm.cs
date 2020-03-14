using ExpenseLoggerApp.Forms.UserControls;
using ExpenseLoggerApp.Helpers;
using ExpenseLoggerApp.Resources;
using ExpenseLoggerBLL.Commands;
using ExpenseLoggerBLL.Queries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseLoggerApp
{
    public partial class ExpenseLoggerAppForm : Form
    {
        private ExpenseLoggerQueries appQueries;
        private ExpenseLoggerCommands appCommands;

        public ExpenseLoggerAppForm()
        {
            InitializeComponent();
            this.appQueries = new ExpenseLoggerQueries();
            this.appCommands = new ExpenseLoggerCommands();

            DoFormCustomSettings();

            buttonHome.Click += ButtonHome_Click;
            buttonReport.Click += ButtonReport_Click;

            // Load Home User Control
            HomeUserControl homeUserControl = new HomeUserControl();
            SwitchView(homeUserControl, buttonHome);
        }

        private void ButtonReport_Click(object sender, EventArgs e)
        {
            ReportUserControl reportUserControl = new ReportUserControl();
            SwitchView(reportUserControl, ((Button)sender));
        }

        private void ButtonHome_Click(object sender, EventArgs e)
        {
            HomeUserControl homeUserControl = new HomeUserControl();
            SwitchView(homeUserControl, ((Button)sender));
        }

        private void SetColor(Button clickedButton)
        {
            for (int i = 0; i < panelFooterMenu.Controls.Count; i++)
            {
                Button button = panelFooterMenu.Controls[i] as Button;
                button.BackColor = Color.Transparent;
                button.ForeColor = Color.Black;
            }

            clickedButton.BackColor = Color.DarkGray;
            clickedButton.ForeColor = Color.White;
        }

        private void SwitchView(UserControl newView, Button clickedButton)
        {
            if (panelMainContent.Controls.Count > 0)
            {
                UserControl oldView = panelMainContent.Controls[0] as UserControl;
                panelMainContent.Controls.Remove(oldView);
                oldView.Dispose();
            }

            panelMainContent.Controls.Add(newView);
            newView.Dock = DockStyle.Fill;

            SetColor(clickedButton);
        }

        private void DoFormCustomSettings()
        {
            this.CenterToScreen();
            this.Text = AppResource.AppName;

            // Prevent users from changing form size
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }


    }
}
