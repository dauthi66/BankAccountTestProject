using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountTestProject
{
    /// <summary>
    /// represents a single customers bank account
    /// </summary>
    public class Account
    {
        /// <summary>
        /// creates an account with a given owner and 0 balance
        /// </summary>
        /// <param name="accOwner">the customer that owns the account</param>
        public Account(string accOwner)
        {
            Owner = accOwner;
        }

        /// <summary>
        /// account holders name first and last
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// amount of money in account
        /// </summary>
        //private set does not allow it to be set outside the class
        public double Balance { get; private set; }

        /// <summary>
        /// add specified amount to account
        /// </summary>
        /// <param name="amt">a positive amount to add to account</param>
        /// <returns>The balance after deposit</returns>
        public double Deposit(double amt)
        {
            if (amt <= 0)
            {
                throw new ArgumentOutOfRangeException($"The amount {amt} must be more than 0");
            }
            Balance += amt;
            return Balance;
        }

        /// <summary>
        /// Removes an amount of money from the balance
        /// and returns updated balance
        /// </summary>
        /// <param name="amt">positive amount of money to be taken from balance</param>
        /// <returns>Returns updated balance after withdraw</returns>
        public double Withdraw(double amt)
        {
            Balance -= amt;
            return Balance;
        }
    }
}
