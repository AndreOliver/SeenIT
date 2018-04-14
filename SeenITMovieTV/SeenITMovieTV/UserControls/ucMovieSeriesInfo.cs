using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using SeenITMovieTV.Database;
using SeenITMovieTV.Resources;
using System.Windows.Forms;
using SeenITMovieTV.Views;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace SeenITMovieTV.UserControls
{
    /// <summary>
    /// Custom UserControl which holds information on a single movie / series. 
    /// </summary>
    public partial class ucMovieSeriesInfo : UserControl
    {
        //Singleton instance to prevent multiple forms being created.
        private static ucMovieSeriesInfo instance;
        private MovieSeriesSummaryFormView SummaryFormHandle;
        private SQL_Interaction databaseConnection;
        private HtmlAgilityWrapper HTMLAgilityWrap;
        public ucMovieSeriesInfo()
        {
            InitializeComponent();
            SummaryFormHandle = MovieSeriesSummaryFormView.GetSummaryFormView;
            databaseConnection = SQL_Interaction.GetSQL_Connection;
            HTMLAgilityWrap = new HtmlAgilityWrapper();
        }

        /// <summary>
        /// Singleton type method which will create a instance of this UC if one doesn't exist. If one does exist then it is returned to the user. 
        /// </summary>
        public static ucMovieSeriesInfo GetUC
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new ucMovieSeriesInfo();                  
                }

                return instance;
            }
        }

        public string MovieSeriesName
        {
            get
            {
                return SummaryFormHandle.Title;
            }
        }
        public string CoverImageLocation
        {
            get
            {
                return Cover_Image_PicBox.ImageLocation;
            }
            set
            {
                Cover_Image_PicBox.ImageLocation = value;
            }
        }
        public string ReleaseDate
        {
            get
            {
                return Year_Label.Text;
            }
            set
            {
                Year_Label.Text = value;
            }
        }
        public string UserRating
        {
            get
            {
                return Rating_Label.Text;
            }
            set
            {
                Rating_Label.Text = value;
            }
        }
        public string MetaScore
        {
            get
            {
                return Meta_Label.Text;
            }
            set
            {
                Meta_Label.Text = value;
            }
        }
        public string Popularity
        {
            get
            {
                return Popularity_Label.Text;
            }
            set
            {
                Popularity_Label.Text = value;
            }
        }
        public string Runtime
        {
            get
            {
                return Run_Time_Label.Text;
            }
            set
            {
                Run_Time_Label.Text = value;
            }
        }
        public string Genres
        {
            get
            {
                return Genres_Label.Text;
            }
            set
            {
                Genres_Label.Text = value;
            }
        }
        public string SimilarMovieSeriesImg
        {
            get
            {
                return Similar_MovieSeries_PicBox.ImageLocation;
            }
            set
            {
                Similar_MovieSeries_PicBox.ImageLocation = value;
            }
        }
        public string IMDB_Link
        {
            get
            {
                return IMDB_Link_Label.Text;
            }
            set
            {
                IMDB_Link_Label.Text = (value);
            }
        }
        private string PersonalRating
        {
            get
            {
                return PersonalRatingTextbox.Text;
            }
            set
            {
                PersonalRatingTextbox.Text = value;
            }
        }
        private string PersonalComment
        {
            get
            {
                return PersonalCommentTextbox.Text;
            }
            set
            {
                PersonalCommentTextbox.Text = value;
            }
        }

        /* PUBLIC METHODS */

        /// <summary>
        /// Once called the function checks if the UC should be opened in read only by evaluating the bool passed in as a parameter.
        /// Set to true if you are opening a movie / series from the Profile View. This will disable all input and only allow the user
        /// to view all of the information on the movie and if they wish, remove it from the database.
        /// </summary>
        /// <param name="ReadOnly"></param>
        public void MakeReadyOnly(bool ReadOnly)
        {
            //Reset all textboxes before populating them with strings pulled from the database.
            ResetAllTextboxes();

            //If set to true then the movie / series already exists in the database.
            if (ReadOnly)
            {
                //Disable all input.
                PersonalRatingTextbox.Enabled = false;
                PersonalCommentTextbox.Enabled = false;

                //Disable the "Add To Database" button.
                Add_To_Watched_Button.Enabled = false;
                Add_To_Watched_Button.Visible = false;

                //Enable a different button which will allow the user to remove the movie / series from the database.
                Remove_From_Watched_Button.Enabled = true;
                Remove_From_Watched_Button.Visible = true;

                //Pull information from the database on this movie / series and fill the view with it.
                var PersonalDetails = databaseConnection.GetpersonalDetails(MovieSeriesName);
                if (PersonalDetails.Count == 0)
                    return;
                PersonalRating = PersonalDetails[0];
                PersonalComment = PersonalDetails[1];
            }

            //If set to false then the movie / series is either being viewed from the main view OR not watched before.
            else
            {
                PersonalRatingTextbox.Enabled = true;
                PersonalCommentTextbox.Enabled = true;

                Add_To_Watched_Button.Enabled = true;
                Add_To_Watched_Button.Visible = true;

                Remove_From_Watched_Button.Enabled = false;
                Remove_From_Watched_Button.Visible = false;
            }
        }

        /*PRIVATE METHODS*/

        /// <summary>
        /// Once called it will check the user rating textbox for invalid numbers / strings. If errors are found the bool will return false.
        /// </summary>
        /// <returns></returns>
        private bool ValidInputCheck()
        {
            double UserRating = 0.0;

            //If the outted value is what we expect then return true, else return false. We expect it to be a double value between 0.0 and 10.0.
            if (Double.TryParse(PersonalRatingTextbox.Text, out UserRating))
            {
                if (UserRating >= 0.0 && UserRating <= 10.00)
                {
                    return true;
                }
            }

            return false;
        }

        private void Add_To_Watched_Button_Click(object sender, EventArgs e)
        {
            //Check for incorrect values being entered into the user rating box.
            bool ValidInput = ValidInputCheck();


            if (ValidInput == false)
            {
                //If invalid values are found show a message box and do not add the movie / series to the database.
                MessageBox.Show("Error, invalid Input for the user rating, please input between 0.0 and 10.0");
                return;
            }

            //If all information entered by the user is valid, check if this movie / series has been watched before.
            bool WatchedBefore = databaseConnection.WatchedBefore(MovieSeriesName);


            if (WatchedBefore == false)
            {
                //Sometimes the movie / series will fail to load all needed information for the database if it hasn't been released yet. If this happens then again show a messagebox informing the user and return out of the function.
                if (UserRating == "Unknown")
                {
                    MessageBox.Show("Error, cannot add to watched list as not yet released!");
                    return;
                }

                //Add the new movie or series to the database using the custom data class.
                databaseConnection.InsertNewMovieSeries(this.MovieSeriesName, this.UserRating, this.MetaScore, this.PersonalRating, this.PersonalComment, this.IMDB_Link, this.Runtime, Genres, this.CoverImageLocation);

                //Inform the user that the movie / series was successfully added to the database.
                MessageBox.Show("Added Movie to watched list successfully!");
            }
            else
            {
                //If a movie / series is found to already exist in the database then let the user know and return out of the function.
                MessageBox.Show("Error, Movie already watched");
            }

            //Reset all information left in textboxes as this can cause issues if left.
            ResetAllTextboxes();
        }

        /// <summary>
        /// Used to Reset all textboxes on the UC.
        /// </summary>
        private void ResetAllTextboxes()
        {
            PersonalCommentTextbox.ResetText();
            PersonalRatingTextbox.ResetText();
        }

        private void Remove_From_Watched_Click(object sender, EventArgs e)
        {
            //TODO: Implement a remove from database function.
            MessageBox.Show("TA DA");
        }

        /// <summary>
        /// Stream the movie selected. If no stream is available then inform the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Stream_Button_Click(object sender, EventArgs e)
        {
            /*PART 1: Search the movie streaming site for our movie. If found retrieve the URL of that movie and save it.*/
            var criteria = FormatNameForSearch(MovieSeriesName);

            string SearchCriteria = "https://solarmoviez.ru/search/" + criteria;

            var InnerHTML = HTMLAgilityWrap.SelectSingleNode(SearchCriteria, "//*[@id='main']/div/div[2]/div").InnerHtml;

            var UnfilteredList = InnerHTML.Split('"', '"').ToList();

            List<string> FilteredToOnlyURLs = new List<string>();

            foreach (var item in UnfilteredList)
            {
                var formatted = FormatNameForFilter(MovieSeriesName);
                if (item.Contains("https://solarmoviez.ru/movie/" + formatted))
                    FilteredToOnlyURLs.Add(item);
            }

            if(FilteredToOnlyURLs.Count == 0)
            {
                MessageBox.Show("Sorry, this movie isn't available for streaming");
                return;
            }

            /*PART 2: Use the saved URL to access the next page where the movie file is located.*/

            var OuterHTML = HTMLAgilityWrap.SelectSingleNode(FilteredToOnlyURLs[0].ToString(), "//*[@id='mv-info']/div/div[1]/div/a").OuterHtml;
            var UnfilteredMovieFileList = InnerHTML.Split('"', '"').ToList();

            List<string> FilteredMovieFileList = new List<string>();

            foreach (var item in UnfilteredList)
            {
                var formatted = FormatNameForFilter(MovieSeriesName);
                if (item.Contains("https://solarmoviez.ru/movie/" + formatted))
                    FilteredMovieFileList.Add(item);
            }

            /*PART 3: Finally Play the Movie*/

            string URL = FilteredMovieFileList[0].ToString();
            URL = URL.Replace(".html", "/watching.html");

            if (Browser_Choice_ComboBox.Enabled == true)
            {
                //Use external users defined broswer.
                WatchNow(URL, Browser_Choice_ComboBox.SelectedItem.ToString());
            }
            else
            {
                this.Hide();
                //Use built in Application browser.
                WatchNowView WatchIT = new WatchNowView(URL);
                WatchIT.Show();
                this.Show();
            }
        }

        private void WatchNow(string url, string browserChosen)
        {
            //Choices currently available:
            //Default browser
            //Chrome
            //Firefox
            //InternetExplorer

            if (browserChosen == "default browser")
                Process.Start(url);
            else
                Process.Start(browserChosen, url);
        }

        private string FormatNameForSearch(string Name)
        {
            var AlteredName = Name;
            Regex.Replace(AlteredName, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
            AlteredName = AlteredName.Replace(" ", "+");
            AlteredName = AlteredName.Replace(":", "");
            AlteredName = AlteredName.Replace(",", "");
            AlteredName = AlteredName.Replace("!", "");
            return (AlteredName + ".html");
        }

        private string FormatNameForFilter(string Name)
        {            
            var AlteredName = Name;
            Regex.Replace(AlteredName, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
            AlteredName = AlteredName.Replace(":", "");
            AlteredName = AlteredName.Replace(" ", "-");
            AlteredName = AlteredName.ToLower();

            return AlteredName;
        }

        private void Watch_Through_External_Browser_Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            Browser_Choice_ComboBox.SelectedIndex = 0;

            if (Watch_Through_External_Browser_Checkbox.Checked == true)
            {
                Browser_Choice_ComboBox.Enabled = true;
                
            }
            else
            {
                Browser_Choice_ComboBox.Enabled = false;
            }
        }

        /*FUTURE FUNCTIONALITY*/

        //Adding functionality to the similar cover photo. If clicked it should refresh the movie summary view with the new movie / series information.
        //private void pictureBox1_Click(object sender, EventArgs e)
        //{
        //    GuiCursor.ToggleWaitCursor(SummaryFormHandle, true);
        //    Re - Load the form with the new titles information.Backbutton will still take them back to main menu.
        //     SummaryFormHandle.Enable(IMDB_Link, false, false);
        //    GuiCursor.ToggleWaitCursor(SummaryFormHandle, false);
        //}
    }
}
