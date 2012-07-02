using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SqlServerDAL
{
    public class DalCComment:IDAL.ICComment
    {
        public List<Model.CComment> getCCommentList()
        {
            List<Model.CComment> lst = new List<Model.CComment>();
            DataTable dt = DBUtility.SqlHelper.executeTable("select * from CComments", CommandType.Text, null);
            foreach (DataRow item in dt.Rows)
            {
                Model.CComment emp = new Model.CComment() { CCommentID = int.Parse(item[0].ToString()), CinemaID = int.Parse(item[1].ToString()), CommTime = DateTime.Parse(item[4].ToString()), Grade = float.Parse(item[5].ToString()), Comment = item[3].ToString(), UserName = item[2].ToString() };
                lst.Add(emp);
            }
            return lst;
        }

        public List<Model.CComment> getCCommentList(int CinemaID)
        {
            List<Model.CComment> lst = new List<Model.CComment>();
            DataTable dt = DBUtility.SqlHelper.executeTable("select * from CComment where CinemaID="+CinemaID+" ORDER BY CommTime DESC", CommandType.Text, null);
            foreach (DataRow item in dt.Rows)
            {
                Model.CComment emp = new Model.CComment() { CCommentID = int.Parse(item[0].ToString()), CinemaID = int.Parse(item[1].ToString()), CommTime = DateTime.Parse(item[2].ToString()), Grade = float.Parse(item[3].ToString()), Comment = item[4].ToString(), UserName = item[5].ToString() };
                lst.Add(emp);
            }
            return lst;
            //throw new NotImplementedException();
        }

        public bool addCComment(Model.CComment ccomment)
        {
            List<Model.CComment> lst = new List<Model.CComment>();
            ccomment.CommTime = DateTime.Now;//获取系统时间
            string sql = "INSERT INTO CComments (CinemaID,UserName,Comment,CommTime,Grade) Values ('"+ccomment.CinemaID+"','"+ccomment.UserName+"','"+ccomment.Comment+"','"+ccomment.CommTime+"','"+ccomment.Grade+"')";
            int dt = DBUtility.SqlHelper.executeNonQuery(sql, CommandType.Text, null);
            if (dt == 1) return true;
            else return false;
            
            //throw new NotImplementedException();
        }

        public bool removeCComent(int id)
        {
            //List<Model.CComment> lst = new List<Model.CComment>();
            string sql = "DELETE FROM CComments where CinemaID=" + id ;
            int dt = DBUtility.SqlHelper.executeNonQuery(sql, CommandType.Text, null);
            if (dt == 1) 
                return true;
            else 
                return false;
           // throw new NotImplementedException();
        }
    }
}
