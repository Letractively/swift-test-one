using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SqlServerDAL
{
    public class DalCinema:IDAL.ICinema
    {
        public List<Model.Cinema> getCinemaList()
        {
            List<Model.Cinema> lst = new List<Model.Cinema>();
            DataTable dt = DBUtility.SqlHelper.executeTable("select * from Cinemas", CommandType.Text, null);
            foreach (DataRow item in dt.Rows)
            {
                Model.Cinema emp = new Model.Cinema() { CinemaID = int.Parse(item[0].ToString()), CinemaName = item[1].ToString(), Address = item[2].ToString(), CinemaMap = item[3].ToString(), CinemaGrade =item[5].ToString(), CinemaTel = item[4].ToString() };
                lst.Add(emp);
            }
            return lst;
        }

        public bool addCinema(Model.Cinema cinema)
        {
            List<Model.Cinema> lst = new List<Model.Cinema>();
            string sql = "INSERT INTO Cinemas Values (CinemaName=" + cinema.CinemaName + ",Address=" + cinema.Address + ",CinemaMap=" + cinema.CinemaMap + ",CinemaTel=" + cinema.CinemaTel + ",CinemaGrade="+cinema.CinemaGrade+")";
            int dt = DBUtility.SqlHelper.executeNonQuery(sql, CommandType.Text, null);
            if (dt == 1) return true;
            else return false;
            //throw new NotImplementedException();
        }

        public bool removeCinema(int id)
        {
            List<Model.Cinema> lst = new List<Model.Cinema>();
            string sql = "Delete From Cinemas where CinemaID="+id;
            int dt = DBUtility.SqlHelper.executeNonQuery(sql, CommandType.Text, null);
            if (dt == 1) return true;
            else return false;
            //throw new NotImplementedException();
        }

        public bool editCinema(Model.Cinema cinema)
        {
            List<Model.Cinema> lst = new List<Model.Cinema>();
            string sql = "Uddate Cinemas set (CinemaName=" + cinema.CinemaName + ",Address=" + cinema.Address + ",CinemaMap=" + cinema.CinemaMap + ",CinemaTel=" + cinema.CinemaTel + ",CinemaGrade=" + cinema.CinemaGrade + ",where CinemaID="+cinema.CinemaID+")";
            int dt = DBUtility.SqlHelper.executeNonQuery(sql, CommandType.Text, null);
            if (dt == 1) return true;
            else return false;
            //throw new NotImplementedException();
        }

        public Model.Cinema getCinemaById(int id)
        {
            Model.Cinema lst1 = new Model.Cinema();
            DataTable dt = DBUtility.SqlHelper.executeTable("select * from Cinemas where CinemaID="+id, CommandType.Text, null);
            foreach (DataRow item in dt.Rows)
            {
                Model.Cinema emp = new Model.Cinema() { CinemaID = int.Parse(item[0].ToString()), CinemaName = item[1].ToString(), Address = item[2].ToString(), CinemaMap = item[3].ToString(), CinemaGrade = item[5].ToString(), CinemaTel = item[4].ToString() };
                lst1 = emp;
            }
            return lst1;
            //throw new NotImplementedException();
        }
    }
}
