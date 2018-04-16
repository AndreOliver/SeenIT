using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions;
using SeenITMovieTV.DataObjects;
using System.Windows.Forms;

namespace SeenITMovieTV.Database
{
    /// <summary>
    /// This class is used as the sole way of trasfering and retreiving data from the applications local database. Implements a singleton design so multiple connections can't be created.
    /// </summary>
    public class SQL_Interaction
    {
        private SqlConnection SqlCon = new SqlConnection();
        private string _UserName;
        private int _UserId;
        private int MovieId;
        private Dictionary<int, string> GenreTypes = new Dictionary<int, string>();
        private Dictionary<int, int> GenreAmount = new Dictionary<int, int>();
        private static SQL_Interaction instance;

        public SQL_Interaction()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database"));
            
        }

        //This method will check for an already existing instance of this class and return it. If one isn't found then it will create a new one and return that.
        public static SQL_Interaction GetSQL_Connection
        {
            get
            {
                if (instance == null)
                {
                    instance = new SQL_Interaction();
                }

                return instance;
            }
        }

        public string UserName
        {
            get
            {
                return this._UserName;
            }
            set
            {
                this._UserName = value;
            }
        }
        public int UserId
        {
            get
            {
                return this._UserId;
            }
            set
            {
                this._UserId = value;
            }
        }

/*PUBLIC METHODS*/

        /// <summary>
        /// This function iterates through the database searching for all movies / series associated with a single user (The user logged on) and retrieves the name, URL and CoverPicure URL of each found movie / series.
        /// </summary>
        public List<MovieTVInformation> GetWatchedList()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["SeenITMovieTV.Database.SeenITDatabase"].ConnectionString;

            //Create a temp list to hold all information retreived from the database.
            List<MovieTVInformation> tempInfo = new List<MovieTVInformation>();
            int SizeOfDataFound = 0;

            //Create the SQL query which will be run against the database. This will return the number of movies / series in the database related to the logged in user.
            string query = "SELECT COUNT(*) FROM MovieSeriesTable m WHERE m.Id IN(SELECT uma.MovieSeriesId FROM UserMovieAssociationTable uma WHERE uma.UserId = '"+UserId+"')";

            //Open the connection and check if the reader has found any rows of data.
            using (this.SqlCon = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, SqlCon))
            {
                SqlCon.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //If data is found then retreive the data from the first row and store it. It will be used to limit how many new placeholders will be created in the temp list for found information.
                            SizeOfDataFound = reader.GetInt32(0);
                        }
                    }
                }
            }

            //Add blank placeholders of information to the list ready to be filled.
            for (int j = 0; j < SizeOfDataFound; j++)
            {
                tempInfo.Add(new MovieTVInformation());
            }

            //Create a second query which will pull all of the information we need from the database for each movie / series.
            string query2 = "SELECT m.Name, m.URL, m.PersonalRating, m.PersonalComment, m.CoverPictureURL FROM MovieSeriesTable m WHERE m.Id IN(SELECT uma.MovieSeriesId FROM UserMovieAssociationTable uma WHERE uma.UserId = '"+UserId+"')";

            int ListCounter = 0;

            using (this.SqlCon = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query2, SqlCon))
            {
                SqlCon.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //Store all of the information we need in the list.
                            if (ListCounter >= SizeOfDataFound || ListCounter > 99)
                                break;
                            tempInfo[ListCounter].Name = reader.GetString(0);
                            tempInfo[ListCounter].IMDBLink = reader.GetString(1);
                            tempInfo[ListCounter].CoverPictureLink = reader.GetString(4);

                            ListCounter++;
                        }
                    }
                }
            }            

            //return the new list of movie / series data to the user.
            return tempInfo;

        }

        /// <summary>
        /// Checks a single movie / series to see if it exists in the database. Returns a bool true if found, and false if it doesn't exist.
        /// </summary>
        /// <param name="MovieSeriesName"></param>
        /// <returns></returns>
        public bool WatchedBefore(string MovieSeriesName)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["SeenITMovieTV.Database.SeenITDatabase"].ConnectionString;

            //Used to see if the movie / series exists in the database. Its value will be replaced with any found movie Id.
            int MovieFound = 0;

            string query = "SELECT m.Id FROM MovieSeriesTable m INNER JOIN UserMovieAssociationTable uma ON m.Id = uma.MovieSeriesId AND uma.UserId = '"+UserId+"' WHERE m.Name = '"+MovieSeriesName+"'; ";

            using (this.SqlCon = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, SqlCon))
            {
                SqlCon.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //If a movie / series is found pull its Id and store it in the local INT.
                            MovieFound = reader.GetInt32(0);
                        }
                    }
                }
            }

            //As movie / series Id start at 1, if this INT is anything other than 0 then a movie / series has been found so return true.
            if(MovieFound != 0)
            {
                return true;
            }

            //If the value of the INT is still 0 then no movie / series has been found so return false.
            return false;
        }

        /// <summary>
        /// Checks to see if the information input into the Log In View was correct. if a user is found matching those details then this function will return true.
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public bool GetUserLogin(string UserName)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["SeenITMovieTV.Database.SeenITDatabase"].ConnectionString;

            //This query will check for an Id matching the user credentials that are provided.
            string query = "SELECT u.Id, u.Name FROM UserTable u WHERE u.Name = '"+UserName+"'";

            using (this.SqlCon = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, SqlCon))
            {
                SqlCon.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //If found then the ID is stored in the private variable and so is the users Name.
                            UserId = reader.GetInt32(0);
                            this.UserName = reader.GetString(1);
                        }
                    }
                }
            }

            //As Ids begin at 1, if this value is not 0 then a user has been found so return true.
            if (UserId != 0)
            {
                return true;
            }
        
            //If the value is still 0 then return false as no user has been found.
            return false;
        }

        public List<string> RetrieveLostDetails(string Email)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["SeenITMovieTV.Database.SeenITDatabase"].ConnectionString;
            List<string> Details = new List<string>();

            string query = "SELECT u.Name, u.Password FROM UserTable u WHERE u.Email = '" + Email + "'";

            using (this.SqlCon = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, SqlCon))
            {
                SqlCon.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Details[0] = reader.GetString(0);
                            Details[1] = reader.GetString(1);
                        }
                    }
                }
            }

            return Details;
        }

        /// <summary>
        /// This method will take the details provided and create a new user. If a user already exists under the name provided then it will return false and let the user know by opening a message box. 
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public bool CreateUserLogin(string UserName, string Password, string Email)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["SeenITMovieTV.Database.SeenITDatabase"].ConnectionString;

            //Check if a user already exists by that name.
            bool AlreadyExists = GetUserLogin(UserName);

            //If no user exists then create one.
            if (AlreadyExists == false)
            {
                string query = "INSERT INTO USERTABLE (Name, Password, Email) OUTPUT INSERTED.ID VALUES (@Name, @Password, @Email)";

                using (this.SqlCon = new SqlConnection(ConnectionString))
                using (SqlCommand command = new SqlCommand(query, SqlCon))
                {
                    SqlCon.Open();

                    command.Parameters.AddWithValue("@Name", UserName);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@Email", Email);

                    //Once the user has been created store their Id in the application ready to be used.
                    UserId = (Int32)command.ExecuteScalar();
                    GetUserLogin(UserName);
                }

                if (UserId != 0)
                {
                    return true;
                }

                return false;
            }

            //If they do then throw an error.
            else
            {
                MessageBox.Show("Erorr, user already exists with this name");
                return false;
            }
        }

        /// <summary>
        /// Returns the highest Movie / Series from the database in the form of a list.
        /// </summary>
        /// <returns></returns>
        public List<string> GetHighestRatedMovieSeries()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["SeenITMovieTV.Database.SeenITDatabase"].ConnectionString;

            List<string> PictureANDTitle = new List<string>();
            string query = "SELECT m.CoverPictureURL, m.Name, m.PersonalRating FROM MovieSeriesTable m WHERE m.Id IN(SELECT uma.MovieSeriesId FROM UserMovieAssociationTable uma WHERE uma.UserId = '"+UserId+"') ORDER BY m.PersonalRating DESC";

            using (this.SqlCon = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, SqlCon))
            {
                SqlCon.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //Pull the CoverPicture URL, Name and Personal Rating and store them in a list of strings.
                            PictureANDTitle.Add(reader.GetString(0));
                            PictureANDTitle.Add(reader.GetString(1));
                            PictureANDTitle.Add(reader.GetString(2));
                        }
                    }
                }
            }

            //Return the list to the user.
            return PictureANDTitle;
        }

        /// <summary>
        /// retrieves a users personal comment and rating for a single movie / series. Returns it in a list of strings.
        /// </summary>
        /// <param name="MoveSeriesName"></param>
        /// <returns></returns>
        public List<string> GetpersonalDetails(string MoveSeriesName)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["SeenITMovieTV.Database.SeenITDatabase"].ConnectionString;

            List<string> RatingANDComment = new List<string>();
            string query = "SELECT m.PersonalRating, m.PersonalComment FROM MovieSeriesTable m WHERE m.Name = '"+ MoveSeriesName + "' AND m.Id IN(SELECT uma.MovieSeriesId FROM UserMovieAssociationTable uma WHERE uma.UserId = '" + UserId + "')";

            using (this.SqlCon = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, SqlCon))
            {
                SqlCon.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //Pull the Rating and the Comment and store it in a list to be returned.
                            RatingANDComment.Add(reader.GetString(0));
                            RatingANDComment.Add(reader.GetString(1));
                        }
                    }
                }
            }

            //Return it to the user.
            return RatingANDComment;
        }

        /// <summary>
        /// This method will take all information on a single movie / series and add it to the database.
        /// </summary>
        /// <param name="MovieSeriesName"></param>
        /// <param name="UserRating"></param>
        /// <param name="MetaScore"></param>
        /// <param name="PersonalRating"></param>
        /// <param name="PersonalComment"></param>
        /// <param name="IMDBLink"></param>
        /// <param name="RunTime"></param>
        /// <param name="Genres"></param>
        /// <param name="CoverPictureLocation"></param>
        public void InsertNewMovieSeries(string MovieSeriesName, string UserRating, string MetaScore, string PersonalRating, string PersonalComment, string IMDBLink, string RunTime, string Genres, string CoverPictureLocation)
        {
            //Add the movie / Series.
            AddMovieSeries(MovieSeriesName, UserRating, MetaScore, PersonalRating, PersonalComment, IMDBLink, RunTime, CoverPictureLocation);
            getUserDetails();

            //Update the movie to be associated with the user who added it.
            UpdateUserMovieAssociationTable();

            //Update the Genre association table to link all genres to the movie / series.
            UpdateGenreAssociation(Genres);
        }

        /// <summary>
        /// Will calcuate the total amount of time a user has spent watching movies / series and return it in the form of a double.
        /// </summary>
        /// <returns></returns>
        public double GetTotalRunTime()
        {
            //retrieve the current users Id.
            getUserDetails();

            double result = PullRunTimeUsingQuery();

            return result;
        }

        /// <summary>
        /// Will Calculate the amount of times a user has watched each genre and return the highest occuring genre type in the form of a string.
        /// </summary>
        /// <returns></returns>
        public string GetFavouriteGenre()
        {
            PullGenreTypes();
            PullGenreAmounts();
            return CalculateBestGenre();
        }

        /// <summary>
        /// Updates the genre to movie association table in the database. Should only be called once a movie / series has been added.
        /// </summary>
        /// <param name="Genres"></param>
        private void UpdateGenreAssociation(string Genres)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["SeenITMovieTV.Database.SeenITDatabase"].ConnectionString;

            List<string> result = Genres.Split('|').ToList();
            result.RemoveAt(result.Count-1);
            foreach(var genre in result)
            {
                
                int genreId = 0;
                string GenreQuery = "SELECT g.Id FROM GenreTable g WHERE g.Type = '" + genre + "'";

                using (this.SqlCon = new SqlConnection(ConnectionString))
                using (SqlCommand cmd = new SqlCommand(GenreQuery, SqlCon))
                {
                    SqlCon.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                //Get the Genre Id for each occuring genre type the user has watched.
                                genreId = reader.GetInt32(reader.GetOrdinal("Id"));
                            }
                        }
                    }
                }

                string query = "INSERT INTO MovieGenreAssociationTable (GenreId, MovieId) VALUES (@GID, @MID)";

                using (this.SqlCon = new SqlConnection(ConnectionString))
                using (SqlCommand command = new SqlCommand(query, SqlCon))
                {
                    SqlCon.Open();

                    //Update the association table with each found genreId to the known Movie / Series Id.
                    command.Parameters.AddWithValue("@GID", genreId);
                    command.Parameters.AddWithValue("@MID", MovieId);

                    command.ExecuteNonQuery();
                }
            }
            
        }

        /// <summary>
        /// Retreive the UserId by matching it with the known userName, this will be stored privately and not returned.
        /// </summary>
        private void getUserDetails()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["SeenITMovieTV.Database.SeenITDatabase"].ConnectionString;

            //Get userId and store it.
            string UserQuery = "SELECT u.Id FROM USERTABLE u WHERE u.Name = '" + UserName + "'";

            using (this.SqlCon = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(UserQuery, SqlCon))
            {
                SqlCon.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            UserId = reader.GetInt32(reader.GetOrdinal("Id"));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Will take all information given and use named parameters to store a single movie / series in the database.
        /// </summary>
        /// <param name="MovieSeriesName"></param>
        /// <param name="UserRating"></param>
        /// <param name="MetaScore"></param>
        /// <param name="PersonalRating"></param>
        /// <param name="PersonalComment"></param>
        /// <param name="IMDBLink"></param>
        /// <param name="RunTime"></param>
        /// <param name="CoverPictureLocation"></param>
        private void AddMovieSeries(string MovieSeriesName, string UserRating, string MetaScore, string PersonalRating, string PersonalComment, string IMDBLink, string RunTime, string CoverPictureLocation)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["SeenITMovieTV.Database.SeenITDatabase"].ConnectionString;

            string query = "INSERT INTO MOVIESERIESTABLE (Name, OfficialUserRating, OfficialMetaScore, PersonalRating, PersonalComment, URL, Runtime, CoverPictureURL) OUTPUT INSERTED.ID VALUES (@MovieSeriesName, @OfficialUserRating, @OfficialMetaScore, @PersonalRating, @PersonalComment, @URL, @Runtime, @CoverPictureURL)";

            using (this.SqlCon = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(query, SqlCon))
            {
                SqlCon.Open();

                command.Parameters.AddWithValue("@MovieSeriesName", MovieSeriesName);
                command.Parameters.AddWithValue("@OfficialUserRating", UserRating);
                command.Parameters.AddWithValue("@OfficialMetaScore", MetaScore);
                command.Parameters.AddWithValue("@PersonalRating", PersonalRating);
                command.Parameters.AddWithValue("@PersonalComment", PersonalComment);
                command.Parameters.AddWithValue("@URL", IMDBLink);
                command.Parameters.AddWithValue("@Runtime", RunTime);
                command.Parameters.AddWithValue("@CoverPictureURL", CoverPictureLocation);

                MovieId = (Int32)command.ExecuteScalar();
            }
        }

        /// <summary>
        /// Updates the user to movie/series Association table. Should only be called once a movie has been added by a user.
        /// </summary>
        private void UpdateUserMovieAssociationTable()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["SeenITMovieTV.Database.SeenITDatabase"].ConnectionString;

            //Use the created query to update the association table, find the query in the SeenITMovieTV Folder.
            string query = "INSERT INTO USERMOVIEASSOCIATIONTABLE (UserId, MovieSeriesId) VALUES (@UID, @MID)";

            using (this.SqlCon = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(query, SqlCon))
            {
                SqlCon.Open();

                command.Parameters.AddWithValue("@UID", UserId);
                command.Parameters.AddWithValue("@MID", MovieId);

                int rowsAdded = command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// retrieves the genreTable and stores it in a list of strings.
        /// </summary>
        private void PullGenreTypes()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["SeenITMovieTV.Database.SeenITDatabase"].ConnectionString;

            for (int i = 1; i <= 27; i++)
            {
                string query = "SELECT g.Id, g.Type FROM GenreTable g WHERE g.Id = '"+i+"'";
                
                using (this.SqlCon = new SqlConnection(ConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, SqlCon))
                {
                    SqlCon.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                GenreTypes.Add(reader.GetInt32(0), reader.GetString(1));
                                break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checks for each genre type that has been watched and calculates which one has been watched the most. Returns it in the form of a string.
        /// </summary>
        /// <returns></returns>
        private string CalculateBestGenre()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["SeenITMovieTV.Database.SeenITDatabase"].ConnectionString;

            int MostOccuringGenreId = 0;
            int HighestScore = 0;
            string MostWatchedGenre = string.Empty;

            foreach(var occurance in GenreAmount)
            {
                if(occurance.Value > HighestScore)
                {
                    HighestScore = occurance.Value;
                    MostOccuringGenreId = occurance.Key;
                }
            }

            GenreTypes.TryGetValue(MostOccuringGenreId, out MostWatchedGenre);

            return MostWatchedGenre;
        }

        /// <summary>
        /// Function which stores how many times a user has watched each genre.
        /// </summary>
        private void PullGenreAmounts()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["SeenITMovieTV.Database.SeenITDatabase"].ConnectionString;

            for (int i = 1; i <= 27; i++)
            {
                //TODO: FIX QUERY TO WORK WITH MULTIPLE USERS: So far the issue is how to join on to the two tables using the MovieSeriesId and GenreId, See the stored query for correct SQL answer and try convert it to C#!
                string query = 
                    "SELECT Count(g.Type) FROM GenreTable g JOIN MovieGenreAssociationTable AS gma ON (gma.GenreId = '" + i + "') JOIN UserMovieAssociationTable AS uma ON (uma.MovieSeriesId = '2') WHERE uma.UserId = '" + UserId + "' GROUP BY g.Type, g.Id HAVING COUNT(g.Type) > 0";

                using (this.SqlCon = new SqlConnection(ConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, SqlCon))
                {
                    SqlCon.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                GenreAmount.Add(i, reader.GetInt32(0));
                                break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// retrieves the total amount of time spent watching movie / series as a double.
        /// </summary>
        /// <returns></returns>
        private double PullRunTimeUsingQuery()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["SeenITMovieTV.Database.SeenITDatabase"].ConnectionString;

            List<string> RunTimeInformation = new List<string>();

            //Get userId and store it.
            string UserQuery = "SELECT m.Runtime FROM MovieSeriesTable m WHERE m.Id in (SELECT ms.MovieSeriesId FROM UserMovieAssociationTable ms WHERE ms.UserId = '" + UserId + "');";

            using (this.SqlCon = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(UserQuery, SqlCon))
            {
                SqlCon.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            RunTimeInformation.Add(reader.GetString(0));
                        }
                    }
                }
            }

            double result = 0;
            Regex rgx = new Regex("[^0-9-]");

            foreach (var time in RunTimeInformation)
            {
                string temp = rgx.Replace(time, "");
                temp = temp.Insert(1, ".");
                result = result + Convert.ToDouble(temp);
            }

            return result;
        }
    }
}
