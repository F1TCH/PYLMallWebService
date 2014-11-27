using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWDTWebServiceApp.Models
{
    interface IFloorPlanRepository
    {
        IEnumerable<FloorPlanClass> GetAll();
        FloorPlanClass GetByUnit(string unit);
        FloorPlanClass Add(FloorPlanClass item);
        void Remove(string unit);
        bool Update(FloorPlanClass item);
    }
}
