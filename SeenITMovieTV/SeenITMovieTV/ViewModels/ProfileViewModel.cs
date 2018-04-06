using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeenITMovieTV.DataObjects;
using SeenITMovieTV.Database;

namespace SeenITMovieTV.ViewModels
{
    public class ProfileViewModel
    {
        private SQL_Interaction DatabaseConnection;

        public ProfileViewModel()
        {

        }

        public List<MovieTVInformation> ViewWatchedMovieSeries()
        {
            List<MovieTVInformation> FoundMovieSeries = new List<MovieTVInformation>();

            DatabaseConnection = SQL_Interaction.GetSQL_Connection;

            FoundMovieSeries = DatabaseConnection.GetWatchedList();
            
            return FoundMovieSeries;
        }
    }
}
