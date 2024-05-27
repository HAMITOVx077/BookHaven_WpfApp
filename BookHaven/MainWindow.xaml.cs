using System.IO;
using System.Net;
using System.Text;
using System.Transactions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Reflection.Metadata.BlobBuilder;
using BookHaven_Library;

namespace BookHaven
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetVisibilityOfObjects();
            ShowUserInfoInProfile();
            ShowBooksInCatalog();
            ShowBooksInMyBooks();
            ShowBooksReturn();
        }

        public void ShowUserInfoInProfile()
        {
            try
            {
                List<User> users = JsonFileManager.GetUsersFromJson();

                foreach (User user in users)
                {
                    if (user.Login == UserManager.UserNow)
                    {
                        Name_TextBlock.Text = user.Name;
                        Surname_TextBlock.Text = user.Surname;
                        Login_TextBlock.Text = user.Login;
                        UserRole_TextBlock.Text = user.UserRole;
                        PhoneNumber_TextBlock.Text = user.PhoneNumber;
                        RegDate_TextBlock.Text = user.RegDate.ToString("yyyy-MM-dd, HH:mm");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при загрузке информации о пользователе: {ex.Message}");
            }
        }

        private void MainOutButton_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow aw = new AuthWindow();
            aw.Show();
            Close();
        }

        private void AddBookButton_Click(object sender, RoutedEventArgs e)
        {
            AddBookWindow wn = new AddBookWindow();
            wn.ShowDialog();
            ShowBooksInCatalog();
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow wn = new AddUserWindow();
            wn.ShowDialog();
        }

        private void ShowBooksInCatalog()
        {
            try
            {
                List<Book> books = JsonFileManager.GetBooksFromJson();
                List<Book> accessBooks = new List<Book>();
                foreach (Book book in books)
                {
                    if (book.BookAccess != false)
                    {
                        accessBooks.Add(book);
                    }
                }
                BooksCatalogDataGrid.ItemsSource = accessBooks;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при загрузке каталога книг: {ex.Message}");
            }
        }

        private void ShowBooksInMyBooks()
        {
            try
            {
                MyBooksDataGrid.ItemsSource = JsonFileManager.GetUserTransactions();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при загрузке моих книг: {ex.Message}");
            }
        }

        private void ShowBooksReturn()
        {
            try
            {
                IssueAndReturnDataGrid.ItemsSource = JsonFileManager.GetTransactionsFromJson();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при загрузке выдачи и возврата книг: {ex.Message}");
            }
        }

        private void SetVisibilityOfObjects()
        {
            try
            {
                string userRole = UserManager.GetUserRole(UserManager.UserNow);

                if (userRole == "User")
                {
                    issue_and_return.Visibility = Visibility.Collapsed;
                    control.Visibility = Visibility.Collapsed;
                    GiveBookButton.Visibility = Visibility.Collapsed;
                    RemoveBookButton.Visibility = Visibility.Collapsed;
                }
                else if (userRole == "Employee")
                {
                    control.Visibility = Visibility.Collapsed;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при установке видимости объектов: {ex.Message}");
            }
        }

        private void GiveBookButton_Click(object sender, RoutedEventArgs e)
        {
            if (BooksCatalogDataGrid.SelectedItem != null)
            {
                try
                {
                    Book selectedBook = (Book)BooksCatalogDataGrid.SelectedItem;
                    BookManager.BookIdNow = selectedBook.BookID;

                    GiveBookWindow wn = new GiveBookWindow();
                    wn.ShowDialog();

                    ShowBooksInMyBooks();
                    ShowBooksReturn();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка при выдаче книги: {ex.Message}");
                }
            }
        }

        private void ReturnBookButton_Click(object sender, RoutedEventArgs e)
        {
            if (IssueAndReturnDataGrid.SelectedItem != null)
            {
                try
                {
                    Transact selectedBook = (Transact)IssueAndReturnDataGrid.SelectedItem;

                    MessageBoxResult result = MessageBox.Show("Подтвердите действие", "Подтверждение", MessageBoxButton.YesNo);

                    if (result == MessageBoxResult.Yes)
                    {
                        TransactionsManager.RemoveBookFromTransactions(selectedBook.BookID);
                        ShowBooksInMyBooks();
                        ShowBooksReturn();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка при возврате книги: {ex.Message}");
                }
            }
        }

        private void BookInfoBookButton_Click(object sender, RoutedEventArgs e)
        {
            if (BooksCatalogDataGrid.SelectedItem != null)
            {
                try
                {
                    Book selectedBook = (Book)BooksCatalogDataGrid.SelectedItem;
                    BookManager.BookIdNow = selectedBook.BookID;

                    BookInfo wn = new BookInfo();
                    wn.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка при показе информации о книге: {ex.Message}");
                }
            }
        }

        private void RemoveBookButton_Click(object sender, RoutedEventArgs e)
        {
            if (BooksCatalogDataGrid.SelectedItem != null)
            {
                try
                {
                    Book selectedBook = (Book)BooksCatalogDataGrid.SelectedItem;
                    BookManager.RemoveBook(selectedBook.BookID);
                    ShowBooksInCatalog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка при удалении книги: {ex.Message}");
                }
            }
        }
    }
}