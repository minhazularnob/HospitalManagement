using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectOneApp.BLL;
using ProjectOneApp.Models.Entity_Models;
using ProjectOneApp.Models.View_Models;

namespace ProjectOneApp.UI
{
    public partial class fourthCaseUI : System.Web.UI.Page
    {
        BillDateTotalFeeManager billDateTotalFeeManager = new BillDateTotalFeeManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblPayStatus.Text = "";
            btnPay.Visible = true;
            LoadGridViewDueBill();

        }

        private void LoadGridViewDueBill()
        {
            List<UnpaidListForFourthCase> unpaidListForFourthCases = billDateTotalFeeManager.GetAllUnpaidBill();
            GridViewDueBill.DataSource = unpaidListForFourthCases;
            GridViewDueBill.DataBind();


        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ViewFourthCaseInformation viewFourthCaseInformation = new ViewFourthCaseInformation();
            viewFourthCaseInformation.BillNo = txtBill.Text;
            viewFourthCaseInformation.MobileNo = txtMobile.Text;
            BillDateTotalFee billDateTotalFee = billDateTotalFeeManager.GetBillInformation(viewFourthCaseInformation);
            if (billDateTotalFee != null)
            {
                if (billDateTotalFee.Status != "paid")
                {
                    txtAmount.Text = billDateTotalFee.TotalFee.ToString();
                    txtDueDate.Text = billDateTotalFee.Date.ToString();
                    ViewState["BillNo"] = billDateTotalFee.BillNumber;
                    lblPayStatus.Text = "";
                }
                else
                {
                    lblPayStatus.Text = "Bill is Paid";
                    btnPay.Visible = false;
                }

            }
            else
            {
                lblPayStatus.Text = "No Match Found";
                btnPay.Visible = false;

            }

            lblWarning.Text = "";
        }

        protected void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                string billNo = ViewState["BillNo"].ToString();
                billDateTotalFeeManager.BillPay(billNo);
                txtAmount.Text = "";
                txtBill.Text = "";
                txtDueDate.Text = "";
                txtMobile.Text = "";
                lblPayStatus.Text = "Bill Paid";
                LoadGridViewDueBill();
            }
            catch (Exception exception)
            {
                if (txtBill.Text==null && txtMobile.Text==null)
                {
                    lblWarning.Text = "Please Enter the Bill Information";                   
                }
            }
            
        }

        protected void GridViewDueBill_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridViewDueBill.SelectedRow;
            txtBill.Text = row.Cells[1].Text;


        }
    }
}