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
    }
}
