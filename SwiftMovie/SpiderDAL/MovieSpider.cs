using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISpider;
using System.Text.RegularExpressions;
using SPUtility;

namespace SpiderDAL
{
    public class MovieSpider:IMovieSpider
    {

        public int getMovieID(string url)
        {
            string p = @"\d\d\d\d\d\d";
            Match match = Regex.Match(url, p);
            if (match.Success)
            {
                return int.Parse(match.Value);
            }
            else
            {
                string a = @"\d\d\d\d\d";
                Match matchID = Regex.Match(url, a);
                if (matchID.Success)
                {
                    return int.Parse(matchID.Value);
                }
            }
            return -1;
            //throw new NotImplementedException();
        }

        public string getMovieName(string html)
        {
            string tag = "span";
            string attribute = "PROPERTY";
            string value = "v:itemreviewed";
            return Spider.getValue(html, tag, attribute, value);
            //throw new NotImplementedException();
        }

        public string getCoverURL(string html)
        {
            string tag = "img";
            string attribute = "REL";
            string value = "v:image";
            string attributeV = "SRC";
            return Spider.getAttValue(html, tag, attribute, value, attributeV);
            //throw new NotImplementedException();
        }

        public string getDirector(string html)
        {
            string tag = "a";
            string attribute = "REL";
            string value = "v:directedBy";
            return Spider.getValue(html, tag, attribute, value);
            //throw new NotImplementedException();
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
            //throw new NotImplementedException();
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
            //throw new NotImplementedException();
        }

        public DateTime getReleaseDate(string html)
        {
            string tag = "span";
            string attribute = "PROPERTY";
            string value = "v:initialReleaseDate";
            string attributeV = "CONTENT";

            string rele = Spider.getAttValue(html, tag, attribute, value, attributeV);
            string a = rele.Remove(0, 7);
            if (int.Parse(a) == 0)
            {
                rele = rele.Remove(6);
            }
            return DateTime.Parse(rele);
            //throw new NotImplementedException();
        }

        public string getRunTime(string html)
        {
            string tag = "span";
            string attribute = "PROPERTY";
            string value = "v:runtime";
            string attributeV = "CONTENT";

            return Spider.getAttValue(html, tag, attribute, value, attributeV);
            
            //throw new NotImplementedException();
        }
    }
}
