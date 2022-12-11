using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Library
{
    public partial class MainForm : Form
    {
        #region Start Work
        public MainForm() 
        {
            InitializeComponent();
            AfterLoadForm();
        }
        ProcessingRequest dataBase; //Элемент класса для работы с базой данных
        /// <summary>
        /// Метод начала работы с базой данных
        /// </summary>
        void AfterLoadForm() 
        {
            GetTablesForTree();
            UserConnection user = new UserConnection("UserPig", "masterkey");
            dataBase = new ProcessingRequest(user.OpenConnection());
            try
            {
                dataBase.Connection.Open();
                dataBase.Table = "Экземпляр книги";
                SelectFromDB(dataBase.Table);
            }
            catch { MessageBox.Show("Не удалось подключиться к базе данных.\n Неверно указаны данные."); }
            bdTableTree.ExpandAll();
        }
        /// <summary>
        /// Метод вывода списка всех отделов библиотеки
        /// </summary>
        /// <param name="connection"> Переменная хранящая подключение к базе данных </param>
        void GetAllDepartmens(NpgsqlConnection connection)
        {
            cBIns1.Items.Clear();
            cBUp1.Items.Clear();
            DataTable dt = ProcessingRequest.SelectAllDeps(connection);
            if(dt.Rows.Count > 0)
            {
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    cBIns1.Items.Add(dt.Rows[i][0].ToString());
                    cBUp1.Items.Add(dt.Rows[i][0].ToString());
                }
            }
        }
        /// <summary>
        /// Метод заполнения древа
        /// </summary>
        void GetTablesForTree()
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
        #endregion
        //UI Закончено?
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
                case "Название отдела":
                    temp = "В данное текстовое поле необходимо указывать название отдела.";
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
                    temp = "В данное числовое поле необходимо указывать кол-во книг необходимое для добавления, изменения или удаления.";
                    break;
                case "Отдел":
                    temp = "В данное поле необходимо выбрать отдел, в котором будут хранится книги связанные с этой карточкой.";
                    break;
                case "Дата выдачи":
                    temp = "В данное поле необходимо указывать или выбрать дату выдачи выбранной книги.";
                    break;
                case "Дата возврата":
                    temp = "В данное поле необходимо указывать или выбрать дату возврата выбранной книги.";
                    break;
                case "Абонент":
                    temp = "В данное тексовое поле необходимо указывать ФИО читателя, берущего книгу";
                    break;
                case "Библиотекарь":
                    temp = "В данное тексовое поле необходимо указывать ФИО библиотекаря, выдающего книгу";
                    break;
                case "Фамилия":
                    temp = "В данное тексовое поле необходимо указывать фамилию человека";
                    break;
                case "Имя":
                    temp = "В данное тексовое поле необходимо указывать имя человека";
                    break;
                case "Отчество":
                    temp = "В данное тексовое поле необходимо указывать отчество человека";
                    break;
            }
            return temp;
        }
        #endregion
        #region Fields Helpers
        /// <summary>
        /// Метод отображения полей для заполнения таблиц
        /// </summary>
        /// <param name="table"> Переменная хранящая значение выбранной таблицы </param>
        void InsertPage(string table)
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
                    btnInsImg.Visible = false;
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
                    btnInsImg.Visible = true;
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
                    btnInsImg.Visible = false;
                    break;
                case "Отдел":
                    //visible
                    lbIns1.Text = "Название отдела"; lbIns1.Visible = true;
                    tBIns1.Visible = true;
                    //non visible
                    lbIns2.Visible = false;
                    tBIns2.Visible = false;
                    lbIns3.Visible = false;
                    tBIns3.Visible = false;
                    lbIns4.Visible = false;
                    dtPIns1.Visible = false;
                    nUDIns1.Visible = false;
                    lbIns5.Visible = false;
                    cBIns1.Visible = false;
                    nUDIns2.Visible = false;
                    dtPIns2.Visible = false;
                    lbIns6.Visible = false;
                    btnInsImg.Visible = false;
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
                    btnInsImg.Visible = false;
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
                    btnInsImg.Visible = false;
                    break;
            }
        }
        /// <summary>
        /// Метод отображения полей для обновления таблиц
        /// </summary>
        /// <param name="table"> Переменная хранящая значение выбранной таблицы </param>
        void UpdatePage(string table)
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
                    lbUp7.Visible = true;
                    chBUp1.Visible = true;
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
                    lbUp7.Visible = false;
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
                    lbUp7.Visible = false;
                    break;
                case "Отдел":
                    //visible
                    lbUp1.Text = "Название отдела"; lbUp1.Visible = true;
                    tBUp1.Visible = true;
                    //non visible
                    lbUp2.Visible = false;
                    tBUp2.Visible = false;
                    lbUp3.Visible = false;
                    tBUp3.Visible = false;
                    lbUp4.Visible = false;
                    dtPUp1.Visible = false;
                    nUDUp1.Visible = false;
                    lbUp5.Visible = false;
                    cBUp1.Visible = false;
                    lbUp6.Visible = false;
                    nUDUp2.Visible = false;
                    dtPUp2.Visible = false;
                    lbUp7.Visible = false;
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
                    lbUp7.Visible = false;
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
                    lbUp7.Visible = false;
                    break;
            }
        }
        #endregion
        //Добавить картинки и их вывод
        #region Image
        private void DataBaseDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = e.RowIndex;
            SelectImg(id);
        }
        #endregion
        //Добавить UPDATE, настроить и проверить Insert
        #region Select
        /// <summary>
        /// Метод вывода базы данных
        /// </summary>
        /// <param name="s"> Переменная хранящая название таблицы, выбранной из древа </param>
        void SelectFromDB(string table)
        {
            DataBaseDGV.DataSource = ProcessingRequest.Select(table, dataBase.Connection);
            InsertPage(table);
            UpdatePage(table);
            GetAllDepartmens(dataBase.Connection);
        }
        /// <summary>
        /// Метод выбора навзвания таблицы для последующего вывода 
        /// </summary>
        private void bdTableTree_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            dataBase.Table = e.Node.Text;
            if (dataBase.Table != "Таблицы данных: ") SelectFromDB(dataBase.Table);
        }
        /// <summary>
        /// Метод вывода изображения в picturebox
        /// </summary>
        /// <param name="id"> Переменная хранящая id выбранной строки</param>
        void SelectImg(int id)
        {
            DataTable dt = ProcessingRequest.SelectImage(id, dataBase.Connection);
            Image img = null;
            byte[] imageArray = (byte[])dt.Rows[0][0];
            if (imageArray != null)
            {
                var ms = new MemoryStream(imageArray);
                img = Image.FromStream(ms);
                ms.Close();
            }
            else img = Image.FromFile("NoImage.png");
            pictureBox1.Image = img;
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
                ProcessingRequest.Delete(id, dataBase.Table, dataBase.Connection);
                SelectFromDB(dataBase.Table);
            }
        }
        #endregion
        #region Insert
        /// <summary>
        /// Обработчик кнопки для добавления данных в таблице
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsert_Click(object sender, EventArgs e)
        {
            string[] data = new string[4];
            data[0] = $"{tBIns1.Text};{tBIns2.Text};{tBIns3.Text}";
            data[1] = $"{Int32.Parse(nUDIns1.Value.ToString())};{Int32.Parse(nUDIns2.Value.ToString())}";
            data[2] = $"{cBIns1.SelectedIndex}";
            data[3] = $"{dtPIns1.Value.Date};{dtPIns1.Value.Date}";
            ProcessingRequest.Insert(dataBase.Table, data, dataBase.Connection);
            SelectFromDB(dataBase.Table);
        }
        /// <summary>
        /// Обработчик кнопки добавления изображения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsImg_Click(object sender, EventArgs e)
        {
            if(dataBase.Table == "Каталожная карточка книги")
            {
                int id = DataBaseDGV.CurrentRow.Index;
                byte[] img = LoadPhotoToArray();
                ProcessingRequest.UpdateImg(id, img, dataBase.Connection);
            }
        }
        #endregion
        #region Update

        #endregion
        #region Dop methods
        /// <summary>
        /// Функция загрузки изображения в byte массив
        /// </summary>
        /// <returns> Возвращает массив байт полученный из изображения </returns>
        byte[] LoadPhotoToArray()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Filter = "All Embroidery Files | *.bmp; *.gif; *.jpeg; *.jpg; " +
             "*.fif;*.fiff;*.png;*.wmf;*.emf" +
             "|Windows Bitmap (*.bmp)|*.bmp" +
             "|JPEG File Interchange Format (*.jpg)|*.jpg;*.jpeg" +
             "|Graphics Interchange Format (*.gif)|*.gif" +
             "|Portable Network Graphics (*.png)|*.png" +
             "|Tag Embroidery File Format (*.tif)|*.tif;*.tiff";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(openFileDialog1.FileName);
                MemoryStream memoryStream = new MemoryStream();
                image.Save(memoryStream, ImageFormat.Jpeg);
                return memoryStream.ToArray();
            }
            else return null;
        }
        #endregion
    }
}
