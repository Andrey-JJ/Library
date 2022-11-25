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
    internal class WorkingWithDB
    {
        string ConnectionToDB { get; } //Строка подключения к базе данных
        public NpgsqlConnection Connection { get; } //Переменная для подключение к базе данных
        public string Table { get; set; } //Переменная хранящая название таблицы выбранной в древе
        /// <summary>
        /// Конструктор класса работы с базой данных
        /// </summary>
        /// <param name="conn"> Переменная хранящая строку подключения к базе данных </param>
        public WorkingWithDB(string conn) 
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
                    temp = "select book_name as \"Название книги\", book_sub as \"Читатель\" from book, book_card" +
                        " where card_id = book_card.id";
                    break;
                case "Каталожная карточка книги":
                    temp = "select book_name as \"Название\", book_author as \"Автор\", book_edit as \"Издание\", book_vol as \"Объем\", department.dep_name as \"Отдел\" from book_card, department " +
                        "where department.id = book_card.dep_id";
                    break;
                case "Выдача":
                    temp = "select book_name as \"Название\", sub_lastname as \"Абонент\", lib_lastname as \"Библиотекарь\", is_date as \"Дата выдачи\", is_rdate as \"Дата возврата\" FROM book_issue, subscriber, librarian, book_card " +
                        "where subscriber.id = book_issue.sub_id and librarian.id = book_issue.lib_id and book_issue.book_id = (SELECT book.id from book where book.card_id = book_card.id order by book.id asc limit 1)";
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
        public static void Insert(string tableinfo, string tabledata, NpgsqlConnection connection)
        {
            string commandText = "";
            string[] dataToInsert = tabledata.Split(';');
            switch (tableinfo)
            {
                case "Экземпляр книги":
                    //Добавить проверку id карточки по названию
                    break;
                case "Каталожная карточка книги":
                    //Возможно изменить 
                    commandText = $"insert into book_card (book_name, book_edit, book_author, book_vol, dep_id) values ('{dataToInsert[0]}', '{dataToInsert[1]}', '{dataToInsert[2]}', '{Int32.Parse(dataToInsert[3])}', '{Int32.Parse(dataToInsert[4])}')";
                    break;
                case "Выдача":
                    //Добавить проверку всех id по именам и названиям
                    break;
                case "Отдел":
                    commandText = $"insert into department (dep_name) values ('{dataToInsert[0]}')";
                    break;
                case "Абонент":
                    commandText = $"insert int subscriber (sub_lastname, sub_name, sub_midname) values ('{dataToInsert[0]}', '{dataToInsert[1]}', '{dataToInsert[2]}')";
                    break;
                case "Библиотекарь":
                    commandText = $"insert int librarian (lib_lastname, lib_name, lib_midname) values ('{dataToInsert[0]}', '{dataToInsert[1]}', '{dataToInsert[2]}')";
                    break;
            }
            try
            {
                NpgsqlCommand command = new NpgsqlCommand(commandText, connection);
                command.ExecuteNonQuery();
            }
            catch { }
        }
    }
}
