using System;
using System.Collections.Generic;
using ProjectOneApp.BLL;
using ProjectOneApp.Models;
using ProjectOneApp.Models.Entity_Models;

namespace ProjectOneApp.UI
{
    public partial class indexUI : System.Web.UI.Page
    {
        private TestTypeManager _testTypeManager=new TestTypeManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadTestTypeGridView();

        }

        private void LoadTestTypeGridView()
        {
            List<TestType> testTypes=_testTypeManager.GetAll();
            typeNameGridView.DataSource = testTypes;
            typeNameGridView.DataBind();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            TestType testType=new TestType();


            if (typeNameTextBox.Text.Length > 1 && typeNameTextBox.Text.Trim().Length > 0 && typeNameTextBox.Text.Length < 40)
            {
                testType.TypeName = typeNameTextBox.Text;
                bool rowsEffected = _testTypeManager.Save(testType);
                if (rowsEffected)
                {
                    messageLabel.Text = "Saved Successfully";
                    typeNameTextBox.Text = null;
                    LoadTestTypeGridView();
                }
                else
                {
                    messageLabel.Text = "Test Name already exists!";
                }
            }
            else
            {
                messageLabel.Text = "Please Enter any valid Value";
                
            }
            

        }      

        protected void backButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("indexUI.aspx.cs");
        }
    }
}