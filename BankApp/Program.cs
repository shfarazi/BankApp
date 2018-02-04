using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //initiating an object or instance or constructing an object
            var account = Bank.CreateAccount("test@test.com", initialBalance:101.10M);
            Console.WriteLine($"AN:{account.AccountNumber}, TA:{account.TypeOfAccount}, Balance: {account.Balance}, EA:{account.EmailAddress}");

            var account2 = Bank.CreateAccount("test2@test.com", AccountType.Savings);
            account2.Deposit(201.10M);
            Console.WriteLine($"AN:{account2.AccountNumber}, TA:{account2.TypeOfAccount}, Balance: {account2.Balance}, EA:{account2.EmailAddress}");
        }
    }
}

