using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    /// <summary>
    /// Класс обработки запросов к базе данных
    /// </summary>
    public class DataBase_ProcessingRequest
    {
        string ConnectionToDB { get; } //Строка подключения к базе данных
        public NpgsqlConnection Connection { get; } //Переменная для подключение к базе данных
        public string Table { get; set; } //Переменная хранящая название таблицы выбранной в древе
        /// <summary>
        /// Конструктор класса работы с базой данных
        /// </summary>
        /// <param name="conn"> Переменная хранящая строку подключения к базе данных </param>
        public DataBase_ProcessingRequest(string conn) 
        {
            this.ConnectionToDB = conn;
            Connection = new NpgsqlConnection(conn);
        }
        #region Select functions
        /// <summary>
        /// Функция для получения выбранной в древе таблицы
        /// </summary>
        /// <param name="s"> Переменная хранящая название выбранной таблицы </param>
        /// <returns> Запрос для вывода выбранной таблицы</returns>
        static string SelectTable(string s) 
        {
            string temp = "";
            switch (s) 
            {
                case "Экземпляр книги":
                    temp = "select book_name as \"Название книги\", book_sub as \"Читатель\" from book, card" +
                        " where card_id = card.id order by book.id";
                    break;
                case "Каталожная карточка книги":
                    temp = "select book_name as \"Название\", book_author as \"Автор\", book_edit as \"Издание\", book_vol as \"Объем\", department.dep_name as \"Отдел\" from card, department " +
                        "where department.id = card.dep_id order by card.id";
                    break;
                case "Выдача":
                    temp = "select book_issue.book_id as \"Номер книги\", card.book_name as \"Название книги\", (sub_lastname || ' ' || sub_name || ' ' || sub_midname) as \"Абонент\", (lib_lastname || ' ' || lib_name || ' ' || lib_midname) as \"Библиотекарь\", is_date as \"Дата выдачи\", is_rdate as \"Дата возврата\" FROM book_issue " +
                        "inner join subscriber on book_issue.sub_id = subscriber.id " +
                        "inner join librarian on book_issue.lib_id = librarian.id " +
                        "inner join book on book_issue.book_id = book.id inner join card on card.id = book.card_id WHERE book.id = book_issue.book_id " +
                        "order by book_issue.id";
                    break;
                case "Отдел":
                    temp = "select id as \"Номер отдела\", dep_name as \"Название отдела\" from department order by department.id";
                    break;
                case "Абонент":
                    temp = "select sub_lastname as \"Фамилия\", sub_name as \"Имя\", sub_midname as \"Отчество\" from subscriber order by sub_lastname";
                    break;
                case "Библиотекарь":
                    temp = "select lib_lastname as \"Фамилия\", lib_name as \"Имя\", lib_midname as \"Отчество\" from librarian order by lib_lastname";
                    break;
            }
            return temp;
        }
        /// <summary>
        /// Метод вывода выбранной таблицы из базы данных
        /// </summary>
        /// <param name="s"> Переменная хранящая выбранную таблицу из древа </param>
        /// <param name="connection"> Переменная подключения к базе данных </param>
        /// <returns></returns>
        public static DataTable Select(string table, NpgsqlConnection connection) 
        {
            DataTable dt = new DataTable();
            string selectedtable = SelectTable(table);
            try 
            {
                NpgsqlCommand command = new NpgsqlCommand(selectedtable, connection);
                NpgsqlDataReader reader = command.ExecuteReader();
                dt.Load(reader);
            }
            catch { MessageBox.Show("Неверно указано название таблицы."); }
            return dt;
        }
        /// <summary>
        /// Метод вывода списка всех отделов в базе данных
        /// </summary>
        /// <param name="connection"> Переменная хранящая подключение к базе данных </param>
        /// <returns> Возвращаемое значение это таблица, полученная в результате работы запроса </returns>
        public static DataTable SelectAllDeps(NpgsqlConnection connection)
        {
            DataTable dt = new DataTable();
            string commandText = "select dep_name from department order by id";
            try
            {
                NpgsqlCommand command = new NpgsqlCommand(commandText, connection);
                NpgsqlDataReader reader = command.ExecuteReader();
                dt.Load(reader);
            }
            catch { }
            return dt;
        }
        /// <summary>
        /// Функция для вывода изображения книги по id 
        /// </summary>
        /// <param name="id"> Переменная хранящая </param>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static DataTable SelectImage(int id, NpgsqlConnection connection)
        {
            DataTable dt = new DataTable();
            string commandText = $"select book_img from card where card.id = {id}";
            try
            {
                NpgsqlCommand command = new NpgsqlCommand(commandText, connection);
                NpgsqlDataReader reader = command.ExecuteReader();
                dt.Load(reader);
            }
            catch { }
            return dt;
        }
        /// <summary>
        /// Функция для получения всех читателей
        /// </summary>
        /// <param name="connection"> Переменная хранящая подключение к базе данных </param>
        /// <returns> Возвращаемое значение это таблица, полученная в результате работы запроса </returns>
        public static DataTable SelectAllSubscribers(NpgsqlConnection connection)
        {
            DataTable dt = new DataTable();
            string commandText = "select (sub_lastname || ' ' || sub_name || ' ' || sub_midname) from subscriber order by id";
            try
            {
                NpgsqlCommand command = new NpgsqlCommand(commandText, connection);
                NpgsqlDataReader reader = command.ExecuteReader();
                dt.Load(reader);
            }
            catch { }
            return dt;
        }
        /// <summary>
        /// Функция для получения всех библиотекарей
        /// </summary>
        /// <param name="connection"> Переменная хранящая подключение к базе данных </param>
        /// <returns> Возвращаемое значение это таблица, полученная в результате работы запроса </returns>
        public static DataTable SelectAllLibrarians(NpgsqlConnection connection)
        {
            DataTable dt = new DataTable();
            string commandText = "select (lib_lastname || ' ' || lib_name || ' ' || lib_midname) from librarian order by id";
            try
            {
                NpgsqlCommand command = new NpgsqlCommand(commandText, connection);
                NpgsqlDataReader reader = command.ExecuteReader();
                dt.Load(reader);
            }
            catch { }
            return dt;
        }
        /// <summary>
        /// Метод получения списка названия всех книг
        /// </summary>
        /// <param name="connection"> Переменная хранящая подключение к базе данных </param>
        /// <returns> Возвращаемое значение это таблица, полученная в результате работы запроса </returns>
        public static DataTable SelectAllBooks(NpgsqlConnection connection)
        {
            DataTable dt = new DataTable();
            string commandText = "select book_name from card order by id";
            try
            {
                NpgsqlCommand command = new NpgsqlCommand(commandText, connection);
                NpgsqlDataReader reader = command.ExecuteReader();
                dt.Load(reader);
            }
            catch { }
            return dt;
        }
        /// <summary>
        /// Метод вывода всех логов базы данных
        /// </summary>
        /// <param name="connection"> Переменная хранящая подключение к базе данных </param>
        /// <returns> Возвращаемое значение это таблица, полученная в результате работы запроса </returns>
        public static DataTable SelectLogs(NpgsqlConnection connection)
        {
            DataTable dt = new DataTable();
            string commandText = "select * from audit";
            try
            {
                NpgsqlCommand command = new NpgsqlCommand(commandText, connection);
                NpgsqlDataReader reader = command.ExecuteReader();
                dt.Load(reader);
            }
            catch { }
            return dt;
        }
        #endregion
        #region Delete functions
        /// <summary>
        /// Функция удаления данных из выбранной таблицы
        /// </summary>
        /// <param name="id"> Переменная хранящая идентификатор удаляемой записи </param>
        /// <param name="tableinfo"> Массив хранящий информацию о таблице. Название и название столбца id </param>
        /// <param name="connection"> Переменная подключения к базе данных </param>
        public static void Delete(int id, string tableinfo, NpgsqlConnection connection) 
        {
            bool flag = false;
            string commandText = "";
            switch (tableinfo)
            {
                case "Экземпляр книги":
                    commandText = $"delete from book where id = {id}";
                    MessageBox.Show($"Внимание будет списана книга, которая может находиться в выдаче! \nНомер книги {id}", "Предупреждение", MessageBoxButtons.OK);
                    break;
                case "Каталожная карточка книги":
                    commandText = $"delete from card where id = {id}";
                    break;
                case "Выдача":
                    commandText = $"delete from book_issue where id = {id}";
                    break;
                case "Отдел":
                    commandText = $"delete from department where id = {id}";
                    break;
                case "Абонент":
                    commandText = $"delete from subscriber where id = {id}";
                    break;
                case "Библиотекарь":
                    commandText = $"delete from librarian where id = {id}";
                    break;
            }
            try
            {
                NpgsqlCommand command = new NpgsqlCommand(commandText, connection);
                command.ExecuteNonQuery();
            }
            catch { }
        }
        #endregion
        #region Insert functions
        /// <summary>
        /// Функция добавления во все таблицы, кроме экземпляра книги и выдачи
        /// </summary>
        /// <param name="commandText"> Переменная хранящая команду для добавления </param>
        /// <param name="connection"> Переменная подключения к базе данных </param>
        public static void Insert(string table, string[] data, NpgsqlConnection connection)
        {
            string commandText = "";
            string[] textboxes = data[0].Split(';');
            string[] numerics = data[1].Split(';');
            string[] comboboxes = data[2].Split(';');
            string[] datepickers = data[3].Split(';');
            string book = comboboxes[0] + ";" + numerics[1];
            if (table == "Экземпляр книги") Insert_book(book, connection);
            else if (table == "Выдача")
            {
                int bookid = GetBookId(Int32.Parse(comboboxes[0]), connection);
                int subid = Int32.Parse(comboboxes[1]);
                int libid = Int32.Parse(comboboxes[2]);
                commandText = $"insert into book_issue (book_id, sub_id, lib_id, is_date, is_rdate) values ({bookid}, {subid}, {libid}, @date1, @date2)";
                Insert_issue(datepickers, commandText, connection);
            }
            else
            {
                int combobox = Int32.Parse(comboboxes[3]);
                switch (table)
                {
                    case "Каталожная карточка книги":
                        commandText = $"insert into card (book_name, book_edit, book_author, book_vol, dep_id) values ('{textboxes[0]}', '{textboxes[1]}', '{textboxes[2]}', '{Int32.Parse(numerics[0])}', '{combobox}')";
                        break;
                    case "Отдел":
                        commandText = $"insert into department (dep_name) values ('{textboxes[0]}')";
                        break;
                    case "Абонент":
                        commandText = $"insert into subscriber (sub_lastname, sub_name, sub_midname) values ('{textboxes[0]}', '{textboxes[1]}', '{textboxes[2]}')";
                        break;
                    case "Библиотекарь":
                        commandText = $"insert into librarian (lib_lastname, lib_name, lib_midname) values ('{textboxes[0]}', '{textboxes[1]}', '{textboxes[2]}')";
                        break;
                }
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand(commandText, connection);
                    command.ExecuteNonQuery();
                }
                catch { MessageBox.Show($"Не удалось добавить данные в таблицу {table}.\n Введены не корректные данные."); }
            }
        }
        /// <summary>
        /// Метод ввода данных в таблицу выдача
        /// </summary>
        /// <param name="dates"> Массив дат для заполнения соответствующих полей таблицы </param>
        /// <param name="commandText"> Переменная хранящая комманду для ввода новых данных в таблицу </param>
        /// <param name="connection"> Переменная хранящая подключение к базе данных </param>
        static void Insert_issue(string[] dates, string commandText, NpgsqlConnection connection)
        {
            try
            {
                NpgsqlCommand command = new NpgsqlCommand(commandText, connection);
                NpgsqlParameter p1 = new NpgsqlParameter("@date1", DbType.Date);
                NpgsqlParameter p2 = new NpgsqlParameter("@date2", DbType.Date);
                p1.Value = Convert.ToDateTime(dates[0]);
                p2.Value = Convert.ToDateTime(dates[1]);
                command.Parameters.Add(p1);
                command.Parameters.Add(p2);
                command.ExecuteNonQuery();
            }
            catch { }
        }
        /// <summary>
        /// Функция добавления данных в таблицу экземпляр книги
        /// </summary>
        /// <param name="dataForTable"> Переменная хранящая название каталожной карточки и кол-во книг </param>
        /// <param name="connection"> Переменная подключения к базе данных </param>
        static void Insert_book(string dataForTable, NpgsqlConnection connection)
        {
            string[] data = dataForTable.Split(';');
            string commandText = "";
            int rowsCount = 0;
            if(Int32.Parse(data[1]) > 0)
            {
                rowsCount = Int32.Parse(data[1]);
                try
                {
                    int cardId = Int32.Parse(data[0]);
                    commandText = $"insert into book (card_id, book_sub) values ('{cardId}','{false}')";
                    for (int i = 0; i < rowsCount; i++)
                    {
                        NpgsqlCommand command = new NpgsqlCommand(commandText, connection);
                        command.ExecuteNonQuery();
                    }
                }
                catch { } //MessageBox.Show($"Не возможно добавить значения в таблицы из-за указаных вами данных.");
            }
            else MessageBox.Show("Внимание!\nНевозможно добавить книги, если указанное кол-во равно или меньше 0.");
        }
        #endregion
        #region Update functions
        /// <summary>
        /// Функция добавления или изменения изображения в таблице каталожной карточки
        /// </summary>
        /// <param name="id"> Переменная хранящая id выбранной записи </param>
        /// <param name="img"> Массив byte хранящий в себе изображение, выбранное пользователем </param>
        /// <param name="connection"> Переменная хранящая подключение к базе данных </param>
        public static void UpdateImg(int id, byte[] img, NpgsqlConnection connection)
        {
            try
            {
                string commandText = $"update card set book_img = @photo  where card.id = '{id}'";
                NpgsqlCommand command = new NpgsqlCommand(commandText, connection);
                NpgsqlParameter parameter = new NpgsqlParameter("@photo", DbType.Binary);
                parameter.Value = img;
                command.Parameters.Add(parameter);
                command.ExecuteNonQuery();
            }
            catch { }
        }
        /// <summary>
        /// Функция обновления выбранной записи
        /// </summary>
        /// <param name="table"> Переменная хранящая название выбранной таблицы </param>
        /// <param name="id"> Переменная хранящая id выбранной записи</param>
        /// <param name="data"> Массив хранящий данные для обновления записи</param>
        /// <param name="connection"> Переменная хранящая подключение к базе данных </param>
        public static void Update(string table, int id, string[] data, NpgsqlConnection connection)
        {
            string commandText = "";
            string[] textboxes = data[0].Split(';');
            string[] numerics = data[1].Split(';');
            int comboboxes = Int32.Parse(data[2]);
            switch (table)
            {
                case "Каталожная карточка книги":
                    commandText = $"update card set book_name = '{textboxes[0]}', book_edit = '{textboxes[1]}', book_author = '{textboxes[2]}', book_vol = '{Int32.Parse(numerics[0])}', dep_id = '{comboboxes}' where card.id = '{id}'";
                    break;
                case "Отдел":
                    commandText = $"update department set dep_name '{textboxes[0]}' where department.id = '{id}'";
                    break;
                case "Абонент":
                    commandText = $"update subscriber set sub_lastname = '{textboxes[0]}', sub_name = '{textboxes[1]}', sub_midname = '{textboxes[2]}' where subscriber.id = '{id}'";
                    break;
                case "Библиотекарь":
                    commandText = $"update librarian set lib_lastname = '{textboxes[0]}', lib_name = '{textboxes[1]}', lib_midname = '{textboxes[2]}' where librarian.id = '{id}'";
                    break;
            }
            try
            {
                NpgsqlCommand command = new NpgsqlCommand(commandText, connection);
                command.ExecuteNonQuery();
            }
            catch { MessageBox.Show($"Не удалось добавить данные в таблицу {table}.\n Введены не корректные данные."); }
        }
        #endregion
        #region Additional functions
        /// <summary>
        /// Метод для получения id выбранного отдела
        /// </summary>
        /// <param name="name"> Переменная хранящая название отдела </param>
        /// <param name="connection"> Переменная хранящая подключение к базе данных </param>
        /// <returns> Возвращает полученное id в ходе выполнения запроса </returns>
        public static int GetDepId(string name, NpgsqlConnection connection)
        {
            int depId = 0;
            DataTable dt = new DataTable();
            string commandText = $"select id from department where department.dep_name = '{name}'";
            try
            {
                NpgsqlCommand getDepId = new NpgsqlCommand(commandText, connection);
                NpgsqlDataReader reader = getDepId.ExecuteReader();
                dt.Load(reader);
            }
            catch { }
            depId = (int)dt.Rows[0][0];
            return depId;
        }
        /// <summary>
        /// Метод для получения id книги выбранной каталожной карточки
        /// </summary>
        /// <param name="cardId"> Переменная хранящая id каталожной карточки </param>
        /// <param name="connection"> Переменная хранящая подключение к базе данных </param>
        /// <returns> Возвращает полученное id в ходе выполнения запроса </returns>
        static int GetBookId(int cardId, NpgsqlConnection connection)
        {
            int depId = 0;
            DataTable dt = new DataTable();
            string commandText = $"select id from book where card_id = '{cardId}' and book_sub = 'false' limit 1";
            try
            {
                NpgsqlCommand getDepId = new NpgsqlCommand(commandText, connection);
                NpgsqlDataReader reader = getDepId.ExecuteReader();
                dt.Load(reader);
            }
            catch { }
            depId = (int)dt.Rows[0][0];
            return depId;
        }
        /// <summary>
        /// Метод формирубщий формуляр выбранной книги
        /// </summary>
        /// <param name="bookId"> Переменная хранящая id выбранной книги </param>
        /// <param name="connection"> Переменная хранящая подключение к базе данных </param>
        /// <returns> Возвращаемое значение это таблица, полученная в результате работы запроса </returns>
        public static DataTable BookFormTable(int bookId, NpgsqlConnection connection)
        {
            DataTable dt = new DataTable();
            string commandText = $"select (sub_lastname || ' ' || sub_name || ' ' || sub_midname) as \"Читатель\", (lib_lastname || ' ' || lib_name || ' ' || lib_midname) as \"Библиотекарь\", is_date as \"Дата выдачи\", is_rdate as \"Дата возврата\" FROM book_issue " +
                $"left join librarian on book_issue.lib_id = librarian.id " +
                $"left join subscriber on book_issue.sub_id = subscriber.id " +
                $"where book_issue.book_id = {bookId} " +
                $"order by book_issue.id";
            try
            {
                NpgsqlCommand getDepId = new NpgsqlCommand(commandText, connection);
                NpgsqlDataReader reader = getDepId.ExecuteReader();
                dt.Load(reader);
            }
            catch { }
            return dt;
        }
        /// <summary>
        /// Метод формурующий формуляр выбранного читателя
        /// </summary>
        /// <param name="subId"> Переменная хранящая id выбранного читателя </param>
        /// <param name="connection"> Переменная хранящая подключение к базе данных </param>
        /// <returns> Возвращаемое значение это таблица, полученная в результате работы запроса </returns>
        public static DataTable SubFormTable(int subId, NpgsqlConnection connection)
        {
            DataTable dt = new DataTable();
            string commandText = $"select book_issue.book_id as \"Номер книги\", card.book_name as \"Название\", (lib_lastname || ' ' || lib_name || ' ' || lib_midname) as \"Библиотекарь\", is_date as \"Дата выдачи\", is_rdate as \"Дата возврата\" FROM book_issue " +
                $"left join librarian on book_issue.lib_id = librarian.id " +
                $"left join book on book_issue.book_id = book.id " +
                $"left join card on card.id = book.card_id WHERE book.id = book_issue.book_id " +
                $"and book_issue.sub_id = {subId} " +
                $"order by book_issue.id";
            try
            {
                NpgsqlCommand getDepId = new NpgsqlCommand(commandText, connection);
                NpgsqlDataReader reader = getDepId.ExecuteReader();
                dt.Load(reader);
            }
            catch {  }
            return dt;
        }
        #endregion
    }
}