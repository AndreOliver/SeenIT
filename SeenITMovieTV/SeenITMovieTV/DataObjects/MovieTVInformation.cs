using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeenITMovieTV.DataObjects
{
    /// <summary>
    /// Custom Data type used to store information on a single movie / series.
    /// </summary>
    public class MovieTVInformation
    {
        //Name of the movie / tv series.
        public string Name { get; set; }

        //Stored in a string, link of cover picture used for thumbnail.
        public string CoverPictureLink { get; set; }

        //Link stored in a string to be used to scrape site.
        public string IMDBLink { get; set; }
    }
}
