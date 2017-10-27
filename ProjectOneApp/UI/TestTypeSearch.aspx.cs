using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ProjectArnobApp.BLL;
using ProjectArnobApp.Models.ViewModels;

namespace ProjectArnobApp.UI
{
    public partial class TestTypeSearch : System.Web.UI.Page
    {
        TestTypeSearchManager _testTypeSearchManager=new TestTypeSearchManager();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void LoadTestType()
        {
            List<TestTypeSearchViewModel> testNameSearchViewModels = _testTypeSearchManager.GetAllTestNameInformation();
            TestTypeSearchGridview.DataSource = testNameSearchViewModels;

            TestTypeSearchGridview.DataBind();

        }

       

        protected void showButtonTestType_Click(object sender, EventArgs e)
        {
            string d = fromTextBoxTestType.Text;
            string t = toTextBoxTestType.Text;
            DateTime from = DateTime.Now.Date;
            DateTime to = DateTime.Now.Date;
            if (!string.IsNullOrEmpty(d) && !string.IsNullOrEmpty(t))
            {
                from = DateTime.Parse(d).Date;
                to = DateTime.Parse(t).Date;

                if (DateTime.Now.Date >= from && DateTime.Now.Date >= to)
                {
                    _testTypeSearchManager.CreateView(from, to);

                    double Total = _testTypeSearchManager.GetTotal();
                    totalTestTypeText.Text = Total.ToString();
                    LoadTestType();
                    _testTypeSearchManager.DropView();
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
                double Total = _testTypeSearchManager.GetTotalForAll();
                totalTestTypeText.Text = Total.ToString();
                List<TestTypeSearchViewModel> testNameSearchViewModels = _testTypeSearchManager.GetAll();
                TestTypeSearchGridview.DataSource = testNameSearchViewModels;

                TestTypeSearchGridview.DataBind();
            }


            pdfButtonTestType.Visible = true;
        }



        protected void pdfButtonTestType_Click(object sender, EventArgs e)
        {
            PdfPTable pdfPTable = new PdfPTable(TestTypeSearchGridview.HeaderRow.Cells.Count);
            foreach (TableCell headerCell in TestTypeSearchGridview.HeaderRow.Cells)
            {
                Font font = new Font();
                font.Color = new BaseColor(TestTypeSearchGridview.HeaderStyle.ForeColor);

                PdfPCell pdfPCell = new PdfPCell(new Phrase(headerCell.Text, font));
                pdfPCell.BackgroundColor = new BaseColor(TestTypeSearchGridview.HeaderStyle.BackColor);
                pdfPTable.AddCell(pdfPCell);
            }
            int temp = 0;
            foreach (GridViewRow gridViewRow in TestTypeSearchGridview.Rows)
            {

                foreach (TableCell tableCell in gridViewRow.Cells)
                {

                    Font font = new Font();
                    font.Color = new BaseColor(TestTypeSearchGridview.RowStyle.ForeColor);

                    Label label = (Label)tableCell.FindControl("Label" + temp.ToString());

                    PdfPCell pdfPCell = new PdfPCell(new Phrase(label.Text));
                    pdfPCell.BackgroundColor = new BaseColor(TestTypeSearchGridview.RowStyle.BackColor);
                    pdfPTable.AddCell(pdfPCell);
                    temp++;
                    if (temp == 4)
                    {
                        temp = 0;
                    }
                }
            }


            Document pdfDocument = new Document(PageSize.A4, 10f, 10f, 150f, 10f);
            PdfWriter writer = PdfWriter.GetInstance(pdfDocument, Response.OutputStream);

            pdfDocument.Open();

            Rectangle page = pdfDocument.PageSize;
            PdfPTable head = new PdfPTable(1);
            head.TotalWidth = page.Width;
            Phrase phrase = new Phrase(
                "Type Wise Repot \n All Data",
                new Font(Font.FontFamily.COURIER, 20)
            );
            if (!string.IsNullOrEmpty(fromDateHiddenField.Value) && !string.IsNullOrEmpty(toDateHiddenField.Value))
            {
                phrase = new Phrase(
                    "Type Wise Repot  \n Date: " + fromDateHiddenField.Value + " To " + toDateHiddenField.Value,
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
                "\nTotal: " + totalTestTypeText.Text,
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
            Response.AppendHeader("content-disposition", "attachment;filename=test.pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();
        }
    }
}