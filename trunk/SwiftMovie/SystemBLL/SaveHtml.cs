using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SPUtility;

namespace SystemBLL
{
    public class SaveHtml
    {
        public static bool saveHtmls()
        {
            string htmlUrlFile = @"F:\lily\TextCache\HtmlURLs.txt";
            string[] htmlURLs = File.ReadAllLines(htmlUrlFile);
            bool success = false;
            foreach (string url in htmlURLs)
            {
                success=TextServer.saveText(TextServer.fileName(url), HtmlServer.getResponse(url));
                string cinemaURL = url + "comingsoon.html";
                success = TextServer.saveText(TextServer.fileName(cinemaURL), HtmlServer.getResponse(cinemaURL));
                cinemaURL = url + "info.html";
                success = TextServer.saveText(TextServer.fileName(cinemaURL), HtmlServer.getResponse(cinemaURL));
                cinemaURL = url + "discount.html";
                success = TextServer.saveText(TextServer.fileName(cinemaURL), HtmlServer.getResponse(cinemaURL));
            }
            return success;
        }
    }
}
