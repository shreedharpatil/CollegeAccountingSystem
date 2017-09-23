using Business.Facede.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
//using PdfFileWriter;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Business.Facede.Nursing.Query
{
    public class GenerateNursingFeeReceiptQuery : IQueryFor<Student, MemoryStream>
    {
        public MemoryStream ExecuteQueryWith(Student student)
        {
            MemoryStream ms = new MemoryStream();

            Document document = new Document(PageSize.A4, 10f, 10f, 125f, 10f);
            PdfWriter.GetInstance(document, ms);//new FileStream("e:\\table.pdf", FileMode.Create));
            document.Open();
            var img = iTextSharp.text.Image.GetInstance(Path.Combine(HttpRuntime.AppDomainAppPath,@"download.jpg"));
            img.ScalePercent(35);
            PdfPCell cell = new PdfPCell(img);
            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            PdfPTable table = new PdfPTable(2);
            float[] widths = new float[] { 2f, 7f };
            table.SetWidths(widths);
            PdfPTable row = new PdfPTable(1);
            PdfPTable table1 = new PdfPTable(2);           

            var p2 = new PdfPCell(new Phrase("NIVEDITA EDUCATIONAL TRUST(R)", FontFactory.GetFont("Arial", 12)));
            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            var times = new iTextSharp.text.Font(bfTimes, 15, iTextSharp.text.Font.BOLD);
            var p3 = new PdfPCell(new Phrase("Nivedita School of Nursing", times));

            var p5 = new PdfPCell(new Phrase("Station Area, Hyderabad - Road - YADGIRI- 585 202.", FontFactory.GetFont("Arial", 12)));
            p2.Colspan = 2;
            p3.Colspan = 2;
            p5.Colspan = 2;

            p2.BorderWidth = 0;
            p3.BorderWidth = 0;
            p5.BorderWidth = 0;

            p2.HorizontalAlignment = 1;
            p3.HorizontalAlignment = 1;
            p5.HorizontalAlignment = 1;

            table1.AddCell(p2);
            table1.AddCell(p3);
            table1.AddCell(p5);
            row.AddCell(table1);
            table.AddCell(cell);
            table.AddCell(row);

            document.Add(table);

            PdfPTable secondRow = new PdfPTable(1);

            var s1 = new PdfPCell(new Phrase("FEE RECEIPT", GetFont(12f)));
            
            s1.HorizontalAlignment = 1;
            secondRow.AddCell(s1);
            document.Add(secondRow);

            PdfPTable thirdRow = new PdfPTable(1);
            PdfPTable nameSection = new PdfPTable(2);
            nameSection.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            var p6 = new Phrase("Name: " + student.Name, FontFactory.GetFont("Arial", 12));

            var p7 = new Phrase("No:     ", FontFactory.GetFont("Arial", 12));
            var p8 = new Phrase("Date: " + student.DateOfAdmission.FormatDate("/"), FontFactory.GetFont("Arial", 12));
            var cell1 = new PdfPCell(p6);
            cell1.BorderWidth = 0;

            cell1.Colspan = 2;
            
            var cell2 = new PdfPCell(p7);
            //cell2.Colspan = 3;
            cell2.BorderWidth = 0;
            nameSection.AddCell(cell2);
            nameSection.AddCell(p8);
            nameSection.AddCell(cell1);
            thirdRow.AddCell(nameSection);
            document.Add(thirdRow);

            PdfPTable fourthRow = new PdfPTable(3);
            float[] width = new float[] { 1f, 5f, 3f };
            fourthRow.SetWidths(width);
            var c1 = new PdfPCell(new Phrase("Sl. No", GetFont(12f)));
            var c2 = new PdfPCell(new Phrase("Particulars", GetFont(12f)));



            PdfPTable headings = new PdfPTable(2);
            var amountHeading = new PdfPCell(new Phrase("Amount", GetFont(12f)));
            amountHeading.Colspan = 2;
            amountHeading.HorizontalAlignment = 1;
            amountHeading.BorderWidth = 0;
            var rupeesHeading = new PdfPCell(new Phrase("Rs", GetFont(12f)));
            rupeesHeading.HorizontalAlignment = 0;
            rupeesHeading.BorderWidth = 0;

            var paiseHeading = new PdfPCell(new Phrase("Ps", GetFont(12f)));
            paiseHeading.HorizontalAlignment = 2;
            paiseHeading.BorderWidth = 0;

            headings.AddCell(amountHeading);
            headings.AddCell(rupeesHeading);
            headings.AddCell(paiseHeading);
            c1.HorizontalAlignment = 1;
            c2.HorizontalAlignment = 1;
            fourthRow.AddCell(c1);
            fourthRow.AddCell(c2);
            fourthRow.AddCell(headings);

            document.Add(fourthRow);

            PdfPTable fifthRow = new PdfPTable(4);
            IList<FeeStructure> fees = new List<FeeStructure> { 
                new FeeStructure{ Description = "Admission Fee", Amount = student.AdmissionFee },new FeeStructure{ Description = "Tution Fee", Amount = student.CourseFee },
                new FeeStructure{ Description = "Phyciatric Fee", Amount = student.PhyciatricFee },new FeeStructure{ Description = "Lab Fee", Amount = student.LabFee },
                new FeeStructure{ Description = "Library Fee", Amount = student.LibraryFee },new FeeStructure{ Description = "Sports Fee", Amount = student.SportsFee },
                new FeeStructure{ Description = "Medical Fee", Amount = student.MedicalFee },new FeeStructure{ Description = "Transportation Fee", Amount = student.TransportationFee },
                new FeeStructure{ Description = "Examination Fees Board / Class", Amount = student.ExaminationFee },new FeeStructure{ Description = "Hostel", Amount = student.HostelFee },
                new FeeStructure{ Description = "Mess", Amount = student.MessFee },new FeeStructure{ Description = "Books Fee", Amount = student.BooksFee },
                new FeeStructure{ Description = "Uniform", Amount = student.UniformFee },new FeeStructure{ Description = "Caution Deposit", Amount = student.CautionDepositFee },
                new FeeStructure{ Description = "Other Fees", Amount = student.OtherFee },  new FeeStructure{ Description = "Total Fee Rs.", Amount = student.TotalFee },
                new FeeStructure{ Description = "Total Fee Paid Rs.", Amount = student.PaidFee }, new FeeStructure{ Description = "Due Fee Rs.", Amount = student.DueFee }
            };

            fifthRow.SetWidths(new float[] { 1f, 5f, 2f, 1f });
            FillValues(document, fifthRow, fees);
            PdfPTable sixthRow = new PdfPTable(1);
            PdfPTable footer = new PdfPTable(2);
            footer.SetWidths(new float[] { 5f, 2f });
            var c4 = new PdfPCell(new Phrase("Rupeesin words: " + changeToWords(student.PaidFee.ToString(),false) + " only", FontFactory.GetFont("Arial", 12)));
            c4.Colspan = 2;
            footer.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            
            var c6 = new PdfPCell(new Phrase("Accountant", FontFactory.GetFont("Arial", 12)));
            c6.HorizontalAlignment = 2;
            c6.Colspan = 2;
            c4.BorderWidth = 0;
            c6.BorderWidth = 0;
            footer.AddCell(c4);
            footer.AddCell(c6);
            sixthRow.AddCell(footer);
            document.Add(sixthRow);
            document.Close();
            ms.Close();
            return ms;
        }

        private iTextSharp.text.Font GetFont(float size)
        {
            return FontFactory.GetFont("Arial", size);
        }

        private void FillValues(Document document, PdfPTable fifthRow, IList<FeeStructure> values)
        {
            int index = 0;
            PdfPCell c1, c2, c3, c4;
            foreach (var fee in values)
            {
                c1 = new PdfPCell(new Phrase((index + 1).ToString(), GetFont(12)));
                c2 = new PdfPCell(new Phrase(fee.Description, GetFont(12)));
                c3 = new PdfPCell(new Phrase(FormatFee(fee.Amount)[0], GetFont(12)));
                c4 = new PdfPCell(new Phrase(FormatFee(fee.Amount)[1], GetFont(12)));
                c1.HorizontalAlignment = 1;
                //c3.HorizontalAlignment = 1;
                //c4.HorizontalAlignment = 1;
                fifthRow.AddCell(c1);
                fifthRow.AddCell(c2);
                fifthRow.AddCell(c3);
                fifthRow.AddCell(c4);
                index += 1;
            }

            document.Add(fifthRow);
        }

        private string[] FormatFee(decimal amount)
        {
            if (amount.ToString().Contains("."))
            {
                return amount.ToString().Split('.');
            }

            return new string[] { amount.ToString(), "00" };
        }

        private String changeToWords(String numb, bool isCurrency)
        {
            String val = "", wholeNo = numb, points = "", andStr = "", pointStr = "";
            String endStr = (isCurrency) ? ("Only") : ("");
            try
            {
                int decimalPlace = numb.IndexOf(".");
                if (decimalPlace > 0)
                {
                    wholeNo = numb.Substring(0, decimalPlace);
                    points = numb.Substring(decimalPlace + 1);
                    if (Convert.ToInt32(points) > 0)
                    {
                        andStr = (isCurrency) ? ("and") : ("point");// just to separate whole numbers from points/cents
                        endStr = (isCurrency) ? ("Rupees " + endStr) : ("");
                        pointStr = translateCents(points);
                    }
                }
                val = String.Format("{0} {1}{2} {3}", translateWholeNumber(wholeNo).Trim(), andStr, pointStr, endStr);
            }
            catch { ;}
            return val;
        }
        private String translateWholeNumber(String number)
        {
            string word = "";
            try
            {
                bool beginsZero = false;//tests for 0XX
                bool isDone = false;//test if already translated
                double dblAmt = (Convert.ToDouble(number));
                //if ((dblAmt > 0) && number.StartsWith("0"))
                if (dblAmt > 0)
                {//test for zero or digit zero in a nuemric
                    beginsZero = number.StartsWith("0");
                    int numDigits = number.Length;
                    int pos = 0;//store digit grouping
                    String place = "";//digit grouping name:hundres,thousand,etc...
                    switch (numDigits)
                    {
                        case 1://ones' range
                            word = ones(number);
                            isDone = true;
                            break;
                        case 2://tens' range
                            word = tens(number);
                            isDone = true;
                            break;
                        case 3://hundreds' range
                            pos = (numDigits % 3) + 1;
                            place = " Hundred ";
                            break;
                        case 4://thousands' range
                        case 5:
                        case 6:
                            pos = (numDigits % 4) + 1;
                            place = " Thousand ";
                            break;
                        case 7://millions' range
                        case 8:
                        case 9:
                            pos = (numDigits % 7) + 1;
                            place = " Million ";
                            break;
                        case 10://Billions's range
                            pos = (numDigits % 10) + 1;
                            place = " Billion ";
                            break;
                        //add extra case options for anything above Billion...
                        default:
                            isDone = true;
                            break;
                    }
                    if (!isDone)
                    {//if transalation is not done, continue...(Recursion comes in now!!)
                        word = translateWholeNumber(number.Substring(0, pos)) + place + translateWholeNumber(number.Substring(pos));
                        //check for trailing zeros
                        if (beginsZero) word = " and " + word.Trim();
                    }
                    //ignore digit grouping names
                    if (word.Trim().Equals(place.Trim())) word = "";
                }
            }
            catch { ;}
            return word.Trim();
        }
        private String tens(String digit)
        {
            int digt = Convert.ToInt32(digit);
            String name = null;
            switch (digt)
            {
                case 10:
                    name = "Ten";
                    break;
                case 11:
                    name = "Eleven";
                    break;
                case 12:
                    name = "Twelve";
                    break;
                case 13:
                    name = "Thirteen";
                    break;
                case 14:
                    name = "Fourteen";
                    break;
                case 15:
                    name = "Fifteen";
                    break;
                case 16:
                    name = "Sixteen";
                    break;
                case 17:
                    name = "Seventeen";
                    break;
                case 18:
                    name = "Eighteen";
                    break;
                case 19:
                    name = "Nineteen";
                    break;
                case 20:
                    name = "Twenty";
                    break;
                case 30:
                    name = "Thirty";
                    break;
                case 40:
                    name = "Fourty";
                    break;
                case 50:
                    name = "Fifty";
                    break;
                case 60:
                    name = "Sixty";
                    break;
                case 70:
                    name = "Seventy";
                    break;
                case 80:
                    name = "Eighty";
                    break;
                case 90:
                    name = "Ninety";
                    break;
                default:
                    if (digt > 0)
                    {
                        name = tens(digit.Substring(0, 1) + "0") + " " + ones(digit.Substring(1));
                    }
                    break;
            }
            return name;
        }
        private String ones(String digit)
        {
            int digt = Convert.ToInt32(digit);
            String name = "";
            switch (digt)
            {
                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
            }
            return name;
        }
        private String translateCents(String cents)
        {
            String cts = "", digit = "", engOne = "";
            for (int i = 0; i < cents.Length; i++)
            {
                digit = cents[i].ToString();
                if (digit.Equals("0"))
                {
                    engOne = "Zero";
                }
                else
                {
                    engOne = ones(digit);
                }
                cts += " " + engOne;
            }
            return cts;
        }
    }

    public class FeeStructure
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }
}
