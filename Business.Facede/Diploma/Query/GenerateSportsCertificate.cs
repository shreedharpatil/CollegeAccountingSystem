
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
    public class GenerateSportsCertificate : IQueryFor<Student, MemoryStream>
    {
        public MemoryStream ExecuteQueryWith(Student st)
        {
            MemoryStream ms = new MemoryStream();
            
            Document document = new Document(PageSize.A4, 10f, 10f, 125f, 10f);
            //Document document = new Document(new RectangleReadOnly(842, 595), 10f, 10f, 125f, 10f);//88f, 88f, 10f, 10f);
            PdfWriter.GetInstance(document, ms);//new FileStream("e:\\table.pdf", FileMode.Create));
            document.Open();
            PdfPTable row = new PdfPTable(1);
            PdfPTable row1 = new PdfPTable(1);
            var p9 = new PdfPCell(new Phrase("\n", FontFactory.GetFont("Arial", 12)));
            p9.BorderWidth = 0;
            var p1 = new PdfPCell(new Phrase("ROTARY BANGALORE INDIRANAGAR", FontFactory.GetFont("Arial", 15)));
            p1.HorizontalAlignment = 1;
            p1.BorderWidth = 0;
            row1.AddCell(p1);

             p1 = new PdfPCell(new Phrase("R.I. Dist: 3190", FontFactory.GetFont("Arial", 6)));
            p1.HorizontalAlignment = 1;
            p1.BorderWidth = 0;

            row1.AddCell(p1);
            row1.AddCell(p9);
            var p2 = new PdfPCell(new Phrase("Inter Adopted School Athletic Meet - 28th January 2012", FontFactory.GetFont("Arial", 10)));
            p2.HorizontalAlignment = 1;
            p2.BorderWidth = 0;
            row1.AddCell(p2);

             p2 = new PdfPCell(new Phrase("at the Sea College Institution Campus - K R Puram.", FontFactory.GetFont("Arial", 10)));
            p2.HorizontalAlignment = 1;
            p2.BorderWidth = 0;
            row1.AddCell(p2);
            row1.AddCell(p9);
            var text = new Chunk("This is to certify that ", FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL));
            var name = new Chunk("VIKAS , N", FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.UNDERLINE));
            
            var t = new Paragraph();
            t.Add(text);
            t.Add(name);
            
            var p4 = new PdfPCell(t);
            p4.HorizontalAlignment = 0;
            p4.BorderWidth = 0;
            p4.PaddingBottom = 5f;
            p4.PaddingLeft = 80f;
            row1.AddCell(p4);

            text = new Chunk("representing  ", FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL));
            name = new Chunk("Govt.  Primary  School,  Hoodi,", FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.UNDERLINE));

            t = new Paragraph();
            t.Add(text);
            t.Add(name);

            text = new Chunk("of Std ", FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL));
            name = new Chunk("sixth std,", FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.UNDERLINE));
            t.Add(text);
            t.Add(name);
            var p5 = new PdfPCell(t);
            p5.HorizontalAlignment = 1;
            p5.BorderWidth = 0;
            p5.PaddingBottom = 5f;
            row1.AddCell(p5);


            text = new Chunk("participated in the tournament in  ", FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL));
            name = new Chunk("4 X 100 MTS [RELAY]", FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.UNDERLINE));

             t = new Paragraph();
            t.Add(text);
            t.Add(name);
            var p6 = new PdfPCell(t);
            p6.HorizontalAlignment = 1;
            p6.BorderWidth = 0;
            p6.PaddingBottom = 5f;
            row1.AddCell(p6);

            

            row1.AddCell(p9);

            var p7 = new PdfPCell(new Phrase("and was placed First/Second/Third.", FontFactory.GetFont("Arial", 12)));
            p7.HorizontalAlignment = 1;
            p7.BorderWidth = 0;
            p7.PaddingBottom = 5f;
            row1.AddCell(p7);
            row1.AddCell(p9);
           
            row.AddCell(row1);
            
            var signature = new PdfPTable(4);
            var p8 = new PdfPCell(new Phrase("Rtn. Dr Krishanan Menon", FontFactory.GetFont("Arial", 10)));
            p8.HorizontalAlignment = 1;
            p8.BorderWidth = 0;
            signature.AddCell(p8);
            p7 = new PdfPCell(new Phrase("Rtn. Mahesh Prathik", FontFactory.GetFont("Arial", 10)));
            p7.HorizontalAlignment = 1;
            p7.BorderWidth = 0;
            signature.AddCell(p7);
            p7 = new PdfPCell(new Phrase("Rtn. Jagadhish M.", FontFactory.GetFont("Arial", 10)));
            p7.HorizontalAlignment = 1;
            p7.BorderWidth = 0;
            signature.AddCell(p7);
            p7 = new PdfPCell(new Phrase("Rtn. Sanjay K Srivastava", FontFactory.GetFont("Arial", 10)));
            p7.HorizontalAlignment = 1;
            p7.BorderWidth = 0;
            signature.AddCell(p7);
            
            p7 = new PdfPCell(new Phrase("President", FontFactory.GetFont("Arial", 8)));
            p7.HorizontalAlignment = 1;
            p7.BorderWidth = 0;
            p7.BorderWidthTop = 0;
            signature.AddCell(p7);
            p7 = new PdfPCell(new Phrase("Secretary", FontFactory.GetFont("Arial", 8)));
            p7.HorizontalAlignment = 1;
            p7.BorderWidth = 0;
            signature.AddCell(p7);
            p7 = new PdfPCell(new Phrase("Director - New Generation", FontFactory.GetFont("Arial", 8)));
            p7.HorizontalAlignment = 1;
            p7.BorderWidth = 0;
            signature.AddCell(p7);
            p7 = new PdfPCell(new Phrase("Chairman - Sports & Youth Devp.", FontFactory.GetFont("Arial", 8)));
            p7.HorizontalAlignment = 1;
            p7.BorderWidth = 0;
            signature.AddCell(p7);
            
            row.AddCell(signature);
            document.Add(row);
            
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
