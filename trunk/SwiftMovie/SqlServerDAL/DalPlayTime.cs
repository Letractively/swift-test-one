using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SqlServerDAL
{
    public class DalPlayTime:IDAL.IPlayTime
    {
        public List<Model.PlayTime> getPlayTimeList()
        {
            List<Model.PlayTime> lst = new List<Model.PlayTime>();
            DataTable dt = DBUtility.SqlHelper.executeTable("select * from PlayTimes", CommandType.Text, null);
            foreach (DataRow item in dt.Rows)
            {
                Model.PlayTime emp = new Model.PlayTime() { PlaytimeID = int.Parse(item[0].ToString()), 
                    MovieID =int.Parse( item[1].ToString()), CinemaID =int.Parse( item[2].ToString()), 
                    Playtime =DateTime.Parse( item[3].ToString()), PlayState =bool.Parse( item[4].ToString()) };
                lst.Add(emp);
            }
            return lst;
            //throw new NotImplementedException();
        }

        public List<Model.PlayTime> getPlayTimeList(int movieID, int cinemaID)
        {
            List<Model.PlayTime> lst = new List<Model.PlayTime>();
            string sql = "SELECT * FROM PlayTimes WHERE MovieID=@movieID AND CinemaID=@cinemaID";
            SqlParameter[] sps = new SqlParameter[]{
                new SqlParameter(){ParameterName="@movieID",Value=movieID},
                new SqlParameter(){ParameterName="@cinemaID",Value=cinemaID}
            };
            DataTable dt = DBUtility.SqlHelper.executeTable(sql, CommandType.Text, sps);
            foreach (DataRow item in dt.Rows)
            {
                Model.PlayTime emp = new Model.PlayTime()
                {
                    PlaytimeID = int.Parse(item[0].ToString()),
                    MovieID = int.Parse(item[1].ToString()),
                    CinemaID = int.Parse(item[2].ToString()),
                    Playtime = DateTime.Parse(item[3].ToString()),
                    PlayState = bool.Parse(item[4].ToString())
                };
                lst.Add(emp);
            }
            return lst;
            //throw new NotImplementedException();
        }

        public bool addNewPlaytime(Model.PlayTime playTime)
        {
            List<Model.PlayTime> lst = new List<Model.PlayTime>();
            //string sql = "INSERT INTO PlayTimes(MovieID,CinemaID,PlayTime,PlayState) Values ('" + playTime.MovieID + "','" + playTime.CinemaID
            //    + "','" + playTime.Playtime + "','" + playTime.PlayState + "')";
            string sql = "INSERT INTO PlayTimes(MovieID,CinemaID,PlayTime,PlayState) VALUES (@movieID,@cinemaID,@playTime,@playState)";
            SqlParameter[] sps = new SqlParameter[]{
                new SqlParameter(){ParameterName="@movieID",Value=playTime.MovieID},
                new SqlParameter(){ParameterName="@cinemaID",Value=playTime.CinemaID},
                new SqlParameter(){ParameterName="@playTime",Value=playTime.Playtime},
                new SqlParameter(){ParameterName="@playState",Value=playTime.PlayState}
            };
            

            int dt = DBUtility.SqlHelper.executeNonQuery(sql, CommandType.Text, sps);
            if (dt == 1) return true;
            else return false;
            //throw new NotImplementedException();
        }

        public bool removePlaytimeByplayTimeID(int playTimeID)
        {
            List<Model.PlayTime> lst = new List<Model.PlayTime>();
            string sql = "Delete From PlayTimes where PlaytimeID=" + playTimeID;
            int dt = DBUtility.SqlHelper.executeNonQuery(sql, CommandType.Text, null);
            if (dt == 1) return true;
            else return false;
            //throw new NotImplementedException();
        }
        public bool removePlaytimeBymovieID(int movieID)
        {
            List<Model.PlayTime> lst = new List<Model.PlayTime>();
            string sql = "Delete From PlayTimes where MovieID=" + movieID;
            int dt = DBUtility.SqlHelper.executeNonQuery(sql, CommandType.Text, null);
            if (dt == 1) return true;
            else return false;
            //throw new NotImplementedException();
        }
        public bool removePlaytimeBycinemaID(int cinemaID)
        {
            List<Model.PlayTime> lst = new List<Model.PlayTime>();
            string sql = "Delete From PlayTimes where CinemaID=" + cinemaID;
            int dt = DBUtility.SqlHelper.executeNonQuery(sql, CommandType.Text, null);
            if (dt == 1) return true;
            else return false;
            //throw new NotImplementedException();
        }

        public bool editPlaytime(Model.PlayTime playTime)
        {
            List<Model.PlayTime> lst = new List<Model.PlayTime>();
            //string sql = "Update Cinemas set MovieID=" +playTime.MovieID + ",CinemaID="
            //    + playTime.CinemaID + ",PlayTime=" + playTime.Playtime +
            //",PlayState"+playTime.PlayState+ ",where PlaytimeID=" + playTime.PlaytimeID ;
            string sql = "UPDATE Cinemas SET MovieID=@movieID,CinemaID=@cinemaID,PlayTime=@playTime,PlayState=@playState WHERE PlaytimeID=@playtimeID";
            SqlParameter[] sps = new SqlParameter[]{
                new SqlParameter(){ParameterName="@movieID",Value=playTime.MovieID},
                new SqlParameter(){ParameterName="@cinemaID",Value=playTime.CinemaID},
                new SqlParameter(){ParameterName="@playTime",Value=playTime.Playtime},
                new SqlParameter(){ParameterName="@playState",Value=playTime.PlayState},
                new SqlParameter(){ParameterName="@playtimeID",Value=playTime.PlaytimeID}
            };
            int dt = DBUtility.SqlHelper.executeNonQuery(sql, CommandType.Text, sps);
            if (dt == 1) return true;
            else return false;
            //throw new NotImplementedException();
        }


        public List<Model.Movie> getSoonMovieList()
        {
            List<Model.Movie> movies = new List<Model.Movie>();
            DateTime now = DateTime.Now;//获取现在的系统时间
            string sql = "SELECT DISTINCT MovieID,MovieName,CoverURL,Director,Protagonist,MovieType,ReleaseDate,RunTime FROM vew_PlayTime WHERE PlayTime>@todayTime ORDER BY RunTime ASC";
            SqlParameter[] sps = new SqlParameter[]{
                new SqlParameter(){ParameterName="@todayTime",Value=now}
            };
            DataTable dt = DBUtility.SqlHelper.executeTable(sql, CommandType.Text, sps);
            foreach (DataRow item in dt.Rows)
            {
                Model.Movie movie = new Model.Movie()
                {
                    MovieID = int.Parse(item[0].ToString()),
                    MovieName = item[1].ToString(),
                    CoverURL = item[2].ToString(),
                    Director = item[3].ToString(),
                    Protagonist = item[4].ToString(),
                    Type = item[5].ToString(),
                    ReleaseDate = DateTime.Parse(item[6].ToString()),
                    RunTime = item[7].ToString()
                };
                movies.Add(movie);
            }
            return movies;
            //throw new NotImplementedException();
        }

        public List<Model.Movie> getSoonMovieList(int cinemaID)
        {
            List<Model.Movie> movies = new List<Model.Movie>();
            DateTime now = DateTime.Now;//获取现在的系统时间
            string sql = "SELECT DISTINCT MovieID,MovieName,CoverURL,Director,Protagonist,MovieType,ReleaseDate,RunTime FROM vew_PlayTime WHERE CinemaID=@cinemaID AND PlayTime>@todayTime ORDER BY RunTime ASC";
            SqlParameter[] sps = new SqlParameter[]{
                new SqlParameter(){ParameterName="@todayTime",Value=now},
                new SqlParameter(){ParameterName="@cinemaID",Value=cinemaID}
            };
            DataTable dt = DBUtility.SqlHelper.executeTable(sql, CommandType.Text, sps);
            foreach (DataRow item in dt.Rows)
            {
                Model.Movie movie = new Model.Movie()
                {
                    MovieID = int.Parse(item[0].ToString()),
                    MovieName = item[1].ToString(),
                    CoverURL = item[2].ToString(),
                    Director = item[3].ToString(),
                    Protagonist = item[4].ToString(),
                    Type = item[5].ToString(),
                    ReleaseDate = DateTime.Parse(item[6].ToString()),
                    RunTime = item[7].ToString()
                };
                movies.Add(movie);
            }
            return movies;
            //throw new NotImplementedException();
        }

        public List<Model.Movie> getRuningMovie()
        {
            List<Model.Movie> movies = new List<Model.Movie>();
            DateTime now = DateTime.Now;//获取现在的系统时间
            string sql = "SELECT DISTINCT MovieID,MovieName,CoverURL,Director,Protagonist,MovieType,ReleaseDate,RunTime FROM vew_PlayTime WHERE PlayTime!>@todayTime ORDER BY RunTime DESC";
            SqlParameter[] sps = new SqlParameter[]{
                new SqlParameter(){ParameterName="@todayTime",Value=now}
            };
            DataTable dt = DBUtility.SqlHelper.executeTable(sql, CommandType.Text, sps);
            foreach (DataRow item in dt.Rows)
            {
                Model.Movie movie = new Model.Movie()
                {
                    MovieID = int.Parse(item[0].ToString()),
                    MovieName = item[1].ToString(),
                    CoverURL = item[2].ToString(),
                    Director = item[3].ToString(),
                    Protagonist = item[4].ToString(),
                    Type = item[5].ToString(),
                    ReleaseDate = DateTime.Parse(item[6].ToString()),
                    RunTime = item[7].ToString()
                };
                movies.Add(movie);
            }
            return movies;
            //throw new NotImplementedException();
        }

        public List<Model.Movie> getRuningMoive(int cinemaID)
        {
            List<Model.Movie> movies = new List<Model.Movie>();
            DateTime now = DateTime.Now;//获取现在的系统时间
            string sql = "SELECT DISTINCT MovieID,MovieName,CoverURL,Director,Protagonist,MovieType,ReleaseDate,RunTime FROM vew_PlayTime WHERE CinemaID=@cinemaID AND PlayTime!>@todayTime ORDER BY RunTime DESC";
            SqlParameter[] sps = new SqlParameter[]{
                new SqlParameter(){ParameterName="@todayTime",Value=now},
                new SqlParameter(){ParameterName="@cinemaID",Value=cinemaID}
            };
            DataTable dt = DBUtility.SqlHelper.executeTable(sql, CommandType.Text, sps);
            foreach (DataRow item in dt.Rows)
            {
                Model.Movie movie = new Model.Movie()
                {
                    MovieID = int.Parse(item[0].ToString()),
                    MovieName = item[1].ToString(),
                    CoverURL = item[2].ToString(),
                    Director = item[3].ToString(),
                    Protagonist = item[4].ToString(),
                    Type = item[5].ToString(),
                    ReleaseDate = DateTime.Parse(item[6].ToString()),
                    RunTime = item[7].ToString()
                };
                movies.Add(movie);
            }
            return movies;
            //throw new NotImplementedException();
        }


        public bool isExist(int movieID, int cinemaID)
        {
            string sql = "SELECT * FROM PlayTimes WHERE MovieID=@movieID AND CinemaID=@cinemaID";
            SqlParameter[] sps = new SqlParameter[]{
                new SqlParameter(){ParameterName="@movieID",Value=movieID},
                new SqlParameter(){ParameterName="@cinemaID",Value=cinemaID}
            };
            if (DBUtility.SqlHelper.executeReader(sql, CommandType.Text, sps).Read())
            {
                return true;
            }
            return false;
            //throw new NotImplementedException();
        }


        public List<Model.PlayTime> getPlayTimeList(int movieID)
        {
            List<Model.PlayTime> playTimes = new List<Model.PlayTime>();
            string sql = "SELECT * FROM PlayTimes WHERE MovieID=@movieID";
            SqlParameter[] sps = new SqlParameter[]{
                new SqlParameter(){ParameterName="@movieID",Value=movieID}
            };
            DataTable dt = DBUtility.SqlHelper.executeTable(sql, CommandType.Text, sps);
            if (dt != null)
            {
                foreach (DataRow item in dt.Rows)
                {
                    Model.PlayTime playTime = new Model.PlayTime()
                    {
                        PlaytimeID = int.Parse(item[0].ToString()),
                        MovieID = int.Parse(item[1].ToString()),
                        CinemaID = int.Parse(item[2].ToString()),
                        Playtime = DateTime.Parse(item[3].ToString()),
                        PlayState = bool.Parse(item[4].ToString())
                    };
                    playTimes.Add(playTime);
                }
            }
            return playTimes;
            //throw new NotImplementedException();
        }
    }
}
