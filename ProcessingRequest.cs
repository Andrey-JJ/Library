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
    internal class ProcessingRequest
    {
        string ConnectionToDB { get; } //Строка подключения к базе данных
        public NpgsqlConnection Connection { get; } //Переменная для подключение к базе данных
        public string Table { get; set; } //Переменная хранящая название таблицы выбранной в древе
        /// <summary>
        /// Конструктор класса работы с базой данных
        /// </summary>
        /// <param name="conn"> Переменная хранящая строку подключения к базе данных </param>
        public ProcessingRequest(string conn) 
        {
            this.ConnectionToDB = conn;
            Connection = new NpgsqlConnection(conn);
        }
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
                        " where card_id = card.id";
                    break;
                case "Каталожная карточка книги":
                    temp = "select book_name as \"Название\", book_author as \"Автор\", book_edit as \"Издание\", book_vol as \"Объем\", department.dep_name as \"Отдел\" from card, department " +
                        "where department.id = card.dep_id";
                    break;
                case "Выдача":
                    temp = "select book_name as \"Название\", (sub_lastname || ' ' || sub_name || ' ' || sub_midname) as \"Абонент\", (lib_lastname || ' ' || lib_name || ' ' || lib_midname) as \"Библиотекарь\", is_date as \"Дата выдачи\", is_rdate as \"Дата возврата\" FROM book_issue, subscriber, librarian, card " +
                        "where subscriber.id = book_issue.sub_id and librarian.id = book_issue.lib_id and book_issue.book_id = (SELECT book.id from book where book.card_id = card.id order by book.id asc limit 1)";
                    break;
                case "Отдел":
                    temp = "select id as \"Номер отдела\", dep_name as \"Название отдела\" from department";
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
        public static DataTable Select(string s, NpgsqlConnection connection) 
        {
            DataTable dt = new DataTable();
            string selectedtable = SelectTable(s);
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
        /// Функция удаления данных из выбранной таблицы
        /// </summary>
        /// <param name="id"> Переменная хранящая идентификатор удаляемой записи </param>
        /// <param name="tableinfo"> Массив хранящий информацию о таблице. Название и название столбца id </param>
        /// <param name="connection"> Переменная подключения к базе данных </param>
        public static void Delete(int id, string tableinfo, NpgsqlConnection connection) 
        {
            string commandText = "";
            switch (tableinfo)
            {
                case "Экземпляр книги":
                    commandText = $"delete from book where id = {id}";
                    break;
                case "Каталожная карточка книги":
                    commandText = $"delete from book_card where id = {id}";
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
        /// <summary>
        /// Функция добавления во все таблицы, кроме экземпляра книги и выдачи
        /// </summary>
        /// <param name="commandText"> Переменная хранящая команду для добавления </param>
        /// <param name="connection"> Переменная подключения к базе данных </param>
        public static void Insert(string table, string[] data, NpgsqlConnection connection)
        {
            string commandText = "";
            //bool cardHaveBooks = false;
            string[] textboxes = data[0].Split(';');
            string[] numerics = data[1].Split(';');
            string book = textboxes[0] + ";" + numerics[1];
            if (table == "Экземпляр книги") Insert_book(book, connection);
            else if (table == "Выдача")
            {
                string[] datepickers = data[4].Split(';');
            }
            else
            {
                int comboboxes = Int32.Parse(data[2]);
                switch (table)
                {
                    case "Каталожная карточка книги":
                        commandText = $"insert into book_card (book_name, book_edit, book_author, book_vol, dep_id) values ('{textboxes[0]}', '{textboxes[1]}', '{textboxes[2]}', '{Int32.Parse(numerics[0])}', '{comboboxes}')";
                        //cardHaveBooks = true;
                        break;
                    case "Отдел":
                        commandText = $"insert into department (dep_name) values ('{textboxes[0]}')";
                        break;
                    case "Абонент":
                        commandText = $"insert int subscriber (sub_lastname, sub_name, sub_midname) values ('{textboxes[0]}', '{textboxes[1]}', '{textboxes[2]}')";
                        break;
                    case "Библиотекарь":
                        commandText = $"insert int librarian (lib_lastname, lib_name, lib_midname) values ('{textboxes[0]}', '{textboxes[1]}', '{textboxes[2]}')";
                        break;
                }
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand(commandText, connection);
                    command.ExecuteNonQuery();
                    //if (cardHaveBooks) Insert_book(book, connection);
                }
                catch { MessageBox.Show($"Не удалось добавить данные в таблицу {table}.\n Введены не корректные данные."); }
            }
        }
        /// <summary>
        /// Функция добавления данных в таблицу экземпляр книги
        /// </summary>
        /// <param name="dataForTable"> Переменная хранящая название каталожной карточки и кол-во книг </param>
        /// <param name="connection"> Переменная подключения к базе данных </param>
        public static void Insert_book(string dataForTable, NpgsqlConnection connection)
        {
            string[] data = dataForTable.Split(';');
            string commandText = "";
            int rowsCount = 0;
            if(Int32.Parse(data[1]) > 0)
            {
                rowsCount = Int32.Parse(data[1]);
                try
                {
                    DataTable cardTable = GetCardId(data[0], connection);
                    int cardId = Int32.Parse(cardTable.Rows[0][0].ToString());
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
        /// <summary>
        /// Метод получения id каталожной карточки по названию
        /// </summary>
        /// <param name="name"> Переменная хранящая название книги </param>
        /// <param name="connection"> Переменная подключения к базе данных </param>
        /// <returns></returns>
        static DataTable GetCardId(string name, NpgsqlConnection connection)
        {
            DataTable dt = new DataTable();
            string commandText = $"select id from card where book_name = '{name}'";
            try
            {
                NpgsqlCommand getCardId = new NpgsqlCommand(commandText, connection);
                NpgsqlDataReader reader = getCardId.ExecuteReader();
                dt.Load(reader);
            }
            catch { }
            return dt;
        }
    }
}
