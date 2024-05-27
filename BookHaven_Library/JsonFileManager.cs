using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Newtonsoft.Json;
using System.IO;
using System.Windows;
using System.Windows.Shapes;

namespace BookHaven_Library
{
    public static class JsonFileManager
    {
        public static string PathToData()
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory; //директория откуда запущено приложение
            string projectRoot = System.IO.Path.GetFullPath(System.IO.Path.Combine(currentDirectory, @"..\..\..")); //исправляем ошибку неправильного пути
            string pathToData = System.IO.Path.Combine(projectRoot, "data"); //путь к папке data
            return pathToData;
        }

        public static string pathToUsers = @$"{PathToData()}\users.json";
        public static string pathToBooks = @$"{PathToData()}\books.json";
        public static string pathToTransactions = @$"{PathToData()}\transactions.json";

        //users
        public static List<User> GetUsersFromJson()
        {
            try
            {
                if (!File.Exists(pathToUsers))
                {
                    return new List<User>();
                }

                string jsonData = File.ReadAllText(pathToUsers);
                return JsonConvert.DeserializeObject<List<User>>(jsonData) ?? new List<User>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при чтении файла пользователей: {ex.Message}");
                return new List<User>();
            }
        }

        public static void WriteUsers(List<User> users)
        {
            try
            {
                string jsonFile = JsonConvert.SerializeObject(users, Formatting.Indented);
                File.WriteAllText(pathToUsers, jsonFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при записи в файл пользователей: {ex.Message}");
            }
        }

        //books
        public static List<Book> GetBooksFromJson()
        {
            try
            {
                if (!File.Exists(pathToBooks))
                {
                    return new List<Book>();
                }

                string jsonData = File.ReadAllText(pathToBooks);
                return JsonConvert.DeserializeObject<List<Book>>(jsonData) ?? new List<Book>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при чтении файла книг: {ex.Message}");
                return new List<Book>();
            }
        }

        public static void WriteBooks(List<Book> books)
        {
            try
            {
                string jsonFile = JsonConvert.SerializeObject(books, Formatting.Indented);
                File.WriteAllText(pathToBooks, jsonFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при записи в файл книг: {ex.Message}");
            }
        }

        //transactions
        public static List<Transact> GetTransactionsFromJson()
        {
            try
            {
                if (!File.Exists(pathToTransactions))
                {
                    return new List<Transact>();
                }
                string jsonData = File.ReadAllText(pathToTransactions);
                return JsonConvert.DeserializeObject<List<Transact>>(jsonData) ?? new List<Transact>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при чтении файла транзакций: {ex.Message}");
                return new List<Transact>();
            }
        }

        public static List<Transact> GetUserTransactions()
        {
            try
            {
                if (!File.Exists(pathToTransactions))
                {
                    return new List<Transact>();
                }

                string jsonFile = File.ReadAllText(pathToTransactions);
                List<Transact>? allTransactions = JsonConvert.DeserializeObject<List<Transact>>(jsonFile);
                List<Transact>? userTransactions = new List<Transact>();

                foreach (Transact tr in allTransactions)
                {
                    if (tr.Login == UserManager.UserNow)
                    {
                        userTransactions.Add(tr);
                    }
                }

                return userTransactions;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при чтении файла транзакций: {ex.Message}");
                return new List<Transact>();
            }
        }

        public static void WriteTransactions(List<Transact> transactions)
        {
            try
            {
                string jsonFile = JsonConvert.SerializeObject(transactions, Formatting.Indented);
                File.WriteAllText(pathToTransactions, jsonFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при записи в файл транзакций: {ex.Message}");
            }
        }
    }
}