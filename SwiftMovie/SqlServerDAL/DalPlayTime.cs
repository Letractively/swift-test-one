using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

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
            DataTable dt = DBUtility.SqlHelper.executeTable("select * from PlayTimes where MovieID=" + movieID + "and CinemaID=" + cinemaID, CommandType.Text, null);
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
            string sql = "INSERT INTO PlayTimes(MovieID,CinemaID,PlayTime,PlayState) Values ('" + playTime.MovieID + "','" + playTime.CinemaID
                + "','" + playTime.Playtime + "','" + playTime.PlayState + "')";
            int dt = DBUtility.SqlHelper.executeNonQuery(sql, CommandType.Text, null);
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
            string sql = "Update Cinemas set MovieID=" +playTime.MovieID + ",CinemaID="
                + playTime.CinemaID + ",PlayTime=" + playTime.Playtime +
            ",PlayState"+playTime.PlayState+ ",where PlaytimeID=" + playTime.PlaytimeID ;
            int dt = DBUtility.SqlHelper.executeNonQuery(sql, CommandType.Text, null);
            if (dt == 1) return true;
            else return false;
            //throw new NotImplementedException();
        }
    }
}
