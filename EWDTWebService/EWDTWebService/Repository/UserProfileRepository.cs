using EWDTWebService.Class;
using EWDTWebService.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EWDTWebService.Repository
{
    public class UserProfileRepository : IUserProfileRepository
    {
        public UserProfileRepository()
        {

        }

        public UserClass Register(UserClass item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            if (RentDBManager.RegisterProfile(item) == 0)
            {
                return null;
            }
            else
            {
                return item;
            }
            //return item;
        }


        public UserClass RetrieveProfile(string userID)
        {
            return RentDBManager.GetProfile(userID);
        }

        public bool UpdateProfile(UserClass item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            if (RentDBManager.UpdateProfile(item) == 0)
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
            RentDBManager.DeleteProfile(id);
        }
    }
}