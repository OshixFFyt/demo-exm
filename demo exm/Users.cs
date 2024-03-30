using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_exm
{
    // Перечисление для типов пользователей
    public enum UserType
    {
        Administrator,
        Waiter,
        Chef
    }

    // Класс для представления пользователя
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public UserType Type { get; set; }
        public bool IsFired { get; set; }

        public User(string username, string password, UserType type)
        {
            Username = username;
            Password = password;
            Type = type;
            IsFired = false;
        }
    }
}
