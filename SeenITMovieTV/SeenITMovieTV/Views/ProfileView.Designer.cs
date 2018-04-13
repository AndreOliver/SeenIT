namespace SeenITMovieTV.Views
{
    partial class ProfileView
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
            this.YellowBorder = new System.Windows.Forms.PictureBox();
            this.Back_Button = new System.Windows.Forms.Button();
            this.User_Name_Label = new System.Windows.Forms.Label();
            this.Runtime_Total_Label = new System.Windows.Forms.Label();
            this.Most_Watched_Genre_Label = new System.Windows.Forms.Label();
            this.Total_Time_Label_Ignore = new System.Windows.Forms.Label();
            this.Most_Watched_Genre_Label_Ignore = new System.Windows.Forms.Label();
            this.Watched_MovieSeries_Panel = new System.Windows.Forms.Panel();
            this.Highest_Rated_PicBox = new System.Windows.Forms.PictureBox();
            this.Highest_Rated_Label_Ignore = new System.Windows.Forms.Label();
            this.Highest_Rated_Title_Label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Watched_Panel_Title_Label_Ignore = new System.Windows.Forms.Label();
            this.SearchWatchedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.Search_Watched_Filter_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.YellowBorder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Highest_Rated_PicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // YellowBorder
            // 
            this.YellowBorder.BackgroundImage = global::SeenITMovieTV.Properties.Resources.yellow_border;
            this.YellowBorder.Location = new System.Drawing.Point(1, 100);
            this.YellowBorder.Name = "YellowBorder";
            this.YellowBorder.Size = new System.Drawing.Size(1076, 17);
            this.YellowBorder.TabIndex = 1;
            this.YellowBorder.TabStop = false;
            // 
            // Back_Button
            // 
            this.Back_Button.BackColor = System.Drawing.Color.Yellow;
            this.Back_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Back_Button.Location = new System.Drawing.Point(11, 59);
            this.Back_Button.Name = "Back_Button";
            this.Back_Button.Size = new System.Drawing.Size(103, 35);
            this.Back_Button.TabIndex = 7;
            this.Back_Button.Text = "Go Back";
            this.Back_Button.UseVisualStyleBackColor = false;
            this.Back_Button.Click += new System.EventHandler(this.Back_Button_Click);
            // 
            // User_Name_Label
            // 
            this.User_Name_Label.BackColor = System.Drawing.Color.Transparent;
            this.User_Name_Label.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.User_Name_Label.ForeColor = System.Drawing.SystemColors.Window;
            this.User_Name_Label.Location = new System.Drawing.Point(354, 15);
            this.User_Name_Label.Name = "User_Name_Label";
            this.User_Name_Label.Size = new System.Drawing.Size(357, 28);
            this.User_Name_Label.TabIndex = 8;
            this.User_Name_Label.Text = "User Name";
            this.User_Name_Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Runtime_Total_Label
            // 
            this.Runtime_Total_Label.AutoSize = true;
            this.Runtime_Total_Label.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Bold);
            this.Runtime_Total_Label.ForeColor = System.Drawing.Color.White;
            this.Runtime_Total_Label.Location = new System.Drawing.Point(479, 140);
            this.Runtime_Total_Label.Name = "Runtime_Total_Label";
            this.Runtime_Total_Label.Size = new System.Drawing.Size(103, 28);
            this.Runtime_Total_Label.TabIndex = 9;
            this.Runtime_Total_Label.Text = "RUNTIME";
            // 
            // Most_Watched_Genre_Label
            // 
            this.Most_Watched_Genre_Label.AutoSize = true;
            this.Most_Watched_Genre_Label.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Bold);
            this.Most_Watched_Genre_Label.ForeColor = System.Drawing.Color.White;
            this.Most_Watched_Genre_Label.Location = new System.Drawing.Point(479, 200);
            this.Most_Watched_Genre_Label.Name = "Most_Watched_Genre_Label";
            this.Most_Watched_Genre_Label.Size = new System.Drawing.Size(79, 28);
            this.Most_Watched_Genre_Label.TabIndex = 10;
            this.Most_Watched_Genre_Label.Text = "GENRE";
            // 
            // Total_Time_Label_Ignore
            // 
            this.Total_Time_Label_Ignore.AutoSize = true;
            this.Total_Time_Label_Ignore.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Total_Time_Label_Ignore.ForeColor = System.Drawing.Color.White;
            this.Total_Time_Label_Ignore.Location = new System.Drawing.Point(23, 140);
            this.Total_Time_Label_Ignore.Name = "Total_Time_Label_Ignore";
            this.Total_Time_Label_Ignore.Size = new System.Drawing.Size(450, 28);
            this.Total_Time_Label_Ignore.TabIndex = 11;
            this.Total_Time_Label_Ignore.Text = "Total Time Spent Watching Movies and Series:";
            // 
            // Most_Watched_Genre_Label_Ignore
            // 
            this.Most_Watched_Genre_Label_Ignore.AutoSize = true;
            this.Most_Watched_Genre_Label_Ignore.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Most_Watched_Genre_Label_Ignore.ForeColor = System.Drawing.Color.White;
            this.Most_Watched_Genre_Label_Ignore.Location = new System.Drawing.Point(23, 200);
            this.Most_Watched_Genre_Label_Ignore.Name = "Most_Watched_Genre_Label_Ignore";
            this.Most_Watched_Genre_Label_Ignore.Size = new System.Drawing.Size(262, 28);
            this.Most_Watched_Genre_Label_Ignore.TabIndex = 12;
            this.Most_Watched_Genre_Label_Ignore.Text = "Your Most Watched Genre:";
            // 
            // Watched_MovieSeries_Panel
            // 
            this.Watched_MovieSeries_Panel.AutoScroll = true;
            this.Watched_MovieSeries_Panel.Location = new System.Drawing.Point(1, 463);
            this.Watched_MovieSeries_Panel.Name = "Watched_MovieSeries_Panel";
            this.Watched_MovieSeries_Panel.Size = new System.Drawing.Size(1075, 306);
            this.Watched_MovieSeries_Panel.TabIndex = 13;
            // 
            // Highest_Rated_PicBox
            // 
            this.Highest_Rated_PicBox.BackColor = System.Drawing.Color.Yellow;
            this.Highest_Rated_PicBox.Location = new System.Drawing.Point(824, 161);
            this.Highest_Rated_PicBox.Name = "Highest_Rated_PicBox";
            this.Highest_Rated_PicBox.Size = new System.Drawing.Size(182, 268);
            this.Highest_Rated_PicBox.TabIndex = 20;
            this.Highest_Rated_PicBox.TabStop = false;
            // 
            // Highest_Rated_Label_Ignore
            // 
            this.Highest_Rated_Label_Ignore.AutoSize = true;
            this.Highest_Rated_Label_Ignore.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Bold);
            this.Highest_Rated_Label_Ignore.ForeColor = System.Drawing.Color.White;
            this.Highest_Rated_Label_Ignore.Location = new System.Drawing.Point(807, 130);
            this.Highest_Rated_Label_Ignore.Name = "Highest_Rated_Label_Ignore";
            this.Highest_Rated_Label_Ignore.Size = new System.Drawing.Size(161, 28);
            this.Highest_Rated_Label_Ignore.TabIndex = 21;
            this.Highest_Rated_Label_Ignore.Text = "King Of The Hill";
            this.Highest_Rated_Label_Ignore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Highest_Rated_Title_Label
            // 
            this.Highest_Rated_Title_Label.AutoSize = true;
            this.Highest_Rated_Title_Label.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Bold);
            this.Highest_Rated_Title_Label.ForeColor = System.Drawing.Color.White;
            this.Highest_Rated_Title_Label.Location = new System.Drawing.Point(825, 432);
            this.Highest_Rated_Title_Label.Name = "Highest_Rated_Title_Label";
            this.Highest_Rated_Title_Label.Size = new System.Drawing.Size(181, 28);
            this.Highest_Rated_Title_Label.TabIndex = 22;
            this.Highest_Rated_Title_Label.Text = "Movie Series Title";
            this.Highest_Rated_Title_Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "label1";
            // 
            // Watched_Panel_Title_Label_Ignore
            // 
            this.Watched_Panel_Title_Label_Ignore.AutoSize = true;
            this.Watched_Panel_Title_Label_Ignore.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Bold);
            this.Watched_Panel_Title_Label_Ignore.ForeColor = System.Drawing.Color.White;
            this.Watched_Panel_Title_Label_Ignore.Location = new System.Drawing.Point(23, 432);
            this.Watched_Panel_Title_Label_Ignore.Name = "Watched_Panel_Title_Label_Ignore";
            this.Watched_Panel_Title_Label_Ignore.Size = new System.Drawing.Size(217, 28);
            this.Watched_Panel_Title_Label_Ignore.TabIndex = 24;
            this.Watched_Panel_Title_Label_Ignore.Text = "Your Watched Movies";
            // 
            // SearchWatchedTextBox
            // 
            this.SearchWatchedTextBox.Location = new System.Drawing.Point(752, 67);
            this.SearchWatchedTextBox.Name = "SearchWatchedTextBox";
            this.SearchWatchedTextBox.Size = new System.Drawing.Size(198, 20);
            this.SearchWatchedTextBox.TabIndex = 26;
            // 
            // Search_Watched_Filter_Button
            // 
            this.Search_Watched_Filter_Button.BackColor = System.Drawing.Color.Yellow;
            this.Search_Watched_Filter_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Search_Watched_Filter_Button.FlatAppearance.BorderSize = 0;
            this.Search_Watched_Filter_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Search_Watched_Filter_Button.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Search_Watched_Filter_Button.Location = new System.Drawing.Point(956, 59);
            this.Search_Watched_Filter_Button.Name = "Search_Watched_Filter_Button";
            this.Search_Watched_Filter_Button.Size = new System.Drawing.Size(105, 35);
            this.Search_Watched_Filter_Button.TabIndex = 25;
            this.Search_Watched_Filter_Button.Text = "Search";
            this.Search_Watched_Filter_Button.UseVisualStyleBackColor = false;
            this.Search_Watched_Filter_Button.Click += new System.EventHandler(this.Search_Watched_Filter_Button_Click);
            // 
            // ProfileView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 774);
            this.Controls.Add(this.SearchWatchedTextBox);
            this.Controls.Add(this.Search_Watched_Filter_Button);
            this.Controls.Add(this.Watched_Panel_Title_Label_Ignore);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Highest_Rated_Title_Label);
            this.Controls.Add(this.Highest_Rated_Label_Ignore);
            this.Controls.Add(this.Highest_Rated_PicBox);
            this.Controls.Add(this.Watched_MovieSeries_Panel);
            this.Controls.Add(this.Most_Watched_Genre_Label_Ignore);
            this.Controls.Add(this.Total_Time_Label_Ignore);
            this.Controls.Add(this.Most_Watched_Genre_Label);
            this.Controls.Add(this.Runtime_Total_Label);
            this.Controls.Add(this.User_Name_Label);
            this.Controls.Add(this.Back_Button);
            this.Controls.Add(this.YellowBorder);
            this.MaximizeBox = false;
            this.Name = "ProfileView";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.Text = " ";
            this.TextAlign = System.Windows.Forms.VisualStyles.HorizontalAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            ((System.ComponentModel.ISupportInitialize)(this.YellowBorder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Highest_Rated_PicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox YellowBorder;
        private System.Windows.Forms.Button Back_Button;
        private System.Windows.Forms.Label User_Name_Label;
        private System.Windows.Forms.Label Runtime_Total_Label;
        private System.Windows.Forms.Label Most_Watched_Genre_Label;
        private System.Windows.Forms.Label Total_Time_Label_Ignore;
        private System.Windows.Forms.Label Most_Watched_Genre_Label_Ignore;
        private System.Windows.Forms.Panel Watched_MovieSeries_Panel;
        private System.Windows.Forms.PictureBox Highest_Rated_PicBox;
        private System.Windows.Forms.Label Highest_Rated_Label_Ignore;
        private System.Windows.Forms.Label Highest_Rated_Title_Label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Watched_Panel_Title_Label_Ignore;
        private System.Windows.Forms.MaskedTextBox SearchWatchedTextBox;
        private System.Windows.Forms.Button Search_Watched_Filter_Button;
    }
}