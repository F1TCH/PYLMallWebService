using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EWDTWebServiceApp.Models;
using EWDTWebServiceApp.Repositories;

namespace EWDTWebServiceApp.Controllers

    public class BidController : ApiController
    {
        static readonly IBidRepository repository = new BidController();

        public IEnumerable<BidClass> GetAllBid()
        {
            BidClass bid = repository.GetById(Id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }
        public HttpResponseMessage PostBid(BidClass item)

    }

