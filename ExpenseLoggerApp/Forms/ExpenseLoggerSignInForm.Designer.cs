namespace ExpenseLoggerApp.Forms
{
    partial class ExpenseLoggerSignInForm
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
            this.tabControlSignInSignUp = new System.Windows.Forms.TabControl();
            this.tabSignIn = new System.Windows.Forms.TabPage();
            this.buttonSignIn = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.tabSignUp = new System.Windows.Forms.TabPage();
            this.buttonSignUp = new System.Windows.Forms.Button();
            this.textBoxSignUpConfirmPassword = new System.Windows.Forms.TextBox();
            this.textBoxSignUpPassword = new System.Windows.Forms.TextBox();
            this.radioButtonFemale = new System.Windows.Forms.RadioButton();
            this.radioButtonMale = new System.Windows.Forms.RadioButton();
            this.textBoxSignUpEmail = new System.Windows.Forms.TextBox();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.labelSignUpConfirmPassword = new System.Windows.Forms.Label();
            this.labelSignUpPassword = new System.Windows.Forms.Label();
            this.labelGender = new System.Windows.Forms.Label();
            this.labelSignUpEmail = new System.Windows.Forms.Label();
            this.labelLastName = new System.Windows.Forms.Label();
            this.labelFirstName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.tabControlSignInSignUp.SuspendLayout();
            this.tabSignIn.SuspendLayout();
            this.tabSignUp.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlSignInSignUp
            // 
            this.tabControlSignInSignUp.Controls.Add(this.tabSignIn);
            this.tabControlSignInSignUp.Controls.Add(this.tabSignUp);
            this.tabControlSignInSignUp.Location = new System.Drawing.Point(3, 1);
            this.tabControlSignInSignUp.Margin = new System.Windows.Forms.Padding(2);
            this.tabControlSignInSignUp.Name = "tabControlSignInSignUp";
            this.tabControlSignInSignUp.SelectedIndex = 0;
            this.tabControlSignInSignUp.Size = new System.Drawing.Size(554, 277);
            this.tabControlSignInSignUp.TabIndex = 0;
            // 
            // tabSignIn
            // 
            this.tabSignIn.Controls.Add(this.buttonSignIn);
            this.tabSignIn.Controls.Add(this.textBoxPassword);
            this.tabSignIn.Controls.Add(this.textBoxEmail);
            this.tabSignIn.Controls.Add(this.labelPassword);
            this.tabSignIn.Controls.Add(this.labelEmail);
            this.tabSignIn.Location = new System.Drawing.Point(4, 22);
            this.tabSignIn.Margin = new System.Windows.Forms.Padding(2);
            this.tabSignIn.Name = "tabSignIn";
            this.tabSignIn.Padding = new System.Windows.Forms.Padding(2);
            this.tabSignIn.Size = new System.Drawing.Size(546, 251);
            this.tabSignIn.TabIndex = 0;
            this.tabSignIn.Text = "Sign In";
            this.tabSignIn.UseVisualStyleBackColor = true;
            // 
            // buttonSignIn
            // 
            this.buttonSignIn.Location = new System.Drawing.Point(222, 173);
            this.buttonSignIn.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSignIn.Name = "buttonSignIn";
            this.buttonSignIn.Size = new System.Drawing.Size(144, 22);
            this.buttonSignIn.TabIndex = 4;
            this.buttonSignIn.Text = "Sign In";
            this.buttonSignIn.UseVisualStyleBackColor = true;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(222, 117);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(144, 20);
            this.textBoxPassword.TabIndex = 3;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(222, 69);
            this.textBoxEmail.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxEmail.Multiline = true;
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(144, 19);
            this.textBoxEmail.TabIndex = 2;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(99, 117);
            this.labelPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(53, 13);
            this.labelPassword.TabIndex = 1;
            this.labelPassword.Text = "Password";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(99, 72);
            this.labelEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(32, 13);
            this.labelEmail.TabIndex = 0;
            this.labelEmail.Text = "Email";
            // 
            // tabSignUp
            // 
            this.tabSignUp.Controls.Add(this.buttonSignUp);
            this.tabSignUp.Controls.Add(this.textBoxSignUpConfirmPassword);
            this.tabSignUp.Controls.Add(this.textBoxSignUpPassword);
            this.tabSignUp.Controls.Add(this.radioButtonFemale);
            this.tabSignUp.Controls.Add(this.radioButtonMale);
            this.tabSignUp.Controls.Add(this.textBoxSignUpEmail);
            this.tabSignUp.Controls.Add(this.textBoxLastName);
            this.tabSignUp.Controls.Add(this.textBoxFirstName);
            this.tabSignUp.Controls.Add(this.labelSignUpConfirmPassword);
            this.tabSignUp.Controls.Add(this.labelSignUpPassword);
            this.tabSignUp.Controls.Add(this.labelGender);
            this.tabSignUp.Controls.Add(this.labelSignUpEmail);
            this.tabSignUp.Controls.Add(this.labelLastName);
            this.tabSignUp.Controls.Add(this.labelFirstName);
            this.tabSignUp.Location = new System.Drawing.Point(4, 22);
            this.tabSignUp.Margin = new System.Windows.Forms.Padding(2);
            this.tabSignUp.Name = "tabSignUp";
            this.tabSignUp.Padding = new System.Windows.Forms.Padding(2);
            this.tabSignUp.Size = new System.Drawing.Size(546, 251);
            this.tabSignUp.TabIndex = 1;
            this.tabSignUp.Text = "Sign Up";
            this.tabSignUp.UseVisualStyleBackColor = true;
            // 
            // buttonSignUp
            // 
            this.buttonSignUp.Location = new System.Drawing.Point(242, 189);
            this.buttonSignUp.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSignUp.Name = "buttonSignUp";
            this.buttonSignUp.Size = new System.Drawing.Size(133, 22);
            this.buttonSignUp.TabIndex = 13;
            this.buttonSignUp.Text = "Sign Up";
            this.buttonSignUp.UseVisualStyleBackColor = true;
            // 
            // textBoxSignUpConfirmPassword
            // 
            this.textBoxSignUpConfirmPassword.Location = new System.Drawing.Point(369, 133);
            this.textBoxSignUpConfirmPassword.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSignUpConfirmPassword.Name = "textBoxSignUpConfirmPassword";
            this.textBoxSignUpConfirmPassword.Size = new System.Drawing.Size(153, 20);
            this.textBoxSignUpConfirmPassword.TabIndex = 12;
            this.textBoxSignUpConfirmPassword.UseSystemPasswordChar = true;
            // 
            // textBoxSignUpPassword
            // 
            this.textBoxSignUpPassword.Location = new System.Drawing.Point(91, 136);
            this.textBoxSignUpPassword.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSignUpPassword.Name = "textBoxSignUpPassword";
            this.textBoxSignUpPassword.Size = new System.Drawing.Size(153, 20);
            this.textBoxSignUpPassword.TabIndex = 11;
            this.textBoxSignUpPassword.UseSystemPasswordChar = true;
            // 
            // radioButtonFemale
            // 
            this.radioButtonFemale.AutoSize = true;
            this.radioButtonFemale.Location = new System.Drawing.Point(463, 85);
            this.radioButtonFemale.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonFemale.Name = "radioButtonFemale";
            this.radioButtonFemale.Size = new System.Drawing.Size(59, 17);
            this.radioButtonFemale.TabIndex = 10;
            this.radioButtonFemale.TabStop = true;
            this.radioButtonFemale.Text = "Female";
            this.radioButtonFemale.UseVisualStyleBackColor = true;
            // 
            // radioButtonMale
            // 
            this.radioButtonMale.AutoSize = true;
            this.radioButtonMale.Checked = true;
            this.radioButtonMale.Location = new System.Drawing.Point(369, 87);
            this.radioButtonMale.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonMale.Name = "radioButtonMale";
            this.radioButtonMale.Size = new System.Drawing.Size(48, 17);
            this.radioButtonMale.TabIndex = 9;
            this.radioButtonMale.TabStop = true;
            this.radioButtonMale.Text = "Male";
            this.radioButtonMale.UseVisualStyleBackColor = true;
            // 
            // textBoxSignUpEmail
            // 
            this.textBoxSignUpEmail.Location = new System.Drawing.Point(91, 85);
            this.textBoxSignUpEmail.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSignUpEmail.Multiline = true;
            this.textBoxSignUpEmail.Name = "textBoxSignUpEmail";
            this.textBoxSignUpEmail.Size = new System.Drawing.Size(153, 19);
            this.textBoxSignUpEmail.TabIndex = 8;
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(369, 35);
            this.textBoxLastName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxLastName.Multiline = true;
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(153, 19);
            this.textBoxLastName.TabIndex = 7;
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Location = new System.Drawing.Point(91, 34);
            this.textBoxFirstName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxFirstName.Multiline = true;
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(153, 19);
            this.textBoxFirstName.TabIndex = 6;
            // 
            // labelSignUpConfirmPassword
            // 
            this.labelSignUpConfirmPassword.AutoSize = true;
            this.labelSignUpConfirmPassword.Location = new System.Drawing.Point(271, 135);
            this.labelSignUpConfirmPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSignUpConfirmPassword.Name = "labelSignUpConfirmPassword";
            this.labelSignUpConfirmPassword.Size = new System.Drawing.Size(91, 13);
            this.labelSignUpConfirmPassword.TabIndex = 5;
            this.labelSignUpConfirmPassword.Text = "Confirm Password";
            // 
            // labelSignUpPassword
            // 
            this.labelSignUpPassword.AutoSize = true;
            this.labelSignUpPassword.Location = new System.Drawing.Point(32, 136);
            this.labelSignUpPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSignUpPassword.Name = "labelSignUpPassword";
            this.labelSignUpPassword.Size = new System.Drawing.Size(53, 13);
            this.labelSignUpPassword.TabIndex = 4;
            this.labelSignUpPassword.Text = "Password";
            // 
            // labelGender
            // 
            this.labelGender.AutoSize = true;
            this.labelGender.Location = new System.Drawing.Point(268, 87);
            this.labelGender.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(42, 13);
            this.labelGender.TabIndex = 3;
            this.labelGender.Text = "Gender";
            // 
            // labelSignUpEmail
            // 
            this.labelSignUpEmail.AutoSize = true;
            this.labelSignUpEmail.Location = new System.Drawing.Point(29, 87);
            this.labelSignUpEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSignUpEmail.Name = "labelSignUpEmail";
            this.labelSignUpEmail.Size = new System.Drawing.Size(32, 13);
            this.labelSignUpEmail.TabIndex = 2;
            this.labelSignUpEmail.Text = "Email";
            // 
            // labelLastName
            // 
            this.labelLastName.AutoSize = true;
            this.labelLastName.Location = new System.Drawing.Point(268, 37);
            this.labelLastName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(58, 13);
            this.labelLastName.TabIndex = 1;
            this.labelLastName.Text = "Last Name";
            // 
            // labelFirstName
            // 
            this.labelFirstName.AutoSize = true;
            this.labelFirstName.Location = new System.Drawing.Point(29, 37);
            this.labelFirstName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new System.Drawing.Size(57, 13);
            this.labelFirstName.TabIndex = 0;
            this.labelFirstName.Text = "First Name";
            // 
            // ExpenseLoggerSignInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 278);
            this.Controls.Add(this.tabControlSignInSignUp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExpenseLoggerSignInForm";
            this.Text = "ExpenseLoggerSignInForm";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.tabControlSignInSignUp.ResumeLayout(false);
            this.tabSignIn.ResumeLayout(false);
            this.tabSignIn.PerformLayout();
            this.tabSignUp.ResumeLayout(false);
            this.tabSignUp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlSignInSignUp;
        private System.Windows.Forms.TabPage tabSignIn;
        private System.Windows.Forms.TabPage tabSignUp;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Button buttonSignIn;
        private System.Windows.Forms.Button buttonSignUp;
        private System.Windows.Forms.TextBox textBoxSignUpConfirmPassword;
        private System.Windows.Forms.TextBox textBoxSignUpPassword;
        private System.Windows.Forms.RadioButton radioButtonFemale;
        private System.Windows.Forms.RadioButton radioButtonMale;
        private System.Windows.Forms.TextBox textBoxSignUpEmail;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.Label labelSignUpConfirmPassword;
        private System.Windows.Forms.Label labelSignUpPassword;
        private System.Windows.Forms.Label labelGender;
        private System.Windows.Forms.Label labelSignUpEmail;
        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.Label labelFirstName;
    }
}