using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    //获取电影信息
    public class MovieBLL
    {
        public List<Model.Movie> getMovieListByName(string name)
        {
            IDAL.IMovie lst = DALFactory.DataAccess.createDalMovie();
            return lst.getMovieListByName(name);
        }

        public List<Model.Movie> getMovieList()
        {
            IDAL.IMovie lst = DALFactory.DataAccess.createDalMovie();
            return lst.getMovieList();
        }
        public Model.Movie getMovieByID(int id)
        {
            IDAL.IMovie lst = DALFactory.DataAccess.createDalMovie();
            return lst.getMovieById(id);
        }
    }

}
