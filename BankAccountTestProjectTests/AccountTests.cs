using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountTestProject;
using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;

namespace BankAccountTestProject.Tests
{
    [TestClass()]
    public class AccountTests
    {
        private Account account;

        //a constructor will create an account before each test start
        [TestInitialize]
        public void CreateDefaultAccount()
        {
            account = new("J Doe");
        }

        //[testinitialize] //runs once before each test is run
        //public void createdefaultaccount()
        //{
        //    account = new("j doe");
        //}
        //parenthesis optional
        [TestMethod()]
        [TestCategory("Deposit")] //allows you to group by traits in test explorer
        public void Deposit_APositiveAmount_AddToBalance()
        {
            //create test
            account.Deposit(100);
            //success parameters (100 was added to balance)
            Assert.AreEqual(100, account.Balance);
        }

        [TestMethod]
        [DataRow(100)]
        [DataRow(.01)]
        [TestCategory("Deposit")]

        public void Deposit_APositiveAmount_Returns_Updated_Balance(double depositAmount)
        {
            //ARRANGE
            //Account acc = new("J Doe"); REFACTORED
            //ACT
            double returnValue = account.Deposit(depositAmount);
            //ASSERT pass if deposit amount and balance are equal
            Assert.AreEqual(depositAmount, account.Balance);
        }

        [TestMethod]
        //use these variables to test
        [DataRow(-1)]
        [DataRow(0)]
        [TestCategory("Deposit")]

        //make sure the exception is thrown
        public void Deposit_ZeroOrLess_ThrowsArgumentException(double invalidDepositAmount)
        {
            //Account account = new("J Doe");
            //lambda makes this anonymous function, wraps in parethensis
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.Deposit(invalidDepositAmount));
        }


        [TestMethod]
        [DataRow(1)]
        [DataRow(0.1)]
        [DataRow(100)]
        [TestCategory("Withdraw")]

        public void Withdraw_PositiveAmount_DecreasesBalance(double withdrawAmount)
        {
            double initialDeposit = 1000;
            double expectedBalance = initialDeposit - withdrawAmount;

            account.Deposit(initialDeposit);
            account.Withdraw(withdrawAmount);

            double actualBalance = account.Balance;
            Assert.AreEqual(expectedBalance, actualBalance);
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(0.1)]
        [DataRow(100)]
        [TestCategory("Withdraw")]
        public void Withdraw_PositiveAmount_ReturnsUpdatedBalance(double withdrawAmount)
        {
            double initialDeposit = 1000;
            double expectedBalance = initialDeposit - withdrawAmount;

            account.Deposit(initialDeposit);
            account.Withdraw(withdrawAmount);

            double actualBalance = account.Balance;

            Assert.AreEqual(expectedBalance, actualBalance);

        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-0.1)]
        [DataRow(-1000)]
        [TestCategory("Withdraw")]
        public void Withdraw_ZeroOrLess_ThrowsArgumentOutOfRangeException(double invalidWithdrawAmount)
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.Withdraw(invalidWithdrawAmount));
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(0.1)]
        [DataRow(100)]
        [TestCategory("Withdraw")]
        public void Withdraw_MoreThanAvailableBalance_ThrowsArgumentException(double overdrawAmount)
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.Withdraw(overdrawAmount));
        }

        [TestMethod]
        [TestCategory("Owner")]
        public void Owner_SetAsNull_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => account.Owner = null);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow("      ")]
        [TestCategory("Owner")]
        public void Owner_SetAsWhitespaceOrEmptyString_ThrowsArgumentException(string emptyName)
        {
            Assert.ThrowsException<ArgumentException>(() => account.Owner = emptyName);
        }

        [TestMethod]
        [DataRow("Kris")]
        [DataRow("Kriston Trevino")]
        [DataRow("Christian Trivvianis")]
        [TestCategory("Owner")]
        public void Owner_SetAsUpTo20Characters_SetsSuccessfully(string validNames)
        {
            account.Owner = validNames;
            Assert.AreEqual(validNames, account.Owner);
        }

        [TestMethod]
        [DataRow("Kris 3rd")]
        [DataRow("#$%!")]
        [DataRow("Christian Trivviannis")]
        [TestCategory("Owner")]
        public void Owner_InvalidOwnerName_ThrowsArgumentException(string invalidNames)
        {
            Assert.ThrowsException<ArgumentException>(() => account.Owner = invalidNames);
        }
    }
} 