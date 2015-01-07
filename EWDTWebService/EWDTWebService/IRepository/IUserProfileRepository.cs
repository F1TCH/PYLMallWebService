using EWDTWebService.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWDTWebService.IRepository
{
    interface IUserProfileRepository
    {
        UserClass GetUserByUsername(string id); //login
        //UserAccount GetEmailbyUsername(string id); //get email
        UserClass Add(UserClass item);//register
        void Remove(string id);//delete
        //bool UpdateUserPassword(UserAccount password);
        //bool UpdateUserEmail(UserAccount id);//update email
    }
}
