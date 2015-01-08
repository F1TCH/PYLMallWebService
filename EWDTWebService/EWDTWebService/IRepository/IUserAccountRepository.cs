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
        //bool Login(string username, string password); // login

        ////UserAccount GetEmail(string id); //get email
        //UserAccount Add(UserAccount item);//register
        //void Remove(string id);//delete
        //bool UpdateUserPassword(UserAccount password);
        //bool UpdateUserEmail(UserAccount id);//update email

        UserAccount Login(string userID);
        UserAccount Register(UserAccount item);
        void DeleteUser(string id);
        bool UpdateUser(UserAccount item); 
    }
}
