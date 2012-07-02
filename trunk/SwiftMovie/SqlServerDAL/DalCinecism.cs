using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SqlServerDAL
{
    public class DalCinecism:IDAL.ICinecism
    {
        public List<Model.Cinecism> getCinecismList()
        {
            List<Model.Cinecism> lst = new List<Model.Cinecism>();
            DataTable dt = DBUtility.SqlHelper.executeTable("select * from Cinecisms", CommandType.Text, null);
            foreach (DataRow item in dt.Rows)
            {
                Model.Cinecism emp = new Model.Cinecism() { CinecismID = int.Parse(item[0].ToString()),UserName=item[1].ToString(),
                    CommTime = DateTime.Parse(item[3].ToString()), MovieID = int.Parse(item[4].ToString()),
                    Comment = item[2].ToString() };
                lst.Add(emp);
            }
            return lst;
           // throw new NotImplementedException();
        }

        public List<Model.Cinecism> getCinecismList(int movieID)
        {
            List<Model.Cinecism> lst = new List<Model.Cinecism>();
            DataTable dt = DBUtility.SqlHelper.executeTable("select * from Cinecisms where MovieID="+movieID+" ORDER BY CommTime DESC", CommandType.Text, null);
            foreach (DataRow item in dt.Rows)
            {
                Model.Cinecism emp = new Model.Cinecism() { CinecismID = int.Parse(item[0].ToString()), UserName = item[1].ToString(), CommTime = DateTime.Parse(item[3].ToString()), MovieID = int.Parse(item[4].ToString()), Comment = item[2].ToString() };
                lst.Add(emp);
            }
            return lst;
           // throw new NotImplementedException();
        }

        public bool addCinecism(Model.Cinecism cinecism)
        {
            List<Model.Cinecism> lst = new List<Model.Cinecism>();
            cinecism.CommTime = DateTime.Now;//获取系统时间
            string sql = "INSERT INTO Cinecisms（UserName,Comment,CommTime,MovieID） Values ('" + cinecism.UserName + "','" + cinecism.Comment + "','" + cinecism.CommTime + "','" + cinecism.MovieID + "')";
            int dt = DBUtility.SqlHelper.executeNonQuery(sql, CommandType.Text, null);
            if (dt == 1) 
                return true;
            else 
                return false;
            //throw new NotImplementedException();
        }

        public bool removeCinecism(int id)
        {
            //List<Model.Cinecism> lst = new List<Model.Cinecism>();
            string sql = "Delete From Cinecisms where CinecismID=" + id;
            int dt = DBUtility.SqlHelper.executeNonQuery(sql, CommandType.Text, null);
            if (dt == 1) 
                return true;
            else 
                return false;
            //throw new NotImplementedException();
        }
    }
}
