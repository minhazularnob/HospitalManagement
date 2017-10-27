using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectOneApp.DAL;
using ProjectOneApp.Models.Entity_Models;
using ProjectOneApp.Models.View_Models;

namespace ProjectOneApp.BLL
{
    public class PatientTestManager
    {
        private PatientTestGateway _patientTestGateway=new PatientTestGateway();
        public bool Save(PatientTest patientTest)
        {
            if (IsTestValid(patientTest.TestSetupId,patientTest))
            {
                return _patientTestGateway.Save(patientTest);
            }
            return false;
        }

       

        private PatientTest GetById(int testId)
        {
            return _patientTestGateway.GetById(testId);
        }

        public List<ViewThirdCaseInformation> GeThirdCaseInformations(int patrintId)
        {
            return _patientTestGateway.GeThirdCaseInformations(patrintId);
        }

        public double GetTotalFee(int patientId)
        {
            return _patientTestGateway.GetTotalFee(patientId);
        }

        private bool IsTestValid(int testId,PatientTest patientTest)
        {
            PatientTest patientTests = GetById(testId);
            if (patientTests != null && patientTests.PatientId==patientTest.PatientId)
            {
                return false;
            }
            return true;
        }
    }
}