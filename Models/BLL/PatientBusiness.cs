using System;
using System.Collections.Generic;
using Patient_API.Models.DAL;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using Patient_API.Models.Common;

namespace Patient_API.Models.BLL
{
    /// <summary>
    /// Business class to XML Deserialize and generate the XML data to insert and display the Patient information
    /// </summary>
    public class PatientBusiness : IPatientData
    {
        /// <summary>
        /// To fetch the Patient details from the DB 
        /// </summary>
        /// <returns>List</returns>
        public List<PatientDetails> GETPatientDetails()
        {
            List<PatientDetails> PatientDetailsList;
            PatientDetailsList = new List<PatientDetails>();
            DataAccessLayer objDataAccessLayer = new DataAccessLayer();
            var listofpatientInfo = objDataAccessLayer.GetPatientInfo();

            foreach (var item in listofpatientInfo)
            {
                PatientDetailsList.Add(CreateXmlToObject(item));
            }
            return PatientDetailsList;
        }
        /// <summary>
        /// Insert the patient information
        /// </summary>
        /// <param name="patientInformation">Model</param>
        public void InsertPatient(PatientDetails patientInformation)
        {

            var resultXML = CreateObjectToXML(patientInformation);
            DataAccessLayer objDataAccessLayer = new DataAccessLayer();
            objDataAccessLayer.SetPatientInfo(resultXML);
        }

        /// <summary>
        /// Deserialize XML to Object
        /// </summary>
        /// <param name="XMLString">String</param>
        /// <returns>model</returns>
        //
        public PatientDetails CreateXmlToObject(string XMLString)
        {
            string Msg = string.Empty;
            PatientDetails patientdetails = new PatientDetails();
            XmlSerializer oXmlSerializer = new XmlSerializer(patientdetails.GetType());

            try
            {
                //The StringReader will be the stream holder for the existing XML file 
                patientdetails = (PatientDetails)oXmlSerializer.Deserialize(new StringReader(XMLString));
            }
            catch (Exception Ex)
            {
                Msg = Ex.Message;
                LogHelper.Error("error in CreateXmlToObject method.", Ex);
            }

            return patientdetails;
        }


        /// <summary>
        /// XMl generation
        /// </summary>
        /// <param name="patientdetails">Object</param>
        /// <returns>String</returns>
        public string CreateObjectToXML(Object patientdetails)
        {
            string Msg = string.Empty;
            XmlDocument xmlDoc = new XmlDocument();
            XmlSerializer xmlSerializer = new XmlSerializer(patientdetails.GetType());
            try
            {
                using (MemoryStream xmlStream = new MemoryStream())
                {
                    xmlSerializer.Serialize(xmlStream, patientdetails);
                    xmlStream.Position = 0;
                    xmlDoc.Load(xmlStream);
                }
            }
            catch (Exception Ex)
            {
                Msg = Ex.Message;
                LogHelper.Error("error in createObjectToXML method.", Ex);
            }

            return xmlDoc.InnerXml;
        }
    }
}