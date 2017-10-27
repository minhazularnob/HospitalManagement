using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectOneApp.BLL;
using ProjectOneApp.Models.Entity_Models;
using ProjectOneApp.Models.View_Models;
using iTextSharp.text;
using com.itextpdf;
using iTextSharp;
using iTextSharp.text.pdf;
using ProjectArnobApp.BLL;
using ProjectArnobApp.Models.ViewModels;

namespace ProjectOneApp.UI
{
    public partial class seventhCaseUI : System.Web.UI.Page
    {
        BillDateTotalFeeManager billDateTotalFeeManager = new BillDateTotalFeeManager();
        TestNameSeacrhManager _testNameSeacrhManager=new TestNameSeacrhManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            //DateTime fromDate = Convert.ToDateTime(txtFromDate.Text);
            //DateTime toDate = Convert.ToDateTime(txtToDate.Text);
            //List<ViewSeventhCaseInformation> billDateTotalFees = billDateTotalFeeManager.GetBillByDate(fromDate, toDate);
            //GridViewUnpaidBill.DataSource = billDateTotalFees;
            //GridViewUnpaidBill.DataBind();
            //txtTotal.Text = billDateTotalFeeManager.GetUnPaidBillTotal(fromDate, toDate).ToString();
            //my code

            string d = txtFromDate.Text;
            string t = txtToDate.Text;
            DateTime from = DateTime.Now.Date;
            DateTime to = DateTime.Now.Date;

            if (!string.IsNullOrEmpty(d) && !string.IsNullOrEmpty(t))
            {

                from = DateTime.Parse(d).Date;
                to = DateTime.Parse(t).Date;
                if (DateTime.Now.Date >= from && DateTime.Now.Date >= to)
                {
                    List<ViewSeventhCaseInformation> billDateTotalFees = billDateTotalFeeManager.GetBillByDate(from, to);
                    GridViewUnpaidBill.DataSource = billDateTotalFees;
                    GridViewUnpaidBill.DataBind();
                    txtTotal.Text = billDateTotalFeeManager.GetUnPaidBillTotal(from, to).ToString();
                    lblMessege.Text = "";

                }
                else
                {
                    lblMessege.Text = "Error Date Format";
                }

            }
            else
            {

                from = DateTime.Parse("1900-01-01").Date;
                to = DateTime.Now.Date;

                List<ViewSeventhCaseInformation> billDateTotalFees = billDateTotalFeeManager.GetBillByDate(from, to);
                GridViewUnpaidBill.DataSource = billDateTotalFees;
                GridViewUnpaidBill.DataBind();
                txtTotal.Text = billDateTotalFeeManager.GetUnPaidBillTotal(from, to).ToString();
                lblMessege.Text = "";




            }

            btnPdf.Visible = true;
        }

        protected void btnPdf_Click(object sender, EventArgs e)
        {
            PdfPTable pdfPTable = new PdfPTable(GridViewUnpaidBill.HeaderRow.Cells.Count);
            foreach (TableCell headerCell in GridViewUnpaidBill.HeaderRow.Cells)
            {
                Font font = new Font();
                font.Color=new BaseColor(GridViewUnpaidBill.HeaderStyle.ForeColor);

                PdfPCell pdfPCell = new PdfPCell(new Phrase(headerCell.Text, font));
                pdfPCell.BackgroundColor=new BaseColor(GridViewUnpaidBill.HeaderStyle.BackColor);
                pdfPTable.AddCell(pdfPCell);
            }

            foreach (GridViewRow gridViewRow in GridViewUnpaidBill.Rows)
            {
                foreach (TableCell tableCell in gridViewRow.Cells)
                {
                    Font font = new Font();
                    font.Color = new BaseColor(GridViewUnpaidBill.RowStyle.ForeColor);


                    PdfPCell pdfPCell = new PdfPCell(new Phrase(tableCell.Text));
                    pdfPCell.BackgroundColor = new BaseColor(GridViewUnpaidBill.RowStyle.BackColor);
                    pdfPTable.AddCell(pdfPCell);
                }
            }


            Document pdfDocument = new Document(PageSize.A4, 10f, 10f, 150f, 10f);
            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);

            pdfDocument.Open();
            pdfDocument.Add(pdfPTable);
            pdfDocument.Close();

            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition","attachment;filename=abc.pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();


        }
    }
}