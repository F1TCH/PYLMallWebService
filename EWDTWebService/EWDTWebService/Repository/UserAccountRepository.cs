using EWDTWebService.Class;
using EWDTWebService.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EWDTWebService.Repository
{
    public class UserAccountRepository : IUserAccountRepository
    {
        public UserAccountRepository()
        {

        }

        public UserAccount AddUser(UserAccount user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            if (RentDBManager.InsertUser(user) == 0)
            {
                return null;
            }
            else return user;
        }

        public UserAccount GetUser(string user)
        {
            return RentDBManager.GetUserbyUsername(user);
        }

        public void DeleteUser(string username)
        {
            RentDBManager.DeleteUser(username);
        }

        public bool UpdateUserPassword(UserAccount password)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            if(RentDBManager.UpdateUserPassword(password)==0)
            {
                return false;
            }
            else 
            {
                return true;
            }
        }
        public bool UpdateUserEmail(UserAccount email)
        {
            if (email == null)
            {
                throw new ArgumentNullException("email");
            }
            if (RentDBManager.UpdateUserEmail(email) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}