using EWDTWebServiceApp.Class;
using EWDTWebServiceApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWDTWebServiceApp.IRepository
{
    interface IUserAccountRepository
    {
        UserAccount GetUser(string user);
        UserAccount AddUser(UserAccount user);
        void DeleteUser(string user);
        bool UpdateUserPassword(UserAccount password);
        bool UpdateUserEmail(UserAccount email);
    }
}
