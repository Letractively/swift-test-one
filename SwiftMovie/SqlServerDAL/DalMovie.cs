using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlServerDAL
{
    public class DalMovie:IDAL.IMovie
    {

        public List<Model.Movie> getMovieList()
        {
            throw new NotImplementedException();
        }

        public bool addMovie(Model.Movie movie)
        {
            throw new NotImplementedException();
        }

        public bool removeMovie(int id)
        {
            throw new NotImplementedException();
        }

        public bool editMovie(Model.Movie movie)
        {
            throw new NotImplementedException();
        }

        public List<Model.Movie> getMovieListByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
