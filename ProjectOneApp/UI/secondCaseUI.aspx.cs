using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectOneApp.BLL;
using ProjectOneApp.Models;
using ProjectOneApp.Models.Entity_Models;
using ProjectOneApp.Models.View_Models;

namespace ProjectOneApp.UI
{
    public partial class secondCase : System.Web.UI.Page
    {
        private TestTypeManager _testTypeManager=new TestTypeManager();
        private TestSetupManager _testSetupManager=new TestSetupManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            LoadDropDownList();

            }
            LoadTestSetupGridView();

        }

        private void LoadDropDownList()
        {
            List<TestType> testTypes = _testTypeManager.GetAll();
            testTypeDropDownList.DataSource = testTypes;
            testTypeDropDownList.DataValueField = "Id";
            testTypeDropDownList.DataTextField = "TypeName";
            testTypeDropDownList.DataBind();

            ListItem defaultListItem = new ListItem("select", string.Empty);
            defaultListItem.Selected = true;
            testTypeDropDownList.Items.Insert(0, defaultListItem);

        }

        private void LoadTestSetupGridView()
        {
            List<ViewAllTestSetup> viewAllTestSetups = _testSetupManager.GetAllTestSetup();
            testSetupGridView.DataSource = viewAllTestSetups;
            testSetupGridView.DataBind();
        }

        private void ResetUI()
        {
            testNameTextBox.Text = "";
            feeTextBox.Text = "";
            LoadDropDownList();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            TestSetup testSetup=new TestSetup();

            ////////////////////
            decimal d;
            if (decimal.TryParse(feeTextBox.Text, out d) && (testNameTextBox.Text.Length > 1 && testNameTextBox.Text.Length <30 && testNameTextBox.Text.Trim().Length > 0) 
                && testTypeDropDownList.SelectedItem.Text!="select")
            {
                testSetup.TestName = testNameTextBox.Text;
                testSetup.Fee = Convert.ToDouble(feeTextBox.Text);
                testSetup.TestTypeId = Convert.ToInt32(testTypeDropDownList.SelectedValue);

                bool rowsEffected = _testSetupManager.Save(testSetup);

                if (rowsEffected)
                {
                    messageLabel.Text = "Saved Successfully";
                    LoadTestSetupGridView();
                    ResetUI();
                }
                else
                {
                    messageLabel.Text = "Name Already Exists";
                    LoadTestSetupGridView();
                }
            }
            else
            {

                messageLabel.Text = "Please enter valid Data";
               
            }

        }
    }
}