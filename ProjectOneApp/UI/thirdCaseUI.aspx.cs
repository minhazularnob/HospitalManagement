using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectOneApp.BLL;
using ProjectOneApp.DAL;
using ProjectOneApp.Models.Entity_Models;
using ProjectOneApp.Models.View_Models;

namespace ProjectOneApp.UI
{
   
    public partial class thirdCaseUI : System.Web.UI.Page
    {
        private TestSetupManager _testSetupManager=new TestSetupManager();
        private PatientInformationManager _patientInformationManager=new PatientInformationManager();
        private PatientTestManager _patientTestManager=new PatientTestManager();
        private BillDateTotalFeeManager _billDateTotalFeeManager=new BillDateTotalFeeManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                checkPatientHiddenField.Value = "true";
                rowHiddenField.Value = "0";
                LoadDropDownList();
                LoadFeeWhenDropDownListSelected();
            }
            
        }

        private void LoadDropDownList()
        {
            List<TestSetup> testSetups = _testSetupManager.GetAll();
            testNameDropDownList.DataSource = testSetups;
            testNameDropDownList.DataValueField = "Id";
            testNameDropDownList.DataTextField = "TestName";
            testNameDropDownList.DataBind();

            ListItem defaultListItem = new ListItem("select", string.Empty);
            defaultListItem.Selected = true;
            testNameDropDownList.Items.Insert(0, defaultListItem);
        }

        private void LoadFeeWhenDropDownListSelected()
        {
            string name = testNameDropDownList.SelectedItem.Text;
            TestSetup testSetup = new TestSetup();
            testSetup = _testSetupManager.GetByName(name);
            if (testSetup != null)
            {
                feeTextBox.Text = testSetup.Fee.ToString();
            }
            else
            {
                feeTextBox.Text = "";
            }
        }

        protected void testNameDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFeeWhenDropDownListSelected();
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            PatientInformation patientInformation = new PatientInformation();
            string date = dateOfBirthTextBox.Text;
            DateTime finalDate = DateTime.Now.Date;
            if (!string.IsNullOrEmpty(date))
            {
                finalDate = DateTime.Parse(date).Date;

            }

            if ((nameOfThePatientTextBox.Text.Length > 0 && nameOfThePatientTextBox.Text.Trim().Length > 0) &&
                (mobileNoTextBox.Text.Length > 0 && mobileNoTextBox.Text.Trim().Length > 0) &&
                (DateTime.Now.Date > finalDate) && testNameDropDownList.SelectedItem.Text != "select")
            {
                patientInformation.Name = nameOfThePatientTextBox.Text;
                patientInformation.DateOfBirth = finalDate;
                patientInformation.MobileNo = mobileNoTextBox.Text;

                if (checkPatientHiddenField.Value.Equals("true"))
                {
                    int rowId = _patientInformationManager.Save(patientInformation);
                    if (rowId > 0)
                    {
                        messageLabel.Text = "Saved Successfully";
                        checkPatientHiddenField.Value = "false";
                        rowHiddenField.Value = rowId.ToString();
                        saveButton.Visible = true;

                    }
                    else
                    {
                        messageLabel.Text = "Error";
                    }
                }
                if (Convert.ToInt32(rowHiddenField.Value) > 0)
                {
                    AddDataIntoPatientTest(Convert.ToInt32(rowHiddenField.Value));

                }

            }
            else
            {
                messageLabel.Text = "Please input valid data";
            }
        }

        private void LoadGridView(int patintId)
        {
            List<ViewThirdCaseInformation> viewThirdCaseInformations =
                _patientTestManager.GeThirdCaseInformations(patintId);

            testSetupGridView.DataSource = viewThirdCaseInformations;
            testSetupGridView.DataBind();
            
        }

        private void PopulateTotalFee(int patientId)
        {
            totalTextBox.Text = _patientTestManager.GetTotalFee(patientId).ToString();
        }

        private void AddDataIntoPatientTest(int patientId)
        {
            PatientTest patientTest = new PatientTest();
            patientTest.PatientId = patientId;
            patientTest.TestSetupId = Convert.ToInt32(testNameDropDownList.SelectedValue);

            bool rowsEffected = _patientTestManager.Save(patientTest);
            if (rowsEffected)
            {
                messageLabel.Text = "Saved successfully!";
                LoadGridView(patientId);
                PopulateTotalFee(patientId);

            }
            else
            {
                messageLabel.Text = "Error ! Same test exists!";

            }
        }

        private void ResetUI()
        {
            nameOfThePatientTextBox.Text = "";
            dateOfBirthTextBox.Text = "";
            mobileNoTextBox.Text = "";
            LoadDropDownList();
            testSetupGridView.DataSource = null;
            testSetupGridView.DataBind();
            totalTextBox.Text = "";
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            checkPatientHiddenField.Value = "true";
            BillDateTotalFee billDateTotalFee=new BillDateTotalFee();
            billDateTotalFee.Date=DateTime.Now.Date;
            billDateTotalFee.BillNumber = "codeInside";

            billDateTotalFee.TotalFee= Convert.ToDouble(totalTextBox.Text);
            billDateTotalFee.PatientId = Convert.ToInt32(rowHiddenField.Value);
            bool rowsEffected = _billDateTotalFeeManager.Save(billDateTotalFee);

            if (rowsEffected)
            {
                messageLabel.Text = "added into bill date table";
                ResetUI();
                saveButton.Visible = false;
            }
            else
            {
                messageLabel.Text = "some error happend";
            }
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("secondCaseUI.aspx");
        }
    }
}