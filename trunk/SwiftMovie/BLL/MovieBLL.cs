using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class MovieBLL
    {
        public List<Model.Movie> getMovieList(string name)
        {
            IDAL.IMovie lst = DALFactory.DataAccess.createDalMovie();
            return lst.getMovieListByName(name);
        }
    }

}
