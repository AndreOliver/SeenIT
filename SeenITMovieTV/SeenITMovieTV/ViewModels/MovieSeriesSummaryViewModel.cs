using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using SeenITMovieTV.Views;
using SeenITMovieTV.UserControls;
using System.Text.RegularExpressions;

namespace SeenITMovieTV.ViewModels
{
    class MovieSeriesSummaryViewModel
    {
        private string URL;
        private bool TV;

        private MovieSeriesSummaryFormView SummaryFormHandle;
        private ucMovieSeriesInfo ucMovieSeriesInfoHandle;

        bool ControlAdded = false;

        public void DisplayInformation(string MovieSeriesURL, bool ReadOnlyView)
        {
            
            URL = MovieSeriesURL;
            SummaryFormHandle = MovieSeriesSummaryFormView.GetSummaryFormView;
            ucMovieSeriesInfoHandle = ucMovieSeriesInfo.GetUC;
            CreateUCMovieSeriesInfo();
            UpdateUCMovieSeriesInfo();
            ucMovieSeriesInfoHandle.MakeReadyOnly(ReadOnlyView);

        }

        public void CreateUCMovieSeriesInfo()
        {
            if (ControlAdded == false)
            {
                SummaryFormHandle.Controls.Add(ucMovieSeriesInfoHandle);
                SummaryFormHandle.Controls[4].Location = new System.Drawing.Point(0, 120);
                ControlAdded = true;
            }
        }

        public void UpdateUCMovieSeriesInfo()
        {
            //Use Web scraping to set all the information for the movie / series.
            if (URL == string.Empty)
            {
                return;
            }

            HtmlWeb website = new HtmlWeb();
            HtmlDocument doc = website.Load(URL);

            //IMDB_LINKdd
            ucMovieSeriesInfoHandle.IMDB_Link = URL;

            //Title Name.
            try
            {
                var TitleLocation = doc.DocumentNode.SelectSingleNode("//*[@id='title-overview-widget']/div[2]/div[2]/div/div[2]/div[2]/h1/text()");
                string Title = TitleLocation.InnerText;
                Title = Title.Split('&', ';')[0];
                SummaryFormHandle.Title = Title;
            }
            catch
            {
                SummaryFormHandle.Title = "Not Yet Released";
            }

            //Release Year.
            try
            {
                var ReleaseYearLocation = doc.DocumentNode.SelectSingleNode("//*[@id='title-overview-widget']/div[2]/div[2]/div/div[2]/div[2]/div/a[4]");
                TV = false;
                if (ReleaseYearLocation == null)
                {
                    TV = true;
                    ReleaseYearLocation = doc.DocumentNode.SelectSingleNode("//*[@id='title-overview-widget']/div[2]/div[2]/div/div[2]/div[2]/div/a[3]");
                    if(ReleaseYearLocation == null)
                    {
                        ReleaseYearLocation = doc.DocumentNode.SelectSingleNode("//*[@id='title-overview-widget']/div[2]/div[2]/div/div[2]/div[2]/div/a[2]");
                    }
                }

                ucMovieSeriesInfoHandle.ReleaseDate = ReleaseYearLocation.InnerText;
            }
            catch
            {
                TV = false;
                var ReleaseYearLocation = doc.DocumentNode.SelectSingleNode("//*[@id='titleYear']/a");

                ucMovieSeriesInfoHandle.ReleaseDate = ReleaseYearLocation.InnerText;
            }

            //Cover Image
            try
            {
                var CoverLocation = doc.DocumentNode.SelectSingleNode("//*[@id='title-overview-widget']/div[2]/div[3]/div[1]/a/img");
                if(CoverLocation == null)
                {
                    TV = true;
                }
                else
                {
                    TV = false;
                }
                if (TV == true || CoverLocation == null)
                {
                    CoverLocation = doc.DocumentNode.SelectSingleNode("//*[@id='title-overview-widget']/div[2]/div[4]/div[1]/a/img");
                }
                
                string Location = CoverLocation.OuterHtml.ToString();
                Location = Location.Split('"', '"').Where((item, index) => index % 2 != 0).ToList()[2];
                ucMovieSeriesInfoHandle.CoverImageLocation = Location;
            }
            catch{ }           

            //User Rating.
            try
            {
                var UserRatingLocation = doc.DocumentNode.SelectSingleNode("//*[@id='title-overview-widget']/div[2]/div[2]/div/div[1]/div[1]/div[1]/strong/span");
                ucMovieSeriesInfoHandle.UserRating = (UserRatingLocation.InnerText + "/10");
            }
            catch
            {
                ucMovieSeriesInfoHandle.UserRating = "Unknown";
            }

            //Metascore.
            try
            {
                var MetascoreLocation = doc.DocumentNode.SelectSingleNode("//*[@id='title-overview-widget']/div[3]/div[2]/div[1]/a/div");
                var Metascore = MetascoreLocation.InnerText;
                Metascore = Regex.Replace(Metascore, @"\t|\n|\r", "");
                ucMovieSeriesInfoHandle.MetaScore = (Metascore + "/100");
            }
            catch
            {
                ucMovieSeriesInfoHandle.MetaScore = "Unknown";
            }

            //Popularity.
            try
            {
                var PopularityLocation = doc.DocumentNode.SelectSingleNode("//*[@id='title-overview-widget']/div[3]/div[2]/div[5]/div[2]/div[2]/span");

                //Movie Scenario.
                if (PopularityLocation == null)
                {
                    PopularityLocation = doc.DocumentNode.SelectSingleNode(" //*[@id='title-overview-widget']/div[3]/div[2]/div[3]/div[2]/div[2]/span");
                }

                var Popularity = PopularityLocation.InnerText;
                Popularity = Regex.Replace(Popularity, @"\t|\n|\r", "");
                Popularity = Popularity.TrimStart(' ');
                var PopRating = Popularity.FirstOrDefault();
                ucMovieSeriesInfoHandle.Popularity = PopRating.ToString();
            }
            catch
            {
                var PopularityLocation = doc.DocumentNode.SelectSingleNode("//*[@id='title-overview-widget']/div[3]/div[2]/div/div[2]/div[2]/span/text()[1]");
                if (PopularityLocation == null)
                {
                    PopularityLocation = doc.DocumentNode.SelectSingleNode("//*[@id='title-overview-widget']/div[3]/div[2]/div[3]/div[2]/div[2]/span/text()[1]");
                }
                if (PopularityLocation != null)
                {
                    var Popularity = PopularityLocation.InnerText;
                    Popularity = Regex.Replace(Popularity, @"\t|\n|\r", "");
                    Popularity = Popularity.TrimStart(' ');
                    var PopRating = Popularity.FirstOrDefault();
                    ucMovieSeriesInfoHandle.Popularity = PopRating.ToString();
                }
            }

            //RunTime.
            try
            {
                var RunTimeLocation = doc.DocumentNode.SelectSingleNode("//*[@id='title-overview-widget']/div[2]/div[2]/div/div[2]/div[2]/div/time");
                var RunTime = RunTimeLocation.InnerText;
                RunTime = Regex.Replace(RunTime, @"\t|\n|\r", "");
                RunTime = RunTime.Replace(" ", string.Empty);
                ucMovieSeriesInfoHandle.Runtime = RunTime;
            }
            catch
            {
                ucMovieSeriesInfoHandle.Runtime = "Not Released";
            }

            //Genres.
            try
            {
                var GenresLocation = doc.DocumentNode.SelectNodes("//*[@id='title-overview-widget']/div[2]/div[2]/div/div[2]/div[2]/div/a");
                var genresSB = new StringBuilder();
                foreach(var node in GenresLocation)
                {
                    if (node.LastChild.Name == "span")
                    {
                        genresSB.Append(node.InnerText + "|");
                    }
                }

                ucMovieSeriesInfoHandle.Genres = genresSB.ToString();
            }
            catch { }

            //Similar Movie/Series.
            try
            {
                Random rndSimilar = new Random(Guid.NewGuid().GetHashCode());
                int similar = rndSimilar.Next(1, 5);

                var SimilarMovieSeries = doc.DocumentNode.SelectSingleNode("//*[@id='title_recs']/div[1]/div/div[2]/div[1]/div[" + similar + "]/a");
                var MovieSeriesLink = SimilarMovieSeries.OuterHtml;
                var MovieSeriesLinkFound = MovieSeriesLink.Split('"', '"').Where((item, index) => index % 2 != 0).ToList()[0];
                //TODO: Similar IMDBLINK ucMovieSeriesInfoHandle.IMDB_Link = MovieSeriesLinkFound;

                var MovieSeriesCoverImage = MovieSeriesLink.Split('"', '"').Where((item, index) => index % 2 != 0).ToList()[7];
                MovieSeriesCoverImage = Regex.Replace(MovieSeriesCoverImage, "._V1_UY113_CR0,0,76,113_AL_.jpg", "._V1_UX182_CR0,0,182,268_AL_.jpg");
                ucMovieSeriesInfoHandle.SimilarMovieSeriesImg = MovieSeriesCoverImage;
            }
            catch { }
        }
    }
}
