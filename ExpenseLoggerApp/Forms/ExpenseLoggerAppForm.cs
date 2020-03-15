using ExpenseLoggerApp.Forms;
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
    public partial class ExpenseLoggerAppForm : ExpenseLoggerFormBase
    {
        public ExpenseLoggerAppForm()
        {
            InitializeComponent();
            this.appQueries = new ExpenseLoggerQueries();
            this.appCommands = new ExpenseLoggerCommands();

            buttonHome.Click += ButtonHome_Click;
            buttonReport.Click += ButtonReport_Click;
            buttonStatistics.Click += ButtonStatistics_Click;
            buttonSettings.Click += ButtonSettings_Click;

            // Load Home User Control
            HomeUserControl homeUserControl = new HomeUserControl();
            SwitchView(homeUserControl, buttonHome);
        }

        private void ButtonSettings_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ButtonStatistics_Click(object sender, EventArgs e)
        {
            StatisticsUserControl statisticsUserControl = new StatisticsUserControl();
            SwitchView(statisticsUserControl, ((Button)sender));
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

        private void SwitchView(BaseUserControl newView, Button clickedButton)
        {
            if (panelMainContent.Controls.Count > 0)
            {
                BaseUserControl oldView = panelMainContent.Controls[0] as BaseUserControl;
                panelMainContent.Controls.Remove(oldView);
                oldView.Dispose();
            }

            panelMainContent.Controls.Add(newView);

            newView.Dock = DockStyle.Fill;
            SetColor(clickedButton);
        }

    }
}
