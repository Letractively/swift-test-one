using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;

namespace SPUtility
{
    public class HtmlServer
    {
        public static string getResponse(string url)
        {
            string html = string.Empty;
            string encoding = string.Empty;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "get";
                request.ContentType = "text/html";
                //byte[] buffer = new byte[1024];
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                string line = string.Empty;
                while ((line = readStream.ReadLine()) != null)
                {
                    html += line;
                }
                receiveStream.Close();
                readStream.Close();
                return html;
            }
            catch
            {
                return "";
            }
        }
    }
}
