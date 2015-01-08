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

        public UserAccount Register(UserAccount item)
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


        public UserAccount Login(string userID)
        {
            return RentDBManager.Login(userID);
        }

        public bool UpdateUser(UserAccount item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            if (RentDBManager.Update(item) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void DeleteUser(string id)
        {
            RentDBManager.DeleteAccount(id);
        }
    }
}