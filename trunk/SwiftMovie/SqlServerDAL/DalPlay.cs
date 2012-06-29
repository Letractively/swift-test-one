using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlServerDAL
{
     public class DalPlay:IDAL.IPlay
    {
        public List<Model.Play> getPlayList()
        {
            throw new NotImplementedException();
        }

        public List<Model.Play> getPlayList(int movieID)
        {
            throw new NotImplementedException();
        }

        public List<Model.Play> getPlayList(int movieID, int cinemaID)
        {
            throw new NotImplementedException();
        }

        public bool addNewPlay(Model.Play play)
        {
            throw new NotImplementedException();
        }

        public bool removePlay(int playID)
        {
            throw new NotImplementedException();
        }

        public bool editPlay(Model.Play play)
        {
            throw new NotImplementedException();
        }
    }
}
