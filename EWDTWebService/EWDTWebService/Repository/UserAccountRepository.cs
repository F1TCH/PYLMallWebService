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

        public UserAccount Add(UserAccount item)//register
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            if (RentDBManager.Register(item) == 0)
            {
                return null;
            }

            else
            {
                return item;
            }
        }

        public void Remove(string id)//delete
        {
            RentDBManager.DeleteAccount(id);
        }

        public bool UpdateUserPassword(UserAccount password)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            if (RentDBManager.UpdatePassword(password) == 0)
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
            if (RentDBManager.UpdateEmail(email) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool Login(string username, string password)
        {
            bool result = RentDBManager.Login(username, password);
            return result;
        }
    }
}