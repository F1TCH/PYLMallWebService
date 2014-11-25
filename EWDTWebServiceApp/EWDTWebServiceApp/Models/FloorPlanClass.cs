using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EWDTWebServiceApp.Models
{
    public class FloorPlanClass
    {
        public string Unit { get; set; }
        public int UnitLevel { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Condition { get; set; }
        public string Imagefile { get; set; }
    }
}