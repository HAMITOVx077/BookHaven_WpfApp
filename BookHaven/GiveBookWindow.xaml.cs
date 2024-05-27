using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BookHaven_Library;

namespace BookHaven
{
    /// <summary>
    /// Логика взаимодействия для GiveBookWindow.xaml
    /// </summary>
    public partial class GiveBookWindow : Window
    {
        public GiveBookWindow()
        {
            InitializeComponent();
        }

        private void GiveBookButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime selectedDate = DateOfReturn_DatePicker.SelectedDate.Value;

                Book bookNow = BookManager.GetBookInfo(BookManager.BookIdNow);

                TransactionsManager.RegTransaction(bookNow.Title, bookNow.Author, bookNow.YearPublished, bookNow.Instance, Login_TextBox.Text, BookManager.BookIdNow, selectedDate);
                MessageBox.Show("Книга успешно выдана пользователю");

                //меняем доступ к книге, чтобы она исчезла из общего каталога
                List<Book> books = JsonFileManager.GetBooksFromJson();
                foreach (Book book in books)
                {
                    if (book.BookID == bookNow.BookID)
                    {
                        book.BookAccess = false;
                    }
                }

                JsonFileManager.WriteBooks(books);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при попытке выдать книгу пользователю: {ex.Message}");
            }
        }
    }
}
