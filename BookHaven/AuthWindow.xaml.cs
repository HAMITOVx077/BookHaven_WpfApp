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
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (UserManager.AuthUser(Login_TextBox.Text, Password_TextBox.Password))
                {
                    UserManager.UserNow = Login_TextBox.Text;

                    MainWindow mw = new MainWindow();
                    mw.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Возникла ошибка, проверьте введённые данные");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при попытке войти в систему: {ex.Message}");
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RegWindow rw = new RegWindow();
                rw.Show();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при попытке перейти в окно регистрации: {ex.Message}");
            }
        }
    }
}