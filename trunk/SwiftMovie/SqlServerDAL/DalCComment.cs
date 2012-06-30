﻿using System;
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
                Model.CComment emp = new Model.CComment() { CCommentID = int.Parse(item[0].ToString()), CinemaID = int.Parse(item[1].ToString()), CommTime = DateTime.Parse(item[2].ToString()), Grade = float.Parse(item[3].ToString()), Comment = item[4].ToString(), UserName = item[5].ToString() };
                lst.Add(emp);
            }
            return lst;
        }

        public List<Model.CComment> getCCommentList(int CinemaID)
        {
            List<Model.CComment> lst = new List<Model.CComment>();
            DataTable dt = DBUtility.SqlHelper.executeTable("select * from CComment where CinemaID="+CinemaID, CommandType.Text, null);
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
            string sql = "INSERT INTO CComments Values (CComentID=" + ccomment.CCommentID + ",CinemaID=" + ccomment.CinemaID + ",UserName=" + ccomment.UserName + ",Comment=" + ccomment.Comment + ",CommTime=" + ccomment.CommTime + ",Grade=" + ccomment.Grade + ")";
            int dt = DBUtility.SqlHelper.executeNonQuery(sql, CommandType.Text, null);
            if (dt == 1) return true;
            else return false;
            
            //throw new NotImplementedException();
        }

        public bool removeCComent(int id)
        {
            List<Model.CComment> lst = new List<Model.CComment>();
            string sql = "DELETE FROM CComments where CinemaID=" + id ;
            int dt = DBUtility.SqlHelper.executeNonQuery(sql, CommandType.Text, null);
            if (dt == 1) return true;
            else return false;
           // throw new NotImplementedException();
        }
    }
}
