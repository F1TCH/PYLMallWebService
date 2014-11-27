using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EWDTWebServiceApp.Models
{
    public class FloorPlanRepository : IFloorPlanRepository
    {
        public FloorPlanRepository()
        {

        }
        public IEnumerable<FloorPlanClass> GetAll()
        {
            return RentDBManager.GetAllFloorPlan().Cast<FloorPlanClass>();  
        }
        public FloorPlanClass GetByUnit(string unit)
        {
            return RentDBManager.GetFloorPlanbyUnit(unit);
        }
        public FloorPlanClass Add(FloorPlanClass item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            if (RentDBManager.InsertFloor(item) == 0)
            {
                return null;
            }
            else
            {
                return item;
            }
        }
        public void Remove(string unit)
        {
            RentDBManager.DeleteFloorPlan(unit);
        }
        public bool Update(FloorPlanClass item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            if (RentDBManager.UpdateFloorPlan(item) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
