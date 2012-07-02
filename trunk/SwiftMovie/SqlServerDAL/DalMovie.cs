using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

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
            //List<Model.Movie> lst = new List<Model.Movie>();
            //string sql = "INSERT INTO Movies(MovieName,CoverURL,Director,Protagonist,MovieType,ReleaseDate,RunTime) Values ('"
            //    + movie.MovieName + "','" + movie.CoverURL + "','" + movie.Director +
            //    "','" + movie.Protagonist + "','" + movie.Type + "','"
            //    + movie.ReleaseDate + "','" + movie.RunTime + "')";

            string sql = "INSERT INTO Movies(MovieName,CoverURL,Director,Protagonist,MovieType,ReleaseDate,RunTime) Values (@MovieName,@CoverURL,@Director,@Protagonist,@Type,@ReleaseDate,@RunTime)";
            SqlParameter[] sps = new SqlParameter[]{
                new SqlParameter(){ParameterName="@MovieName",Value=movie.MovieName},
                new SqlParameter(){ParameterName="@CoverURL",Value=movie.CoverURL},
                new SqlParameter(){ParameterName="@Director",Value=movie.Director},
                new SqlParameter(){ParameterName="@Protagonist",Value=movie.Protagonist},
                new SqlParameter(){ParameterName="@Type",Value=movie.Type},
                new SqlParameter(){ParameterName="@ReleaseDate",Value=movie.ReleaseDate},
                new SqlParameter(){ParameterName="@RunTime",Value=movie.RunTime},
            };
            int dt = DBUtility.SqlHelper.executeNonQuery(sql, CommandType.Text, sps);
            if (dt == 1) 
                return true;
            else 
                return false;
            //throw new NotImplementedException();
        }

        public bool removeMovie(int id)
        {
            //List<Model.Movie> lst = new List<Model.Movie>();
            string sql = "Delete From Movies where MovieID=" + id;
            int dt = DBUtility.SqlHelper.executeNonQuery(sql, CommandType.Text, null);
            if (dt == 1) return true;
            else return false;
            //throw new NotImplementedException();
        }

        public bool editMovie(Model.Movie movie)
        {
            List<Model.Movie> lst = new List<Model.Movie>();
            //string sql = "Update Cinemas set MovieName=" + movie.MovieName + ",CoverURL=" + movie.CoverURL + 
            //    ",Director=" + movie.Director + ",Protagonist=" + movie.Protagonist +
            //    ",MovieType=" + movie.Type + ",ReleaseDate=" + movie.ReleaseDate +
            //    ",RunTime=" + movie.RunTime + ",where MovieID="+movie.MovieID;
            string sql = "UPDATE Movies m SET m.CoverURL=@URL,m.Director=@Director,m.Protagonist=@Pro,m.MovieType=@Type,m.ReleaseDate=@Rel,m.RunTime=@Run WHERE m.MovieID=@id";
            SqlParameter[] sps = new SqlParameter[]{
                new SqlParameter(){ParameterName="@URL",Value=movie.CoverURL},
                new SqlParameter(){ParameterName="@Director",Value=movie.Director},
                new SqlParameter(){ParameterName="@Pro",Value=movie.Protagonist},
                new SqlParameter(){ParameterName="@Rel",Value=movie.ReleaseDate},
                new SqlParameter(){ParameterName="@Run",Value=movie.RunTime},
                new SqlParameter(){ParameterName="@id",Value=movie.MovieID},
                new SqlParameter(){ParameterName="@Type",Value=movie.Type},
            };

            int dt = DBUtility.SqlHelper.executeNonQuery(sql, CommandType.Text, sps);
            if (dt == 1) 
                return true;
            else 
                return false;
            //throw new NotImplementedException();
        }

        public List<Model.Movie> getMovieListByName(string name)
        {
            List<Model.Movie> lst = new List<Model.Movie>();
            DataTable dt = DBUtility.SqlHelper.executeTable("select * from Movies where (MovieName like '%"+name+"%') order by MovieName", 
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


        public Model.Movie getMovieById(int id)
        {
            List<Model.Movie> lst = new List<Model.Movie>();
            //Model.Movie movie = new Model.Movie();
            string sql = "SELECT * FROM Movies WHERE MovieID=@id";
            SqlParameter[] sps = new SqlParameter[]{
                new SqlParameter(){ParameterName = "@id",Value=id}
            };
            SqlDataReader dr = DBUtility.SqlHelper.executeReader(sql, CommandType.Text, sps);
            if (dr.Read())
            {
                Model.Movie movie = new Model.Movie() { MovieID = int.Parse(dr[0].ToString()), MovieName = dr[1].ToString(), CoverURL = dr[2].ToString(), Director = dr[3].ToString(), Protagonist = dr[4].ToString(), Type = dr[5].ToString(), ReleaseDate = DateTime.Parse(dr[6].ToString()), RunTime = float.Parse(dr[7].ToString()) };
                return movie;
            }
            else
                return null;
           
            //throw new NotImplementedException();
        }
    }
}
