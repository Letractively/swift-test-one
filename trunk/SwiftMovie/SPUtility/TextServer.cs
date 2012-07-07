using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace SPUtility
{
    public class TextServer
    {
        public static string fileName(string name)
        {
            string cinema = "cinema";
            string comingsoon = "comingsoon";
            string info = "info.html";
            string discount = "discount.html";
            if (name.Length < 40)//为电影的URL
            {
                string a = name.Remove(0, 23);
                string b = a.TrimEnd('/');
                string fileName = @"F:\lily\TextCache\movie" + "\\" + b + ".txt";
                return fileName;
            }
            else if (Regex.IsMatch(name, cinema, RegexOptions.IgnoreCase))
            {
                string fileName = @"F:\lily\TextCache\Cinema.txt";
                return fileName;
            }
            else if (Regex.IsMatch(name, comingsoon, RegexOptions.IgnoreCase))
            {
                string path = @"\d\d\d\d";
                Match match = Regex.Match(name, path);
                if (!Directory.Exists(@"F:\lily\TextCache\Cinema\" + match.Value))
                {
                    Directory.CreateDirectory(@"F:\lily\TextCache\Cinema\" + match.Value);
                }
                string fileName = @"F:\lily\TextCache\Cinema\" + match.Value + "\\comingsoon.txt";
                return fileName;
            }
            else if (Regex.IsMatch(name, info, RegexOptions.IgnoreCase))
            {
                string path = @"\d\d\d\d";
                Match match = Regex.Match(name, path);
                if (!Directory.Exists(@"F:\lily\TextCache\Cinema\" + match.Value))
                {
                    Directory.CreateDirectory(@"F:\lily\TextCache\Cinema\" + match.Value);
                }
                string fileName = @"F:\lily\TextCache\Cinema\" + match.Value + "\\info.txt";
                return fileName;
            }
            else if (Regex.IsMatch(name, discount, RegexOptions.IgnoreCase))
            {
                string path = @"\d\d\d\d";
                Match match = Regex.Match(name, path);
                if (!Directory.Exists(@"F:\lily\TextCache\Cinema\" + match.Value))
                {
                    Directory.CreateDirectory(@"F:\lily\TextCache\Cinema\" + match.Value);
                }
                string fileName = @"F:\lily\TextCache\Cinema\" + match.Value + "\\discount.txt";
                return fileName;
            }
            else
            {
                string path = @"\d\d\d\d";
                string fileName = @"F:\lily\TextCache\Cinema\";
                Match match = Regex.Match(name, path);
                if (!Directory.Exists(@"F:\lily\TextCache\Cinema\" + match.Value))
                {
                    Directory.CreateDirectory(@"F:\lily\TextCache\Cinema\" + match.Value);
                }
                if (match.Success)
                {
                    return fileName + match.Value + "\\" + match.Value + ".txt";
                }
                else
                    return null;
            }
        }
        public static bool saveText(string fileName, string text)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(text);
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            try
            {
                FileStream fs = File.Create(fileName);
                fs.Write(info, 0, info.Length);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
