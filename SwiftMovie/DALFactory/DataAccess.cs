using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL;
using System.Configuration;
using System.Reflection;

namespace DALFactory
{
    public abstract class DataAccess
    {
        static string path = ConfigurationManager.AppSettings["WebDAL"].ToString();
        public static IUser createDalUser()
        {
            IUser user = (IUser)Assembly.Load(path).CreateInstance(path + ".DalUser");
            return user;
        }
        public static IMovie createDalMovie()
        {
            IMovie movie = (IMovie)Assembly.Load(path).CreateInstance(path + ".DalMovie");
            return movie;
        }
        public static ICComment createDalCComment()
        {
            ICComment ccomment = (ICComment)Assembly.Load(path).CreateInstance(path + ".DalCComment");
            return ccomment;
        }
        public static ICinecism createDalCinecism()
        {
            ICinecism cinecism = (ICinecism)Assembly.Load(path).CreateInstance(path + ".DalCinecism");
            return cinecism;
        }
        public static ICinema createDalCinema()
        {
            ICinema cinema = (ICinema)Assembly.Load(path).CreateInstance(path + ".DalCinema");
            return cinema;
        }
        public static IPlay createDalPlay()
        {
            IPlay play = (IPlay)Assembly.Load(path).CreateInstance(path + ".DalPlay");
            return play;
        }
        public static IPlayTime createDalPlayTime()
        {
            IPlayTime playTime = (IPlayTime)Assembly.Load(path).CreateInstance(path + ".DalPlayTime");
            return playTime;
        }
    }
}
