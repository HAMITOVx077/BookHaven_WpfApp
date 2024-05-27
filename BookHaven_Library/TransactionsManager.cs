using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookHaven_Library
{
    public class TransactionsManager
    {
        public static string path = @$"{JsonFileManager.PathToData()}\transactions.json";

        public static bool RegTransaction(string title, string author, string yearPublished, string instance, string login, string bookID, DateTime dateOfReturn)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(title) && !string.IsNullOrWhiteSpace(author) && !string.IsNullOrWhiteSpace(yearPublished) &&
                    !string.IsNullOrWhiteSpace(instance) && !string.IsNullOrWhiteSpace(login) && !string.IsNullOrWhiteSpace(bookID))
                {
                    List<Transact> transactions = JsonFileManager.GetTransactionsFromJson();
                    Transact newTransaction = new Transact(title, author, yearPublished, instance, login, bookID, dateOfReturn);
                    transactions.Add(newTransaction);
                    JsonFileManager.WriteTransactions(transactions);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при попытке зарегестрировать выдачу книги: {ex.Message}");
                return false;
            }
        }

        public static void RemoveBookFromTransactions(string bookID)
        {
            try
            {
                List<Transact> transactions = JsonFileManager.GetTransactionsFromJson();
                transactions.RemoveAll(transaction => transaction.BookID == bookID);
                JsonFileManager.WriteTransactions(transactions);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при попытке удалить книгу со списка транзакций: {ex.Message}");
            }
        }
    }
}