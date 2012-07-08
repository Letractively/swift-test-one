using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using Model;
using SpiderDAL;


namespace SystemBLL
{
    public class SavePlay
    {
        public bool savePlays()
        {
            bool success = false;
            PlaySpider ps = new PlaySpider();
            IDAL.IPlay playDAL = DALFactory.DataAccess.createDalPlay();
            string cinemaURL = @"F:\lily\TextCache\Cinema\" ;
            string[] cineFiles = Directory.GetDirectories(cinemaURL);
            if (cineFiles != null)
            {
                foreach (string cineFile in cineFiles)
                {
                    Match match = Regex.Match(cineFile, @"\d\d\d\d");
                    string srtID = match.Value;
                    string playURL = cineFile + "\\" + srtID + ".txt";
                    //string playHtml = File.ReadAllText(playURL);

                    List<Play> plays = new List<Play>();
                    plays = ps.getPlays(playURL);
                    if (plays == null)
                    {
                        continue;
                    }
                    foreach (Play play in plays)
                    {
                        if (!playDAL.getPlayById(play.PlayID))
                        {
                            success = playDAL.addNewPlay(play);
                        }
                    }
                }
            }
            return success;
        }
    }
}
