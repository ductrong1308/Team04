using ExpenseLoggerApp.Forms;
using ExpenseLoggerApp.Forms.UserControls;
using ExpenseLoggerApp.Helpers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ExpenseLoggerApp
{
    public partial class ExpenseLoggerAppForm : ExpenseLoggerFormBase
    {
        public ExpenseLoggerAppForm()
        {
            InitializeComponent();

            // Showing a label with user's firstName when they logged in.
            labelUserName.Text = "Hi, " + UserIdentity.Instance.FirstName;

            // Load Home User Control
            HomeUserControl homeUserControl = new HomeUserControl();
            SwitchView(homeUserControl, buttonHome);

            // Register events.
            buttonHome.Click += ButtonHome_Click;
            buttonReport.Click += ButtonReport_Click;
            buttonStatistics.Click += ButtonStatistics_Click;
            buttonSettings.Click += ButtonSettings_Click;
            linkLabelSignOut.Click += LinkLabelSignOut_Click;
        }

        /// <summary>
        /// This function will help users to log out the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinkLabelSignOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            ExpenseLoggerSignInForm signInForm = new ExpenseLoggerSignInForm();
            signInForm.ShowDialog();
            this.Close();
        }

        /// <summary>
        /// Switch to the screen settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSettings_Click(object sender, EventArgs e)
        {
            SettingsUserControl statisticsUserControl = new SettingsUserControl();
            SwitchView(statisticsUserControl, ((Button)sender));
        }

        /// <summary>
        /// Switch to the screen statistics.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonStatistics_Click(object sender, EventArgs e)
        {
            StatisticsUserControl statisticsUserControl = new StatisticsUserControl();
            SwitchView(statisticsUserControl, ((Button)sender));
        }

        /// <summary>
        /// Swich to the screen Report.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonReport_Click(object sender, EventArgs e)
        {
            ReportUserControl reportUserControl = new ReportUserControl();
            SwitchView(reportUserControl, ((Button)sender));
        }

        /// <summary>
        /// Switch to the home screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonHome_Click(object sender, EventArgs e)
        {
            HomeUserControl homeUserControl = new HomeUserControl();
            SwitchView(homeUserControl, ((Button)sender));
        }

        /// <summary>
        /// Highlight which screen is in active.
        /// </summary>
        /// <param name="clickedButton"></param>
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

        /// <summary>
        /// Switch from a view to another view when user chose another screen in the footer menu bar.
        /// </summary>
        /// <param name="newView"></param>
        /// <param name="clickedButton"></param>
        private void SwitchView(BaseUserControl newView, Button clickedButton)
        {
            if (panelMainContent.Controls.Count > 0)
            {
                // Remove the current view.
                BaseUserControl oldView = panelMainContent.Controls[0] as BaseUserControl;
                panelMainContent.Controls.Remove(oldView);
                oldView.Dispose();
            }

            // Add the view to the main panel.
            panelMainContent.Controls.Add(newView);

            // Setting the view with dock style.
            newView.Dock = DockStyle.Fill;
            SetColor(clickedButton);
        }
    }
}
