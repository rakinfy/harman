using Patient_API.Models.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Patient_API.Models.DAL
{
    /// <summary>
    /// This class is for connecting to database and retriving the information
    /// </summary>
    public class DataAccessLayer
    {
        public SqlConnection _connection { get; set; }
        public SqlCommand cmd;

        /// <summary>
        /// connecting to SQl connection
        /// </summary>
        public void Connection()
        {
            _connection = new SqlConnection("Data Source=.;Initial Catalog=TestDB;Integrated Security=True;"); 
            try
            {
                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();
            }
            catch (Exception Ex)
            {
                LogHelper.Error("Error while connecting to SQL.", Ex);
                throw new InvalidOperationException(Ex.Message);
            }
        }

      
        /// <summary>
        /// Insert the patient details
        /// </summary>
        /// <param name="xmlvalue">String</param>
        /// <returns>int</returns>
        public int SetPatientInfo(string xmlvalue)
        {
            int i = 0;
            string msg = string.Empty;

            try
            {
                Connection();
                cmd = new SqlCommand("SavePatientData", _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@data", SqlDbType.Xml).Value = xmlvalue;
                i = cmd.ExecuteNonQuery();
                _connection.Close();
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error while inserting the Patient information.", ex);
                throw new InvalidOperationException(ex.Message);
            }
            return i;
        }

        
        /// <summary>
        /// Get the patient information from SQL DB
        /// </summary>
        /// <returns>List</returns>
        public List<string> GetPatientInfo()
        {
            var patientmodellist = new List<string>();

            try
            {
                Connection();
                cmd = new SqlCommand("GetPatientData", _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader _sqlDataReader = cmd.ExecuteReader();
                while (_sqlDataReader.Read())
                {
                    patientmodellist.Add(_sqlDataReader.GetString(_sqlDataReader.GetOrdinal("PatientDetail")));
                }

                _connection.Close();
            }
            catch (Exception ex)
            {
                LogHelper.Error("Error while connecting to SQL.", ex);
                throw new InvalidOperationException(ex.Message);
            }

            return patientmodellist;
        }
    }
}
