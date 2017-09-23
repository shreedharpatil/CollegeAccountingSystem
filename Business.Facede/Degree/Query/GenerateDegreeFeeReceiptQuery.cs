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

namespace Business.Facede.Degree.Query
{
    public class GenerateDegreeFeeReceiptQuery : IQueryFor<Student, MemoryStream>
    {
        public MemoryStream ExecuteQueryWith(Student student)
        {
            MemoryStream ms = new MemoryStream();

            Document document = new Document(PageSize.A4, 10f, 10f, 100f, 10f);
            PdfWriter.GetInstance(document, ms);//new FileStream("e:\\table.pdf", FileMode.Create));
            document.Open();
            var trustInfo = new PdfPTable(3);
            var r1 = new PdfPCell(new Phrase("ESTD - 2011-11", FontFactory.GetFont("Arial", 12)));
            var r2 = new PdfPCell(new Phrase("Nivedita Educational Trust(R)", FontFactory.GetFont("Arial", 12)));
            var r3 = new PdfPCell(new Phrase("Ph:(08473) 250600", FontFactory.GetFont("Arial", 12)));
            r1.BorderWidth = 0;
            r2.BorderWidth = 0;
            r3.BorderWidth = 0;
            trustInfo.AddCell(r1);
            trustInfo.AddCell(r2);
            trustInfo.AddCell(r3);           

            var firstRow = new PdfPTable(1);
            var cell1 = new PdfPCell(new Phrase("NIVEDITA SCIENCE DEGREE COLLEGE", FontFactory.GetFont("Arial", 15)));
            var cell3 = new PdfPCell(new Phrase("Station Area , Hyderabad Road, YADGIR - 585 202", FontFactory.GetFont("Arial", 12)));
            cell1.HorizontalAlignment = 1;
            cell3.HorizontalAlignment = 1;
            cell1.BorderWidth = 0;
            cell3.BorderWidth = 0;

            firstRow.AddCell(cell1);
            firstRow.AddCell(cell3);

            var secondRow = new PdfPTable(3);
            var cell11 = new PdfPCell(new Phrase("No.", FontFactory.GetFont("Arial", 12)));
            var cell12 = new PdfPCell(new Phrase("FEES RECEIPT", FontFactory.GetFont("Arial", 12)));
            var cell13 = new PdfPCell(new Phrase("Date :  " + student.DateOfAdmission.FormatDate("/"), FontFactory.GetFont("Arial", 12)));

            cell11.BorderWidth = 0;
            cell12.BorderWidth = 0;
            cell13.BorderWidth = 0;
            var cell21 = new PdfPCell(new Phrase("Name :  " + student.Name, FontFactory.GetFont("Arial", 12)));
            cell21.Colspan = 3;
            cell21.BorderWidth = 0;
            var cell31 = new PdfPCell(new Phrase("Admission No.", FontFactory.GetFont("Arial", 12)));
            var cell32 = new PdfPCell(new Phrase("Class : " + student.Year + " Sem, " + student.BranchName , FontFactory.GetFont("Arial", 12)));
            cell31.BorderWidth = 0;
            cell31.Colspan = 2;
            cell32.BorderWidth = 0;
            secondRow.AddCell(cell11);
            secondRow.AddCell(cell12);
            secondRow.AddCell(cell13);
            secondRow.AddCell(cell21);
            secondRow.AddCell(cell31);
            secondRow.AddCell(cell32);

            var firstrow = new PdfPCell(firstRow);
            firstrow.BorderWidth = 0;
            var secondrow = new PdfPCell(secondRow);
            secondrow.BorderWidth = 0;
            var thirdrow = new PdfPCell(trustInfo);
            thirdrow.BorderWidth = 0;
            var header = new PdfPTable(1);
            header.AddCell(thirdrow);
            header.AddCell(firstrow);
            header.AddCell(secondrow);
            var mainheader = new PdfPTable(1);
            mainheader.AddCell(header);
            document.Add(mainheader);
            PdfPTable fourthRow = new PdfPTable(3);
            float[] width = new float[] { 1f, 5f, 3f };
            fourthRow.SetWidths(width);
            var c1 = new PdfPCell(new Phrase("Sl. No", GetFont(12f)));
            var c2 = new PdfPCell(new Phrase("PARTICULARS", GetFont(12f)));

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
                new FeeStructure{ Description = "Application Fees", Amount = student.ApplicationFee},new FeeStructure{ Description = "Tution Fees", Amount = student.CourseFee },
                new FeeStructure{ Description = "Laboratary Fees", Amount = student.LabFee },new FeeStructure{ Description = "Library Fees", Amount = student.LibraryFee },
                new FeeStructure{ Description = "House Examination Fees", Amount = student.HomeExamFee },new FeeStructure{ Description = "Medical Examination Fees", Amount = student.MedicalExamFee },
                new FeeStructure{ Description = "Union Fees", Amount = student.UnionFee },new FeeStructure{ Description = "College Sports Fees", Amount = student.CollegeSportsFee },
                new FeeStructure{ Description = "Mis Fee", Amount = student.MisFee },new FeeStructure{ Description = "Reading Room Fees", Amount = student.ReadingRoomFee },new FeeStructure{ Description = "Identity Cards Fees", Amount = student.IdentityCardFee},new FeeStructure{ Description = "Student Aid Fund", Amount = student.StudentAidFundFee },
                new FeeStructure{ Description = "Magazine Fees", Amount = student.MagazineFee },new FeeStructure{ Description = "Annual Day", Amount = student.AnnualDayFee },
                new FeeStructure{ Description = "Student Aid's Fund", Amount = student.StudentAidFundFee},new FeeStructure{ Description = "Teacher's Benefit Fund", Amount = student.TeacherBenefitFundFee},

                new FeeStructure{ Description = "Student's Welfare Fund", Amount = student.StudentWelfareFundFee},new FeeStructure{ Description = "Science Development Fund", Amount = student.ScienceDevelopmentFee},
                new FeeStructure{ Description = "University Registration Fund", Amount = student.UniversityRegistrationFee},new FeeStructure{ Description = "Eligibility Application Fees", Amount = student.EligibilityApplicationFee},
                new FeeStructure{ Description = "Eligibility Fees", Amount = student.EligibilityFee},new FeeStructure{ Description = "University Sports Fees", Amount = student.UniversitySportsFee},
                new FeeStructure{ Description = "University Welfare Fees", Amount = student.UniversityWelfareFee},new FeeStructure{ Description = "Carrier Guidence Fund", Amount = student.CarrierGuidenceFundFee},
                new FeeStructure{ Description = "Corpus Fund", Amount = student.CorpusFundFee},new FeeStructure{ Description = "N. S. S", Amount = student.NssFee},
                
                new FeeStructure{ Description = "College Development Fees", Amount = student.CollegeDevelopmentFee},new FeeStructure{ Description = "University Silver Jubilee Fees", Amount = student.UniversitysilverJubileeFee},
                new FeeStructure{ Description = "Miscellaneous", Amount = student.MiscellaneousFee},

                new FeeStructure{ Description = "Total Fee Rs.", Amount = student.TotalFee },
                new FeeStructure{ Description = "Total Fee Paid Rs.", Amount = student.PaidFee }, new FeeStructure{ Description = "Due Fee Rs.", Amount = student.DueFee }
            };

            fifthRow.SetWidths(new float[] { 1f, 5f, 2f, 1f });
            FillValues(document, fifthRow, fees);
            PdfPTable footer = new PdfPTable(1);

            var c4 = new PdfPCell(new Phrase("Rupees In words : " + changeToWords(student.PaidFee.ToString(), false) + "only", FontFactory.GetFont("Arial", 12)));
            footer.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            var c6 = new PdfPCell(new Phrase("Signature", FontFactory.GetFont("Arial", 12)));
            c6.HorizontalAlignment = 2;
            c4.BorderWidth = 0;
            c6.BorderWidth = 0;
            footer.AddCell(c4);
            footer.AddCell(c6);
            var foot = new PdfPTable(1);
            foot.AddCell(footer);
            document.Add(foot);
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

