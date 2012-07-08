using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Model;
using SpiderDAL;

namespace SystemBLL
{
    class SavePlayTime
    {
        public bool savePlayTime()
        {
            bool success = false;
            PlayTimeSpider pts = new PlayTimeSpider();
            IDAL.IPlayTime playTimeDAL = DALFactory.DataAccess.createDalPlayTime();
            string cineUrl = @"F:\lily\TextCache\Cinema\";
            string[] cineFiles = Directory.GetDirectories(cineUrl);
            if (cineFiles != null)
            {
                foreach (string cineFile in cineFiles)
                {
                    string playTimeURL = cineFiles + "\\" + "comingsoon.txt";
                    List<PlayTime> playTimes = pts.getPlayTimes(playTimeURL);
                    foreach (PlayTime playTime in playTimes)
                    {
                        if (playTimeDAL.getPlayTimeList(playTime.MovieID, playTime.CinemaID) == null)
                        {
                            success = playTimeDAL.addNewPlaytime(playTime);
                        }
                    }
                }
            }
            return success;
        }
    }
}
