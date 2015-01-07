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

        //Login
        public bool Login(string username, string password)
        {
            bool result = repository.Login(username, password);
            return true;
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
        public HttpResponseMessage PostUser(UserAccount item)
        {
            item = repository.Add(item);
            var response = Request.CreateResponse<UserAccount>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.username });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public HttpResponseMessage DeleteUser(string id)
        {
            repository.Remove(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }


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
