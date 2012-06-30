using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace IDAL
{
    public interface IPlayTime
    {
        List<PlayTime> getPlayTimeList();
        List<PlayTime> getPlayTimeList(int movieID, int cinemaID);
        bool addNewPlaytime(PlayTime playTime);
        /// <summary>
        /// 删除上映时间段
        /// </summary>
        /// <param name="playTimeID">上映时间段ID</param>
        /// <returns>删除成功为true，否则flase</returns>
        bool removePlaytimeByplayTimeID(int playTimeID);
        /// <summary>
        /// 删除上映时间段
        /// </summary>
        /// <param name="movieID">上映电影的ID</param>
        /// <returns>删除成功为true，否则flase</returns>
        bool removePlaytimeBymovieID(int movieID);
        /// <summary>
        /// 删除上映时间段
        /// </summary>
        /// <param name="cinemaID">上映影院的ID</param>
        /// <returns>删除成功为true，否则flase</returns>
        bool removePlaytimeBycinemaID(int cinemaID);
        bool editPlaytime(PlayTime playTime);
    }
}
