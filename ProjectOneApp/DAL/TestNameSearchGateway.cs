using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using ProjectArnobApp.Models.ViewModels;
using ProjectArnobApp.UI;
using ProjectOneApp.DAL;

namespace ProjectArnobApp.DAL
{
    
    public class TestNameSearchGateway: CommonGateway
    {
        public double total;

        public void CreateView(DateTime from, DateTime to)
        {
          
            string query = @"create view vw_CheckTemp as
            select pt.PatientId,pt.TestSetupId from BillDateTotalFee b inner join PatientTest pt on
            b.PatientId=pt.PatientId where b.BillDate between   '" + from + "'   and '" + to + "'";

            Connection.Open();
            Command.CommandText = query;
            Command.ExecuteNonQuery();
            Connection.Close();
            
        }
        public List<TestNameSearchViewModel> GetAllTestNameInformation()
        {
            //query
            string query = @"select ts.TestName TestName,Count(ct.PatientId) as TotalTest,Sum(case when ct.PatientId>0 then ts.Fee else 0 end) TotalAmount from TestSetup ts 
            left outer join vw_CheckTemp ct on ts.Id=ct.TestSetupId group by ts.TestName ";
            Connection.Open();
            //query execuite
            Command.CommandText = query;
            SqlDataReader reader = Command.ExecuteReader();
            List<TestNameSearchViewModel> testNameSearchViewModels = new List<TestNameSearchViewModel>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TestNameSearchViewModel testNameSearchViewModel = new TestNameSearchViewModel();
                    testNameSearchViewModel = new TestNameSearchViewModel();
                    testNameSearchViewModel.TestName = (string) reader["TestName"];
                    testNameSearchViewModel.TotalTest = (int) reader["TotalTest"];
                    testNameSearchViewModel.TotalAmount = Convert.ToDouble(reader["TotalAmount"].ToString());
                    testNameSearchViewModels.Add(testNameSearchViewModel);
                }

            }
            reader.Close();
            Connection.Close();
            return testNameSearchViewModels;

        }

        public List<TestNameSearchViewModel> GetAll()
        {
            //query
            string query = @"select ts.TestName,Count(pt.PatientId) as TotalTest,Sum(case when pt.PatientId>0 then ts.Fee else 0 end) TotalAmount from TestSetup ts 
                            left outer join PatientTest pt on ts.Id=pt.TestSetupId left outer join BillDateTotalFee b ON
                               pt.PatientId=b.PatientId group by ts.TestName ";
            Connection.Open();
            //query execuite
            Command.CommandText = query;
            SqlDataReader reader = Command.ExecuteReader();
            List<TestNameSearchViewModel> testNameSearchViewModels = new List<TestNameSearchViewModel>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TestNameSearchViewModel testNameSearchViewModel = new TestNameSearchViewModel();
                    testNameSearchViewModel = new TestNameSearchViewModel();
                    testNameSearchViewModel.TestName = (string)reader["TestName"];
                    testNameSearchViewModel.TotalTest = (int)reader["TotalTest"];
                    testNameSearchViewModel.TotalAmount = Convert.ToDouble(reader["TotalAmount"].ToString());
                    testNameSearchViewModels.Add(testNameSearchViewModel);
                }

            }
            reader.Close();
            Connection.Close();
            return testNameSearchViewModels;

        }

        public double GetTotalForAll()
        {
            string query = @"select Sum(t.TotalAmount) Total from(select ts.TestName,Count(pt.PatientId) as TotalRequest,Sum(case when pt.PatientId>0 then ts.Fee else 0 end)TotalAmount from TestSetup ts 
                            left outer join PatientTest pt on ts.Id=pt.TestSetupId left outer join BillDateTotalFee b ON
                            pt.PatientId=b.PatientId group by ts.TestName) as t";
            Connection.Open();
            //query execuite
            Command.CommandText = query;
            SqlDataReader reader = Command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TestNameSearchTotalViewModel testNameSearchTotalViewModel = new TestNameSearchTotalViewModel();
                    testNameSearchTotalViewModel.Total = (double)reader["Total"];
                    total = testNameSearchTotalViewModel.Total;


                }

            }
            reader.Close();
            Connection.Close();
            return total;
        }

        public double GetTotal()
        {
            string query = @"select Sum(t.TotalAmount) Total from(select ts.TestName TestName,Count(ct.PatientId) as TotalTest,Sum(case when ct.PatientId>0 then ts.Fee else 0 end) TotalAmount from TestSetup ts 
            left outer join vw_CheckTemp ct on ts.Id=ct.TestSetupId group by ts.TestName ) as t ";
            Connection.Open();
            //query execuite
            Command.CommandText = query;
            SqlDataReader reader = Command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TestNameSearchTotalViewModel testNameSearchTotalViewModel = new TestNameSearchTotalViewModel();
                    testNameSearchTotalViewModel.Total = (double)reader["Total"];
                    total = testNameSearchTotalViewModel.Total;


                }

            }
            reader.Close();
            Connection.Close();
            return total;


        }

        public void DropView()
        {
            string query = @"drop view vw_CheckTemp";

            Connection.Open();
            Command.CommandText = query;
            Command.ExecuteNonQuery();
            // SqlDataReader reader = Command.ExecuteReader();
            // reader.Close();
            Connection.Close();

        }
    }
}