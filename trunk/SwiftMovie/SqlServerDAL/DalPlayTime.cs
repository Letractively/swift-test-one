using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlServerDAL
{
    public class DalPlayTime:IDAL.IPlayTime
    {
        public List<Model.PlayTime> getPlayTimeList()
        {
            throw new NotImplementedException();
        }

        public List<Model.PlayTime> getPlayTimeList(int movieID, int cinemaID)
        {
            throw new NotImplementedException();
        }

        public bool addNewPlaytime(Model.PlayTime playTime)
        {
            throw new NotImplementedException();
        }

        public bool removePlaytime(int playTimeID)
        {
            throw new NotImplementedException();
        }

        public bool editPlaytime(Model.PlayTime playTime)
        {
            throw new NotImplementedException();
        }
    }
}
