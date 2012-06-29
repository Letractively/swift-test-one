using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace IDAL
{
    public interface ICinecism
    {
        List<Cinecism> getCinecismList();
        List<Cinecism> getCinecismList(int movieID);
        /// <summary>
        /// 增加一条评论
        /// </summary>
        /// <param name="cinecism">注意：时间为系统时间，不要求这就传入，可在方法里生成</param>
        /// <returns></returns>
        bool addCinecism(Cinecism cinecism);
        bool removeCinecism(int id);
    }
}
