using ExpenseLoggerApp.Helpers;
using ExpenseLoggerApp.Resources;
using ExpenseLoggerBLL.Commands;
using ExpenseLoggerBLL.Queries;
using ExpenseLoggerDAL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace ExpenseLoggerApp.Forms
{
    public partial class ExpenseLoggerSignInForm : ExpenseLoggerFormBase
    {
        public ExpenseLoggerSignInForm()
        {
            InitializeComponent();
            this.RegisterAppEvents();
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
                if (!ValidationHelper.IsValidEmail(email))
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
                && password.Equals(confirmPassword) && ValidationHelper.IsValidEmail(email);

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
                    if (!ValidationHelper.IsValidEmail(email))
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


            List<Setting> userSettings = appQueries.GetUserSettings(loggedInUser.Id);
            Setting currencySetting = userSettings.FirstOrDefault(x => x.Name.Trim().ToLower() == "currency");
            string currency = currencySetting == null ? "$" : currencySetting.Value;

            LoginInfo.Currency = currency;
            LoginInfo.UserPreferenceCulture = CultureHelpers.UserPreferenceCulture(currency);

            // Close the current form and open the main form after logged in
            this.Hide();
            ExpenseLoggerAppForm expenseLoggerAppForm = new ExpenseLoggerAppForm();
            expenseLoggerAppForm.ShowDialog();
            this.Close();
        }
    }
}