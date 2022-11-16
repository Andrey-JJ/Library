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
    public partial class MainForm : Form
    {
        public MainForm() 
        {
            InitializeComponent();
            StartWork();
        }
        WorkingWithDB dataBase; //Элемент класса для работы с базой данных
        /// <summary>
        /// Метод начала работы с базой данных
        /// </summary>
        void StartWork() 
        {
            TreeBD();
            UserConnection user = new UserConnection("UserPig", "masterkey");
            dataBase = new WorkingWithDB(user.OpenConnection());
            try
            {
                dataBase.Connection.Open();
                SelectFromDB("Экземпляр книги");
            }
            //MessageBox.Show("Не удалось подключиться к базе данных.\n Неверно указаны данные.");
            catch { }
        }
        /// <summary>
        /// Метод заполнения древа
        /// </summary>
        void TreeBD() 
        {
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
        
        //Добавить для оставшихся полей
        #region Helps
        private void OnMouseEnter(object sender, EventArgs e) 
        {
            Label label = (Label)sender;
            label.Font = new Font(label.Font, FontStyle.Underline);
        }
        private void OnMouseLeave(object sender, EventArgs e) 
        {
            Label label = (Label)sender;
            label.Font = new Font(label.Font, FontStyle.Regular);
        }
        private void OnMouseHover(object sender, EventArgs e)
        {
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
        //Добавить картинки и их вывод
        private void DataBaseDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = e.RowIndex;
        }

        //Добавить оставшиеся методы
        #region Select, Insert, Update, Delete
        /// <summary>
        /// Метод вывода базы данных
        /// </summary>
        /// <param name="s"> Переменная хранящая название таблицы, выбранной из древа </param>
        void SelectFromDB(string s) => DataBaseDGV.DataSource = WorkingWithDB.Select(s, dataBase.Connection);
        /// <summary>
        /// Метод выбора навзвания таблицы для последующего вывода 
        /// </summary>
        private void bdTableTree_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            dataBase.Table = e.Node.Text;
            if (dataBase.Table != "Таблицы данных: ") SelectFromDB(dataBase.Table);
        }
        /// <summary>
        /// Обработчик кнопки для удаления данных из таблицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(DataBaseDGV.CurrentRow != null)
            {
                string[] s = new string[2]; //s[0] - название таблицы s[1] - название столбца id в таблице
                switch (dataBase.Table) {
                    case "Экземпляр книги":
                        s[0] = "book";
                        s[1] = "book_id";
                        break;
                    case "Каталожная карточка книги":
                        s[0] = "book_card";
                        s[1] = "bcard_id";
                        break;
                    case "Выдача":
                        s[0] = "issue";
                        s[1] = "is_id";
                        break;
                    case "Отдел":
                        s[0] = "department";
                        s[1] = "dep_id";
                        break;
                    case "Абонент":
                        s[0] = "subscriber";
                        s[1] = "sub_id";
                        break;
                    case "Библиотекарь":
                        s[0] = "librarian";
                        s[1] = "lib_id";
                        break;
                }
                int id = DataBaseDGV.CurrentRow.Index;
                WorkingWithDB.Delete(id, s, dataBase.Connection);
                SelectFromDB(s[0]);
            }
        }
        #endregion
    }
}
