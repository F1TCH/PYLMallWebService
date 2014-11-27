using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EWDTWebServiceApp.Models;

namespace EWDTWebServiceApp.Controllers
{
    public class BidController : ApiController
    {
        static readonly IBidRepository repository = new BidRepository();

        public IEnumerable<BidClass> GetAllBid()
        {
            return repository.GetAll();
        }
        public BidClass GetBid(double bid)
        {
            BidClass item = repository.GetByBid(bid);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public HttpResponseMessage PostBid(BidClass item)
        {
            item = repository.Add(item);
            var response = Request.CreateResponse<BidClass>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.BiddingAmt });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutBid(double BiddingAmt, BidClass bid)
        {
            bid.BiddingAmt = BiddingAmt;
            if (!repository.Update(bid))
            {
                // throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public HttpResponseMessage DeleteBid(double bid)
        {
            repository.Remove(bid);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}