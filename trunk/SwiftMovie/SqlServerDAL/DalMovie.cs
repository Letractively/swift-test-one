using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SqlServerDAL
{
    public class DalMovie:IDAL.IMovie
    {

        public List<Model.Movie> getMovieList()
        {
            List<Model.Movie> lst = new List<Model.Movie>();
            DataTable dt = DBUtility.SqlHelper.executeTable("select * from Movies", CommandType.Text, null);
            foreach (DataRow item in dt.Rows)
            {
                Model.Movie emp = new Model.Movie() { MovieID = int.Parse(item[0].ToString()), MovieName = item[1].ToString(), CoverURL = item[2].ToString(),Director = item[3].ToString(), Protagonist = item[4].ToString(), Type = item[5].ToString(),ReleaseDate=DateTime.Parse(item[6].ToString()),RunTime=float.Parse(item[7].ToString()) };
                lst.Add(emp);
            }
            return lst;
            //throw new NotImplementedException();
        }

        public bool addMovie(Model.Movie movie)
        {
            List<Model.Movie> lst = new List<Model.Movie>();
            string sql = "INSERT INTO Movies Values (MovieID=" + movie.MovieID + ",MovieName=" 
                +movie.MovieName + ",CoverURL=" + movie.CoverURL + ",Director=" + movie.Director + 
                ",Protagonist=" + movie.Protagonist + ",MovieType=" + movie.Type +",ReleaseDate="
                +movie.ReleaseDate+",RunTime="+movie.RunTime+ ")";
            int dt = DBUtility.SqlHelper.executeNonQuery(sql, CommandType.Text, null);
            if (dt == 1) return true;
            else return false;
            //throw new NotImplementedException();
        }

        public bool removeMovie(int id)
        {
            List<Model.Movie> lst = new List<Model.Movie>();
            string sql = "Delete From Movies where MovieID=" + id;
            int dt = DBUtility.SqlHelper.executeNonQuery(sql, CommandType.Text, null);
            if (dt == 1) return true;
            else return false;
            //throw new NotImplementedException();
        }

        public bool editMovie(Model.Movie movie)
        {
            List<Model.Movie> lst = new List<Model.Movie>();
            string sql = "Uddate Cinemas set (MovieName=" + movie.MovieName + ",CoverURL=" + movie.CoverURL + 
                ",Director=" + movie.Director + ",Protagonist=" + movie.Protagonist +
                ",MovieType=" + movie.Type + ",ReleaseDate=" + movie.ReleaseDate +
                ",RunTime=" + movie.RunTime + ",where MovieID="+movie.MovieID+")";
            int dt = DBUtility.SqlHelper.executeNonQuery(sql, CommandType.Text, null);
            if (dt == 1) return true;
            else return false;
            //throw new NotImplementedException();
        }

        public List<Model.Movie> getMovieListByName(string name)
        {
            List<Model.Movie> lst = new List<Model.Movie>();
            DataTable dt = DBUtility.SqlHelper.executeTable("select * from Movies where MovieName="+name, 
                CommandType.Text, null);
            foreach (DataRow item in dt.Rows)
            {
                Model.Movie emp = new Model.Movie() { MovieID = int.Parse(item[0].ToString()), 
                    MovieName = item[1].ToString(), CoverURL = item[2].ToString(), 
                    Director = item[3].ToString(), Protagonist = item[4].ToString(), 
                    Type = item[5].ToString(), ReleaseDate = DateTime.Parse(item[6].ToString()), 
                    RunTime = float.Parse(item[7].ToString()) };
                lst.Add(emp);
            }
            return lst;
            //throw new NotImplementedException();
        }
    }
}
