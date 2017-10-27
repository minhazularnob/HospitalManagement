using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ProjectOneApp.Models;
using ProjectOneApp.Models.Entity_Models;

namespace ProjectOneApp.DAL
{
    public class TestTypeGateway:CommonGateway
    {
        public bool Save(TestType testType)
        {
            string query="INSERT INTO TestType (TypeName) VALUES( '" +testType.TypeName+"')";

            Connection.Open();

            Command.CommandText = query;

            int rowsEffected = Command.ExecuteNonQuery();
            Connection.Close();

            return rowsEffected > 0;
        }

        public TestType GetByTestName(string testName)
        {
            string query = "SELECT * FROM TestType WHERE TypeName = '"+testName+"'";

            Connection.Open();
            Command.CommandText = query;
            SqlDataReader reader = Command.ExecuteReader();
            TestType testType = null;

            if (reader.HasRows)
            {
                testType=new TestType();
                reader.Read();
                testType.Id = (int)reader["Id"];
                testType.TypeName = reader["TypeName"].ToString();
            }
            reader.Close();
            Connection.Close();
           

            return testType;
        }

        public List<TestType> GetAll()
        {
            string query = "SELECT * FROM TestType ORDER BY TypeName ";

            Connection.Open();
            Command.CommandText = query;

            SqlDataReader reader = Command.ExecuteReader();
            List<TestType> testTypes=new List<TestType>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TestType testType=new TestType();

                    testType.Id = (int) reader["Id"];
                    testType.TypeName = reader["TypeName"].ToString();
                    testTypes.Add(testType);
                }
            }
            reader.Close();
            Connection.Close();

            return testTypes;
        }
    }
}