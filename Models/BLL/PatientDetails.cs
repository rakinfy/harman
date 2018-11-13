using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Patient_API.Models.BLL
{
    public class PatientDetails
    {
        // The forename
        public string ForeName { get; set; }
        // The surname
        public string Surname { get; set; }
        // Date of birth
        public DateTime DateOfBirth { get; set; }
        // Gender
        public Gender Gender { get; set; }
        // Telephone numbers
        public List<Telephone> Telephones { get; set; }
    }


    // Enumeration for gender
    public enum Gender
    {
        Male = 0,
        Female = 1,
        Other = 2
    }
}