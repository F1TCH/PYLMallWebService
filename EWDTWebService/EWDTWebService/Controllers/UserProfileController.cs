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

        public UserClass GetProfile(string UserID)
        {
            UserClass item = repository.RetrieveProfile(UserID);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public HttpResponseMessage PostUser(UserClass item)
        {
            item = repository.Register(item);
            var response = Request.CreateResponse<UserClass>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { username = item.Username });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutUser(string id, UserClass user)
        {
            //user.Username = id;

            if (!repository.UpdateProfile(user))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public HttpResponseMessage DeleteUser(string id)
        {
            repository.DeleteUser(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
