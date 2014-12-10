﻿using EWDTWebService.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWDTWebService.IRepository
{
    interface IFloorPlanRepository
    {
        IEnumerable<FloorPlan> GetAll();
    }
}
