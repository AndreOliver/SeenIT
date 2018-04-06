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
            this.SuspendLayout();
            // 
            // Watching_Through_SeenIT_Label_Ignore
            // 
            this.Watching_Through_SeenIT_Label_Ignore.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Watching_Through_SeenIT_Label_Ignore.AutoSize = true;
            this.Watching_Through_SeenIT_Label_Ignore.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Watching_Through_SeenIT_Label_Ignore.ForeColor = System.Drawing.Color.White;
            this.Watching_Through_SeenIT_Label_Ignore.Location = new System.Drawing.Point(464, 38);
            this.Watching_Through_SeenIT_Label_Ignore.Name = "Watching_Through_SeenIT_Label_Ignore";
            this.Watching_Through_SeenIT_Label_Ignore.Size = new System.Drawing.Size(256, 28);
            this.Watching_Through_SeenIT_Label_Ignore.TabIndex = 13;
            this.Watching_Through_SeenIT_Label_Ignore.Text = "Watching Through SeenIT";
            this.Watching_Through_SeenIT_Label_Ignore.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // WatchNowView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 888);
            this.Controls.Add(this.Watching_Through_SeenIT_Label_Ignore);
            this.Name = "WatchNowView";
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.TextAlign = System.Windows.Forms.VisualStyles.HorizontalAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WatchNowView_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Watching_Through_SeenIT_Label_Ignore;
    }
}