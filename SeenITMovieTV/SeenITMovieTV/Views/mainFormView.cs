using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MetroFramework.Forms;
using SeenITMovieTV.ViewModels;
using SeenITMovieTV.DataObjects;
using SeenITMovieTV.UserControls;

namespace SeenITMovieTV
{
    public partial class mainFormView : MetroForm
    {
        //Used to check how many user controls to dynamically load.
        private int SizeOfMovieTVList;

        //Used to check if movies or series should be retreived.
        private bool loadMovies;

        //List of ThumbNail boxes (user control).
        private List<ucThumbnailBox> ucMovieTVList;

        //This ViewModel will be used to handle the majority of the logic behind this View.
        private mainFormViewModel MainFormViewModel;

        //This list will contain all the information needed to populate the home screen with movies / series.
        private List<MovieTVInformation> AllMoviesOrSeriesList;

        public mainFormView()
        {
            SizeOfMovieTVList = 0;
            loadMovies = true;

            InitializeComponent();
            Initialise_ThumbnailUC();
            Initialise_Display();

            MainFormViewModel = new mainFormViewModel(this);
        }

        private void Search_Filter_Button_Click(object sender, EventArgs e)
        {
            Reset_Thumbails();
            GuiCursor.WaitCursor(() => { AllMoviesOrSeriesList = MainFormViewModel.SearchClicked(SearchTextBox.Text); });
            UpdateThumbnails();
        }

        private void Profile_View_Button_Click(object sender, EventArgs e)
        {
            MainFormViewModel.ProfileClicked();
        }

        private void MovieTV_Toggle_Button_Click(object sender, EventArgs e)
        {
            //Reset all visuals ready for next use.
            Reset_Thumbails();

            if (loadMovies == true)
            {
                Movie_Toggle_Button.Text = "View Top Series";

                //Return a list of all series found (watched and unwatched, not yet filtered).
                GuiCursor.WaitCursor(() => { AllMoviesOrSeriesList = MainFormViewModel.ViewMovies(); });

                loadMovies = false;
            }
            else
            {
                Movie_Toggle_Button.Text = "View Top Movies";

                //Return a list of all movies found (watched and unwatched, not yet filtered).
                GuiCursor.WaitCursor(() => { AllMoviesOrSeriesList = MainFormViewModel.ViewSeries(); });

                loadMovies = true;
            }

            UpdateThumbnails();
        }

        private void UpdateThumbnails()
        {          
            SizeOfMovieTVList = AllMoviesOrSeriesList.Count;

            //Only 100 to be loaded, if more gets pulled back then chop them out of the list.
            if(SizeOfMovieTVList > 100)
            {
                AllMoviesOrSeriesList.RemoveRange(100, 100);
                SizeOfMovieTVList = AllMoviesOrSeriesList.Count;
            }

            //Check we can look through the list without null exceptions.
            if (SizeOfMovieTVList != 0)
            {
                //Enable the display and show user all movies / series found.
                for (int i = 0; i < SizeOfMovieTVList; i++)
                {
                    ucMovieTVList[i].Visible = true;
                    ucMovieTVList[i].Enabled = true;

                    if (AllMoviesOrSeriesList[i].Name != String.Empty)
                    {
                        ucMovieTVList[i].Thumbnail_Name = AllMoviesOrSeriesList[i].Name;
                        ucMovieTVList[i].Thumbnail_Image_Location = AllMoviesOrSeriesList[i].CoverPictureLink;
                        ucMovieTVList[i].IMDB_Link = AllMoviesOrSeriesList[i].IMDBLink;
                        ucMovieTVList[i].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    }
                }
            }
        }

        private void Initialise_Display()
        {
            //Used to position each tile.
            int XPos = 20;
            int YPos = 0;

            //Used to access each tile individually.
            int Tracker = 0;

            //Loop through and place all thumbnail tiles ready for use.
            for(int i = 0; i < 20; i++)
            {
                for(int j=0; j < 5; j++)
                {
                    //Add each control then disable them and hide them. They will be re-enabled when movie data has been retreived.
                    Cover_Panel.Controls.Add(ucMovieTVList[Tracker]);
                    
                    ucMovieTVList[Tracker].Visible = false;
                    ucMovieTVList[Tracker].Enabled = false;
                    ucMovieTVList[Tracker].Location = new Point(XPos, YPos);

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

        private void Initialise_ThumbnailUC()
        {
            //Create the default 100 picture boxes and hide / lock them until movie or series data has been retreived.
            ucMovieTVList = new List<ucThumbnailBox>(100);
            for (int i = 0; i < 100; i++)
            {
                ucMovieTVList.Add(new ucThumbnailBox(this));
            }
        }

        private void Reset_Thumbails()
        {
            for(int i=0; i < 100; i++)
            {
                ucMovieTVList[i].Visible = false;
                ucMovieTVList[i].Name = "";
                ucMovieTVList[i].Enabled = false;
                ucMovieTVList[i].BackColor = Color.Yellow;
            }
        }

        private void Donate_Button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("BTC: 1DdK7DvLwpk48e1EXfQpKw3zumxXsu5HqD");
        }
    }
}
