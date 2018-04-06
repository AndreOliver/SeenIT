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

namespace SeenITMovieTV.Views
{
    public partial class MovieSeriesSummaryFormView : MetroForm
    {
        private mainFormView MainHandle;
        private static MovieSeriesSummaryViewModel MovieSeriesViewModel;
        private ProfileView ProfileHandle;
        private bool ReturnToProfile;

        //Singleton instance to prevent multiple forms being created.
        private static MovieSeriesSummaryFormView instance;

        //Retreiving the singleton by checking if it has already been created. If not then instanciate it.
        public static MovieSeriesSummaryFormView GetSummaryFormView
        {
            get
            {
                if(instance == null || instance.IsDisposed)
                {
                    instance = new MovieSeriesSummaryFormView();
                    MovieSeriesViewModel = new MovieSeriesSummaryViewModel();
                }

                return instance;
            }
        }

        public mainFormView SetMainHandle
        {
            set
            {
                MainHandle = value;
            }
        }

        public ProfileView setProfileHandle
        {
            set
            {
                ProfileHandle = value;
            }
        }

        public string Title
        {
            get
            {
                return Movie_Title_Label.Text;
            }
            set
            {
                Movie_Title_Label.Text = value;
            }
        }

        public MovieSeriesSummaryFormView()
        {
            InitializeComponent();           
        }

        private void Back_Button_Click(object sender, EventArgs e)
        {
            this.Hide();

            if (ReturnToProfile == false)
                MainHandle.Show();
            else
                ProfileHandle.Show();
        }

        public bool Enable(string URL, bool Hide, bool ReadyOnly)
        {
            //If read only is true then the back button must take the user back to the profile view.
            ReturnToProfile = ReadyOnly;

            //Check to see if Hide has been set to true. This occurs when data is too large to load instantly and causes visual lag on the application.
            this.Show();

            //To fix this we set the form visibility to false until the form is ready to be displayed.
            if (Hide == true)
              this.Visible = false;

            if (ReadyOnly == false)
            {
                //The URL of the movie / series to be displayed is passed to the view model where the business logic is completed, this instance will NOT be read only.
                MovieSeriesViewModel.DisplayInformation(URL, false);
            }
            else
            {
                //The URL of the movie / series to be displayed is passed to the view model where the business logic is completed, this instance will be read only.
                MovieSeriesViewModel.DisplayInformation(URL, true);
            }

            //Once this has finished we reveal the new form to the user.
            this.Visible = true;

            //Return true to show the action has been successful.
            return true;
        }
    }
}
