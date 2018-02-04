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
            Console.WriteLine("********************");
            Console.WriteLine("Welcome to my bank!");
            Console.WriteLine("********************");
            while (true)
            {
                Console.WriteLine("0.Exit");
                Console.WriteLine("1.Create a new account");
                Console.WriteLine("2.Deposite");
                Console.WriteLine("3.Withdrawal");
                Console.WriteLine("4. Print all accounts");

                Console.Write("Select an option:");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "0":
                        Console.WriteLine("Thank you for visiting!");
                        return;
                    case "1":
                        Console.WriteLine("Email Address:");
                        var emailAddress = Console.ReadLine();
                        var accountTypes = Enum.GetNames(typeof(AccountType));
                        for (int i = 0; i < accountTypes.Length; i++)
                        {
                            Console.WriteLine($"{i + 1}.{accountTypes[i]}");
                        }
                        Console.Write("Select an account type:");
                        var accountType = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Deposit:");
                        var amount = Convert.ToDecimal(Console.ReadLine());

                        var account = Bank.CreateAccount(emailAddress, (AccountType)(accountType - 1), amount);
                        Console.WriteLine($"AN:{account.AccountNumber}, TA:{account.TypeOfAccount}, Balance: {account.Balance}, EA:{account.EmailAddress}");
                        break;
                    case "2":
                        PrintAllAccounts();
                        Console.Write("Select an account number:");
                        var accountNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Deposit amount:");
                        var depositAmount = Convert.ToDecimal(Console.ReadLine());
                        Bank.Deposit(accountNumber, depositAmount);
                        break;
                    case "3":
                        PrintAllAccounts();
                        Console.Write("Select an account number:");
                        accountNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Withdraw amount:");
                        var withdrawAmount = Convert.ToDecimal(Console.ReadLine());
                        Bank.Withdraw(accountNumber, withdrawAmount);
                        break;
                    case "4":
                        PrintAllAccounts();
                        break;
                    default:
                        break;
                }
            }

        }

        private static void PrintAllAccounts()
        {
            var accounts = Bank.GetAccounts();
            foreach (var acnt in accounts)
            {
                Console.WriteLine($"AN:{acnt.AccountNumber}, TA:{acnt.TypeOfAccount}, Balance: {acnt.Balance:C}, EA:{acnt.EmailAddress}");
            }
        }
    }
}

