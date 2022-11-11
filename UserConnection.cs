using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class UserConnection
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public UserConnection(string user, string password)
        {
            this.UserId = user;
            this.Password = password;
        }
        public string OpenConnection()
        {
            return $"Server=localhost;Port=5432;User Id={UserId};Password={Password};Database=library;";
        }
    }
}
