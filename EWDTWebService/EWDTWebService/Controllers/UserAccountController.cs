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

        public UserAccount GetUserByUserID(string UserID)//login
        {
            UserAccount item = repository.Login(UserID);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }
            return item;
        }

        public HttpResponseMessage PostUser(UserAccount item)//register
        {
            item = repository.Register(item);
            var response = Request.CreateResponse<UserAccount>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { username = item.username });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutUser(string id, UserAccount user)
        {
            user.username = id;

            if (!repository.UpdateUser(user))
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
