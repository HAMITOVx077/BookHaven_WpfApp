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
    /// Логика взаимодействия для AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public AddUserWindow()
        {
            InitializeComponent();
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (UserManager.CheckUserRepeating(Login_TextBox.Text))
                {
                    MessageBox.Show("Такой пользователь уже существует");
                }
                else
                {
                    ComboBoxItem selectedItem = (ComboBoxItem)UserRoleComboBox.SelectedItem;
                    string? userRole = selectedItem.Content.ToString();

                    if (UserManager.RegUser(Name_TextBox.Text, Surname_TextBox.Text, Login_TextBox.Text, Password_TextBox.Password, PhoneNumber_TextBox.Text, userRole))
                    {
                        MessageBox.Show("Пользователь успешно добавлен");
                        ClearUserInformation();
                    }
                    else
                    {
                        MessageBox.Show("Возникла ошибка, проверьте введённые данные");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при добавлении пользователя: {ex.Message}");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ClearUserInformation()
        {
            try
            {
                Name_TextBox.Text = "";
                Surname_TextBox.Text = "";
                Login_TextBox.Text = "";
                Password_TextBox.Password = "";
                PhoneNumber_TextBox.Text = "";
                UserRoleComboBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при очистке информации о пользователе: {ex.Message}");
            }
        }
    }
}