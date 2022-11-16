using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    temp = "select book_name as \"Название книги\", book_sub as \"Читатель\" from book, book_card where book_card_id = bcard_id order by book_id";
                    break;
                case "Каталожная карточка книги":
                    temp = "select book_name as \"Название\", book_author as \"Автор\", book_edit as \"Издание\", book_vol as \"Объем\", dep_name as \"Отдел\" from book_card, department where book_dep_id = dep_id order by bcard_id";
                    break;
                //Изменить вывод таблицы выдача
                case "Выдача":
                    temp = "select book_name, sub_lastname, lib_lastname, is_date, is_rdate from book_issue, book_card, subscriber, librarian";
                    break;
                case "Отдел":
                    temp = "select dep_id as \"Номер отдела\", dep_name as \"Название отдела\" from department order by dep_id";
                    break;
                case "Абонент":
                    temp = "select sub_lastname as \"Фамилия\", sub_name as \"Имя\", sub_midname as \"Отчество\" from subscriber order by sub_id";
                    break;
                case "Библиотекарь":
                    temp = "select lib_lastname as \"Фамилия\", lib_name as \"Имя\", lib_midname as \"Отчество\" from librarian order by lib_id";
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
            //MessageBox.Show("Неверно указано название таблицы.");
            catch { }
            return dt;
        }
        /// <summary>
        /// Функция удаления данных из выбранной таблицы
        /// </summary>
        /// <param name="id"> Переменная хранящая идентификатор удаляемой записи </param>
        /// <param name="tableinfo"> Массив хранящий информацию о таблице. Название и название столбца id </param>
        /// <param name="connection"> Переменная подключения к базе данных </param>
        public static void Delete(int id, string[] tableinfo, NpgsqlConnection connection) 
        {
            string commandText = $"delete from {tableinfo[0]} where {tableinfo[1]} = {id}";
            NpgsqlCommand command = new NpgsqlCommand(commandText, connection);
            command.ExecuteNonQuery();
        }
    }
}
