using EWDTWebService.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWDTWebService.IRepository
{
    interface IUserAccountRepository
    {
        UserAccount GetUserByUsername(string id); //login
        UserAccount AddUser(UserAccount user);
        void DeleteUser(string user);
        bool UpdateUserPassword(UserAccount password);
        bool UpdateUserEmail(UserAccount email);
    }
}
