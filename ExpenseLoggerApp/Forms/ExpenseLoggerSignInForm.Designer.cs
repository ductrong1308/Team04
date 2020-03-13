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
            this.tabControl1 = new System.Windows.Forms.TabControl();
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
            this.tabControl1.SuspendLayout();
            this.tabSignIn.SuspendLayout();
            this.tabSignUp.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSignIn);
            this.tabControl1.Controls.Add(this.tabSignUp);
            this.tabControl1.Location = new System.Drawing.Point(5, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1016, 511);
            this.tabControl1.TabIndex = 0;
            // 
            // tabSignIn
            // 
            this.tabSignIn.Controls.Add(this.buttonSignIn);
            this.tabSignIn.Controls.Add(this.textBoxPassword);
            this.tabSignIn.Controls.Add(this.textBoxEmail);
            this.tabSignIn.Controls.Add(this.labelPassword);
            this.tabSignIn.Controls.Add(this.labelEmail);
            this.tabSignIn.Location = new System.Drawing.Point(4, 33);
            this.tabSignIn.Name = "tabSignIn";
            this.tabSignIn.Padding = new System.Windows.Forms.Padding(3);
            this.tabSignIn.Size = new System.Drawing.Size(1008, 474);
            this.tabSignIn.TabIndex = 0;
            this.tabSignIn.Text = "Sign In";
            this.tabSignIn.UseVisualStyleBackColor = true;
            // 
            // buttonSignIn
            // 
            this.buttonSignIn.Location = new System.Drawing.Point(407, 319);
            this.buttonSignIn.Name = "buttonSignIn";
            this.buttonSignIn.Size = new System.Drawing.Size(264, 40);
            this.buttonSignIn.TabIndex = 4;
            this.buttonSignIn.Text = "Sign In";
            this.buttonSignIn.UseVisualStyleBackColor = true;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(407, 216);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(260, 29);
            this.textBoxPassword.TabIndex = 3;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(407, 127);
            this.textBoxEmail.Multiline = true;
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(260, 32);
            this.textBoxEmail.TabIndex = 2;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(181, 216);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(98, 25);
            this.labelPassword.TabIndex = 1;
            this.labelPassword.Text = "Password";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(181, 132);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(60, 25);
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
            this.tabSignUp.Location = new System.Drawing.Point(4, 33);
            this.tabSignUp.Name = "tabSignUp";
            this.tabSignUp.Padding = new System.Windows.Forms.Padding(3);
            this.tabSignUp.Size = new System.Drawing.Size(1008, 474);
            this.tabSignUp.TabIndex = 1;
            this.tabSignUp.Text = "Sign Up";
            this.tabSignUp.UseVisualStyleBackColor = true;
            // 
            // buttonSignUp
            // 
            this.buttonSignUp.Location = new System.Drawing.Point(444, 349);
            this.buttonSignUp.Name = "buttonSignUp";
            this.buttonSignUp.Size = new System.Drawing.Size(243, 40);
            this.buttonSignUp.TabIndex = 13;
            this.buttonSignUp.Text = "Sign Up";
            this.buttonSignUp.UseVisualStyleBackColor = true;
            // 
            // textBoxSignUpConfirmPassword
            // 
            this.textBoxSignUpConfirmPassword.Location = new System.Drawing.Point(677, 246);
            this.textBoxSignUpConfirmPassword.Name = "textBoxSignUpConfirmPassword";
            this.textBoxSignUpConfirmPassword.Size = new System.Drawing.Size(277, 29);
            this.textBoxSignUpConfirmPassword.TabIndex = 12;
            this.textBoxSignUpConfirmPassword.UseSystemPasswordChar = true;
            // 
            // textBoxSignUpPassword
            // 
            this.textBoxSignUpPassword.Location = new System.Drawing.Point(167, 251);
            this.textBoxSignUpPassword.Name = "textBoxSignUpPassword";
            this.textBoxSignUpPassword.Size = new System.Drawing.Size(277, 29);
            this.textBoxSignUpPassword.TabIndex = 11;
            this.textBoxSignUpPassword.UseSystemPasswordChar = true;
            // 
            // radioButtonFemale
            // 
            this.radioButtonFemale.AutoSize = true;
            this.radioButtonFemale.Location = new System.Drawing.Point(849, 157);
            this.radioButtonFemale.Name = "radioButtonFemale";
            this.radioButtonFemale.Size = new System.Drawing.Size(102, 29);
            this.radioButtonFemale.TabIndex = 10;
            this.radioButtonFemale.TabStop = true;
            this.radioButtonFemale.Text = "Female";
            this.radioButtonFemale.UseVisualStyleBackColor = true;
            // 
            // radioButtonMale
            // 
            this.radioButtonMale.AutoSize = true;
            this.radioButtonMale.Checked = true;
            this.radioButtonMale.Location = new System.Drawing.Point(677, 160);
            this.radioButtonMale.Name = "radioButtonMale";
            this.radioButtonMale.Size = new System.Drawing.Size(80, 29);
            this.radioButtonMale.TabIndex = 9;
            this.radioButtonMale.TabStop = true;
            this.radioButtonMale.Text = "Male";
            this.radioButtonMale.UseVisualStyleBackColor = true;
            // 
            // textBoxSignUpEmail
            // 
            this.textBoxSignUpEmail.Location = new System.Drawing.Point(167, 157);
            this.textBoxSignUpEmail.Multiline = true;
            this.textBoxSignUpEmail.Name = "textBoxSignUpEmail";
            this.textBoxSignUpEmail.Size = new System.Drawing.Size(277, 32);
            this.textBoxSignUpEmail.TabIndex = 8;
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(677, 65);
            this.textBoxLastName.Multiline = true;
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(277, 32);
            this.textBoxLastName.TabIndex = 7;
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Location = new System.Drawing.Point(167, 63);
            this.textBoxFirstName.Multiline = true;
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(277, 32);
            this.textBoxFirstName.TabIndex = 6;
            // 
            // labelSignUpConfirmPassword
            // 
            this.labelSignUpConfirmPassword.AutoSize = true;
            this.labelSignUpConfirmPassword.Location = new System.Drawing.Point(497, 250);
            this.labelSignUpConfirmPassword.Name = "labelSignUpConfirmPassword";
            this.labelSignUpConfirmPassword.Size = new System.Drawing.Size(171, 25);
            this.labelSignUpConfirmPassword.TabIndex = 5;
            this.labelSignUpConfirmPassword.Text = "Confirm Password";
            // 
            // labelSignUpPassword
            // 
            this.labelSignUpPassword.AutoSize = true;
            this.labelSignUpPassword.Location = new System.Drawing.Point(59, 251);
            this.labelSignUpPassword.Name = "labelSignUpPassword";
            this.labelSignUpPassword.Size = new System.Drawing.Size(98, 25);
            this.labelSignUpPassword.TabIndex = 4;
            this.labelSignUpPassword.Text = "Password";
            // 
            // labelGender
            // 
            this.labelGender.AutoSize = true;
            this.labelGender.Location = new System.Drawing.Point(492, 160);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(77, 25);
            this.labelGender.TabIndex = 3;
            this.labelGender.Text = "Gender";
            // 
            // labelSignUpEmail
            // 
            this.labelSignUpEmail.AutoSize = true;
            this.labelSignUpEmail.Location = new System.Drawing.Point(54, 160);
            this.labelSignUpEmail.Name = "labelSignUpEmail";
            this.labelSignUpEmail.Size = new System.Drawing.Size(60, 25);
            this.labelSignUpEmail.TabIndex = 2;
            this.labelSignUpEmail.Text = "Email";
            // 
            // labelLastName
            // 
            this.labelLastName.AutoSize = true;
            this.labelLastName.Location = new System.Drawing.Point(492, 68);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(106, 25);
            this.labelLastName.TabIndex = 1;
            this.labelLastName.Text = "Last Name";
            // 
            // labelFirstName
            // 
            this.labelFirstName.AutoSize = true;
            this.labelFirstName.Location = new System.Drawing.Point(54, 68);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new System.Drawing.Size(106, 25);
            this.labelFirstName.TabIndex = 0;
            this.labelFirstName.Text = "First Name";
            // 
            // ExpenseLoggerSignInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 514);
            this.Controls.Add(this.tabControl1);
            this.Name = "ExpenseLoggerSignInForm";
            this.Text = "ExpenseLoggerSignInForm";
            this.tabControl1.ResumeLayout(false);
            this.tabSignIn.ResumeLayout(false);
            this.tabSignIn.PerformLayout();
            this.tabSignUp.ResumeLayout(false);
            this.tabSignUp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
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