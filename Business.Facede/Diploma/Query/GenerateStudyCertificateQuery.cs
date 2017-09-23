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

namespace Business.Facede.Query
{
    public class GenerateStudyCertificateQuery : IQueryFor<Student, MemoryStream>
    {
        public MemoryStream ExecuteQueryWith(Student st)
        {
            MemoryStream ms = new MemoryStream();

            Document document = new Document(PageSize.A4);//, 10f, 10f, 125f, 10f);
            //Document document = new Document(new RectangleReadOnly(842, 595), 10f, 10f, 125f, 10f);//88f, 88f, 10f, 10f);
            PdfWriter.GetInstance(document, ms);//new FileStream("e:\\table.pdf", FileMode.Create));
            document.Open();
            PdfPTable row = new PdfPTable(1);
            PdfPTable row1 = new PdfPTable(1);
            var p1 = new PdfPCell(new Phrase("(A) PROFORMA FOR STUDY CERTIFICATE", FontFactory.GetFont("Arial", 14)));
            p1.HorizontalAlignment = 1;
            row1.AddCell(p1);

            var p2 = new PdfPCell(new Phrase("Name, full postal address and telephone number of the institution", FontFactory.GetFont("Arial", 12)));
            p2.HorizontalAlignment = 1;
            p2.BorderWidth = 0;
            row1.AddCell(p2);

            var p3 = new PdfPCell(new Phrase("Date : 06/08/2007", FontFactory.GetFont("Arial", 12)));
            p3.HorizontalAlignment = 2;
            p3.BorderWidth = 0;
            row1.AddCell(p3);

            var text = new Chunk("This is to certify that Sri / Kum ", FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL));
            var name = new Chunk("ARUNKUMAR", FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.UNDERLINE));
            
            var t = new Paragraph();
            t.Add(text);
            t.Add(name);
            
            var p4 = new PdfPCell(t);
            p4.HorizontalAlignment = 0;
            p4.BorderWidth = 0;
            p4.PaddingBottom = 5f;
            p4.PaddingLeft = 4f;
            row1.AddCell(p4);

            var p5 = new PdfPCell(new Phrase("S/o / D/o  BASAYYA has studied from First", FontFactory.GetFont("Arial", 12)));
            p5.HorizontalAlignment = 0;
            p5.BorderWidth = 0;
            p5.PaddingBottom = 5f;
            row1.AddCell(p5);

            var p6 = new PdfPCell(new Phrase("standard to Third standard in our institution during 1991-92 to 1992-93 as per", FontFactory.GetFont("Arial", 12)));
            p6.HorizontalAlignment = 0;
            p6.BorderWidth = 0;
            p6.PaddingBottom = 5f;
            row1.AddCell(p6);

            var p7 = new PdfPCell(new Phrase("the institution records.", FontFactory.GetFont("Arial", 12)));
            p7.HorizontalAlignment = 0;
            p7.BorderWidth = 0;
            p7.PaddingBottom = 5f;
            row1.AddCell(p7);

            var p8 = new PdfPCell(new Phrase("The above details are true and correct to the best of my knowledge.", FontFactory.GetFont("Arial", 12)));
            p8.HorizontalAlignment = 0;
            p8.BorderWidth = 0;
            p8.PaddingLeft = 4f;
            row1.AddCell(p8);

            var p9 = new PdfPCell(new Phrase("\n", FontFactory.GetFont("Arial", 12)));
            p9.BorderWidth = 0;
            row1.AddCell(p9);
            row1.AddCell(p9);
            row1.AddCell(p9);

            var p10 = new PdfPCell(new Phrase("Signature of Head of the Institution", FontFactory.GetFont("Arial", 12)));
            p10.HorizontalAlignment = 0;
            p10.BorderWidth = 0;
            row1.AddCell(p10);

            var p11 = new PdfPCell(new Phrase("Name in Block Letters : SMT MARY BELLAD", FontFactory.GetFont("Arial", 12)));
            p11.HorizontalAlignment = 0;
            p11.BorderWidth = 0;
            row1.AddCell(p11);
            row1.AddCell(p9);

            var p12 = new PdfPCell(new Phrase("------------------------------------------------------------------------------------------------------", FontFactory.GetFont("Arial", 12)));
            p12.HorizontalAlignment = 0;
            p12.BorderWidth = 0;
            row1.AddCell(p12);

            row1.AddCell(p9);

            var p13 = new PdfPCell(new Phrase("COUNTER SIGNED BY ME", FontFactory.GetFont("Arial", 12)));
            p13.HorizontalAlignment = 1;
            p13.BorderWidth = 0;
            row1.AddCell(p13);

            row1.AddCell(p9);

            var p14 = new PdfPCell(new Phrase("Address. Seal & Office Telephone Number of the Block Educational Officer / DDPI", FontFactory.GetFont("Arial", 11)));
            p14.HorizontalAlignment = 1;
            p14.BorderWidth = 0;
            row1.AddCell(p14);
            row.AddCell(row1);
            row.AddCell(p9);
            document.Add(row);


            PdfPTable row2 = new PdfPTable(1);
            PdfPTable row3 = new PdfPTable(1);
            p1 = new PdfPCell(new Phrase("(B) PROFORMA FOR KANNADA MEDIUM STUDY CERTIFICATE", FontFactory.GetFont("Arial", 14)));
            p1.HorizontalAlignment = 1;
            row3.AddCell(p1);

            p2 = new PdfPCell(new Phrase("Name, full postal address and telephone number of the institution", FontFactory.GetFont("Arial", 12)));
            p2.HorizontalAlignment = 1;
            p2.BorderWidth = 0;
            row3.AddCell(p2);

            p3 = new PdfPCell(new Phrase("Date : 06/08/2007", FontFactory.GetFont("Arial", 12)));
            p3.HorizontalAlignment = 2;
            p3.BorderWidth = 0;
            row3.AddCell(p3);

            p4 = new PdfPCell(new Phrase("This is to certify that Sri / Kum ARUNKUMAR " +
                "S/o / D/o  BASAYYA has studied in Kannada medium from First " +
                "standard to Third standard in our institution during 1991-92 to 1992-93 as per" +
                "the institution records."
            , FontFactory.GetFont("Arial", 12)));
            p4.HorizontalAlignment = 0;
            p4.BorderWidth = 0;
            p4.PaddingBottom = 5f;
            p4.SpaceCharRatio = 5f;
            row3.AddCell(p4);

            //p5 = new PdfPCell(new Phrase("S/o / D/o  BASAYYA has studied in Kannada medium from First", FontFactory.GetFont("Arial", 12)));
            //p5.HorizontalAlignment = 0;
            //p5.BorderWidth = 0;
            //row3.AddCell(p5);

            //p6 = new PdfPCell(new Phrase("standard to Third standard in our institution during 1991-92 to 1992-93 as per", FontFactory.GetFont("Arial", 12)));
            //p6.HorizontalAlignment = 0;
            //p6.BorderWidth = 0;
            //row3.AddCell(p6);

            //p7 = new PdfPCell(new Phrase("the institution records.", FontFactory.GetFont("Arial", 12)));
            //p7.HorizontalAlignment = 0;
            //p7.BorderWidth = 0;
            //row3.AddCell(p7);

            p8 = new PdfPCell(new Phrase("The above details are true and correct to the best of my knowledge.", FontFactory.GetFont("Arial", 12)));
            p8.HorizontalAlignment = 0;
            p8.BorderWidth = 0;
            row3.AddCell(p8);

            row3.AddCell(p9);
            row3.AddCell(p9);
            row3.AddCell(p9);

            p10 = new PdfPCell(new Phrase("Signature of Head of the Institution", FontFactory.GetFont("Arial", 12)));
            p10.HorizontalAlignment = 0;
            p10.BorderWidth = 0;
            row3.AddCell(p10);

            p11 = new PdfPCell(new Phrase("Name in Block Letters : SMT MARY BELLAD", FontFactory.GetFont("Arial", 12)));
            p11.HorizontalAlignment = 0;
            p11.BorderWidth = 0;
            row3.AddCell(p11);
            row3.AddCell(p9);

            p12 = new PdfPCell(new Phrase("------------------------------------------------------------------------------------------------------", FontFactory.GetFont("Arial", 12)));
            p12.HorizontalAlignment = 0;
            p12.BorderWidth = 0;
            row3.AddCell(p12);

            row3.AddCell(p9);

            p13 = new PdfPCell(new Phrase("COUNTER SIGNED BY ME", FontFactory.GetFont("Arial", 12)));
            p13.HorizontalAlignment = 1;
            p13.BorderWidth = 0;
            row3.AddCell(p13);

            row3.AddCell(p9);

             p14 = new PdfPCell(new Phrase("Address. Seal & Office Telephone Number of the Block Educational Officer / DDPI", FontFactory.GetFont("Arial", 11)));
            p14.HorizontalAlignment = 1;
            p14.BorderWidth = 0;
            row3.AddCell(p14);

            row2.AddCell(row3);

            
            document.Add(row2);
            document.Close();
            ms.Close();
            return ms;
        }

        private iTextSharp.text.Font GetFont(float size)
        {
            return FontFactory.GetFont("Arial", size);
        }        
    }   
}
