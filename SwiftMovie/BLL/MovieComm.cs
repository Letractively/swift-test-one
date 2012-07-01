using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using IDAL;
using DALFactory;

namespace BLL
{
    /// <summary>
    /// 查看、添加电影评论
    /// </summary>
    public class MovieComm
    {
        /// <summary>
        /// 添加一条评论
        /// </summary>
        /// <param name="comm">评论的实体</param>
        /// <returns>成功返回true，否则false</returns>
        public bool addNewComm(Cinecism comm)
        {
            ICinecism cinecism = DataAccess.createDalCinecism();
            return cinecism.addCinecism(comm);
        }
        /// <summary>
        /// 获取某电影全部评论
        /// </summary>
        /// <param name="movieID">某电影的ID编号</param>
        /// <returns>全部评论实体</returns>
        public List<Cinecism> getMovieComm(int movieID)
        {
            ICinecism cinecism = DataAccess.createDalCinecism();
            List<Cinecism> lst = cinecism.getCinecismList(movieID);
            return lst;
        }
    }
}
