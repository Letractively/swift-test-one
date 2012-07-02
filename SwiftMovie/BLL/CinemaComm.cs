using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    class CinemaComm
    {
        /// <summary>
        /// 获取电影院的评论，并按照时间降序排列
        /// </summary>
        /// <param name="cinemaID">电影院ID</param>
        /// <returns>时间降序排列的评论</returns>
        public List<Model.CComment> getCCommentById(int cinemaID)
        {
            IDAL.ICComment CComment = DALFactory.DataAccess.createDalCComment();
            return CComment.getCCommentList(cinemaID);
        }
        /// <summary>
        /// 增加一条评论
        /// </summary>
        /// <param name="cinemaID">电影院ID</param>
        /// <param name="userName">用户名</param>
        /// <param name="comment">评论内容</param>
        /// <param name="grade">评分</param>
        /// <returns>成功返回true，否则false</returns>
        public bool addCComment(int cinemaID, string userName, string comment, float grade)
        {
            Model.CComment CComment = new Model.CComment()
            {
                CinemaID = cinemaID,
                UserName = userName,
                Comment = comment,
                Grade = grade
            };
            IDAL.ICComment Comment = DALFactory.DataAccess.createDalCComment();
            return Comment.addCComment(CComment); 
        }
    }
}
