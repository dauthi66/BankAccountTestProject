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
        private string name;
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
        public string Owner 
        {
            get { return name; }
            set 
            { 
                if (value == null)
                {
                    throw new ArgumentNullException($"The name inputted: {Owner} cannot be null");
                }
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"The name inputted: {Owner} cannot be blank");
                }
                if (IsOwnerNameValid(value))
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentException($"The name inputted: {Owner} can only be up to 20 A-Z characters");
                }

                //check that owner is only characters
                //if value contains any numbers or special characters - throws argumentException
            } 
        }

        private bool IsOwnerNameValid(string ownerName)
        {
            char[] validCharacters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 
                                'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

            ownerName = ownerName.ToLower();

            const int MaxNameLength = 20;

            if (ownerName.Length > MaxNameLength)
            {
                return false;
            }

            foreach (char letter in ownerName)
            {
                if ( letter != ' ' && !validCharacters.Contains(letter))
                {
                    return false;
                }
            }
    
            return true;
        }

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
            if (amt <= 0)
            {
                throw new ArgumentOutOfRangeException($"The amount {amt} must be more than 0");
            }
            if (amt > Balance)
            {
                throw new ArgumentOutOfRangeException($"Your balance of {Balance} does not have enough funds");

            }
            Balance -= amt;
            return Balance;
        }
    }
}
