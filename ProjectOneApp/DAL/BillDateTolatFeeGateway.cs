using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ProjectOneApp.Models.Entity_Models;
using ProjectOneApp.Models.View_Models;

namespace ProjectOneApp.DAL
{
    public class BillDateTolatFeeGateway:CommonGateway
    {
        public bool Save(BillDateTotalFee billDateTotalFee)
        {
            string query = "INSERT INTO BillDateTotalFee (BillDate,BillNumber,TotalFee,PatientId,BillStatus) VALUES('" + billDateTotalFee.Date + "','" +
                           billDateTotalFee.BillNumber + "','" + billDateTotalFee.TotalFee + "','" +
                           billDateTotalFee.PatientId + "','unpaid')";

            Connection.Open();
            Command.CommandText = query;

           int rowsEffected= Command.ExecuteNonQuery();
            Connection.Close();

            return rowsEffected > 0;
        }

        public BillDateTotalFee GetBillByBillNumber(Models.View_Models.ViewFourthCaseInformation viewFourthCaseInformation)
        {
            string query = "SELECT * FROM BillDateTotalFee WHERE BillNumber='" + viewFourthCaseInformation.BillNo + "'";
            query.ToUpper();
            Connection.Open();
            Command.CommandText = query;

            SqlDataReader reader = Command.ExecuteReader();
            BillDateTotalFee billDateTotalFee = null;

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    billDateTotalFee = new BillDateTotalFee();
                    billDateTotalFee.Id = (int) reader["Id"];
                    billDateTotalFee.Date = (DateTime) reader["BillDate"];
                    billDateTotalFee.BillNumber = reader["BillNumber"].ToString();
                    billDateTotalFee.TotalFee = (double) reader["TotalFee"];
                    billDateTotalFee.PatientId = (int) reader["PatientId"];
                    billDateTotalFee.Status = reader["BillStatus"].ToString();
                }
            }
            reader.Close();
            Connection.Close();
            return billDateTotalFee;
        }

        public BillDateTotalFee GetBillByPatientId(PatientInformation patientInformation)
        {
            string query = "SELECT * FROM BillDateTotalFee WHERE PatientId='"+patientInformation.Id+"'";
            query.ToUpper();
            Connection.Open();
            Command.CommandText = query;

            SqlDataReader reader = Command.ExecuteReader();
            BillDateTotalFee billDateTotalFee = null;

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    billDateTotalFee = new BillDateTotalFee();
                    billDateTotalFee.Id = (int)reader["Id"];
                    billDateTotalFee.Date = (DateTime)reader["BillDate"];
                    billDateTotalFee.BillNumber = reader["BillNumber"].ToString();
                    billDateTotalFee.TotalFee = (double)reader["TotalFee"];
                    billDateTotalFee.PatientId = (int)reader["PatientId"];
                    billDateTotalFee.Status = reader["BillStatus"].ToString();
                }
            }
            reader.Close();
            Connection.Close();
            return billDateTotalFee;
        }

        public bool BillPay(string billNo)
        {
            string query = "UPDATE BillDateTotalFee SET BillStatus='paid' WHERE BillNumber='"+billNo+"'";
            Connection.Open();
            Command.CommandText = query;

            int row_Affected = Command.ExecuteNonQuery();
            return row_Affected > 0;
        }

        public List<ViewSeventhCaseInformation> GetBillByDate(DateTime fromDate, DateTime toDate)
        {
            string query = "SELECT BillDateTotalFee.BillNumber As 'Bill Number', Patient.Mobile AS 'Contact No', Patient.Name AS 'Patient Name', BillDateTotalFee.TotalFee As 'Bill Amount' " +
                           "FROM BillDateTotalFee " +
                           "INNER JOIN Patient " +
                           "ON BillDateTotalFee.PatientId=Patient.Id " +
                           "AND BillDateTotalFee.BillDate BETWEEN '" + fromDate + "' AND '" + toDate + "' AND BillDateTotalFee.BillStatus !='paid'";
            Connection.Open();
            Command.CommandText = query;

            SqlDataReader reader = Command.ExecuteReader();
            List<ViewSeventhCaseInformation> viewSeventhCaseInformations = new List<ViewSeventhCaseInformation>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ViewSeventhCaseInformation viewSeventhCaseInformation = new ViewSeventhCaseInformation();
                    viewSeventhCaseInformation.BillNumber = reader["Bill Number"].ToString();
                    viewSeventhCaseInformation.PatientMobile = reader["Contact No"].ToString();
                    viewSeventhCaseInformation.PatientName = reader["Patient Name"].ToString();
                    viewSeventhCaseInformation.TotalFee = (double)reader["Bill Amount"];
                    viewSeventhCaseInformations.Add(viewSeventhCaseInformation);
                }
            }
            reader.Close();
            Connection.Close();
            return viewSeventhCaseInformations;
        }

        public double GetUnPaidBillTotal(DateTime fromDate, DateTime toDate)
        {
            string query ="SELECT SUM(BillDateTotalFee.TotalFee) AS BillTotal " +
                          "FROM BillDateTotalFee INNER JOIN Patient " +
                          "ON BillDateTotalFee.PatientId=Patient.Id AND BillDateTotalFee.BillDate BETWEEN '" +fromDate + "' AND ' " + toDate + " ' AND BillDateTotalFee.BillStatus !='paid'";
            Connection.Open();
            Command.CommandText = query;
            SqlDataReader reader = Command.ExecuteReader();
            //string billTotal = "                ";
            Double billTotal = 0.00;
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    billTotal = Convert.ToDouble(reader["BillTotal"]);
                }
            }
            reader.Close();
            Connection.Close();
            return billTotal;           

        }

        public List<UnpaidListForFourthCase> GetAllUnpaidBill()
        {
            string query = "SELECT BillDateTotalFee.BillDate, BillDateTotalFee.BillNumber, BillDateTotalFee.TotalFee, Patient.Name, Patient.Mobile " +
                           "FROM BillDateTotalFee " +
                           "INNER Join Patient ON BillDateTotalFee.PatientId=Patient.Id AND BillDateTotalFee.BillStatus='unpaid'";
            Connection.Open();
            Command.CommandText = query;

            SqlDataReader reader = Command.ExecuteReader();
            List<UnpaidListForFourthCase> unpaidListForFourthCases = new List<UnpaidListForFourthCase>();
            int sl = 1;

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    UnpaidListForFourthCase unpaidListForFourthCase = new UnpaidListForFourthCase();
                    unpaidListForFourthCase.SL = sl;
                    unpaidListForFourthCase.BillNumber = reader["BillNumber"].ToString();
                    unpaidListForFourthCase.BillDate = (DateTime)reader["BillDate"];
                    unpaidListForFourthCase.TotalFee = (double)reader["TotalFee"];
                    unpaidListForFourthCase.Name = reader["Name"].ToString();
                    unpaidListForFourthCase.Mobile = reader["Mobile"].ToString();
                    unpaidListForFourthCases.Add(unpaidListForFourthCase);
                    sl++;
                }
            }
            reader.Close();
            Connection.Close();
            return unpaidListForFourthCases;
        }
    }
}