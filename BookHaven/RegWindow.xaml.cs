using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// Логика взаимодействия для RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        public RegWindow()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (UserManager.CheckUserRepeating(Login_TextBox.Text))
                {
                    MessageBox.Show("Такой пользователь уже существует");
                }
                else
                {
                    if (UserManager.RegUser(Name_TextBox.Text, Surname_TextBox.Text, Login_TextBox.Text, Password_TextBox.Password, PhoneNumber_TextBox.Text, "User"))
                    {
                        MessageBox.Show("Вы успешно зарегестрированы, пожалуйста войдите в систему");

                        AuthWindow aw = new AuthWindow();
                        aw.Show();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Возникла ошибка, проверьте ведённые данные");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при регистрации пользователя: {ex.Message}");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow aw = new AuthWindow();
            aw.Show();
            Close();
        }
    }
}
