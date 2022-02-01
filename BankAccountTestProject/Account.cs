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
    internal class Account
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
        public void Deposit(double amt)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes an amount of money from the balance
        /// </summary>
        /// <param name="amt">positive amount of money to be taken from balance</param>
        public void Withdraw(double amt)
        {
            throw new NotImplementedException();
        }


    }
}
