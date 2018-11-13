using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Hosting;
using Patient_API.Models.BLL;
using Patient_API.Models.Common;
using Patient_API.Models.DAL;

namespace Patient_API.Controllers
{
    /// <summary>
    /// This class has two endpoint to display the Patient details and insert the patient information
    /// </summary>
    public class PatientController : ApiController
    {
        #region MemberVariable(s)
        IPatientData ObjPatientBusiness;
        #endregion
        public PatientController(IPatientData _ObjPatientBusiness)
        {
            ObjPatientBusiness = _ObjPatientBusiness;

        }

        public PatientController()
        {
            DataAccessLayer objDataAccessLayer = new DataAccessLayer();
        }

        /// <summary>
        /// This method is used to display the Patient details
        /// </summary>
        /// <returns>HttpResponseMessage</returns>
        [HttpGet]
        public HttpResponseMessage Get()
        {
            List<PatientDetails> PatientDetailsList;
            HttpResponseMessage response = null;
            HttpRequestMessage request = new HttpRequestMessage();
            request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());

            try
            {
                LogHelper.Info("Get Patient details");
                PatientDetailsList = ObjPatientBusiness.GETPatientDetails();
                response = request.CreateResponse<List<PatientDetails>>(HttpStatusCode.OK, PatientDetailsList);
                LogHelper.Info("Get XML Patient details completed ");
            }
            catch (Exception Ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, Ex.Message);
                LogHelper.Error("Get Patient details API error.", Ex);
            }

            return response;
        }



        /// <summary>
        /// Post method to insert the data in XML format for Patient
        /// </summary>
        /// <param name="patientInformation">Model</param>
        /// <returns>HttpResponseMessage</returns>
        [HttpPost]
        public HttpResponseMessage Post(PatientDetails patientInformation)
        {
            string msg = string.Empty;
            HttpResponseMessage response = null;
            HttpRequestMessage request = new HttpRequestMessage();
            request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());

            try
            {
                LogHelper.Info("Insert patient details invoked");
                ObjPatientBusiness.InsertPatient(patientInformation);
                response = request.CreateResponse<PatientDetails>(HttpStatusCode.OK, patientInformation);
                LogHelper.Info("Insert patient details completed");
            }
            catch (Exception Ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, Ex.Message);
                LogHelper.Error("Insert patient details error", Ex);
            }
            return response;
        }


    }


}

