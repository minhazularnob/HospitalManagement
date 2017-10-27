using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ProjectArnobApp.Models.ViewModels;
using ProjectOneApp.DAL;

namespace ProjectArnobApp.DAL
{
    public class TestTypeSearchGateway : CommonGateway
    {
        private Double total;

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

        public List<TestTypeSearchViewModel> GetAllTestNameInformation()
        {
            //query
//            string query =
//                @"select tt.TypeName,Sum(case when ct.PatientId>0 then ts.Fee else 0 End) TotalFee,Count(ct.PatientId) as TotalRequest from TestType tt left outer join
//            TestSetup ts on tt.Id=ts.TestTypeId left outer join vw_CheckTemp ct on ts.Id=ct.TestSetupId group by 
//             tt.TypeName";
            string query =
                @"select tt.TypeName as 'Test Name',Sum(case when ct.PatientId>0 then ts.Fee else 0 End) as 'Total Amount',Count(ct.PatientId) as 'Total Test' from TestType tt left outer join
            TestSetup ts on tt.Id=ts.TestTypeId left outer join vw_CheckTemp ct on ts.Id=ct.TestSetupId group by 
             tt.TypeName";
            Connection.Open();
            //query execuite
            Command.CommandText = query;
            SqlDataReader reader = Command.ExecuteReader();
            List<TestTypeSearchViewModel> testTypeSearchViewModels = new List<TestTypeSearchViewModel>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TestTypeSearchViewModel testTypeSearchViewModel = new TestTypeSearchViewModel();
                    testTypeSearchViewModel = new TestTypeSearchViewModel();
                    testTypeSearchViewModel.TypeName = (string)reader["Test Name"];
                    testTypeSearchViewModel.TotalFee = (double)reader["Total Amount"];
                    testTypeSearchViewModel.TotalRequest = (int)reader["Total Test"];
                    testTypeSearchViewModels.Add(testTypeSearchViewModel);
                }
                
                

            }
            reader.Close();
            Connection.Close();
            return testTypeSearchViewModels;
        }

        public List<TestTypeSearchViewModel> GetAll()
        {
            string query =
                @"select tt.TypeName as 'Test Name',Sum(case when pt.PatientId>0 then ts.Fee else 0 end) as 'Total Amount',Count(pt.PatientId) as 'Total Test' from TestType
                tt left outer join TestSetup ts ON tt.Id=ts.TestTypeId left outer join PatientTest pt on ts.Id=pt.TestSetupId left outer join BillDateTotalFee b ON
                pt.PatientId=b.PatientId group by tt.TypeName";
            Connection.Open();
            //query execuite
            Command.CommandText = query;
            SqlDataReader reader = Command.ExecuteReader();
            List<TestTypeSearchViewModel> testTypeSearchViewModels = new List<TestTypeSearchViewModel>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TestTypeSearchViewModel testTypeSearchViewModel = new TestTypeSearchViewModel();
                    testTypeSearchViewModel = new TestTypeSearchViewModel();
                    testTypeSearchViewModel.TypeName = (string)reader["Test Name"];
                    testTypeSearchViewModel.TotalFee = (double)reader["Total Amount"];
                    testTypeSearchViewModel.TotalRequest = (int)reader["Total Test"];
                    testTypeSearchViewModels.Add(testTypeSearchViewModel);
                }



            }
            reader.Close();
            Connection.Close();
            return testTypeSearchViewModels;
        }

        public double GetTotalForAll()
        {
            string query = @"select sum(t.TotalFee)  Total from (select tt.TypeName,Sum(case when pt.PatientId>0 then ts.Fee else 0 end) TotalFee,Count(pt.PatientId) as TotalRequest from TestType
                            tt left outer join TestSetup ts ON tt.Id=ts.TestTypeId left outer join PatientTest pt on ts.Id=pt.TestSetupId left outer join BillDateTotalFee b ON
                            pt.PatientId=b.PatientId group by tt.TypeName) as t";
            Connection.Open();
            //query execuite
            Command.CommandText = query;
            SqlDataReader reader = Command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TestTypeSearchTotalViewModel testTypeSearchTotalViewModel = new TestTypeSearchTotalViewModel();
                    testTypeSearchTotalViewModel.Total = (double)reader["Total"];
                    total = testTypeSearchTotalViewModel.Total;


                }

            }
            reader.Close();
            Connection.Close();
            return total;

        }


        public double GetTotal()
            {
                string query = @"select sum(t.TotalFee)  Total from (select tt.TypeName,Sum(case when ct.PatientId>0 then ts.Fee else 0 End) TotalFee,Count(ct.PatientId) as TotalRequest from TestType tt left outer join
                TestSetup ts on tt.Id=ts.TestTypeId left outer join vw_CheckTemp ct on ts.Id=ct.TestSetupId group by 
                tt.TypeName) as t ";
                Connection.Open();
                //query execuite
                Command.CommandText = query;
                SqlDataReader reader = Command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TestTypeSearchTotalViewModel testTypeSearchTotalViewModel = new TestTypeSearchTotalViewModel();
                        testTypeSearchTotalViewModel.Total = (double)reader["Total"];
                        total = testTypeSearchTotalViewModel.Total;


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
