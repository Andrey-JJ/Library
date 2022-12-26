using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Font;
using iText.Layout.Properties;

namespace Library
{
    /// <summary>
    /// Класс для создания pdf формуляров читателя и книги
    /// </summary>
    public class PDF_FormGenerator
    {
        /// <summary>
        /// Метод создания формуляра читателя
        /// </summary>
        /// <param name="dt"> Таблица хранящая данные из базы </param>
        /// <param name="filename"> Переменная хранящая название файла </param>
        /// <param name="subname"> Переменная хранящая выбранного читателя </param>
        public static void ExportSubFormToPDF(DataTable dt, string filename, string subname)
        {
            try
            {
                Document document = CreateDocument(filename);
                Paragraph header = new Paragraph($"Формуляр читателя - {subname}")
                   .SetTextAlignment(TextAlignment.CENTER)
                   .SetFontSize(18);
                document.Add(header);

                Paragraph newline = new Paragraph(new Text("\n"));
                document.Add(newline);

                Table table = new Table(5);
                table.AddCell(new Paragraph(new Text(dt.Columns[0].ColumnName)));
                table.AddCell(new Paragraph(new Text(dt.Columns[1].ColumnName)));
                table.AddCell(new Paragraph(new Text(dt.Columns[2].ColumnName)));
                table.AddCell(new Paragraph(new Text(dt.Columns[3].ColumnName)));
                table.AddCell(new Paragraph(new Text(dt.Columns[4].ColumnName)));

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    table.AddCell(new Paragraph(new Text(dt.Rows[i][0].ToString())));
                    table.AddCell(new Paragraph(new Text(dt.Rows[i][1].ToString())));
                    table.AddCell(new Paragraph(new Text(dt.Rows[i][2].ToString())));
                    table.AddCell(new Paragraph(new Text(dt.Rows[i][3].ToString())));
                    table.AddCell(new Paragraph(new Text(dt.Rows[i][4].ToString())));
                }
                document.Add(table);
                document.Close();
            }
            catch { }
        }
        /// <summary>
        /// Метод создания формуляра книги
        /// </summary>
        /// <param name="dt"> Таблица хранящая данные из базы </param>
        /// <param name="filename"> Переменная хранящая название файла </param>
        /// <param name="data"> Массив хранящий название и номер книги </param>
        public static void ExportBookFormToPDF(DataTable dt, string filename, string[] data)
        {
            try
            {
                Document document = CreateDocument(filename);
                Paragraph header = new Paragraph($"Формуляр книги - {data[1]} №{data[0]}")
                   .SetTextAlignment(TextAlignment.CENTER)
                   .SetFontSize(18);
                document.Add(header);

                Paragraph newline = new Paragraph(new Text("\n"));
                document.Add(newline);

                Table table = new Table(5);
                table.AddCell(new Paragraph(new Text(dt.Columns[0].ColumnName)));
                table.AddCell(new Paragraph(new Text(dt.Columns[1].ColumnName)));
                table.AddCell(new Paragraph(new Text(dt.Columns[2].ColumnName)));
                table.AddCell(new Paragraph(new Text(dt.Columns[3].ColumnName)));

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    table.AddCell(new Paragraph(new Text(dt.Rows[i][0].ToString())));
                    table.AddCell(new Paragraph(new Text(dt.Rows[i][1].ToString())));
                    table.AddCell(new Paragraph(new Text(dt.Rows[i][2].ToString())));
                    table.AddCell(new Paragraph(new Text(dt.Rows[i][3].ToString())));
                }
                document.Add(table);
                document.Close();
            }
            catch { }
        }
        /// <summary>
        /// Метод создания документа по выбранному пути
        /// </summary>
        /// <param name="path"></param>
        /// <returns> Возвращает переменную типа Document для внесения данных </returns>
        private static Document CreateDocument(string path)
        {
            Document document = new Document(new PdfDocument(new PdfWriter(path)));
            PdfFont font = PdfFontFactory.CreateFont(Properties.Resources.dinpro_bold, PdfEncodings.IDENTITY_H);
            document.SetFont(font);
            return document;
        }
        /// <summary>
        /// Метод выбора пути сохранения файла
        /// </summary>
        /// <param name="filename"></param>
        /// <returns> Возвращает строку с именем файла для сохранения </returns>
        public static string GetFileName(string filename)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = filename;
            saveFileDialog.DefaultExt = "pdf";
            saveFileDialog.Filter = "PDF файлы (*.pdf)|*.pdf|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                return saveFileDialog.FileName;
            }
            else return null;
        }
    }
}
