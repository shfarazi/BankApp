using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    static class Bank
    {
        public static Account CreateAccount(string emailAddress, AccountType typeOfAccount=AccountType.Checking, decimal initialBalance=0.0M)

        {
            var account = new Account
            {
                EmailAddress = emailAddress,
                TypeOfAccount = typeOfAccount
            };
            if (initialBalance > 0)
                account.Deposit(initialBalance);
            return account;
        }
    }
}
