using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ProjectOneApp.Models;
using ProjectOneApp.Models.Entity_Models;
using ProjectOneApp.Models.View_Models;

namespace ProjectOneApp.DAL
{
    public class TestSetupGateway:CommonGateway
    {
        public bool Save(TestSetup testSetup)
        {
            string query = "INSERT INTO TestSetup (TestName,Fee,TestTypeId) VALUES ('" + testSetup.TestName + "','" +
                           testSetup.Fee + "','" + testSetup.TestTypeId + "')";

            Connection.Open();
            Command.CommandText = query;

            int rowsEffected = Command.ExecuteNonQuery();
            Connection.Close();

            return rowsEffected > 0;
        }

        public List<TestSetup> GetAll()
        {
            string query = "SELECT * FROM TestSetup";
            Connection.Open();
            Command.CommandText = query;

            SqlDataReader reader = Command.ExecuteReader();
            List<TestSetup> testSetups=new List<TestSetup>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TestSetup testSetup=new TestSetup();
                    testSetup.Id = (int) reader["Id"];
                    testSetup.TestName = reader["TestName"].ToString();
                    testSetup.Fee = (double) reader["Fee"];
                    testSetup.TestTypeId = (int) reader["TestTypeId"];
                    testSetups.Add(testSetup);
                }
            }
            reader.Close();
            Connection.Close();

            return testSetups;
        }

        public TestSetup GetByName(string name)
        {
            string query = "SELECT * FROM TestSetup WHERE TestName = '"+name+"'";
            Connection.Open();
            Command.CommandText = query;

            SqlDataReader reader = Command.ExecuteReader();

            TestSetup testSetup = null;
            if (reader.HasRows)
            {
                testSetup = new TestSetup();
                reader.Read();
                testSetup.Id = (int)reader["Id"];
                testSetup.TestName = reader["TestName"].ToString();
                testSetup.Fee = (double)reader["Fee"];
                testSetup.TestTypeId = (int)reader["TestTypeId"];
            }
            reader.Close();
            Connection.Close();
            return testSetup;

        }

        public List<ViewAllTestSetup> GetAllTestSetup()
        {
            string query = "SELECT * FROM VW_TestSetupView ORDER BY TestName";
            Connection.Open();
            Command.CommandText = query;

            SqlDataReader reader = Command.ExecuteReader();
            List<ViewAllTestSetup> viewAllTestSetups = new List<ViewAllTestSetup>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ViewAllTestSetup viewAllTestSetup = new ViewAllTestSetup();
                    viewAllTestSetup.Id = (int)reader["Id"];
                    viewAllTestSetup.TestName = reader["TestName"].ToString();
                    viewAllTestSetup.Fee = (double)reader["Fee"];
                    viewAllTestSetup.TestTypeId = (int)reader["TestTypeId"];
                    viewAllTestSetup.TestTypeName = reader["TypeName"].ToString();
                    viewAllTestSetups.Add(viewAllTestSetup);
                }
            }
            reader.Close();
            Connection.Close();

            return viewAllTestSetups;
        }
    }
}