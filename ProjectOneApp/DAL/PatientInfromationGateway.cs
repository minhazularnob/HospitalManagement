using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ProjectOneApp.Models.Entity_Models;

namespace ProjectOneApp.DAL
{
    public class PatientInfromationGateway:CommonGateway
    {

        public int Save(PatientInformation patientInformation)
        {
            string query = "INSERT INTO  Patient (Name,DateOfBirth, Mobile) VALUES('" + patientInformation.Name + "','" +
                           patientInformation.DateOfBirth + "','" + patientInformation.MobileNo + "'); SELECT CAST (scope_identity() AS int)";

            Connection.Open();
            Command.CommandText = query;

            int rowId = (int) Command.ExecuteScalar();
            Connection.Close();

            return rowId;
        }

        public PatientInformation GetPatientByMobile(Models.View_Models.ViewFourthCaseInformation viewFourthCaseInformation)
        {
            string query = "SELECT * FROM Patient WHERE Mobile='"+viewFourthCaseInformation.MobileNo+"'";
            Connection.Open();
            Command.CommandText = query;

            SqlDataReader reader = Command.ExecuteReader();
            PatientInformation patientInformation = null;

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    patientInformation = new PatientInformation();
                    patientInformation.Id = (int) reader["Id"];
                    patientInformation.Name = reader["Name"].ToString();
                    patientInformation.DateOfBirth = (DateTime) reader["DateOfBirth"];
                    patientInformation.MobileNo = reader["Mobile"].ToString();
                }
            }
            reader.Close();
            Connection.Close();
            return patientInformation;
        }
    }
}