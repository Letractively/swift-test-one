using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    class PlayTimeBLL
    {
        public List<Model.PlayTime> getPlayTimeList(int movieID, int cinemaID)
        {
            IDAL.IPlayTime lst = DALFactory.DataAccess.createDalPlayTime();
            return lst.getPlayTimeList(movieID, cinemaID);
        }
    }
}
