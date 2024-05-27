using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven_Library
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string YearPublished { get; set; }
        public string Instance {  get; set; }
        public string BookID { get; set; }
        public bool BookAccess { get; set; }
        public string Description { get; set; }

        public Book(string title, string author, string yearPublished, string instance, string bookID, bool bookAccess, string description)
        {
            Title = title;
            Author = author;
            YearPublished = yearPublished;
            Instance = instance;
            BookID = bookID;
            BookAccess = true;
            Description = description;
        }
    }
}
