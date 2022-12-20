using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    /// <summary>
    /// Форма формуляр книги
    /// </summary>
    public partial class BookForm : Form
    {
        /// <summary>
        /// Конструктор класса создающий форму и сохраняющий файл
        /// </summary>
        /// <param name="dt"> Таблица хранящая данные из базы данных </param>
        /// <param name="data"> Массив хранящий название и номер выбранной книги </param>
        public BookForm(DataTable dt, string[] data)
        {
            InitializeComponent();
            dGVBook.DataSource = dt;
            this.Text = $"Формуляр книги {data[1]} №{data[0]}";
            string filename = PDF_FormGenerator.GetFileName("ФормулярКниги_"+DateTime.Now);
            PDF_FormGenerator.ExportBookFormToPDF(dt, filename, data);
        }
        /// <summary>
        /// Обработчик кнопки закрытия формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
