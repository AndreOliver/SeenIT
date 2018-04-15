namespace SeenITMovieTV.Views
{
    partial class LogInView
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
            this.LogIn_Label = new System.Windows.Forms.Label();
            this.LogIn_Button = new System.Windows.Forms.Button();
            this.Create_Account_Button = new System.Windows.Forms.Button();
            this.UserName_MaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.Password_MaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.Name_Label_Ignore = new System.Windows.Forms.Label();
            this.Password_Label_Ignore = new System.Windows.Forms.Label();
            this.Email_Label_Ignore = new System.Windows.Forms.Label();
            this.Email_MaskedTextbox = new System.Windows.Forms.MaskedTextBox();
            this.Forgot_Password_Label = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LogIn_Label
            // 
            this.LogIn_Label.BackColor = System.Drawing.Color.Transparent;
            this.LogIn_Label.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogIn_Label.ForeColor = System.Drawing.SystemColors.Window;
            this.LogIn_Label.Location = new System.Drawing.Point(105, 19);
            this.LogIn_Label.Name = "LogIn_Label";
            this.LogIn_Label.Size = new System.Drawing.Size(215, 28);
            this.LogIn_Label.TabIndex = 6;
            this.LogIn_Label.Text = "Log In - SeenIT";
            this.LogIn_Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LogIn_Button
            // 
            this.LogIn_Button.BackColor = System.Drawing.Color.Yellow;
            this.LogIn_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogIn_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LogIn_Button.Location = new System.Drawing.Point(261, 346);
            this.LogIn_Button.Name = "LogIn_Button";
            this.LogIn_Button.Size = new System.Drawing.Size(103, 35);
            this.LogIn_Button.TabIndex = 8;
            this.LogIn_Button.Text = "Log In";
            this.LogIn_Button.UseVisualStyleBackColor = false;
            this.LogIn_Button.Click += new System.EventHandler(this.LogIn_Button_Click);
            // 
            // Create_Account_Button
            // 
            this.Create_Account_Button.BackColor = System.Drawing.Color.Yellow;
            this.Create_Account_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Create_Account_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Create_Account_Button.Location = new System.Drawing.Point(43, 346);
            this.Create_Account_Button.Name = "Create_Account_Button";
            this.Create_Account_Button.Size = new System.Drawing.Size(103, 35);
            this.Create_Account_Button.TabIndex = 9;
            this.Create_Account_Button.Text = "Create Account";
            this.Create_Account_Button.UseVisualStyleBackColor = false;
            this.Create_Account_Button.Click += new System.EventHandler(this.Create_Account_Button_Click);
            // 
            // UserName_MaskedTextBox
            // 
            this.UserName_MaskedTextBox.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Bold);
            this.UserName_MaskedTextBox.Location = new System.Drawing.Point(205, 116);
            this.UserName_MaskedTextBox.Name = "UserName_MaskedTextBox";
            this.UserName_MaskedTextBox.Size = new System.Drawing.Size(159, 27);
            this.UserName_MaskedTextBox.TabIndex = 10;
            // 
            // Password_MaskedTextBox
            // 
            this.Password_MaskedTextBox.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Bold);
            this.Password_MaskedTextBox.Location = new System.Drawing.Point(205, 185);
            this.Password_MaskedTextBox.Name = "Password_MaskedTextBox";
            this.Password_MaskedTextBox.PasswordChar = '*';
            this.Password_MaskedTextBox.Size = new System.Drawing.Size(159, 27);
            this.Password_MaskedTextBox.TabIndex = 11;
            this.Password_MaskedTextBox.UseSystemPasswordChar = true;
            // 
            // Name_Label_Ignore
            // 
            this.Name_Label_Ignore.AutoSize = true;
            this.Name_Label_Ignore.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name_Label_Ignore.ForeColor = System.Drawing.Color.White;
            this.Name_Label_Ignore.Location = new System.Drawing.Point(38, 123);
            this.Name_Label_Ignore.Name = "Name_Label_Ignore";
            this.Name_Label_Ignore.Size = new System.Drawing.Size(121, 28);
            this.Name_Label_Ignore.TabIndex = 12;
            this.Name_Label_Ignore.Text = "User Name:";
            // 
            // Password_Label_Ignore
            // 
            this.Password_Label_Ignore.AutoSize = true;
            this.Password_Label_Ignore.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password_Label_Ignore.ForeColor = System.Drawing.Color.White;
            this.Password_Label_Ignore.Location = new System.Drawing.Point(38, 185);
            this.Password_Label_Ignore.Name = "Password_Label_Ignore";
            this.Password_Label_Ignore.Size = new System.Drawing.Size(111, 28);
            this.Password_Label_Ignore.TabIndex = 13;
            this.Password_Label_Ignore.Text = "Password:";
            // 
            // Email_Label_Ignore
            // 
            this.Email_Label_Ignore.AutoSize = true;
            this.Email_Label_Ignore.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Email_Label_Ignore.ForeColor = System.Drawing.Color.White;
            this.Email_Label_Ignore.Location = new System.Drawing.Point(38, 247);
            this.Email_Label_Ignore.Name = "Email_Label_Ignore";
            this.Email_Label_Ignore.Size = new System.Drawing.Size(71, 28);
            this.Email_Label_Ignore.TabIndex = 15;
            this.Email_Label_Ignore.Text = "Email:";
            // 
            // Email_MaskedTextbox
            // 
            this.Email_MaskedTextbox.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Bold);
            this.Email_MaskedTextbox.Location = new System.Drawing.Point(152, 247);
            this.Email_MaskedTextbox.Name = "Email_MaskedTextbox";
            this.Email_MaskedTextbox.Size = new System.Drawing.Size(212, 27);
            this.Email_MaskedTextbox.TabIndex = 14;
            // 
            // Forgot_Password_Label
            // 
            this.Forgot_Password_Label.BackColor = System.Drawing.Color.Yellow;
            this.Forgot_Password_Label.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Forgot_Password_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Forgot_Password_Label.Location = new System.Drawing.Point(152, 346);
            this.Forgot_Password_Label.Name = "Forgot_Password_Label";
            this.Forgot_Password_Label.Size = new System.Drawing.Size(103, 35);
            this.Forgot_Password_Label.TabIndex = 16;
            this.Forgot_Password_Label.Text = "Forgot Details";
            this.Forgot_Password_Label.UseVisualStyleBackColor = false;
            this.Forgot_Password_Label.Click += new System.EventHandler(this.Forgot_Password_Label_Click);
            // 
            // LogInView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.Controls.Add(this.Forgot_Password_Label);
            this.Controls.Add(this.Email_Label_Ignore);
            this.Controls.Add(this.Email_MaskedTextbox);
            this.Controls.Add(this.Password_Label_Ignore);
            this.Controls.Add(this.Name_Label_Ignore);
            this.Controls.Add(this.Password_MaskedTextBox);
            this.Controls.Add(this.UserName_MaskedTextBox);
            this.Controls.Add(this.Create_Account_Button);
            this.Controls.Add(this.LogIn_Button);
            this.Controls.Add(this.LogIn_Label);
            this.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "LogInView";
            this.Padding = new System.Windows.Forms.Padding(40, 129, 40, 43);
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.TextAlign = System.Windows.Forms.VisualStyles.HorizontalAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LogInView_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LogIn_Label;
        private System.Windows.Forms.Button LogIn_Button;
        private System.Windows.Forms.Button Create_Account_Button;
        private System.Windows.Forms.MaskedTextBox UserName_MaskedTextBox;
        private System.Windows.Forms.MaskedTextBox Password_MaskedTextBox;
        private System.Windows.Forms.Label Name_Label_Ignore;
        private System.Windows.Forms.Label Password_Label_Ignore;
        private System.Windows.Forms.Label Email_Label_Ignore;
        private System.Windows.Forms.MaskedTextBox Email_MaskedTextbox;
        private System.Windows.Forms.Button Forgot_Password_Label;
    }
}