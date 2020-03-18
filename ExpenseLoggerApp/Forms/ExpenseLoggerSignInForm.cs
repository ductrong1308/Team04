using ExpenseLoggerApp.Helpers;
using ExpenseLoggerApp.Resources;
using ExpenseLoggerDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ExpenseLoggerApp.Forms
{
    public partial class ExpenseLoggerSignInForm : ExpenseLoggerFormBase
    {
        public ExpenseLoggerSignInForm()
        {
            InitializeComponent();

            // Register events.
            buttonSignIn.Click += ButtonSignIn_Click;
            buttonSignUp.Click += ButtonSignUp_Click;
            textBoxPassword.KeyDown += EnterSignIn;
            textBoxEmail.KeyDown += EnterSignIn;
        }

        /// <summary>
        /// After filling email and password, users can hit enter key to log in.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnterSignIn(object sender, KeyEventArgs e)
        {
            // Detect if user has hit the enter key.
            if (e.KeyCode == Keys.Enter)
            {
                // Do signin.
                this.SignIn();
            }
        }

        /// <summary>
        /// Help users to sign in the application when they clicked on SignIn button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSignIn_Click(object sender, EventArgs e)
        {
            this.SignIn();
        }

        /// <summary>
        /// Help users to sign up an account in the system.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSignUp_Click(object sender, EventArgs e)
        {
            // Using error provider, a build-in provider of C#.
            errorProvider.Clear();
            string firstName = textBoxFirstName.Text.Trim();
            string lastName = textBoxLastName.Text.Trim();
            string email = textBoxSignUpEmail.Text.Trim();
            string password = textBoxSignUpPassword.Text;
            string confirmPassword = textBoxSignUpConfirmPassword.Text;

            // Validate user inputted data.
            bool isFormDataValid = ValidateSignUpInformation(firstName, lastName, email, password, confirmPassword);
            if (isFormDataValid)
            {
                // Create a new user.
                User newUser = new User()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    EmailAddress = email,
                    Password = PasswordHelper.Encrypt(password),
                    Gender = radioButtonMale.Checked,
                    Categories = AppDefaultValues.ExpenseCategories,
                    Settings = new List<Setting>()
                    {
                        new Setting()
                        {
                            Name = "Currency",
                            Value = AppDefaultValues.Currencies.FirstOrDefault().Value.ToString()
                        }
                    }
                };

                bool isNewUserAdded = appCommands.AddNewUser(newUser);

                // Showing message when new user was added successfully.
                if (isNewUserAdded)
                {
                    MessageBox.Show(AppResource.RegistrationSuccessful);
                    tabControlSignInSignUp.SelectedTab = tabSignIn;
                }
                else
                {
                    // Error to indicate the new registration has been failed.
                    MessageBox.Show(AppResource.ErrorHasOccurred);
                }
            }
        }

        /// <summary>
        /// SignIn to the system.
        /// </summary>
        private void SignIn()
        {
            // Clear all the previous error.
            errorProvider.Clear();

            string email = textBoxEmail.Text;
            string password = textBoxPassword.Text;

            try
            {
                // Disable SignIn button while in log in process.
                buttonSignIn.Enabled = false;

                // Check user email and password.
                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
                {
                    // Encrypt password before getting user info and compare the email and password..
                    string encryptedPassword = PasswordHelper.Encrypt(password);
                    User loggedInUser = appQueries.GetUserByEmailAndPassword(email, encryptedPassword);

                    if (loggedInUser == null)
                    {
                        // User logged in fail.
                        MessageBox.Show(AppResource.InvalidLoginInfo);
                    }
                    else
                    {
                        // User logged in.
                        this.OpenExpenseLoggerAppForm(loggedInUser);
                    }
                }
                else
                {
                    // Display error sign when user missed entering data to the login form.
                    this.ValidateSignInForm(email, password);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Re-activate signin button in any cases.
                buttonSignIn.Enabled = true;
            }

        }

        /// <summary>
        /// Validate SignIn form data.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        private void ValidateSignInForm(string email, string password)
        {
            // Checking email.
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

            // Checking password.
            if (string.IsNullOrEmpty(password))
            {
                errorProvider.SetError(textBoxPassword, AppResource.PasswordIsRequired);
            }
        }

        /// <summary>
        /// Validate information in the signup form.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="confirmPassword"></param>
        /// <returns></returns>
        private bool ValidateSignUpInformation(string firstName, string lastName, string email, string password, string confirmPassword)
        {
            // Check if all the data is valid
            bool isFormInfoValid =
                !string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName)
                && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(confirmPassword)
                && password.Equals(confirmPassword) && ValidationHelper.IsValidEmail(email);

            // If the data is invalid
            // This condition will check every field and showing error sign corresponding to the control.
            if (!isFormInfoValid)
            {
                // Validate FirstName
                if (string.IsNullOrEmpty(firstName))
                {
                    errorProvider.SetError(textBoxFirstName, AppResource.FirstNameIsRequired);
                }

                // Validate LastName
                if (string.IsNullOrEmpty(lastName))
                {
                    errorProvider.SetError(textBoxLastName, AppResource.LastName);
                }

                // Validate Email.
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

                // Validate Password
                if (string.IsNullOrEmpty(password))
                {
                    errorProvider.SetError(textBoxSignUpPassword, AppResource.PasswordIsRequired);
                }

                if (string.IsNullOrEmpty(password))
                {
                    errorProvider.SetError(textBoxSignUpConfirmPassword, AppResource.ConfirmPasswordIsRequired);
                }

                // Check if password and confirm password are the same.
                if (!password.Equals(confirmPassword))
                {
                    MessageBox.Show(AppResource.PasswordNotMatch);
                }
            }

            return isFormInfoValid;
        }

        /// <summary>
        /// Storing user infomation in the shared class and display main form.
        /// </summary>
        /// <param name="loggedInUser"></param>
        private void OpenExpenseLoggerAppForm(User loggedInUser)
        {
            // Storing user information for later use.
            UserIdentity.Instance.UserId = loggedInUser.Id;
            UserIdentity.Instance.FirstName = loggedInUser.FirstName;
            UserIdentity.Instance.LastName = loggedInUser.LastName;

            List<Setting> userSettings = appQueries.GetUserSettings(loggedInUser.Id);
            Setting currencySetting = userSettings.FirstOrDefault(x => x.Name.Trim().ToLower() == "currency");
            string currency = currencySetting == null
                ? AppDefaultValues.Currencies.FirstOrDefault().Text : currencySetting.Value;

            UserIdentity.Instance.Currency = currency;
            UserIdentity.Instance.UserPreferenceCulture = CultureHelper.UserPreferenceCulture(currency);

            // Close the current form and open the main form after logged in
            this.Hide();
            ExpenseLoggerAppForm expenseLoggerAppForm = new ExpenseLoggerAppForm();
            expenseLoggerAppForm.ShowDialog();
            this.Close();
        }
    }
}