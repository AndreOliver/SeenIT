namespace SeenITMovieTV.Views
{
    partial class MovieSeriesSummaryFormView
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
            this.Movie_Title_Label = new System.Windows.Forms.Label();
            this.Back_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.YellowBorder)).BeginInit();
            this.SuspendLayout();
            // 
            // YellowBorder
            // 
            this.YellowBorder.BackgroundImage = global::SeenITMovieTV.Properties.Resources.yellow_border;
            this.YellowBorder.Location = new System.Drawing.Point(1, 100);
            this.YellowBorder.Name = "YellowBorder";
            this.YellowBorder.Size = new System.Drawing.Size(1038, 17);
            this.YellowBorder.TabIndex = 1;
            this.YellowBorder.TabStop = false;
            // 
            // Movie_Title_Label
            // 
            this.Movie_Title_Label.BackColor = System.Drawing.Color.Transparent;
            this.Movie_Title_Label.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Movie_Title_Label.ForeColor = System.Drawing.SystemColors.Window;
            this.Movie_Title_Label.Location = new System.Drawing.Point(330, 20);
            this.Movie_Title_Label.Name = "Movie_Title_Label";
            this.Movie_Title_Label.Size = new System.Drawing.Size(357, 28);
            this.Movie_Title_Label.TabIndex = 5;
            this.Movie_Title_Label.Text = "Movie Title";
            this.Movie_Title_Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Back_Button
            // 
            this.Back_Button.BackColor = System.Drawing.Color.Yellow;
            this.Back_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Back_Button.Location = new System.Drawing.Point(10, 59);
            this.Back_Button.Name = "Back_Button";
            this.Back_Button.Size = new System.Drawing.Size(103, 35);
            this.Back_Button.TabIndex = 6;
            this.Back_Button.Text = "Go Back";
            this.Back_Button.UseVisualStyleBackColor = false;
            this.Back_Button.Click += new System.EventHandler(this.Back_Button_Click);
            // 
            // MovieSeriesSummaryFormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 740);
            this.ControlBox = false;
            this.Controls.Add(this.Back_Button);
            this.Controls.Add(this.Movie_Title_Label);
            this.Controls.Add(this.YellowBorder);
            this.Name = "MovieSeriesSummaryFormView";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.TextAlign = System.Windows.Forms.VisualStyles.HorizontalAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MovieSeriesSummaryFormView_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.YellowBorder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox YellowBorder;
        private System.Windows.Forms.Label Movie_Title_Label;
        private System.Windows.Forms.Button Back_Button;
    }
}