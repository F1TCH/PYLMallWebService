using EWDTWebService.Class;
using EWDTWebService.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EWDTWebService.Repository
{
    public class FloorPlanRepository : IFloorPlanRepository
    {
        public FloorPlanRepository()
        {

        }
        public IEnumerable<FloorPlan> GetAll()
        {
            return RentDBManager.GetAllUnit().Cast<FloorPlan>();
        }
        //public FloorPlan Add(FloorPlan item)
        //{
        //    if (item == null)
        //    {
        //        throw new ArgumentNullException("item");
        //    }
        //    if(RentDBManager.
        //}
    }
}