using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Patient_API.Models.BLL
{
    public class Telephone
    {
        public PhoneType PhoneType { get; set; }
        public string PhoneNumber { get; set; }
    }
    // Enumeration for phone type
    public enum PhoneType
    {
        Home = 0,
        Work = 1,
        Mobile = 2
    }
}