using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

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
            string sql = "SELECT * FROM Users WHERE UserName=@userName AND Password=@password";
            SqlParameter[] sps = new SqlParameter[]{
                new SqlParameter(){ParameterName="@userName",Value=name},
                new SqlParameter(){ParameterName="@password",Value=password}
            };
            SqlDataReader item = DBUtility.SqlHelper.executeReader(sql, CommandType.Text, sps);
            if (item.Read())
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
                return emp;
            }
            else
            {
                return null;
            }
            //DataTable dt = DBUtility.SqlHelper.executeTable("select * from Users where UserName="+name+",and Password="+password, CommandType.Text, null);

            //foreach (DataRow item in dt.Rows)
            //{
            //    Model.User emp = new Model.User()
            //    {

            //        UserID = int.Parse(item[0].ToString()),
            //        UserName = item[1].ToString(),
            //        Password = item[2].ToString(),
            //        Email = item[3].ToString(),
            //        Address = item[4].ToString(),
            //        BookState = bool.Parse(item[5].ToString()),
            //    };
            //    lst=emp;
            //}
            //return lst;
            
            //throw new NotImplementedException();
        }

        public bool addNewUser(Model.User user)
        {
            List<Model.User> lst = new List<Model.User>();
            string sql = "INSERT INTO Users(UserName,Password,Email,Address,BookState) Values ('" + user.UserName + "','" + user.Password
                + "','" + user.Email + "','" + user.Address + "','" + user.BookState + "')";
            int dt = DBUtility.SqlHelper.executeNonQuery(sql, CommandType.Text, null);
            if (dt == 1) return true;
            else return false;
            //throw new NotImplementedException();
        }

        public bool eidtUser(Model.User user)
        {
            List<Model.User> lst = new List<Model.User>();
            string sql = "Update Users set UserID=" + user.UserID
                + ",UserName=" + user.UserName + ",Password=" + user.Password
                + ",Email=" + user.Email + ",Address" + user.Address + ",BookState=" + user.BookState ;
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


        public bool isUserExist(string userName)
        {
            string sql = "SELECT * FROM Users WHERE UserName=@userName";
            SqlParameter[] sps = new SqlParameter[]{
                new SqlParameter(){ParameterName="@userName",Value=userName}
            };
            SqlDataReader sr = DBUtility.SqlHelper.executeReader(sql, CommandType.Text, sps);
            if (sr.Read())
            {
                return true;
            }
            else 
            {
                return false;
            }
            //throw new NotImplementedException();
        }
    }
}
