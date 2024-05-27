using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven_Library
{
    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string UserRole { get; set; }
        public DateTime RegDate { get; set; }

        public User(string name, string surname, string login, string password, string phoneNumber, string userRole)
        {
            Name = name;
            Surname = surname;
            Login = login;
            Password = password;
            PhoneNumber = phoneNumber;
            UserRole = userRole;
            RegDate = DateTime.Now;
        }
    }
}
