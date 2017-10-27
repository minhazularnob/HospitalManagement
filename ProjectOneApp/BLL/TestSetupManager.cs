using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectOneApp.DAL;
using ProjectOneApp.Models;
using ProjectOneApp.Models.Entity_Models;
using ProjectOneApp.Models.View_Models;

namespace ProjectOneApp.BLL
{
    public class TestSetupManager
    {
        private TestSetupGateway _testSetupGateway=new TestSetupGateway();
        public bool Save(TestSetup testSetup)
        {
            if (ValidateSave(testSetup) && IsNameAvailable(testSetup.TestName))
            {
                return _testSetupGateway.Save(testSetup);
            }
            return false;
        }

        public List<TestSetup> GetAll()
        {
            return _testSetupGateway.GetAll();
        }

        public List<ViewAllTestSetup> GetAllTestSetup()
        {
            return _testSetupGateway.GetAllTestSetup();
        }

        public TestSetup GetByName(string name)
        {
            return _testSetupGateway.GetByName(name);
        }


        private bool IsNameAvailable(string name)
        {
            TestSetup testSetup = GetByName(name);

            if (testSetup == null)
            {
                return true;
            }
            return false;
        }

        private bool ValidateSave(TestSetup testSetup)
        {
            if (testSetup.Fee > 0 && testSetup.TestTypeId > 0)
            {
                return true;
            }
            return false;
        }
    }
}