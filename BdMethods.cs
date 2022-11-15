using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class BdMethods
    {
        string ConnectionToDB { get; } //Строка подключения к базе данных
        public NpgsqlConnection Connection { get; } //Переменная для подключение к базе данных
        /// <summary>
        /// Конструктор класса работы с базой данных
        /// </summary>
        /// <param name="conn"> Переменная хранящая строку подключения к базе данных </param>
        public BdMethods(string conn) {
            this.ConnectionToDB = conn;
            Connection = new NpgsqlConnection(conn);
        }
        /// <summary>
        /// Функция для получения выбранной в древе таблицы
        /// </summary>
        /// <param name="s"> Переменная хранящая название выбранной таблицы </param>
        /// <returns> Запрос для вывода выбранной таблицы</returns>
        public static string SelectTable(string s) {
            string temp = "";
            switch (s) {
                case "Экземпляр книги":
                    temp = "select book_name, book_sub from book, book_card where book_card_id = bcard_id order by book_id";
                    break;
                case "Каталожная карточка книги":
                    temp = "select book_name, book_author, book_edit, book_vol, dep_name from book_card, department where book_dep_id = dep_id order by bcard_id";
                    break;
                case "Выдача":
                    temp = "select * from book_issue";
                    break;
                case "Отдел":
                    temp = "select dep_id, dep_name from department order by dep_id";
                    break;
                case "Абонент":
                    temp = "select sub_lastname, sub_name, sub_midname from subscriber order by sub_id";
                    break;
                case "Библиотекарь":
                    temp = "select lib_lastname, lib_name, lib_midname from librarian order by lib_id";
                    break;
            }
            return temp;
        }
    }
}
