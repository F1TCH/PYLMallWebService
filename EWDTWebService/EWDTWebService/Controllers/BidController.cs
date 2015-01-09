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
    public class BidController : ApiController
    {
        static readonly IBidRepository repository = new BidRepository();

        public BidClass GetBid(string UserID)
        {
            BidClass item = repository.RetrieveBid(UserID);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public HttpResponseMessage PostBid(BidClass item)
        {
            item = repository.Bid(item);
            var response = Request.CreateResponse<BidClass>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { username = item.Username });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutBid(string id, BidClass user)
        {
            //user.Username = id;

            if (!repository.UpdateBid(user))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public HttpResponseMessage DeleteBid(string id)
        {
            repository.DeleteBid(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
