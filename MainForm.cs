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
            catch { MessageBox.Show("Не удалось подключиться к базе данных.\n Неверно указаны данные."); }
            bdTableTree.ExpandAll();
        }
        //Добавить для оставшихся полей
        #region UI Help information
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
        #region Label Helpers
        //Подчеркивание Label при наведении
        private void OnMouseEnter(object sender, EventArgs e) 
        {
            Label label = (Label)sender;
            label.Font = new Font(label.Font, FontStyle.Underline);
        }
        //Убрать подчеркивание Label после наведения
        private void OnMouseLeave(object sender, EventArgs e) 
        {
            Label label = (Label)sender;
            label.Font = new Font(label.Font, FontStyle.Regular);
        }
        //Вывод подсказки при наведении
        private void OnMouseHover(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            string message = LabelHelp(label.Text);
            toolTip1.Show(message, label);
        }
        //Выбор подсказки
        string LabelHelp(string s){
            string temp = "";
            switch (s)
            {
                case "Название книги":
                    temp = "В данное текстовое поле необходимо указывать название книги.";
                    break;
                case "Автор/Авторы":
                    temp = "В данное текстовое поле необходимо указывать автора/ов книги.";
                    break;
                case "Издание":
                    temp = "В данное текстовое поле необходимо указывать издание книги (Название издательства, год издания).";
                    break;
                case "Объем":
                    temp = "В данное числовое поле необходимо указывать объем книги (Кол-во страниц).";
                    break;
                case "Кол-во книг":
                    temp = "В данное числовое поле необходимо указывать кол-во книг необходимое для добавления, изменения или удаления";
                    break;
                case "Отдел":
                    temp = "В данное поле необходимо выбрать отдел, в котором будут хранится книги связанные с этой карточкой";
                    break;
            }
            return temp;
        }
        #endregion
        //Добавить поля для отдела
        /// <summary>
        /// Метод отображения полей для заполнения таблиц
        /// </summary>
        /// <param name="table"> Переменная хранящая значение выбранной таблицы </param>
        void InsFields(string table)
        {
            switch (table)
            {
                case "Экземпляр книги":
                    //visible
                    lbIns1.Text = "Название книги"; lbIns1.Visible = true;
                    tBIns1.Visible = true;
                    lbIns2.Text = "Издание"; lbIns2.Visible = true;
                    tBIns2.Visible = true;
                    lbIns3.Text = "Автор/Авторы"; lbIns3.Visible = true;
                    tBIns3.Visible = true;
                    lbIns4.Text = "Объем"; lbIns4.Visible = true;
                    nUDIns1.Visible = true;
                    lbIns5.Text = "Отдел"; lbIns5.Visible = true;
                    cBIns1.Visible = true;
                    lbIns6.Text = "Кол-во книг"; lbIns6.Visible = true;
                    nUDIns2.Visible = true;
                    //non visible
                    dtPIns1.Visible = false;
                    dtPIns2.Visible = false;
                    break;
                case "Каталожная карточка книги":
                    //visible
                    lbIns1.Text = "Название книги"; lbIns1.Visible = true;
                    tBIns1.Visible = true;
                    lbIns2.Text = "Издание"; lbIns2.Visible = true;
                    tBIns2.Visible = true;
                    lbIns3.Text = "Автор/Авторы"; lbIns3.Visible = true;
                    tBIns3.Visible = true;
                    lbIns4.Text = "Объем"; lbIns4.Visible = true;
                    nUDIns1.Visible = true;
                    lbIns5.Text = "Отдел"; lbIns5.Visible = true;
                    cBIns1.Visible = true;
                    lbIns6.Text = "Кол-во книг"; lbIns6.Visible = true;
                    nUDIns2.Visible = true;
                    //non visible
                    dtPIns1.Visible = false;
                    dtPIns2.Visible = false;
                    break;
                case "Выдача":
                    //visible
                    lbIns1.Text = "Название книги"; lbIns1.Visible = true;
                    tBIns1.Visible = true;
                    lbIns2.Text = "Абонент"; lbIns2.Visible = true;
                    tBIns2.Visible = true;
                    lbIns3.Text = "Библиотекарь"; lbIns3.Visible = true;
                    tBIns3.Visible = true;
                    lbIns4.Text = "Дата выдачи"; lbIns4.Visible = true;
                    dtPIns1.Visible = true;
                    lbIns6.Text = "Дата возврата"; lbIns6.Visible = true;
                    dtPIns2.Visible = true;
                    //non visible
                    lbIns5.Visible = false;
                    cBIns1.Visible = false;
                    nUDIns1.Visible = false;
                    nUDIns2.Visible = false;
                    break;
                case "Отдел":
                    //visible
                    //non visible
                    break;
                case "Абонент":
                    //visible
                    lbIns1.Text = "Фамилия"; lbIns1.Visible = true;
                    tBIns1.Visible = true;
                    lbIns2.Text = "Имя"; lbIns2.Visible = true;
                    tBIns2.Visible = true;
                    lbIns3.Text = "Отчество"; lbIns3.Visible = true;
                    tBIns3.Visible = true;
                    //non visible
                    lbIns4.Visible = false;
                    nUDIns1.Visible = false;
                    lbIns5.Visible = false;
                    cBIns1.Visible = false;
                    dtPIns1.Visible = false;
                    lbIns6.Visible = false;
                    nUDIns2.Visible = false;
                    cBIns1.Visible = false;
                    dtPIns2.Visible = false;
                    break;
                case "Библиотекарь":
                    //visible
                    lbIns1.Text = "Фамилия"; lbIns1.Visible = true;
                    tBIns1.Visible = true;
                    lbIns2.Text = "Имя"; lbIns2.Visible = true;
                    tBIns2.Visible = true;
                    lbIns3.Text = "Отчество"; lbIns3.Visible = true;
                    tBIns3.Visible = true;
                    //non visible
                    lbIns4.Visible = false;
                    nUDIns1.Visible = false;
                    lbIns5.Visible = false;
                    cBIns1.Visible = false;
                    dtPIns1.Visible = false;
                    lbIns6.Visible = false;
                    nUDIns2.Visible = false;
                    cBIns1.Visible = false;
                    dtPIns2.Visible = false;
                    break;
            }
        }
        /// <summary>
        /// Метод отображения полей для обновления таблиц
        /// </summary>
        /// <param name="table"> Переменная хранящая значение выбранной таблицы </param>
        void UpFields(string table)
        {
            switch (table)
            {
                case "Экземпляр книги":
                    //visible
                    lbUp1.Text = "Название книги"; lbUp1.Visible = true;
                    tBUp1.Visible = true;
                    lbUp2.Text = "Издание"; lbUp2.Visible = true;
                    tBUp2.Visible = true;
                    lbUp3.Text = "Автор/Авторы"; lbUp3.Visible = true;
                    tBUp3.Visible = true;
                    lbUp4.Text = "Объем"; lbUp4.Visible = true;
                    nUDUp1.Visible = true;
                    lbUp5.Text = "Отдел"; lbUp5.Visible = true;
                    cBUp1.Visible = true;
                    lbUp6.Text = "Кол-во книг"; lbUp6.Visible = true;
                    nUDUp2.Visible = true;
                    //non visible
                    dtPUp1.Visible = false;
                    dtPUp2.Visible = false;
                    break;
                case "Каталожная карточка книги":
                    //visible
                    lbUp1.Text = "Название книги"; lbUp1.Visible = true;
                    tBUp1.Visible = true;
                    lbUp2.Text = "Издание"; lbUp2.Visible = true;
                    tBUp2.Visible = true;
                    lbUp3.Text = "Автор/Авторы"; lbUp3.Visible = true;
                    tBUp3.Visible = true;
                    lbUp4.Text = "Объем"; lbUp4.Visible = true;
                    nUDUp1.Visible = true;
                    lbUp5.Text = "Отдел"; lbUp5.Visible = true;
                    cBUp1.Visible = true;
                    lbUp6.Text = "Кол-во книг"; lbUp6.Visible = true;
                    nUDUp2.Visible = true;
                    //non visible
                    dtPUp1.Visible = false;
                    dtPUp2.Visible = false;
                    break;
                case "Выдача":
                    //visible
                    lbUp1.Text = "Название книги"; lbUp1.Visible = true;
                    tBUp1.Visible = true;
                    lbUp2.Text = "Абонент"; lbUp2.Visible = true;
                    tBUp2.Visible = true;
                    lbUp3.Text = "Библиотекарь"; lbUp3.Visible = true;
                    tBUp3.Visible = true;
                    lbUp4.Text = "Дата выдачи"; lbUp4.Visible = true;
                    dtPUp1.Visible = true;
                    lbUp6.Text = "Дата возврата"; lbUp6.Visible = true;
                    dtPUp2.Visible = true;
                    //non visible
                    lbUp5.Visible = false;
                    cBUp1.Visible = false;
                    nUDUp1.Visible = false;
                    nUDUp2.Visible = false;
                    break;
                case "Отдел":
                    //visible
                    //non visible
                    break;
                case "Абонент":
                    //visible
                    lbUp1.Text = "Фамилия"; lbUp1.Visible = true;
                    tBUp1.Visible = true;
                    lbUp2.Text = "Имя"; lbUp2.Visible = true;
                    tBUp2.Visible = true;
                    lbUp3.Text = "Отчество"; lbUp3.Visible = true;
                    tBUp3.Visible = true;
                    //non visible
                    lbUp4.Visible = false;
                    nUDUp1.Visible = false;
                    lbUp5.Visible = false;
                    cBUp1.Visible = false;
                    dtPUp1.Visible = false;
                    lbUp6.Visible = false;
                    nUDUp2.Visible = false;
                    cBUp1.Visible = false;
                    dtPUp2.Visible = false;
                    break;
                case "Библиотекарь":
                    //visible
                    lbUp1.Text = "Фамилия"; lbUp1.Visible = true;
                    tBUp1.Visible = true;
                    lbUp2.Text = "Имя"; lbUp2.Visible = true;
                    tBUp2.Visible = true;
                    lbUp3.Text = "Отчество"; lbUp3.Visible = true;
                    tBUp3.Visible = true;
                    //non visible
                    lbUp4.Visible = false;
                    nUDUp1.Visible = false;
                    lbUp5.Visible = false;
                    cBUp1.Visible = false;
                    dtPUp1.Visible = false;
                    lbUp6.Visible = false;
                    nUDUp2.Visible = false;
                    cBUp1.Visible = false;
                    dtPUp2.Visible = false;
                    break;
            }
        }
        #endregion
        //Добавить картинки и их вывод
        private void DataBaseDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = e.RowIndex;
        }
        //Добавить оставшиеся методы
        #region Select
        /// <summary>
        /// Метод вывода базы данных
        /// </summary>
        /// <param name="s"> Переменная хранящая название таблицы, выбранной из древа </param>
        void SelectFromDB(string s)
        {
            DataBaseDGV.DataSource = WorkingWithDB.Select(s, dataBase.Connection);
            InsFields(s);
        }
        /// <summary>
        /// Метод выбора навзвания таблицы для последующего вывода 
        /// </summary>
        private void bdTableTree_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            dataBase.Table = e.Node.Text;
            if (dataBase.Table != "Таблицы данных: ") SelectFromDB(dataBase.Table);
        }
        #endregion
        #region Delete
        /// <summary>
        /// Обработчик кнопки для удаления данных из таблицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(DataBaseDGV.CurrentRow != null)
            {
                int id = DataBaseDGV.CurrentRow.Index;
                WorkingWithDB.Delete(id, dataBase.Table, dataBase.Connection);
                SelectFromDB(dataBase.Table);
            }
        }
        #endregion
        private void btnInsert_Click(object sender, EventArgs e)
        {
            string data = "";
            switch (dataBase.Table) 
            {
                case "Экземпляр книги":
                    //data = 
                    break;
                case "Каталожная карточка книги":
                    data = $"{tBIns1.Text};{tBIns2.Text};{tBIns3.Text};{nUDIns1.Value};{cBIns1.SelectedIndex.ToString()}";
                    break;
                case "Выдача":
                    break;
                case "Отдел":
                    break;
                case "Абонент":
                    data = $"{tBIns1.Text};{tBIns2.Text};{tBIns3.Text}";
                    break;
                case "Библиотекарь":
                    data = $"{tBIns1.Text};{tBIns2.Text};{tBIns3.Text}";
                    break;
            }
            WorkingWithDB.Insert(dataBase.Table, data, dataBase.Connection);
            SelectFromDB(dataBase.Table);
        }
    }
}
