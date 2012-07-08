using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Model;
using System.IO;
using Winista.Text.HtmlParser;
using Winista.Text.HtmlParser.Filters;
using Winista.Text.HtmlParser.Lex;
using Winista.Text.HtmlParser.Tags;
using Winista.Text.HtmlParser.Util;

namespace SpiderDAL
{
    public class PlayTimeSpider
    {
        public List<PlayTime> getPlayTimes(string xmlFile)
        {
            Match match = Regex.Match(xmlFile, @"\d\d\d\d");
            string cinemaID = match.Value;//电影院的ID
            List<PlayTime> playTimes = new List<PlayTime>();
            string html = File.ReadAllText(xmlFile);

            Lexer lexer = new Lexer(html);
            Parser playParser = new Parser(lexer);
            NodeFilter playFilter = new HasAttributeFilter("CLASS", "px14");
            NodeList playTimeList = playParser.ExtractAllNodesThatMatch(playFilter);
            if (playTimeList.Count >= 1)
            {
                for (int i = 0; i < playTimeList.Count; i++)
                {
                    PlayTime playTime = new PlayTime();
                    ITag playTag = (playTimeList[i] as ITag);
                    ITag idTag = (playTag.FirstChild as ITag);
                    if (idTag.Attributes != null)
                    {
                        string strID = idTag.Attributes["HREF"].ToString();
                        Match idMatch = Regex.Match(strID, @"\d\d\d\d\d\d");
                        if (idMatch.Success)
                        {
                            playTime.MovieID = int.Parse(idMatch.Value);
                        }
                        else
                        {
                            Match strMatch = Regex.Match(strID, @"\d\d\d\d\d");
                            if (strMatch.Success)
                            {
                                playTime.MovieID = int.Parse(strMatch.Value);
                            }
                        }
                        
                    }
                    string strTime = playTag.NextSibling.NextSibling.ToPlainTextString();
                    char[] a = {'上','映'};
                    strTime = strTime.Trim(a);
                    playTime.Playtime = DateTime.Parse(strTime);
                    playTime.CinemaID = int.Parse(cinemaID);
                    playTime.PlayState = true;

                    playTimes.Add(playTime);
                }
                return playTimes;
            }
            return null;
        }
    }
}
