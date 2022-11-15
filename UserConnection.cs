using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class UserConnection
    {
        public string UserId { get; set; } //Идентификатор пользователя базы данных
        public string Password { get; set; } //Пароль пользователя
        /// <summary>
        /// Конструктор класса для подключения пользователя
        /// </summary>
        /// <param name="user"> Переменная хранящая логин пользователя </param>
        /// <param name="password"> Переменная хранящая пароль пользователя </param>
        public UserConnection(string user, string password) {
            this.UserId = user;
            this.Password = password;
        }
        /// <summary>
        /// Функция получения строки для подключения к базе данных
        /// </summary>
        /// <returns> Строка подключения к базе данных </returns>
        public string OpenConnection() { return $"Server=localhost;Port=5432;User Id={UserId};Password={Password};Database=library;"; }
    }
}
