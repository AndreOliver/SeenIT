namespace SeenITMovieTV.Views
{
    partial class WatchNowView
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
            this.Watching_Through_SeenIT_Label_Ignore = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Watching_Through_SeenIT_Label_Ignore
            // 
            this.Watching_Through_SeenIT_Label_Ignore.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Watching_Through_SeenIT_Label_Ignore.AutoSize = true;
            this.Watching_Through_SeenIT_Label_Ignore.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Watching_Through_SeenIT_Label_Ignore.ForeColor = System.Drawing.Color.White;
            this.Watching_Through_SeenIT_Label_Ignore.Location = new System.Drawing.Point(553, 24);
            this.Watching_Through_SeenIT_Label_Ignore.Name = "Watching_Through_SeenIT_Label_Ignore";
            this.Watching_Through_SeenIT_Label_Ignore.Size = new System.Drawing.Size(102, 28);
            this.Watching_Through_SeenIT_Label_Ignore.TabIndex = 13;
            this.Watching_Through_SeenIT_Label_Ignore.Text = "Watching";
            this.Watching_Through_SeenIT_Label_Ignore.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SeenITMovieTV.Properties.Resources.SeenIT_Logo_LogInView_Sized;
            this.pictureBox1.Location = new System.Drawing.Point(12, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 43);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // WatchNowView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 888);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Watching_Through_SeenIT_Label_Ignore);
            this.Name = "WatchNowView";
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.TextAlign = System.Windows.Forms.VisualStyles.HorizontalAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Watching_Through_SeenIT_Label_Ignore;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}