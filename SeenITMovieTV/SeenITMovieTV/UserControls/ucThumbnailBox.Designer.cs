namespace SeenITMovieTV
{
    partial class ucThumbnailBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PicBox1 = new System.Windows.Forms.PictureBox();
            this.MovieSeriesName = new System.Windows.Forms.TextBox();
            this.IMDBLink = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // PicBox1
            // 
            this.PicBox1.BackColor = System.Drawing.Color.Yellow;
            this.PicBox1.Location = new System.Drawing.Point(3, 3);
            this.PicBox1.Name = "PicBox1";
            this.PicBox1.Size = new System.Drawing.Size(182, 268);
            this.PicBox1.TabIndex = 0;
            this.PicBox1.TabStop = false;
            this.PicBox1.Click += new System.EventHandler(this.PicBox1_Click);
            // 
            // MovieSeriesName
            // 
            this.MovieSeriesName.BackColor = System.Drawing.Color.Yellow;
            this.MovieSeriesName.Location = new System.Drawing.Point(17, 241);
            this.MovieSeriesName.Name = "MovieSeriesName";
            this.MovieSeriesName.Size = new System.Drawing.Size(153, 20);
            this.MovieSeriesName.TabIndex = 1;
            this.MovieSeriesName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // IMDBLink
            // 
            this.IMDBLink.AutoSize = true;
            this.IMDBLink.Location = new System.Drawing.Point(79, 19);
            this.IMDBLink.Name = "IMDBLink";
            this.IMDBLink.Size = new System.Drawing.Size(0, 13);
            this.IMDBLink.TabIndex = 2;
            // 
            // ucThumbnailBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MovieSeriesName);
            this.Controls.Add(this.PicBox1);
            this.Controls.Add(this.IMDBLink);
            this.Name = "ucThumbnailBox";
            this.Size = new System.Drawing.Size(188, 275);
            ((System.ComponentModel.ISupportInitialize)(this.PicBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox PicBox1;
        private System.Windows.Forms.TextBox MovieSeriesName;
        private System.Windows.Forms.Label IMDBLink;
    }
}
