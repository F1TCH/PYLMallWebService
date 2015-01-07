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
        UserAccount GetEmail(string id); //get email
        UserAccount Add(UserAccount item);//register
        void Remove(string id);//delete
        bool UpdatePassword(UserAccount password);
        bool UpdateEmail(UserAccount id);//update email
    }
}
