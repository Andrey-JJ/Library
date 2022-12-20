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
    public partial class SubForm : Form
    {
        public SubForm(DataTable dt, string s)
        {
            InitializeComponent();
            this.Text = $"Формуляр читателя - {s}";
            dGVSub.DataSource = dt;
            string filename = PDF_FormGenerator.GetFileName("ФормулярЧитателя_" + DateTime.Now);
            PDF_FormGenerator.ExportSubFormToPDF(dt, filename, s);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
