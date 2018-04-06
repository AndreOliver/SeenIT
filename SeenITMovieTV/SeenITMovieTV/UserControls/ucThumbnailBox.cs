using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SeenITMovieTV.Views;

namespace SeenITMovieTV
{
    public partial class ucThumbnailBox : UserControl
    {
        private mainFormView MainFormHandle;
        private MovieSeriesSummaryFormView SummaryHandle;
        private ProfileView Profilehandle;
        private bool UseWatchedOnly;

        //Constructor for main view. We set the UseWatchedOnly bool to false as the user hasn't come from the Profile View.
        public ucThumbnailBox(mainFormView handle)
        {
            InitializeComponent();
            MainFormHandle = handle;
            UseWatchedOnly = false;
        }

        //Constructor for profile View. UseWatchedOnly is true as only movies / series that the user has watched will be displayed in the profile view.
        public ucThumbnailBox(ProfileView handle)
        {
            InitializeComponent();
            Profilehandle = handle;
            UseWatchedOnly = true;
        }

        //String that holds the name and release year of a single movie / series.
        public string Thumbnail_Name
        {
            get
            {
                return MovieSeriesName.Text;
            }
            set
            {
                MovieSeriesName.Text = value;
            }
        }

        //String that holds the URL of an image. This is used to load the picture box background image.
        public string Thumbnail_Image_Location
        {
            get
            {
                return PicBox1.ImageLocation;
            }
            set
            {
                PicBox1.ImageLocation = value;
            }
        }

        //String that holds the URL of a single movie / series.
        public string IMDB_Link
        {
            get
            {
                return IMDBLink.Text;
            }
            set
            {
                if (value.Contains("https://"))
                    IMDBLink.Text = value;
                else
                    IMDBLink.Text = ("https://" + value);
            }
        }

        private void PicBox1_Click(object sender, EventArgs e)
        {
            //Get an instance of the singleton form which will contain all of the movie / series information and hide the main form from the user.
            SummaryHandle = MovieSeriesSummaryFormView.GetSummaryFormView;
            SummaryHandle.SetMainHandle = MainFormHandle;

            if (UseWatchedOnly == false)
            {
                //Enable a wait cursor on the main form to show the user that an action is happening in the background.
                GuiCursor.ToggleWaitCursor(MainFormHandle, true);


                //Call to enable the new information form.
                if (SummaryHandle.Enable(IMDB_Link, true, false) == true)
                {
                    //Once completed the main form will hide and we will disable the wait cursor as the action has been carried out.
                    MainFormHandle.Hide();
                    GuiCursor.ToggleWaitCursor(MainFormHandle, false);
                }
            }
            else
            {
                //Change functionality of back button to take user back to profile view instead of the main view.
                SummaryHandle.setProfileHandle = Profilehandle;

                //Enable a wait cursor on the main form to show the user that an action is happening in the background.
                GuiCursor.ToggleWaitCursor(Profilehandle, true);

                //Call to enable the new information form.
                if (SummaryHandle.Enable(IMDB_Link, true, true) == true)
                {
                    //Once completed the main form will hide and we will disable the wait cursor as the action has been carried out.
                    Profilehandle.Hide();
                    GuiCursor.ToggleWaitCursor(Profilehandle, false);
                }
            }
        }        
    }
}
