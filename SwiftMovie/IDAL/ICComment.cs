using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace IDAL
{
    public interface ICComment
    {
        List<CComment> getCCommentList();
        List<CComment> getCCommentList(int CinemaID);
        /// <summary>
        /// 增加一条评论
        /// </summary>
        /// <param name="ccomment">注意：时间不能直接传入，在方法里生成</param>
        /// <returns></returns>
        bool addCComment(CComment ccomment);
        bool removeCComent(int id);
    }
}
