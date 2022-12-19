using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Library
{
    public class PDF_FormGenerator
    {
        public static void ExportToPDF(DataTable dt, string filename)
        {
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream($@"C:\Users\Jake\Desktop\{filename}", FileMode.Create));
            document.Open();
            Font font = FontFactory.GetFont(FontFactory.TIMES_BOLDITALIC, 11);
            PdfPTable table = new PdfPTable(dt.Columns.Count);
            PdfPRow row = null;
            float[] widths = new float[] { 4f, 4f, 4f, 4f };
            table.SetWidths(widths);
            table.WidthPercentage = 100;
            
            string colname = "";
            PdfPCell cell = new PdfPCell(new Phrase("PRODUCTS"));
            cell.Colspan = dt.Columns.Count;
            foreach (DataColumn c in dt.Columns)
                table.AddCell(new Phrase(c.ColumnName, font));
            int i = 0;
            foreach (DataRow r in dt.Rows)
            {
                table.AddCell(new Phrase(r[i].ToString(), font));
                i++;
            }
            document.Add(table);
            document.Close();
        }
    }
}
