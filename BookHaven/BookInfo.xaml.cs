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
    /// Логика взаимодействия для BookInfo.xaml
    /// </summary>
    public partial class BookInfo : Window
    {
        public BookInfo()
        {
            InitializeComponent();
            ShowBookInfo();
        }

        private void OutButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void ShowBookInfo()
        {
            try
            {
                Book book = BookManager.GetBookInfo(BookManager.BookIdNow);

                TitleTextBlock.Text = book.Title;
                AuthorTextBlock.Text = book.Author;
                YearPublishedTextBlock.Text = book.YearPublished;
                InstanceTextBlock.Text = book.Instance;
                DescriptionTextBlock.Text = book.Description;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при получении информации о книге: {ex.Message}");
            }
        }
    }
}
