using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Model;
using SpiderDAL;

namespace SystemBLL
{
    public class SavePlayTime
    {
        public bool savePlayTime()
        {
            bool success = false;
            PlayTimeSpider pts = new PlayTimeSpider();
            IDAL.IPlayTime playTimeDAL = DALFactory.DataAccess.createDalPlayTime();
            IDAL.IMovie movieDAL = DALFactory.DataAccess.createDalMovie();
            string cineUrl = @"F:\lily\TextCache\Cinema\";
            string[] cineFiles = Directory.GetDirectories(cineUrl);
            if (cineFiles != null)
            {
                foreach (string cineFile in cineFiles)
                {
                    string playTimeURL = cineFile + "\\" + "comingsoon.txt";
                    List<PlayTime> playTimes = new List<PlayTime>();
                    playTimes = pts.getPlayTimes(playTimeURL);
                    if (playTimes == null)
                    {
                        continue;
                    }
                    foreach (PlayTime playTime in playTimes)
                    {
                        if (!playTimeDAL.isExist(playTime.MovieID, playTime.CinemaID) )
                        {
                            if (!movieDAL.isExist(playTime.MovieID))
                            {
                                string movieURLs = @"F:\lily\TextCache\movieURLs.txt";
                                string htmlUrl = "http://movie.mtime.com/" + playTime.MovieID.ToString() + "/";
                                using (StreamWriter file = new StreamWriter(movieURLs, true))
                                {
                                    file.WriteLine(htmlUrl);
                                }
                                continue;
                            }
                            success = playTimeDAL.addNewPlaytime(playTime);
                        }
                    }
                }
            }
            return success;
        }
    }
}
