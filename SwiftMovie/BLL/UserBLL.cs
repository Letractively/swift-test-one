using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class UserBLL
    {
        /// <summary>
        /// 注册新用户
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">用户密码</param>
        /// <param name="email">用户email地址</param>
        /// <param name="address">用户住址</param>
        /// <returns>用户名已存在，返回0；用户注册成功，返回1；否则返回-1.</returns>
        public int register(string userName, string password, string email, string address)
        {
            IDAL.IUser IUser = DALFactory.DataAccess.createDalUser();
            if (IUser.isUserExist(userName))
            {
                return 0;
            }
            else
            {
                Model.User User = new Model.User()
                {
                    UserName = userName,
                    Password = password,
                    Email = email,
                    Address = address,
                    BookState = true
                };
                if (IUser.addNewUser(User))
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>成功返回true，否则false</returns>
        public bool login(string userName, string password)
        {
            IDAL.IUser IUser = DALFactory.DataAccess.createDalUser();
            Model.User User = IUser.getUser(userName, password);
            if (User == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
