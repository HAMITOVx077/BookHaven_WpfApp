using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven_Library
{
    public class Transact
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string YearPublished { get; set; }
        public string Instance { get; set; }
        public string Login {  get; set; }
        public string BookID { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfReturn { get; set; }
        public Transact(string title, string author, string yearPublished, string instance, string login, string bookID, DateTime dateOfReturn)
        {
            Title = title;
            Author = author;
            YearPublished = yearPublished;
            Instance = instance;
            Login = login;
            BookID = bookID;
            DateOfIssue = DateTime.Now;
            DateOfReturn = dateOfReturn;
        }
    }
}
