﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven_Library
{
    public class Employee : User
    {
        public Employee(string name, string surname, string login, string password, string phoneNumber, string userRole)
            : base(name, surname, login, password, phoneNumber, userRole)
        {
        }
    }
}