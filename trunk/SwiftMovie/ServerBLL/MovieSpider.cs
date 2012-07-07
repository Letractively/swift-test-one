using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Winista.Text.HtmlParser;
using System.Text.RegularExpressions;

namespace ServerBLL
{
    public class MovieSpider
    {
        public int getMovieID(string url)
        { 
            string p = @"\d\d\d\d\d\d";
            Match match = Regex.Match(url, p);
            if (match.Success)
            {
                return int.Parse(match.Value);
            }
            return -1;
        }
        public string getMovieName(string html)
        {
            string tag = "span";
            string attribute = "PROPERTY";
            string value = "v:itemreviewed";
            return Spider.getValue(html, tag, attribute, value);
        }

        public string getCoverURL(string html)
        {
            string tag = "img";
            string attribute = "REL";
            string value = "v:image";
            string attributeV = "SRC";
            return Spider.getAttValue(html, tag, attribute, value, attributeV);
        }

        public string getDirector(string html)
        {
            string tag = "a";
            string attribute = "REL";
            string value = "v:directedBy";
            return Spider.getValue(html, tag, attribute, value);
        }

        public string getProtagonist(string html)
        {
            string tag = "a";
            string attribute = "REL";
            string attValue = "v:starring";
            string value = string.Empty;
            List<string> values = Spider.getValues(html, tag, attribute, attValue);
            for (int i = 0; i < values.Count; i++)
            {
                value += values[i];
            }
            return value;
        }

        public string getMovieType(string html)
        {
            string tag = "a";
            string attribute = "PROPERTY";
            string attValue = "v:genre";
            string value = string.Empty;

            List<string> values = Spider.getValues(html, tag, attribute, attValue);
            for (int i = 0; i < values.Count; i++)
            {
                value += values[i];
            }
            return value;
        }

        public DateTime getReleaseDate(string html)
        {
            string tag = "span";
            string attribute = "PROPERTY";
            string value = "v:initialReleaseDate";
            string attributeV = "CONTENT";

            string rele = Spider.getAttValue(html, tag, attribute, value, attributeV);
            return DateTime.Parse(rele);
        }

        public float getRunTime(string html)
        {
            string tag = "span";
            string attribute = "PROPERTY";
            string value = "v:runtime";
            string attributeV = "CONTENT";

            string strTime = Spider.getAttValue(html, tag, attribute, value, attributeV);
            char[] a = {'分','钟'};
            strTime = strTime.TrimEnd(a);
            return float.Parse(strTime);
        }
    }
}
