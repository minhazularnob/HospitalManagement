using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.UI.WebControls;
using ProjectArnobApp.BLL;
using ProjectArnobApp.DAL;
using ProjectArnobApp.Models.ViewModels;
using iTextSharp.text;
using com.itextpdf;
using iTextSharp;
using iTextSharp.text.pdf;

namespace ProjectArnobApp.UI
{
    public partial class TestNameSearch : System.Web.UI.Page
    {
        private TestNameSeacrhManager _testNameSeacrhManager=new  TestNameSeacrhManager();
               
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            //LoadTestName();

            }
        }

        private void LoadTestName()
        {
            List<TestNameSearchViewModel> testNameSearchViewModels = _testNameSeacrhManager.GetAllTestNameInformation();
            TestNameSearchGridview.DataSource = testNameSearchViewModels;

            TestNameSearchGridview.DataBind();
            
               
        }

        public void showButtonTestNameSearch_Click(object sender, EventArgs e)
        {
            string d = fromTextBox.Text;
            string t = toTextBox.Text;
            DateTime from = DateTime.Now.Date;
            DateTime to = DateTime.Now.Date;

            if (!string.IsNullOrEmpty(d) && !string.IsNullOrEmpty(t))
            {

                from = DateTime.Parse(d).Date;
                to = DateTime.Parse(t).Date;
                if (DateTime.Now.Date >= from && DateTime.Now.Date >= to)
                {
                    _testNameSeacrhManager.CreateView(from, to);

                    double Total = _testNameSeacrhManager.GetTotal();
                    totalTestNameSearch.Text = Total.ToString();
                    LoadTestName();
                    _testNameSeacrhManager.DropView();
                    fromDateHiddenField.Value = from.ToShortDateString();
                    toDateHiddenField.Value = to.ToShortDateString();
                }
                else
                {
                    messageLabel.Text = "Error Date Format";
                }

            }
            else
            {
                double Total = _testNameSeacrhManager.GetTotalForAll();
                totalTestNameSearch.Text = Total.ToString();
                List<TestNameSearchViewModel> testNameSearchViewModels = _testNameSeacrhManager.GetAll();
                TestNameSearchGridview.DataSource = testNameSearchViewModels;

                TestNameSearchGridview.DataBind();
            }
            pdfButtonTestNameSearch.Visible = true;
        }

        protected void nextButtonTestName_Click(object sender, EventArgs e)
        {
            Response.Redirect("TestTypeSearch.aspx");
        }

        protected void pdfButtonTestNameSearch_Click(object sender, EventArgs e)
        {
            PdfPTable pdfPTable = new PdfPTable(TestNameSearchGridview.HeaderRow.Cells.Count);
            foreach (TableCell headerCell in TestNameSearchGridview.HeaderRow.Cells)
            {
                Font font = new Font();
                font.Color = new BaseColor(TestNameSearchGridview.HeaderStyle.ForeColor);

                PdfPCell pdfPCell = new PdfPCell(new Phrase(headerCell.Text, font));
                pdfPCell.BackgroundColor = new BaseColor(TestNameSearchGridview.HeaderStyle.BackColor);
                pdfPTable.AddCell(pdfPCell);
            }
            int temp = 0;
            foreach (GridViewRow gridViewRow in TestNameSearchGridview.Rows)
            {

                foreach (TableCell tableCell in gridViewRow.Cells)
                {

                    Font font = new Font();
                    font.Color = new BaseColor(TestNameSearchGridview.RowStyle.ForeColor);

                    Label label =(Label) tableCell.FindControl("Label"+temp.ToString());

                    PdfPCell pdfPCell = new PdfPCell(new Phrase(label.Text));
                    pdfPCell.BackgroundColor = new BaseColor(TestNameSearchGridview.RowStyle.BackColor);
                    pdfPTable.AddCell(pdfPCell);
                    temp++;
                    if (temp == 4)
                    {
                        temp = 0;
                    }
                }
            }


            Document pdfDocument = new Document(PageSize.A4, 10f, 10f, 150f, 10f);
            PdfWriter writer=PdfWriter.GetInstance(pdfDocument, Response.OutputStream);

            pdfDocument.Open();
            Rectangle page = pdfDocument.PageSize;
            PdfPTable head = new PdfPTable(1);
            head.TotalWidth = page.Width;
            Phrase phrase = new Phrase(
                "Test Wise Repot \n All Data",
                new Font(Font.FontFamily.COURIER, 20)
            );
            if (!string.IsNullOrEmpty(fromDateHiddenField.Value) && !string.IsNullOrEmpty(toDateHiddenField.Value))
            {
                 phrase = new Phrase(
                    "Test Wise Repot \n Date: " + fromDateHiddenField.Value+" To "+toDateHiddenField.Value,
                    new Font(Font.FontFamily.COURIER, 20)
                );
            }
   
            PdfPCell c = new PdfPCell(phrase);
            c.Border = Rectangle.NO_BORDER;
            c.VerticalAlignment = Element.ALIGN_RIGHT;
            c.HorizontalAlignment = Element.ALIGN_CENTER;
            head.AddCell(c);
            head.WriteSelectedRows(
                // first/last row; -1 writes all rows
                0, -1,
                // left offset
                0,
                // ** bottom** yPos of the table
                page.Height - pdfDocument.TopMargin + head.TotalHeight + 80,
                writer.DirectContent
            );

            pdfDocument.Add(pdfPTable);
            PdfPTable total = new PdfPTable(1);
            head.TotalWidth = page.Width;
            Phrase data = new Phrase(
                "\nTotal: " + totalTestNameSearch.Text,
                new Font(Font.FontFamily.COURIER, 15)
            );
            PdfPCell cell = new PdfPCell(data);
            cell.Border = Rectangle.NO_BORDER;
            cell.VerticalAlignment = Element.ALIGN_TOP;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            total.AddCell(cell);
            pdfDocument.Add(total);

            pdfDocument.Close();

            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition", "attachment;filename=abc.pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();
        }
    }
}