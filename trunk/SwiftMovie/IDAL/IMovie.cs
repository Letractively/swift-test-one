using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace IDAL
{
    public interface IMovie
    {
        List<Movie> getMovieList();
        bool addMovie(Movie movie);
        bool removeMovie(int id);
        bool editMovie(Movie movie);
        /// <summary>
        /// 根据电影名（完整或非完整），查询出电影列表
        /// </summary>
        /// <param name="name">电影名（完整或是非完整的）</param>
        /// <returns></returns>
        List<Movie> getMovieListByName(string name);
    }
}
