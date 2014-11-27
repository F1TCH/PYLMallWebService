using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EWDTWebServiceApp.Models;

namespace EWDTWebServiceApp.Controllers
{
    public class FloorPlanController : ApiController
    {
        static readonly IFloorPlanRepository repository = new FloorPlanRepository();

        public IEnumerable<FloorPlanClass> GetAllFloorPlan()
        {
            return repository.GetAll();
        }
        public FloorPlanClass GetUnit(string unit)
        {
            FloorPlanClass item = repository.GetByUnit(unit);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public HttpResponseMessage PostUnit(FloorPlanClass item)
        {
            item = repository.Add(item);
            var response = Request.CreateResponse<FloorPlanClass>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Unit });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutUnit(string UnitNo, FloorPlanClass unit)
        {
            unit.Unit = UnitNo;
            if (!repository.Update(unit))
            {
                // throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public HttpResponseMessage DeleteUnit(string unit)
        {
            repository.Remove(unit);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
