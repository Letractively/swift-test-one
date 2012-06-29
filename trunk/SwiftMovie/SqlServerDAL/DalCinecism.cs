using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlServerDAL
{
    public class DalCinecism:IDAL.ICinecism
    {
        public List<Model.Cinecism> getCinecismList()
        {
            throw new NotImplementedException();
        }

        public List<Model.Cinecism> getCinecismList(int movieID)
        {
            throw new NotImplementedException();
        }

        public bool addCinecism(Model.Cinecism cinecism)
        {
            throw new NotImplementedException();
        }

        public bool removeCinecism(int id)
        {
            throw new NotImplementedException();
        }
    }
}
