using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    static class Bank
    {
        private static BankModel db = new BankModel();
     
        /// <summary>
        /// Create a bank account
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <param name="typeOfAccount"></param>
        /// <param name="initialBalance"></param>
        /// <returns>Returns the account</returns>
        /// <exception cref="System.ArgumentNullException" />
        public static Account CreateAccount(string emailAddress, AccountType typeOfAccount = AccountType.Checking, decimal initialBalance = 0.0M)

        {
            if(string.IsNullOrEmpty(emailAddress) ||string.IsNullOrWhiteSpace(emailAddress))
            {
                throw new ArgumentNullException("emailAddress", "Email Address cannot be empty.");
            }

            var account = new Account
            {
                EmailAddress = emailAddress,
                TypeOfAccount = typeOfAccount
            };
            if (initialBalance > 0)
                account.Deposit(initialBalance);
            db.Accounts.Add(account);
            db.SaveChanges();
            return account;
        }

        public static IEnumerable<Account> GetAccounts()
        {
            return db.Accounts;
        }

        public static Account GetAccountByAccountNumber(int accountNumber)
        {
            var account = db.Accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();
            if (account == null)
                return null;

            return account;

        }

        public static IEnumerable<Transaction> GetTransactionsByAccountNumber(int accountNumber)
        {
            return db.Transactions.Where(t => t.AccountNumber == accountNumber).OrderByDescending(t => t.TransactionDate);
        }

        public static void Deposit(int accountNumber, decimal amount)
        {
            var account = GetAccountByAccountNumber(accountNumber);
            account.Deposit(amount);

            var transaction = new Transaction
            {
                TransactionDate = DateTime.Now,
                TransactionAmount = amount,
                Description = "Branch deposit",
                TransactionType = TypesOfTransaction.Credit,
                AccountNumber = account.AccountNumber
            };
            db.Transactions.Add(transaction);
            db.SaveChanges();
        }
        public static void Withdraw(int accountNumber, decimal amount)
        {
            var account = GetAccountByAccountNumber(accountNumber);
            account.Withdraw(amount);

            var transaction = new Transaction
            {
                TransactionDate = DateTime.Now,
                TransactionAmount = amount,
                Description = "Branch withdraw",
                TransactionType = TypesOfTransaction.Debit,
                AccountNumber = account.AccountNumber
            };
            db.Transactions.Add(transaction);
            db.SaveChanges();

        }
    }
}
