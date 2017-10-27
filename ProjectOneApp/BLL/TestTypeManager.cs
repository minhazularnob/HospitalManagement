using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectOneApp.DAL;
using ProjectOneApp.Models;
using ProjectOneApp.Models.Entity_Models;

namespace ProjectOneApp.BLL
{
    public class TestTypeManager
    {
        private TestTypeGateway _testTypeGateway = new TestTypeGateway();

        public bool Save(TestType testType)
        {
            if (ValidateSave(testType) && IsNameAvailable(testType.TypeName))
            {
                return _testTypeGateway.Save(testType);
            }
            return false;

        }

        public List<TestType> GetAll()
        {
            return _testTypeGateway.GetAll();
        }

        private TestType GetByTestName(string testName)
        {
            return _testTypeGateway.GetByTestName(testName);
        }

        private bool IsNameAvailable(string testName)
        {
            TestType testType = GetByTestName(testName);

            if (testType == null)
            {
                return true;
            }
            return false;

        }

        private bool ValidateSave(TestType testType)
        {
            if (!(string.IsNullOrEmpty(testType.TypeName)))
            {
                return true;
            }
            return false;
        }
    }
}