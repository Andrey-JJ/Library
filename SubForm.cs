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
    /// Форма формуляр читателя
    /// </summary>
    public partial class SubForm : Form
    {
        /// <summary>
        /// Конструктор класса создающий форму и сохраняющий файл
        /// </summary>
        /// <param name="dt"> Таблица хранящая данные из базы данных </param>
        /// <param name="s"> Переменная хранящая выбранного читателя </param>
        public SubForm(DataTable dt, string s)
        {
            InitializeComponent();
            this.Text = $"Формуляр читателя - {s}";
            dGVSub.DataSource = dt;
            string filename = PDF_FormGenerator.GetFileName($"ФормулярЧитателя_{s}_" + DateTime.Now.Date);
            PDF_FormGenerator.ExportSubFormToPDF(dt, filename, s);
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
