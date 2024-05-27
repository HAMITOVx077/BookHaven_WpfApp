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
    /// Логика взаимодействия для AddBookWindow.xaml
    /// </summary>
    public partial class AddBookWindow : Window
    {
        public bool NeedingBooksUpdate = true;
        public AddBookWindow()
        {
            InitializeComponent();
        }

        private void AddBookButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (BookManager.CheckBookRepeating(BookID_TextBox.Text))
                {
                    MessageBox.Show("Книга с таким айди уже существует");
                }
                else
                {
                    if (BookManager.RegBook(Title_TextBox.Text, Author_TextBox.Text, YearPublished_TextBox.Text, Instance_TextBox.Text, BookID_TextBox.Text, true, Description_TextBox.Text))
                    {
                        MessageBox.Show("Книга успешно добавлена");
                        ClearBookInformation();
                    }
                    else
                    {
                        MessageBox.Show("Возникла ошибка, проверьте введённые данные");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при добавлении книги: {ex.Message}");
            }
        }

        private void ClearBookInformation()
        {
            try
            {
                Title_TextBox.Text = "";
                Author_TextBox.Text = "";
                YearPublished_TextBox.Text = "";
                Instance_TextBox.Text = "";
                Description_TextBox.Text = "";
                BookID_TextBox.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при очистке информации о книге: {ex.Message}");
            }
        }
    }
}