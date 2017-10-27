using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectOneApp.DAL;
using ProjectOneApp.Models.Entity_Models;

namespace ProjectOneApp.BLL
{
    public class PatientInformationManager
    {
        private PatientInfromationGateway _patientInfromationGateway=new PatientInfromationGateway();
        public int Save(PatientInformation patientInformation)
        {
            if (ValidateSave(patientInformation))
            {
                return _patientInfromationGateway.Save(patientInformation);
            }
            return 0;
        }

       

        private bool ValidateSave(PatientInformation patientInformation)
        {
            if (!string.IsNullOrEmpty(patientInformation.Name) &&
                !string.IsNullOrEmpty(patientInformation.DateOfBirth.ToString()) &&
                !string.IsNullOrEmpty(patientInformation.MobileNo))
            {
                return true;
            }
            return false;
        }


        public PatientInformation GetPatientByMobile(Models.View_Models.ViewFourthCaseInformation viewFourthCaseInformation)
        {
            return _patientInfromationGateway.GetPatientByMobile(viewFourthCaseInformation);
        }
    }
}