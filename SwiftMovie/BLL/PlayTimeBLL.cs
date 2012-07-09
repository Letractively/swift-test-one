using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class PlayTimeBLL
    {
        public List<Model.PlayTime> getPlayTimeList(int movieID, int cinemaID)
        {
            IDAL.IPlayTime lst = DALFactory.DataAccess.createDalPlayTime();
            return lst.getPlayTimeList(movieID, cinemaID);
        }
        public List<Model.PlayTime> getPlayTimeList()
        {
            IDAL.IPlayTime lst = DALFactory.DataAccess.createDalPlayTime();
            return lst.getPlayTimeList();
        }
        public List<Model.PlayTime> getPlayTimeList(int movieID)
        {
            IDAL.IPlayTime lst = DALFactory.DataAccess.createDalPlayTime();
            return lst.getPlayTimeList(movieID);
        }
    }
}
