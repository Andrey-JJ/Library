using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Library
{
    public partial class BDworkForm : Form
    {
        public BDworkForm()
        {
            InitializeComponent();
            StartWork();
        }
        string connectionToDB;
        NpgsqlConnection conn;
        void TreeBD()
        {
            treeView1.BeforeSelect += new TreeViewCancelEventHandler(treeView1_BeforeSelect);
            TreeNode node = new TreeNode("Таблицы данных: ");
            node.Nodes.Add("Экземпляр книги");
            node.Nodes.Add("Каталожная карточка книги");
            node.Nodes.Add("Выдача");
            node.Nodes.Add("Отдел");
            node.Nodes.Add("Абонент");
            node.Nodes.Add("Библиотекарь");
            treeView1.Nodes.Add(node);
        }
        void StartWork()
        {
            TreeBD();
            UserConnection user = new UserConnection("UserPig", "masterkey");
            connectionToDB = user.OpenConnection();
            try
            {
                conn = new NpgsqlConnection(connectionToDB);
                conn.Open();
                SelectFromDB("Экземпляр книги");
            }
            catch {  }
        }
        void SelectFromDB(string s)
        {
            string temp = "";
            switch (s)
            {
                case "Экземпляр книги":
                    temp = "copy_of_book";
                    break;
                case "Каталожная карточка книги":
                    temp = "catalog_card_of_book";
                    break;
                case "Выдача":
                    temp = "book_issue";
                    break;
                case "Отдел":
                    temp = "department";
                    break;
                case "Абонент":
                    temp = "subscriber";
                    break;
                case "Библиотекарь":
                    temp = "librarian";
                    break;
            }
            string table = $"select * from {temp}";
            try
            {
                NpgsqlCommand command = new NpgsqlCommand(table, conn);
                NpgsqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;
            }
            catch { }
        }
        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            string s = e.Node.Text;
            if(s != "Таблицы данных: ") SelectFromDB(s);
        }
    }
}
