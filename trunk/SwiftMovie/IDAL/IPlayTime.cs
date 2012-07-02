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
        /// <summary>
        /// 获取即将播放的电影
        /// </summary>
        /// <returns>按上映时间升序排列即将上映的电影</returns>
        List<Movie> getSoonMovieList();
        /// <summary>
        /// 获取某电影院即将上映的电影
        /// </summary>
        /// <param name="cinemaID">电影院的ID</param>
        /// <returns>按上映时间升序排列即将上映的电影</returns>
        List<Movie> getSoonMovieList(int cinemaID);
        /// <summary>
        /// 获取正在热播的电影
        /// </summary>
        /// <returns>按降序排列的正在热播的电影</returns>
        List<Movie> getRuningMovie();
        /// <summary>
        /// 获取某电影院正在热播的电影
        /// </summary>
        /// <param name="cinemaID">电影院ID</param>
        /// <returns>按降序排列的正在热播的电影</returns>
        List<Movie> getRuningMoive(int cinemaID);
    }
}
