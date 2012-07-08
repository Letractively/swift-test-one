using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Winista.Text.HtmlParser;
using Winista.Text.HtmlParser.Lex;
using Winista.Text.HtmlParser.Tags;
using Winista.Text.HtmlParser.Util;
using Winista.Text.HtmlParser.Filters;
using System.Text.RegularExpressions;
using System.IO;

namespace SpiderDAL
{
    public class PlaySpider:ISpider.IPlay
    {
        public List<Model.Play> getPlays(string xmlFile)
        {
            Match strCinema = Regex.Match(xmlFile, @"\d\d\d\d");
            string cinemaID = strCinema.Value;
            string html = File.ReadAllText(xmlFile);
            List<Model.Play> plays = new List<Model.Play>();
            Lexer lexer = new Lexer(html);
            Parser parser = new Parser(lexer);
            //获取影片列表的node
            string listAttribute = "METHOD";
            string listAttValue = "mdShowtime";
            NodeFilter movieListFilter = new HasAttributeFilter(listAttribute, listAttValue);
            NodeList movieNodeList = parser.ExtractAllNodesThatMatch(movieListFilter);
            if (movieNodeList.Count >= 1)
            {
                //获取每个电影的html
                for (int i = 0; i < movieNodeList.Count; i++)
                {
                    INode node = movieNodeList[i];
                    string movieHtml = node.ToHtml();
                    Lexer movieLexer = new Lexer(movieHtml);
                    Parser movieParser = new Parser(movieLexer);
                    //获取影片ID
                    NodeFilter idFilter = new HasAttributeFilter("CLASS", "c_000");
                    NodeList idNodes = movieParser.ExtractAllNodesThatMatch(idFilter);
                    string strID = string.Empty;
                    if (idNodes.Count >= 1)
                    {
                        ITag idTag = (idNodes[0] as ITag);
                        if (idTag.Attributes != null)
                        {
                            string str = idTag.Attributes["HREF"].ToString();
                            Match match = Regex.Match(str, @"\d\d\d\d\d\d");
                            if (match.Success)
                            {
                                strID = match.Value;//电影的ID
                            }
                            else
                            {
                                Match ma = Regex.Match(str, @"\d\d\d\d\d");
                                if (ma.Success)
                                {
                                    strID = ma.Value;
                                }
                            }
                            //strID = match.Value;//电影的ID
                        }
                    }
                    //获取影片播放时段列表
                    Lexer lexer2 = new Lexer(movieHtml);
                    Parser movieParser2 = new Parser(lexer2);
                    NodeFilter playFilter = new HasAttributeFilter("_TYPE", "expiry");
                    //NodeList playNodes = parser.ExtractAllNodesThatMatch(playFilter);
                    NodeList playNodes = movieParser2.ExtractAllNodesThatMatch(playFilter);
                    if (playNodes.Count >= 1)
                    {
                        for (int j = 0; j < playNodes.Count; j++)
                        {
                            Model.Play play = new Model.Play();
                            ITag playTag = (playNodes[j] as ITag);
                            if (playTag.Attributes != null)
                            {
                                play.CinemaID = int.Parse(cinemaID);
                                play.MovieID = int.Parse(strID);
                                play.PlayID = int.Parse(playTag.Attributes["SHOWTIMEID"].ToString());
                                string strTime = playTag.Attributes["TIME"].ToString();
                                if (strTime == null || strTime == "")
                                {
                                    continue;
                                }
                                strTime = strTime.Trim();
                                strTime = strTime.Remove(0, 10);
                                play.PlayName = strTime.Trim();
                                //ITag tag2 = (playTag.FirstChild as ITag);
                                //string strPrice = tag2.FirstChild.ToPlainTextString(); //playTag.FirstChild.FirstChild.ToPlainTextString();
                                string strPrice = playTag.FirstChild.NextSibling.FirstChild.NextSibling.ToPlainTextString();
                                if (strPrice != null&&strPrice!=""&&strPrice!=" ")
                                {
                                    strPrice = strPrice.Trim();
                                    strPrice = strPrice.Remove(0, 1);
                                    play.Price = float.Parse(strPrice);
                                }
                                else
                                {
                                    play.Price = 0f;
                                }
                                plays.Add(play);
                            }
                        }
                    }
                }
                return plays;
            }
            return null;
            //throw new NotImplementedException();
        }
    }
}
