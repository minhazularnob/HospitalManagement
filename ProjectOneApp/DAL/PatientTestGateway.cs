using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ProjectOneApp.Models.Entity_Models;
using ProjectOneApp.Models.View_Models;

namespace ProjectOneApp.DAL
{
    public class PatientTestGateway:CommonGateway
    {
        public bool Save(PatientTest patientTest)
        {
            string query = "INSERT INTO PatientTest (TestSetupId, PatientId) VALUES('" + patientTest.TestSetupId + "','" +
                           patientTest.PatientId + "')";

            Connection.Open();
            Command.CommandText = query;

            int rowsEffected = Command.ExecuteNonQuery();
            Connection.Close();

            return rowsEffected > 0;
        }

        public double GetTotalFee(int patientId)
        {
            string query = "SELECT SUM(FEE) FROM VW_ThirdCaseInformation WHERE Id = '" + patientId + "'";
            Connection.Open();
            Command.CommandText = query;

            double totalFee =(double) Command.ExecuteScalar();

            return totalFee;
        }

        public List<ViewThirdCaseInformation> GeThirdCaseInformations(int patientId)
        {
            string query = "SELECT * FROM VW_ThirdCaseInformation WHERE Id = '"+patientId+"'";
            Connection.Open();
            Command.CommandText = query;

            SqlDataReader reader = Command.ExecuteReader();
            List<ViewThirdCaseInformation> viewThirdCaseInformations = new List<ViewThirdCaseInformation>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ViewThirdCaseInformation thirdCaseInformation = new ViewThirdCaseInformation();
                    
                    thirdCaseInformation.TestName = reader["TestName"].ToString();
                    thirdCaseInformation.Fee = (double)reader["Fee"];
                    viewThirdCaseInformations.Add(thirdCaseInformation);
                }
            }
            reader.Close();
            Connection.Close();

            return viewThirdCaseInformations;
        }

        public PatientTest GetById(int testId)
        {
            string query = "SELECT * FROM PatientTest WHERE TestSetupId = '" + testId + "'";
            Connection.Open();
            Command.CommandText = query;

            SqlDataReader reader = Command.ExecuteReader();

            PatientTest patientTest = null;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    patientTest = new PatientTest();
                    patientTest.Id = (int) reader["Id"];
                    patientTest.PatientId = (int) reader["PatientId"];
                    patientTest.TestSetupId = (int) reader["TestSetupId"];
                }
            }
            reader.Close();
            Connection.Close();
            return patientTest;
        }
    }
}