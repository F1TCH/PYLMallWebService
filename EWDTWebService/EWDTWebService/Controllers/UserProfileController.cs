using EWDTWebService.Class;
using EWDTWebService.IRepository;
using EWDTWebService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EWDTWebService.Controllers
{
    public class UserProfileController : ApiController
    {
        static readonly IUserProfileRepository repository = new UserProfileRepository();

        //Login
        public UserProfile GetUserByUsername(string id)
        {
            UserProfile item = repository.GetUserByUsername(id);

            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        //public UserAccount GetEmailbyUsername(string id)
        //{
        //    UserAccount item = repository.GetEmailbyUsername(id);

        //    if (item == null)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }
        //    return item;
        //}
        //register
        public HttpResponseMessage PostUser(UserProfile item)
        {
            item = repository.Add(item);
            var response = Request.CreateResponse<UserProfile>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public HttpResponseMessage DeleteUser(string id)
        {
            repository.Remove(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }


        //public bool UpdatePassword(UserAccount password)
        //{
        //    if (password == null)
        //    {
        //        throw new ArgumentNullException("password");
        //    }
        //    if (RentDBManager.UpdateUserPassword(password) == null)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}
        //public void PutUser(string id, UserAccount useraccount)
        //{
        //    useraccount.username = id;
        //    if(!repository.UpdateUserEmail(useraccount))
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }
        //}
    }
}
