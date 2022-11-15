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
        public BDworkForm() {
            InitializeComponent();
            StartWork();
        }
        BdMethods bdMethods; //Элемент класса для работы с базой данных
        /// <summary>
        /// Метод заполнения древа
        /// </summary>
        void TreeBD() {
            bdTableTree.BeforeSelect += new TreeViewCancelEventHandler(bdTableTree_BeforeSelect);
            TreeNode node = new TreeNode("Таблицы данных: ");
            node.Nodes.Add("Экземпляр книги");
            node.Nodes.Add("Каталожная карточка книги");
            node.Nodes.Add("Выдача");
            node.Nodes.Add("Отдел");
            node.Nodes.Add("Абонент");
            node.Nodes.Add("Библиотекарь");
            bdTableTree.Nodes.Add(node);
        }
        /// <summary>
        /// Метод начала работы с базой данных
        /// </summary>
        void StartWork() {
            TreeBD();
            UserConnection user = new UserConnection("UserPig", "masterkey");
            bdMethods = new BdMethods(user.OpenConnection());
            try{
                bdMethods.Connection.Open();
                SelectFromDB("Экземпляр книги");
            }
            catch { MessageBox.Show("Не удалось подключиться к базе данных.\n Неверно указаны данные."); }
        }
        /// <summary>
        /// Метод вывода базы данных
        /// </summary>
        /// <param name="s"> Переменная хранящая название таблицы, выбранной из древа </param>
        void SelectFromDB(string s) {
            string selectedtable = BdMethods.SelectTable(s);
            try{
                NpgsqlCommand command = new NpgsqlCommand(selectedtable, bdMethods.Connection);
                NpgsqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;
            }
            catch { MessageBox.Show("Неверно указано название таблицы."); }
        }
        /// <summary>
        /// Метод выбора навзвания таблицы для последующего вывода 
        /// </summary>
        private void bdTableTree_BeforeSelect(object sender, TreeViewCancelEventArgs e) {
            string s = e.Node.Text;
            if(s != "Таблицы данных: ") SelectFromDB(s);
        }
        //Добавить для оставшихся полей
        #region Label help
        private void OnMouseEnter(object sender, EventArgs e) {
            Label label = (Label)sender;
            label.Font = new Font(label.Font, FontStyle.Underline);
        }
        private void OnMouseLeave(object sender, EventArgs e) {
            Label label = (Label)sender;
            label.Font = new Font(label.Font, FontStyle.Regular);
        }
        private void OnMouseHover(object sender, EventArgs e){
            Label label = (Label)sender;
            string message = LabelHelp(label.Text);
            toolTip1.Show(message, label);
        }
        string LabelHelp(string s){
            string temp = "";
            switch (s)
            {
                case "Название книги":
                    temp = "В данное текстовое поле необходимо указывать название книги.";
                    break;
                case "Автор книги":
                    temp = "В данное текстовое поле необходимо указывать автора/ов книги.";
                    break;
                case "Издание книги":
                    temp = "В данное текстовое поле необходимо указывать издание книги (Название издательства, год издания).";
                    break;
                case "Объем":
                    temp = "В данное числовое поле необходимо указывать объем книги (Кол-во страниц).";
                    break;
                case "Кол-во книг":
                    temp = "В данное числовое поле необходимо указывать кол-во книг необходимое для добавления, изменения или удаления";
                    break;
            }
            return temp;
        }
        #endregion  
    }
}
