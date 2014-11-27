using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EWDTWebServiceApp.Models
{
    public class UserRepository : IUserRepository
    {
        public UserRepository()
        {

        }
        public IEnumerable<UserClass> GetAll()
        {
            return RentDBManager.GetAllUser().Cast<UserClass>();   
        }
        public UserClass GetByUser(string user)
        {
            return RentDBManager.GetUserbyUsername(user);
        }
        public UserClass Add(UserClass item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            if (RentDBManager.InsertUser(item) == 0)
            {
                return null;
            }
            else
            {
                return item;
            }
        }
        public void Remove(string user)
        {
            RentDBManager.DeleteUser(user);
        }
        public bool Update(UserClass item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            if (RentDBManager.UpdateUser(item) == 0)
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
