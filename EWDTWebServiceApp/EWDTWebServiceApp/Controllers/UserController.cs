using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EWDTWebServiceApp.Models;

namespace EWDTWebServiceApp.Controllers
{
    public class UserController : ApiController
    {
        static readonly IUserRepository repository = new UserRepository();

        public IEnumerable<UserClass> GetAllUser()
        {
            return repository.GetAll();
        }
        public UserClass GetUser(string user)
        {
            UserClass item = repository.GetByUser(user);
            if(item==null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public HttpResponseMessage PostUser(UserClass item)
        {
            item = repository.Add(item);
                var response = Request.CreateResponse<UserClass>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new {id=item.Username});
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutUser(string Username,UserClass user)
        {
            user.Username = Username;
            if (!repository.Update(user))
            {
                // throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public HttpResponseMessage DeleteUser(string user)
        {
            repository.Remove(user);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
