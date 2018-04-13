using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework.Forms;
using SeenITMovieTV.ViewModels;
using SeenITMovieTV.Database;
using SeenITMovieTV.DataObjects;

namespace SeenITMovieTV.Views
{
    public partial class ProfileView : MetroForm
    {
        private List<ucThumbnailBox> ucWatchedMovieTVList;

        //This list will contain all the information needed to populate the home screen with movies / series.
        private List<MovieTVInformation> AllMoviesOrSeriesList;
        private int SizeOfMovieTVList;

        public ProfileView()
        {
            SizeOfMovieTVList = 0;

            InitializeComponent();

            InitialiseThumbnailUC();
            InitialiseDisplay();
            InitialiseProfile();           
        }

        //private List<ucThumbnailBox> ucWatchedMovieTVList;
        private mainFormView MainHandle;
        private static ProfileViewModel MovieSeriesViewModel;
        private static SQL_Interaction DataConnection;
        private static ProfileView instance;

        public static ProfileView GetProfileFormView
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    DataConnection = SQL_Interaction.GetSQL_Connection;
                    instance = new ProfileView();                                  
                }

                return instance;
            }
        }

        public mainFormView SetHandle
        {
            set
            {
                MainHandle = value;
            }
        }

        public string SetUserNameTitle
        {
            set
            {
                User_Name_Label.Text = value;               
            }
        }

        public void InitialiseProfile()
        {
            SetUserNameTitle = DataConnection.UserName;
            Runtime_Total_Label.Text = (DataConnection.GetTotalRunTime().ToString() + "Hours");
            Most_Watched_Genre_Label.Text = DataConnection.GetFavouriteGenre();
            GetTopMovie();
            GetWatchedMovieSeries();
        }

        private void GetTopMovie()
        {
            List<string> temp = new List<string>();

            temp = DataConnection.GetHighestRatedMovieSeries();

            if(temp.Count == 0)
            { return; }
            Highest_Rated_PicBox.ImageLocation = temp[0];
            Highest_Rated_Title_Label.Text = (temp[1]);
            Highest_Rated_Label_Ignore.Text = Highest_Rated_Label_Ignore.Text + " - " + temp[2];
        }

        private void Back_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainHandle.Show();
        }

        private void UpdateThumbnails()
        {
            //Set the for loop size by checking the count. We do this so that we dont go out of bounds reading the array.
            SizeOfMovieTVList = AllMoviesOrSeriesList.Count;

            //Check we can look through the list without null exceptions.
            if (SizeOfMovieTVList != 0)
            {
                //Enable the display and show user all movies / series found.
                for (int i = 0; i < SizeOfMovieTVList; i++)
                {
                    ucWatchedMovieTVList[i].Visible = true;
                    ucWatchedMovieTVList[i].Enabled = true;

                    if (AllMoviesOrSeriesList[i].Name != String.Empty)
                    {
                        ucWatchedMovieTVList[i].Thumbnail_Name = AllMoviesOrSeriesList[i].Name;
                        ucWatchedMovieTVList[i].Thumbnail_Image_Location = AllMoviesOrSeriesList[i].CoverPictureLink;
                        ucWatchedMovieTVList[i].IMDB_Link = AllMoviesOrSeriesList[i].IMDBLink;
                        ucWatchedMovieTVList[i].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    }
                }
            }
        }

        /// <summary>
        /// Overloaded method to use a specific list instead of the default global one.
        /// </summary>
        /// <param name="ListToUpdateWith"></param>
        private void UpdateThumbnails(List<MovieTVInformation> ListToUpdateWith)
        {
            //Set the for loop size by checking the count. We do this so that we dont go out of bounds reading the array.
            SizeOfMovieTVList = ListToUpdateWith.Count;

            //Check we can look through the list without null exceptions.
            if (SizeOfMovieTVList != 0)
            {
                //Enable the display and show user all movies / series found.
                for (int i = 0; i < SizeOfMovieTVList; i++)
                {
                    ucWatchedMovieTVList[i].Visible = true;
                    ucWatchedMovieTVList[i].Enabled = true;

                    if (AllMoviesOrSeriesList[i].Name != String.Empty)
                    {
                        ucWatchedMovieTVList[i].Thumbnail_Name = ListToUpdateWith[i].Name;
                        ucWatchedMovieTVList[i].Thumbnail_Image_Location = ListToUpdateWith[i].CoverPictureLink;
                        ucWatchedMovieTVList[i].IMDB_Link = ListToUpdateWith[i].IMDBLink;
                        ucWatchedMovieTVList[i].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    }
                }
            }
        }

        private void InitialiseDisplay()
        {
            //Used to position each tile.
            int XPos = 20;
            int YPos = 0;

            //Used to access each tile individually.
            int Tracker = 0;

            //Loop through and place all thumbnail tiles ready for use.
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    //Add each control then disable them and hide them. They will be re-enabled when movie data has been retreived.
                    Watched_MovieSeries_Panel.Controls.Add(ucWatchedMovieTVList[Tracker]);

                    ucWatchedMovieTVList[Tracker].Visible = true;
                    ucWatchedMovieTVList[Tracker].Enabled = true;
                    ucWatchedMovieTVList[Tracker].Location = new Point(XPos, YPos);

                    //Adjust X as needed.
                    XPos = XPos + 200;

                    //Increment the tracker variable.
                    Tracker++;
                }
                //Offset to need line and reset X Position.
                XPos = 20;
                YPos = YPos + 300;
            }
        }

        private void InitialiseThumbnailUC()
        {
            //Create the default 100 picture boxes and hide / lock them until movie or series data has been retreived.
            ucWatchedMovieTVList = new List<ucThumbnailBox>(100);
            for (int i = 0; i < 100; i++)
            {
                ucWatchedMovieTVList.Add(new ucThumbnailBox(this));
            }
        }

        private void ResetThumbails()
        {
            for (int i = 0; i < 100; i++)
            {
                ucWatchedMovieTVList[i].Visible = false;
                ucWatchedMovieTVList[i].Name = "";
                ucWatchedMovieTVList[i].Enabled = false;
                ucWatchedMovieTVList[i].BackColor = Color.Yellow;
            }
        }

        private void GetWatchedMovieSeries()
        {
            MovieSeriesViewModel = new ProfileViewModel();
            //Reset all visuals ready for next use.
            ResetThumbails();

            //Return a list of all series found (Only Watched).
            GuiCursor.WaitCursor(() => { AllMoviesOrSeriesList = DataConnection.GetWatchedList(); });

            //Update using the information found.
            UpdateThumbnails();
        }

        private void Search_Watched_Filter_Button_Click(object sender, EventArgs e)
        {
            //Reset the profile view to get ready to only show search results.
            ResetThumbails();

            //Create a copy, as we don't want to alter the original list.
            var tempList = new List<MovieTVInformation>();

            foreach (var movie in AllMoviesOrSeriesList)
            {
                if(movie.Name.ToLower().Contains(SearchWatchedTextBox.Text) == true)
                {                    
                    tempList.Add(movie);
                }
            }

            UpdateThumbnails(tempList);
        }

        private void ProfileView_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}
