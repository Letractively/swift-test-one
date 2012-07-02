using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    class CinecismBLL
    {
        /// <summary>
        /// 获取电影的影评，并安时间降序排列
        /// </summary>
        /// <param name="movieID">电影的ID</param>
        /// <returns>时间降序排列的评论</returns>
        public List<Model.Cinecism> getCinecismById(int movieID)
        {
            IDAL.ICinecism Cinecism = DALFactory.DataAccess.createDalCinecism();
            return Cinecism.getCinecismList(movieID);
        }
        /// <summary>
        /// 添加一条影评
        /// </summary>
        /// <param name="movieID">电影的ID</param>
        /// <param name="userName">用户名</param>
        /// <param name="comment">评论内容</param>
        /// <returns>成功返回true，否则false</returns>
        public bool addCinecism(int movieID,string userName,string comment)
        {
            Model.Cinecism Cinecism = new Model.Cinecism()
            {
                UserName = userName,
                Comment = comment,
                MovieID = movieID
            };
            IDAL.ICinecism ICinecism = DALFactory.DataAccess.createDalCinecism();
            return ICinecism.addCinecism(Cinecism);
        }
    }
}
