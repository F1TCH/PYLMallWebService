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
    public class FloorPlanController : ApiController
    {
        static readonly IFloorPlanRepository repository = new FloorPlanRepository();

        public IEnumerable<FloorPlan> GetAllUnit()
        {
            return repository.GetAll();
        }
    }
}
