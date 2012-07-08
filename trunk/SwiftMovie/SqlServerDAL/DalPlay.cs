using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SqlServerDAL
{
     public class DalPlay:IDAL.IPlay
    {
        public List<Model.Play> getPlayList()
        {
            List<Model.Play> lst = new List<Model.Play>();
            DataTable dt = DBUtility.SqlHelper.executeTable("select * from Plays", CommandType.Text, null);
            foreach (DataRow item in dt.Rows)
            {
                Model.Play emp = new Model.Play() { PlayID = int.Parse(item[0].ToString()), PlayName = item[1].ToString(),
                    MovieID = int.Parse(item[2].ToString()), CinemaID = int.Parse(item[3].ToString()), 
                    Price = float.Parse(item[4].ToString()) };
                lst.Add(emp);
            }
            return lst;
            //throw new NotImplementedException();
        }

        public List<Model.Play> getPlayListBymovieID(int movieID)
        {
            List<Model.Play> lst = new List<Model.Play>();
            DataTable dt = DBUtility.SqlHelper.executeTable("select * from Plays where MovieID="+movieID, CommandType.Text, null);
            foreach (DataRow item in dt.Rows)
            {
                Model.Play emp = new Model.Play()
                {
                    PlayID = int.Parse(item[0].ToString()),
                    PlayName = item[1].ToString(),
                    MovieID = int.Parse(item[2].ToString()),
                    CinemaID = int.Parse(item[3].ToString()),
                    Price = float.Parse(item[4].ToString())
                };
                lst.Add(emp);
            }
            return lst;
           // throw new NotImplementedException();
        }
        public List<Model.Play> getPlayListBycinemaID(int cinemaID)
        {
            List<Model.Play> lst = new List<Model.Play>();
            DataTable dt = DBUtility.SqlHelper.executeTable("select * from Plays where CinemaID=" + cinemaID, CommandType.Text, null);
            foreach (DataRow item in dt.Rows)
            {
                Model.Play emp = new Model.Play()
                {
                    PlayID = int.Parse(item[0].ToString()),
                    PlayName = item[1].ToString(),
                    MovieID = int.Parse(item[2].ToString()),
                    CinemaID = int.Parse(item[3].ToString()),
                    Price = float.Parse(item[4].ToString())
                };
                lst.Add(emp);
            }
            return lst;
            // throw new NotImplementedException();
        }

        public List<Model.Play> getPlayList(int movieID, int cinemaID)
        {
            List<Model.Play> lst = new List<Model.Play>();
            string sql = "SELECT * FROM Plays WHERE MovieID=@MovieID AND CinemaID=@CinemaID ORDER BY PlayName";
            SqlParameter[] sps = new SqlParameter[]{
                new SqlParameter(){ParameterName="@MovieID",Value=movieID},
                new SqlParameter(){ParameterName="@CinemaID",Value=cinemaID}
            };
            DataTable dt = DBUtility.SqlHelper.executeTable(sql, CommandType.Text, sps);
            foreach (DataRow item in dt.Rows)
            {
                Model.Play emp = new Model.Play()
                {
                    PlayID = int.Parse(item[0].ToString()),
                    PlayName = item[1].ToString(),
                    MovieID = int.Parse(item[2].ToString()),
                    CinemaID = int.Parse(item[3].ToString()),
                    Price = float.Parse(item[4].ToString())
                };
                lst.Add(emp);
            }
            return lst;
            //throw new NotImplementedException();
        }

        public bool addNewPlay(Model.Play play)
        {
            //List<Model.Play> lst = new List<Model.Play>();
            //string sql = "INSERT INTO Plays(PlayName,MovieID,CinemaID,Price) Values ('"
            //    + play.PlayName + "','" + play.MovieID + "','" + play.CinemaID
            //    + "','" + play.Price  + "')";
            string sql = "INSERT INTO Plays(PlayID,PlayName,MovieID,CinemaID,Price) VALUES(@PlayID,@PlayName,@MovieID,@CinemaID,@Price)";
            SqlParameter[] sps = new SqlParameter[]{
                new SqlParameter(){ParameterName="@PlayID",Value=play.PlayID},
                new SqlParameter(){ParameterName="@PlayName",Value=play.PlayName},
                new SqlParameter(){ParameterName="@MovieID",Value=play.MovieID},
                new SqlParameter(){ParameterName="@CinemaID",Value=play.CinemaID},
                new SqlParameter(){ParameterName="@Price",Value=play.Price}
            };
            int dt = DBUtility.SqlHelper.executeNonQuery(sql, CommandType.Text, sps);
            if (dt == 1) return true;
            else return false;
            //throw new NotImplementedException();
        }

        public bool removePlay(int playID)
        {
            //List<Model.Play> lst = new List<Model.Play>();
            string sql = "Delete From Plays where PlayID=" + playID;
            int dt = DBUtility.SqlHelper.executeNonQuery(sql, CommandType.Text, null);
            if (dt == 1) return true;
            else return false;
           // throw new NotImplementedException();
        }

        public bool editPlay(Model.Play play)
        {
            List<Model.Play> lst = new List<Model.Play>();
            //string sql = "Update Cinemas set PlayName=" + play.PlayID +
            //    ",MovieID=" + play.MovieID + ",CinemaID=" + play.CinemaID
            //    + ",Price=" + play.Price + ",where PlayID="+play.PlayID;
            string sql = "UPDATE Cinemas SET PlayName=@playName,MovieID=@movieID,CinemaID=@cinemaID,Price=@price WHERE PlayID=@playID";
            SqlParameter[] sps = new SqlParameter[]{
                new SqlParameter(){ParameterName="@playName",Value=play.PlayName},
                new SqlParameter(){ParameterName="@movieID",Value=play.MovieID},
                new SqlParameter(){ParameterName="@cinemaID",Value=play.CinemaID},
                new SqlParameter(){ParameterName="@price",Value=play.Price},
                new SqlParameter(){ParameterName="@playID",Value=play.PlayID}
            };

            int dt = DBUtility.SqlHelper.executeNonQuery(sql, CommandType.Text, sps);
            if (dt == 1) return true;
            else return false;
           // throw new NotImplementedException();
        }


        public bool getPlayById(int playID)
        {
            string sql = "SELECT * FROM Plays WHERE PlayID=@playID";
            SqlParameter[] sps = new SqlParameter[]{
                new SqlParameter(){ParameterName="@playID",Value=playID}
            };
            SqlDataReader da = DBUtility.SqlHelper.executeReader(sql, CommandType.Text, sps);
            if (da.Read())
            {
                return true;
            }
            return false;
            //throw new NotImplementedException();
        }
    }
}
