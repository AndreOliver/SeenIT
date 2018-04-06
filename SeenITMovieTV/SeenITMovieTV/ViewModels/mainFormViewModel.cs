using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeenITMovieTV.DataObjects;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SeenITMovieTV.Views;

namespace SeenITMovieTV.ViewModels
{
    class mainFormViewModel
    {
        static readonly Regex trimmer = new Regex(@"\s\s+");
        ProfileView ProfileHandle;
        mainFormView Mainhandle;

        public List<MovieTVInformation> SearchClicked(string searchCriteria)
        {
            List<MovieTVInformation> AllFoundMovies = new List<MovieTVInformation>();
            string MovieSeriesToFind = string.Empty;

            HtmlWeb website = new HtmlWeb();
            
            MovieSeriesToFind = "https://www.imdb.com/find?q=" + searchCriteria + "&s=tt&ref_=fn_al_tt_mr";

            HtmlAgilityPack.HtmlDocument doc = website.Load(MovieSeriesToFind);
            List<HtmlNode> MovieSeriesFoundNode = new List<HtmlNode>();

            try
            {
                MovieSeriesFoundNode = doc.DocumentNode.SelectNodes("//*[@id='main']/div/div[2]/table/tr").ToList();
            }
            catch
            {
                MessageBox.Show("No Results Found");
            }

            for (int i = 0; i < MovieSeriesFoundNode.Count; i++)
            {
                AllFoundMovies.Add(new MovieTVInformation());
            }

            Parallel.ForEach(MovieSeriesFoundNode, (node, state, counter) =>
            {
                var input = node.InnerHtml;
                var output = input.Split('"', '"').Where((item, index) => index % 2 != 0).ToList();

                //Name.
                var TempName = node.InnerText;
                TempName = AdjustName(TempName, Convert.ToInt32(counter));
                AllFoundMovies[Convert.ToInt32(counter)].Name = TempName;

                //CoverPhoto Image.
                var TempImg = output[2];
                TempImg = AdjustImage(TempImg);
                AllFoundMovies[Convert.ToInt32(counter)].CoverPictureLink = TempImg;

                //IMDB Link.
                var TempLink = output[1];
                TempLink = ("www.imdb.com" + TempLink);
                AllFoundMovies[Convert.ToInt32(counter)].IMDBLink = TempLink;
                
            });

            return AllFoundMovies;
        }

        public int ProfileClicked()
        {
            ProfileHandle = ProfileView.GetProfileFormView;
            ProfileHandle.SetHandle = Mainhandle;
            Mainhandle.Hide();
            ProfileHandle.Show();

            return 0;
        }

        public mainFormViewModel(mainFormView handle)
        {
            Mainhandle = handle;
        }

        public List<MovieTVInformation> ViewMovies()
        {
            List<MovieTVInformation> AllFoundMovies = new List<MovieTVInformation>();
            HtmlWeb website = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = website.Load("http://www.imdb.com/chart/moviemeter"); 

            var MovieNodes = doc.DocumentNode.SelectNodes("//*[@id='main']/div/span/div/div/div[3]/table/tbody/tr").ToList();

            for (int i = 0; i < MovieNodes.Count; i++)
            {
                AllFoundMovies.Add(new MovieTVInformation());
            }

            Parallel.ForEach(MovieNodes, (node, state, counter) =>
            {
                var input = node.InnerHtml;
                var output = input.Split('"', '"').Where((item, index) => index % 2 != 0).ToList();

                //Name.
                var TempName = node.InnerText;
                TempName = AdjustName(TempName, Convert.ToInt32(counter));
                AllFoundMovies[Convert.ToInt32(counter)].Name = TempName;

                //CoverPhoto Image.
                var TempImg = output[12];
                TempImg = AdjustImage(TempImg);
                AllFoundMovies[Convert.ToInt32(counter)].CoverPictureLink = TempImg;

                //IMDB Link.
                var TempLink = output[11];
                TempLink = ("www.imdb.com" + TempLink);
                AllFoundMovies[Convert.ToInt32(counter)].IMDBLink = TempLink;
            });

            return AllFoundMovies;
        }

        public List<MovieTVInformation> ViewSeries()
        {           
            List<MovieTVInformation> AllFoundSeries = new List<MovieTVInformation>();
            HtmlWeb website = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = website.Load("http://www.imdb.com/chart/tvmeter");

            var SeriesNodes = doc.DocumentNode.SelectNodes("//*[@id='main']/div/span/div/div/div[3]/table/tbody/tr").ToList();

            for (int i = 0; i < SeriesNodes.Count; i++)
            {
                AllFoundSeries.Add(new MovieTVInformation());
            }

            Parallel.ForEach(SeriesNodes, (node, state, counter) =>
            {
                var input = node.InnerHtml;
                var output = input.Split('"', '"').Where((item, index) => index % 2 != 0).ToList();

                //Name.
                var TempName = node.InnerText;
                TempName = AdjustName(TempName, Convert.ToInt32(counter));
                AllFoundSeries[Convert.ToInt32(counter)].Name = TempName;

                //CoverPhoto Image.
                var TempImg = output[12];
                TempImg = AdjustImage(TempImg);
                AllFoundSeries[Convert.ToInt32(counter)].CoverPictureLink = TempImg;

                //IMDB Link.
                var TempLink = output[11];
                TempLink = ("www.imdb.com" + TempLink);
                AllFoundSeries[Convert.ToInt32(counter)].IMDBLink = TempLink;
            });

            return AllFoundSeries;
        }

        private string AdjustImage(string URL)
        {
            var tempURL = URL;
            int index = tempURL.IndexOf("._");
            if (index > 0)
                tempURL = tempURL.Substring(tempURL.LastIndexOf("._"));

            switch (tempURL)
            {
                case "._V1_UX45_CR0,0,45,67_AL_.jpg":
                    URL = Regex.Replace(URL, "._V1_UX45_CR0,0,45,67_AL_.jpg", "._V1_UX182_CR0,0,182,268_AL_.jpg");
                    break;

                case "._V1_UY67_CR0,0,45,67_AL_.jpg":
                    URL = Regex.Replace(URL, "._V1_UY67_CR0,0,45,67_AL_.jpg", "._V1_UX182_CR0,0,182,268_AL_.jpg");
                    break;

                case "._V1_UY67_CR1,0,45,67_AL_.jpg":
                    URL = Regex.Replace(URL, "._V1_UY67_CR1,0,45,67_AL_.jpg", "._V1_UY268_CR3,0,182,268_AL_.jpg");
                    break;

                case "._V1_UY67_CR37,0,45,67_AL_.jpg":
                    URL = Regex.Replace(URL, "._V1_UY67_CR37,0,45,67_AL_.jpg", "._V1_UY268_CR147,0,182,268_AL_.jpg");
                    break;

                case "._V1_UY67_CR2,0,45,67_AL_.jpg":
                    URL = Regex.Replace(URL, "._V1_UY67_CR2,0,45,67_AL_.jpg", "._V1_UY268_CR8,0,182,268_AL_.jpg");
                    break;

                case "._V1_UY67_CR6,0,45,67_AL_.jpg":
                    URL = Regex.Replace(URL, "._V1_UY67_CR6,0,45,67_AL_.jpg", "._V1_UY268_CR24,0,182,268_AL_.jpg");
                    break;

                case "._V1_UY67_CR3,0,45,67_AL_.jpg":
                    URL = Regex.Replace(URL, "._V1_UY67_CR3,0,45,67_AL_.jpg", "._V1_UY268_CR11,0,182,268_AL_.jpg");
                    break;

                case "._V1_UX32_CR0,0,32,44_AL_.jpg":
                    URL = Regex.Replace(URL, "._V1_UX32_CR0,0,32,44_AL_.jpg", "._V1_UX182_CR0,0,182,268_AL_.jpg");
                    break;

                default:
                    break;
            }

            return URL;
        }

        private string AdjustName(string name, int placement)
        {
            name = name.TrimStart();
            name = name.TrimEnd();
            name = name.Replace("\n", string.Empty);
            int index = name.LastIndexOf("(");
            if (index > 0)
            {
                name = name.Substring(0, index);
            }

            name = trimmer.Replace(name, " ");
            name = name.Remove(name.Length - 1);
            if (placement > 8)
            {
                name = name.Remove(name.Length - 1);
            }

            return name;
        }
    }
}