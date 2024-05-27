using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;

namespace BookHaven_Library
{
    public static class BookManager
    {
        public static string? BookIdNow { get; set; }

        public static string path = @$"{JsonFileManager.PathToData()}\books.json";

        public static bool RegBook(string title, string author, string yearPublished, string instance, string bookID, bool bookAccess, string description)
        {
            try
            {
                List<Book> books = JsonFileManager.GetBooksFromJson();

                if (!string.IsNullOrWhiteSpace(title) && !string.IsNullOrWhiteSpace(author) && !string.IsNullOrWhiteSpace(yearPublished) &&
                    !string.IsNullOrWhiteSpace(instance) && !string.IsNullOrWhiteSpace(bookID) && !string.IsNullOrWhiteSpace(description))
                {
                    Book newBook = new Book(title, author, yearPublished, instance, bookID, true, description);
                    books.Add(newBook);
                    JsonFileManager.WriteBooks(books);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при регистрации книги: {ex.Message}");
                return false;
            }
        }

        public static Book GetBookInfo(string bookID)
        {
            try
            {
                List<Book> books = JsonFileManager.GetBooksFromJson();

                foreach (Book bk in books)
                {
                    if (bk.BookID == bookID)
                    {
                        return bk;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении информации о книге: {ex.Message}");
                return null;
            }
        }

        public static void RemoveBook(string bookID)
        {
            try
            {
                List<Book> books = JsonFileManager.GetBooksFromJson();
                books.RemoveAll(book => book.BookID == bookID);
                JsonFileManager.WriteBooks(books);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении книги: {ex.Message}");
            }
        }
        public static bool CheckBookRepeating(string bookId)
        {
            try
            {
                List<Book> books = JsonFileManager.GetBooksFromJson();
                foreach (Book book in books)
                {
                    if (book.BookID == bookId)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при проверке на повторение айдишников книг: {ex.Message}");
                return true;
            }
        }
    }
}