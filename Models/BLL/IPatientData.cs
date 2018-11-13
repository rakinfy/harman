using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Patient_API.Models.DAL;

namespace Patient_API.Models.BLL
{
    /// <summary>
    /// Interface to display the patient details and insert the pateint Information
    /// </summary>
    public interface IPatientData
    {

        List<PatientDetails> GETPatientDetails();
        void InsertPatient(PatientDetails patientInformation);
    }
}