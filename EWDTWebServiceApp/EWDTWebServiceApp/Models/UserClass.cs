using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EWDTWebServiceApp.Models
{
    public class UserClass
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string NRIC { get; set; }
        public string Email { get; set; }
        public int TelephoneNo { get; set; }
        public int HandphoneNo { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string DoB { get; set; }
        public string SQ1 { get; set; }
        public string SQ2 { get; set; }
        public string SQAns1 { get; set; }
        public string SQAns2 { get; set; }
    }
}