using ExpenseLoggerApp.Helpers;
using ExpenseLoggerApp.Resources;
using ExpenseLoggerBLL.Commands;
using ExpenseLoggerBLL.Queries;
using ExpenseLoggerDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseLoggerApp.Forms
{
    public partial class ExpenseLoggerSignInForm : Form
    {
        private ExpenseLoggerQueries appQueries;
        private ExpenseLoggerCommands appCommands;
        private ErrorProvider errorProvider;

        public ExpenseLoggerSignInForm()
        {
            InitializeComponent();

            appQueries = new ExpenseLoggerQueries();
            appCommands = new ExpenseLoggerCommands();
            errorProvider = new ErrorProvider();

            this.DoCustomAppSettings();
            this.RegisterAppEvents();
        }

        private void DoCustomAppSettings()
        {
            errorProvider.Clear();
            this.CenterToScreen();
            this.Text = AppResource.AppName;
        }

        private void RegisterAppEvents()
        {
            buttonSignIn.Click += ButtonSignIn_Click;
            buttonSignUp.Click += ButtonSignUp_Click;
        }

        private void ButtonSignIn_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();

            string email = textBoxEmail.Text;
            string password = textBoxPassword.Text;

            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                string encryptedPassword = PasswordHelper.Encrypt(password);
                User loggedInUser = appQueries.GetUserByEmailAndPassword(email, encryptedPassword);

                if (loggedInUser == null)
                {
                    MessageBox.Show(AppResource.InvalidLoginInfo);
                }
                else
                {
                    this.OpenExpenseLoggerAppForm(loggedInUser);
                }
            }
            else
            {
                this.ValidateSignInForm(email, password);
            }
        }

        private void ButtonSignUp_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            string firstName = textBoxFirstName.Text.Trim();
            string lastName = textBoxLastName.Text.Trim();
            string email = textBoxSignUpEmail.Text.Trim();
            string password = textBoxSignUpPassword.Text;
            string confirmPassword = textBoxSignUpConfirmPassword.Text;

            bool isFormDataValid = ValidateSignUpInformation(firstName, lastName, email, password, confirmPassword);
            if (isFormDataValid)
            {
                User newUser = new User()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    EmailAddress = email,
                    Password = PasswordHelper.Encrypt(password),
                    Gender = radioButtonMale.Checked
                };

                bool isNewUserAdded = appCommands.AddNewUser(newUser);

                if (isNewUserAdded)
                {
                    this.OpenExpenseLoggerAppForm(newUser);
                }
                else
                {
                    MessageBox.Show(AppResource.ErrorHasOccurred);
                }
            }
        }

        private void ValidateSignInForm(string email, string password)
        {
            if (string.IsNullOrEmpty(email))
            {
                errorProvider.SetError(textBoxEmail, AppResource.EmailIsRequired);
            }
            else
            {
                if (!EmailHelper.IsValidEmail(email))
                {
                    errorProvider.SetError(textBoxEmail, AppResource.InvalidEmailFormat);
                }
            }

            if (string.IsNullOrEmpty(password))
            {
                errorProvider.SetError(textBoxPassword, AppResource.PasswordIsRequired);
            }
        }

        private bool ValidateSignUpInformation(string firstName, string lastName, string email, string password, string confirmPassword)
        {
            bool isFormInfoValid =
                !string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName)
                && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(confirmPassword)
                && password.Equals(confirmPassword) && EmailHelper.IsValidEmail(email);

            if (!isFormInfoValid)
            {
                if (string.IsNullOrEmpty(firstName))
                {
                    errorProvider.SetError(textBoxFirstName, AppResource.FirstNameIsRequired);
                }

                if (string.IsNullOrEmpty(lastName))
                {
                    errorProvider.SetError(textBoxLastName, AppResource.LastName);
                }

                if (string.IsNullOrEmpty(email))
                {
                    errorProvider.SetError(textBoxSignUpEmail, AppResource.EmailIsRequired);
                }
                else
                {
                    if (!EmailHelper.IsValidEmail(email))
                    {
                        errorProvider.SetError(textBoxSignUpEmail, AppResource.InvalidEmailFormat);
                    }
                }

                if (string.IsNullOrEmpty(password))
                {
                    errorProvider.SetError(textBoxSignUpPassword, AppResource.PasswordIsRequired);
                }

                if (string.IsNullOrEmpty(password))
                {
                    errorProvider.SetError(textBoxSignUpConfirmPassword, AppResource.ConfirmPasswordIsRequired);
                }

                if (!password.Equals(confirmPassword))
                {
                    MessageBox.Show(AppResource.PasswordNotMatch);
                }
            }

            return isFormInfoValid;
        }

        private void OpenExpenseLoggerAppForm(User loggedInUser)
        {
            // Storing user information for later use.
            LoginInfo.UserId = loggedInUser.Id;
            LoginInfo.UserFirstName = loggedInUser.FirstName;
            LoginInfo.UserLastName = loggedInUser.LastName;

            // Close the current form and open the main form after logged in
            this.Hide();
            ExpenseLoggerAppForm expenseLoggerAppForm = new ExpenseLoggerAppForm();
            expenseLoggerAppForm.ShowDialog();
            this.Close();
        }
    }
}