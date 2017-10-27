using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectOneApp.DAL;
using ProjectOneApp.Models.Entity_Models;
using ProjectOneApp.Models.View_Models;

namespace ProjectOneApp.BLL
{
    public class BillDateTotalFeeManager
    {
        private BillDateTolatFeeGateway _billDateTotalFeeGateway=new BillDateTolatFeeGateway();
        PatientInformationManager patientInformationManager=new PatientInformationManager();
        public bool Save(BillDateTotalFee billDateTotalFee)
        {

            billDateTotalFee.BillNumber = GetBillNumberGenerate();
            return _billDateTotalFeeGateway.Save(billDateTotalFee);
        }

        private string GetBillNumberGenerate()
        {
            string year = DateTime.Now.Year.ToString();
            //string month = DateTime.Now.Month.ToString();
            string month = DateTime.Now.ToString("MM");

            Random rnd = new Random();
            int mainSerial = rnd.Next(1, 99999);

            return year + month + "codeinside" + mainSerial;
        }



        public BillDateTotalFee GetBillInformation(Models.View_Models.ViewFourthCaseInformation viewFourthCaseInformation)
        {
            if (viewFourthCaseInformation.BillNo == null)
            {
                viewFourthCaseInformation.BillNo = "123";
            }
            if (viewFourthCaseInformation.MobileNo == null)
            {
                viewFourthCaseInformation.MobileNo = "123";
            }


            BillDateTotalFee billDateTotalFee = _billDateTotalFeeGateway.GetBillByBillNumber(viewFourthCaseInformation);
            if (billDateTotalFee == null)
            {
                PatientInformation patientInformation = patientInformationManager.GetPatientByMobile(viewFourthCaseInformation);
                try
                {
                    billDateTotalFee = _billDateTotalFeeGateway.GetBillByPatientId(patientInformation);
                }
                catch (Exception e)
                {
                    
                }                               
                return billDateTotalFee;
            }
            return billDateTotalFee;


        }

        public bool BillPay(string billNo)
        {
            return _billDateTotalFeeGateway.BillPay(billNo);
        }

        public List<ViewSeventhCaseInformation> GetBillByDate(DateTime fromDate, DateTime toDate)
        {
            return _billDateTotalFeeGateway.GetBillByDate(fromDate, toDate);
        }


        public double GetUnPaidBillTotal(DateTime fromDate, DateTime toDate)
        {
            return _billDateTotalFeeGateway.GetUnPaidBillTotal( fromDate,  toDate);
        }





        public List<UnpaidListForFourthCase> GetAllUnpaidBill()
        {
            return _billDateTotalFeeGateway.GetAllUnpaidBill();
        }
    }
}