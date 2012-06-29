using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace IDAL
{
    public interface IUser
    {
        List<User> getUserList();
        User getUser(string name, string password);
        bool addNewUser(User user);
        bool eidtUser(User user);
        bool removeUser(int userID);
    }
}
