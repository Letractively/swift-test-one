using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SqlServerDAL
{
    public class DalUser:IDAL.IUser
    {
        public List<Model.User> getUserList()
        {
            //throw new NotImplementedException();
            List<Model.User> lst = new List<Model.User>();
            DataTable dt = DBUtility.SqlHelper.executeTable("select * from Users", CommandType.Text, null);
            foreach (DataRow item in dt.Rows)
            {
                Model.User emp = new Model.User()
                {
                    UserID = int.Parse(item[0].ToString()),
                    UserName = item[1].ToString(),
                    Password = item[2].ToString(),
                    Email = item[3].ToString(),
                    Address = item[4].ToString(),
                    BookState=bool.Parse(item[5].ToString()),
                };
                lst.Add(emp);
            }
            return lst;
        }

        public Model.User getUser(string name, string password)
        {
            Model.User lst = new Model.User();
            DataTable dt = DBUtility.SqlHelper.executeTable("select * from Users where UserName="+name+",and Password="+password, CommandType.Text, null);

            foreach (DataRow item in dt.Rows)
            {
                Model.User emp = new Model.User()
                {

                    UserID = int.Parse(item[0].ToString()),
                    UserName = item[1].ToString(),
                    Password = item[2].ToString(),
                    Email = item[3].ToString(),
                    Address = item[4].ToString(),
                    BookState = bool.Parse(item[5].ToString()),
                };
                lst=emp;
            }
            return lst;
            
            //throw new NotImplementedException();
        }

        public bool addNewUser(Model.User user)
        {
            List<Model.User> lst = new List<Model.User>();
            string sql = "INSERT INTO Users Values (UserID=" + user.UserID
                + ",UserName=" + user .UserName + ",Password=" + user.Password
                + ",Email=" + user.Email + ",Address" + user.Address +",BookState="+user.BookState+ ")";
            int dt = DBUtility.SqlHelper.executeNonQuery(sql, CommandType.Text, null);
            if (dt == 1) return true;
            else return false;
            //throw new NotImplementedException();
        }

        public bool eidtUser(Model.User user)
        {
            List<Model.User> lst = new List<Model.User>();
            string sql = "Uddate Users set UserID=" + user.UserID
                + ",UserName=" + user.UserName + ",Password=" + user.Password
                + ",Email=" + user.Email + ",Address" + user.Address + ",BookState=" + user.BookState + ")";
            int dt = DBUtility.SqlHelper.executeNonQuery(sql, CommandType.Text, null);
            if (dt == 1) return true;
            else return false;
            //throw new NotImplementedException();
        }

        public bool removeUser(int userID)
        {
            List<Model.User> lst = new List<Model.User>();
            string sql = "Delete From Users where UserID=" + userID;
            int dt = DBUtility.SqlHelper.executeNonQuery(sql, CommandType.Text, null);
            if (dt == 1) return true;
            else return false;
            //throw new NotImplementedException();
        }
    }
}
