using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPUtility;
using System.Text.RegularExpressions;
using Winista.Text.HtmlParser.Filters;
using Winista.Text.HtmlParser.Lex;
using Winista.Text.HtmlParser.Tags;
using Winista.Text.HtmlParser.Util;
using Winista.Text.HtmlParser.Nodes;
using Winista.Text.HtmlParser;

namespace SpiderDAL
{
    public class CinemaSpider:ISpider.ICinemaSpider
    {
        public int getCinemaID(string url)
        {
            string p = @"\d\d\d\d";
            Match match = Regex.Match(url, p);
            return int.Parse(match.Value);
            //throw new NotImplementedException();
        }

        public string getCinemaName(string html)
        {
            string tag = "h2";
            string attribute = "CLASS";
            string attValue = "fl c_fff yahei px24 normal pt6 lh10";
            return Spider.getValue(html, tag, attribute, attValue);
            //throw new NotImplementedException();
        }

        public string getAddress(string html)
        {
            string tag = "dd";
            string attribute = "CLASS";
            string attValue = "mt9";
            return Spider.getValue(html, tag, attribute, attValue);
            //throw new NotImplementedException();
        }

        public string getCinemaMap(string html)
        {
            return null;
            //throw new NotImplementedException();
        }

        public string getCinemaTel(string html)
        {
            string tag = "dd";
            string attribute = "CLASS";
            string attValue = "mt6";
            return Spider.getValue(html, tag, attribute, attValue);
            //throw new NotImplementedException();
        }

        public float getCinemaGrade(string html)
        {
            //string tag = "dd";
            //string attribute = "CLASS";
            //string attValue = "total";
            //string left = Spider.getValue(html, tag, attribute, attValue);
            //string tag2 = "dd";
            //string attribute2 = "CLASS";
            //string attValue2 = "total2";
            //string right = Spider.getValue(html, tag2, attribute2, attValue2);
            //string grade = left + right;
            ////return float.Parse(grade);
            //return 1.1f;
            //throw new NotImplementedException();

            Lexer lexer = new Lexer(html);
            Parser parser = new Parser(lexer);
            NodeFilter nodeFilter = new HasAttributeFilter("CLASS", "point ml12 px18");
            NodeList nodeList = parser.ExtractAllNodesThatMatch(nodeFilter);
            if (nodeList.Count == 1)
            {
                INode node = nodeList[0];
                ITag tagLeft = (node.FirstChild as ITag);
                ITag tagRight = (node.LastChild as ITag);
                string left = tagLeft.ToPlainTextString();
                string right = tagRight.ToPlainTextString();
                string strGrade = left + right;
                return float.Parse(strGrade);
            }
            return 7.0f;
        }

        public string getPrivilege(string html)
        {
            string tag = "dd";
            string attribute = "CLASS";
            string attValue = "mt6 c_666";
            List<string> values = Spider.getValues(html, tag, attribute, attValue);
            string value = string.Empty;
            for (int i = 0; i < values.Count; i++)
            {
                value += values[i];
            }
            return value;
            //throw new NotImplementedException();
        }

        public string getVIP(string html)
        {
            string tag = "dd";
            string attribute = "CLASS";
            string attValue = "c_666";
            return Spider.getValue(html, tag, attribute, attValue);
            //throw new NotImplementedException();
        }

        //public string getDining(string html)
        //{

        //    throw new NotImplementedException();
        //}

        //public string getPark(string html)
        //{
        //    throw new NotImplementedException();
        //}

        //public string getGameCenter(string html)
        //{
        //    throw new NotImplementedException();
        //}

        //public string getIntro3D(string html)
        //{
        //    throw new NotImplementedException();
        //}

        //public string getIntroVIP(string html)
        //{
        //    throw new NotImplementedException();
        //}

        public string getIntroduce(string html)
        {
            string tag = "div";
            string attribute = "CLASS";
            string attValue = "c_666";
            return Spider.getValue(html, tag, attribute, attValue);
            //throw new NotImplementedException();
        }


        public bool getCinemaFive(string html, out string dining, out string park, out string gameCenter, out string intro3D, out string introVIP)
        {
            //string vip = string.Empty;
            //string html = File.ReadAllText(url);
            dining = string.Empty;
            park = string.Empty;
            gameCenter = string.Empty;
            intro3D = string.Empty;
            introVIP = string.Empty;
            Lexer lexer = new Lexer(html);
            Parser parser = new Parser(lexer);
            NodeFilter nodeFilter = new HasAttributeFilter("CLASS", "c_000");
            NodeList nodeList = parser.ExtractAllNodesThatMatch(nodeFilter);
            for (int i = 0; i < nodeList.Count; i++)
            {
                INode node = nodeList[i];
                ITag tagPar = (node.Parent as ITag);
                ITag tagSib = (node.PreviousSibling as ITag);
                if (tagSib.Attributes["CLASS"] != null)
                {
                    switch (tagSib.Attributes["CLASS"].ToString())
                    {
                        case "ico_cside1 mr12":
                            dining = tagPar.ToPlainTextString();
                            break;
                        case "ico_cside2 mr12":
                            park = tagPar.ToPlainTextString();
                            break;
                        case "ico_cside3 mr12":
                            gameCenter = tagPar.ToPlainTextString();
                            break;
                        case "ico_cside5 mr12":
                            intro3D = tagPar.ToPlainTextString();
                            break;
                        case "ico_cside7 mr12":
                            introVIP = tagPar.ToPlainTextString();
                            break;
                    }
                }
            }
            return true;
            //throw new NotImplementedException();
        }
    }
}
