using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    static class Bank
    {
        private static List<Account> accounts = new List<Account>();
        public static Account CreateAccount(string emailAddress, AccountType typeOfAccount = AccountType.Checking, decimal initialBalance = 0.0M)

        {
            var account = new Account
            {
                EmailAddress = emailAddress,
                TypeOfAccount = typeOfAccount
            };
            if (initialBalance > 0)
                account.Deposit(initialBalance);
            accounts.Add(account);
            return account;
        }

        public static IEnumerable<Account> GetAccounts()
        {
            return accounts;
        }

        public static Account GetAccountByAccountNumber(int accountNumber)
        {
            var account = accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();
            if (account == null)
                return null;

            return account;

        }
        public static void Deposit(int accountNumber, decimal amount)
        {
            var account = GetAccountByAccountNumber(accountNumber);
            account.Deposit(amount);
        }
        public static void Withdraw(int accountNumber, decimal amount)
        {
            var account = GetAccountByAccountNumber(accountNumber);
            account.Withdraw(amount);
        }
    }
}
