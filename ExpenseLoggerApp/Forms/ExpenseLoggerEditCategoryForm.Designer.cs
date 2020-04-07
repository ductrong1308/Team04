namespace ExpenseLoggerApp.Forms
{
    partial class ExpenseLoggerEditCategoryForm
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
            this.buttonUpdateCurrentCategory = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxCategory = new System.Windows.Forms.TextBox();
            this.labelCategory = new System.Windows.Forms.Label();
            this.buttonAddNewCategory = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonUpdateCurrentCategory
            // 
            this.buttonUpdateCurrentCategory.Location = new System.Drawing.Point(177, 159);
            this.buttonUpdateCurrentCategory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonUpdateCurrentCategory.Name = "buttonUpdateCurrentCategory";
            this.buttonUpdateCurrentCategory.Size = new System.Drawing.Size(83, 29);
            this.buttonUpdateCurrentCategory.TabIndex = 9;
            this.buttonUpdateCurrentCategory.Text = "Update";
            this.buttonUpdateCurrentCategory.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(308, 159);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(83, 29);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // textBoxCategory
            // 
            this.textBoxCategory.Location = new System.Drawing.Point(161, 78);
            this.textBoxCategory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxCategory.Name = "textBoxCategory";
            this.textBoxCategory.Size = new System.Drawing.Size(195, 20);
            this.textBoxCategory.TabIndex = 10;
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Location = new System.Drawing.Point(80, 76);
            this.labelCategory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(49, 13);
            this.labelCategory.TabIndex = 7;
            this.labelCategory.Text = "Category";
            // 
            // buttonAddNewCategory
            // 
            this.buttonAddNewCategory.Location = new System.Drawing.Point(46, 159);
            this.buttonAddNewCategory.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddNewCategory.Name = "buttonAddNewCategory";
            this.buttonAddNewCategory.Size = new System.Drawing.Size(83, 29);
            this.buttonAddNewCategory.TabIndex = 12;
            this.buttonAddNewCategory.Text = "Add";
            this.buttonAddNewCategory.UseVisualStyleBackColor = true;
            // 
            // ExpenseLoggerEditCategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 244);
            this.Controls.Add(this.buttonAddNewCategory);
            this.Controls.Add(this.buttonUpdateCurrentCategory);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.textBoxCategory);
            this.Controls.Add(this.labelCategory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExpenseLoggerEditCategoryForm";
            this.Text = "ExpenseLoggerEditExpenseForm";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonUpdateCurrentCategory;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxCategory;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.Button buttonAddNewCategory;
    }
}