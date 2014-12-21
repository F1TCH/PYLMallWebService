using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EWDTWebService.Class
{
    public class UserProfile
    {
        public string nric { get; set; }
        public int Telno { get; set; }
        public int Handphno { get; set; }
        public string gender { get; set; }
        public string address { get; set; }
        public string DoB { get; set; }
        public string SQ1 { get; set; }
        public string SQ2 { get; set; }
        public string SQAns1 { get; set; }
        public string SQAns2 { get; set; }
    }
}