﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public enum AccountType

    {
        Checking,
        Savings,
        Loan,
        CD,
    }
    /// <summary>
    /// This is a bank account
    /// </summary>
    public class Account
    {
        

        #region Properties
        /// <summary>
        /// Unique number for the account
        /// </summary>
        [Key]

        public int AccountNumber { get; set; }
        [StringLength(50, ErrorMessage ="Account name must be less than 50 characters")]
        public string AccountName { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal Balance { get; set; }
        [Required]
        public AccountType TypeOfAccount { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        #endregion

        #region Constructors
        public Account()
        {
            CreatedDate = DateTime.Now;
        }

        #endregion

        #region Methods
        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public decimal Withdraw(decimal amount)
        {
            Balance -= amount;
            return Balance;
        }
        #endregion
    }
}