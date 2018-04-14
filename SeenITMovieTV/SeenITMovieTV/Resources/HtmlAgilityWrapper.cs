using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace SeenITMovieTV.Resources
{
    /// <summary>
    /// Wrapper class for the HTML-Agility-Pack. To browse the custom functions of this class, see its source.
    /// </summary>
    class HtmlAgilityWrapper
    {
        public List<HtmlNode> SelectMultipleNodes(string URLToScrape, string XPath)
        {
            HtmlWeb Website = new HtmlWeb();

            HtmlDocument Document = Website.Load(URLToScrape);
            
            if(Document.ParsedText != string.Empty && Document.ParseErrors != null)
            {
                var Nodes = Document.DocumentNode.SelectNodes(XPath).ToList();

                return Nodes;
            }

            return null;
        }

        public HtmlNode SelectSingleNode(string URLToScrape, string XPath)
        {
            HtmlWeb Website = new HtmlWeb();

            HtmlDocument Document = Website.Load(URLToScrape);

            if (Document.ParsedText != string.Empty && Document.ParseErrors != null)
            {
                var Node = Document.DocumentNode.SelectSingleNode(XPath);

                return Node;
            }

            return null;
        }
    }
}
