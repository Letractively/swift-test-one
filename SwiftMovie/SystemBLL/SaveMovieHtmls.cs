using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SPUtility;

namespace SystemBLL
{
    public class SaveMovieHtmls
    {
        public static bool saveMovies()
        {
            string htmlUrlFile = @"F:\lily\TextCache\movieURLs.txt";
            string[] htmlURLs = File.ReadAllLines(htmlUrlFile);
            bool success = false;
            foreach (string url in htmlURLs)
            {
                success = TextServer.saveText(TextServer.fileName(url),HtmlServer.getResponse(url));
            }
            return success;
        }
    }
}
