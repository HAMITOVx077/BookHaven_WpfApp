using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Diagnostics;

namespace BookHaven_Library
{
    public static class UserManager
    {
        public static string UserNow { get; set; } = "";

        public static string pathToUsers = @$"{JsonFileManager.PathToData()}\users.json";

        public static bool AuthUser(string login, string password)
        {
            try
            {
                List<User> users = JsonFileManager.GetUsersFromJson();

                foreach (User user in users)
                {
                    if (user.Login == login && user.Password == password)
                        return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при авторизации пользователя: {ex.Message}");
                return false;
            }
        }

        public static bool RegUser(string name, string surname, string login, string password, string phoneNumber, string userRole)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(surname) && !string.IsNullOrWhiteSpace(login) &&
                    !string.IsNullOrWhiteSpace(password) && !string.IsNullOrWhiteSpace(phoneNumber) && !string.IsNullOrWhiteSpace(userRole))
                {
                    List<User> users = JsonFileManager.GetUsersFromJson();
                    User newUser = new User(name, surname, login, password, phoneNumber, userRole);
                    users.Add(newUser);
                    JsonFileManager.WriteUsers(users);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при регистрации пользователя: {ex.Message}");
                return false;
            }
        }

        public static string GetUserRole(string login)
        {
            try
            {
                List<User> users = JsonFileManager.GetUsersFromJson();

                foreach (User user in users)
                {
                    if (user.Login == login)
                        return user.UserRole;
                }
                return "User";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении уровня доступа пользователя {ex.Message}");
                return "User";
            }
        }

        public static bool CheckUserRepeating(string login)
        {
            try
            {
                List<User> users = JsonFileManager.GetUsersFromJson();
                foreach (User user in users)
                {
                    if (user.Login == login)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при проверке на повторение логинов пользователей: {ex.Message}");
                return true;
            }
        }
    }
}