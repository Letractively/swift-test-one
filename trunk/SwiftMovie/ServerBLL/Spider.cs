using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Winista.Text.HtmlParser;
using Winista.Text.HtmlParser.Filters;
using Winista.Text.HtmlParser.Lex;
using Winista.Text.HtmlParser.Nodes;
using Winista.Text.HtmlParser.Tags;
using Winista.Text.HtmlParser.Util;

namespace ServerBLL
{
    public class Spider
    {
        /// <summary>
        /// 读取本地的html文件
        /// </summary>
        /// <param name="url">本地文件的url</param>
        /// <returns>Parser类型，用于进一步处理</returns>
        public static string getHtml(string url)
        {
            string html = File.ReadAllText(url);
            //Lexer lexer = new Lexer(html);
            //Parser parser = new Parser(lexer);
            return html;
        }
        /// <summary>
        /// 获取目标数据
        /// </summary>
        /// <param name="parser">目标html文件</param>
        /// <param name="tag">标签名称</param>
        /// <param name="attribute">标签里面的属性名称</param>
        /// <param name="attValue">属性的值</param>
        /// <returns>标签内的目标数据</returns>
        public static string getValue(string html, string tag, string attribute, string attValue)
        {
            Lexer lexer = new Lexer(html);
            Parser parser = new Parser(lexer);
            string value = string.Empty;
            NodeFilter nodeFilter = new TagNameFilter(tag);
            NodeList nodeList = parser.Parse(nodeFilter);
            for (int i = 0; i < nodeList.Count; i++)
            {
                INode node = nodeList[i];
                ITag tagNode = (node as ITag);
                if (tagNode.Attributes != null && tagNode.Attributes.Count > 0)
                {
                    foreach (string key in tagNode.Attributes.Keys)
                    {
                        if (key.Contains("<TAGNAME>")) 
                        {
                            continue;
                        }
                        if (key.Contains(attribute))
                        {
                            if (tagNode.Attributes[key].ToString() == attValue)
                            {
                                value = tagNode.ToPlainTextString();
                                return value;
                            }
                        }
                    }
                }
            }
            return null;
        }

        public static string getAttValue(string html, string tag, string attribute, string attValue,string attributeV)
        {
            Lexer lexer = new Lexer(html);
            Parser parser = new Parser(lexer);
            string value = string.Empty;
            NodeFilter nodeFilter = new TagNameFilter(tag);
            NodeList nodeList = parser.ExtractAllNodesThatMatch(nodeFilter);
            for (int i = 0; i < nodeList.Count; i++)
            {
                INode node = nodeList[i];
                ITag tagNode = (node as ITag);
                if (tagNode.Attributes != null && tagNode.Attributes.Count > 0)
                {
                    foreach (string key in tagNode.Attributes.Keys)
                    {
                        if (key.Contains("<TAGNAME>"))
                        {
                            continue;
                        }
                        if (key.Contains(attribute))
                        {
                            if (tagNode.Attributes[key].ToString() == attValue)
                            {
                                value = tagNode.Attributes[attributeV].ToString();
                                return value;
                            }
                        }
                    }
                }
            }
            return null;
        }

        public static List<string> getValues(string html, string tag, string attribute, string attValue)
        {
            Lexer lexer = new Lexer(html);
            Parser parser = new Parser(lexer);
            string value = string.Empty;
            List<string> values = new List<string>();
            NodeFilter nodeFilter = new TagNameFilter(tag);
            NodeList nodeList = parser.Parse(nodeFilter);
            for (int i = 0; i < nodeList.Count; i++)
            {
                INode node = nodeList[i];
                ITag tagNode = (node as ITag);
                if (tagNode.Attributes != null && tagNode.Attributes.Count > 0)
                {
                    foreach (string key in tagNode.Attributes.Keys)
                    {
                        if (key.Contains("<TAGNAME>"))
                        {
                            continue;
                        }
                        if (key.Contains(attribute))
                        {
                            if (tagNode.Attributes[key].ToString() == attValue)
                            {
                                value = tagNode.ToPlainTextString();
                                values.Add(value);
                            }
                        }
                    }
                }
            }
            return values;
        }
    }
}
