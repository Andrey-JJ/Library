using Npgsql;
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
    public partial class LogsForm : Form
    {
        public LogsForm(NpgsqlConnection connection)
        {
            InitializeComponent();
            GetLogs(connection);
        }
        void GetLogs(NpgsqlConnection connection)
        {
            DataTable dt = DataBase_ProcessingRequest.SelectLogs(connection);
            dataGridView1.DataSource = dt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
