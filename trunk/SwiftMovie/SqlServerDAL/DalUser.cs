using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlServerDAL
{
    public class DalUser:IDAL.IUser
    {
        public List<Model.User> getUserList()
        {
            throw new NotImplementedException();
        }

        public Model.User getUser(string name, string password)
        {
            throw new NotImplementedException();
        }

        public bool addNewUser(Model.User user)
        {
            throw new NotImplementedException();
        }

        public bool eidtUser(Model.User user)
        {
            throw new NotImplementedException();
        }

        public bool removeUser(int userID)
        {
            throw new NotImplementedException();
        }
    }
}
