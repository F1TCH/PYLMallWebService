using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EWDTWebService.Repository;
using EWDTWebService.Class;
using EWDTWebService.IRepository;

namespace EWDTWebService.Controllers
{
    public class UserAccountController : ApiController
    {
        static readonly IUserAccountRepository repository = new UserAccountRepository();

        public UserAccount GetUser(string user)
        {
            return RentDBManager.GetUserbyUsername(user);
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
            else
            {
                return user;
            }
        }
        public void RemoveUser(string user)
        {
            RentDBManager.DeleteUser(user);
        }
        public bool UpdatePassword(UserAccount password)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            if (RentDBManager.UpdateUserPassword(password) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool UpdateEmail(UserAccount email)
        {
            if (email == null)
            {
                throw new ArgumentNullException("email");
            }
            if (RentDBManager.UpdateUserEmail(email) == null)
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
