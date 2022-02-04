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
        public AccountTests()
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
        //make sure the exception is thrown
        public void Deposit_ZeroOrLess_ThrowsArgumentException(double invalidDepositAmount)
        {
            Account account = new("J Doe");
                                                        //lambda makes this anonymous function, wraps in parethensis
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.Deposit(invalidDepositAmount));
        }


        [TestMethod]
        public void Withdraw_PositiveAmount_DecreasesBalance()
        {
            double initialDeposit = 100;
            double withdrawAmount = 50;
            double expectedBalance = initialDeposit - withdrawAmount;

            account.Deposit(initialDeposit);
            account.Withdraw(withdrawAmount);

            double actualBalance = account.Balance;
            Assert.AreEqual(expectedBalance, actualBalance);
        }

        public void Withdraw_PositiveAmount_ReturnsUpdatedBalance()
        {
            Assert.Fail();
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-.01)]
        [DataRow(-1000)]
        public void Withdraw_ZeroOrLess_ThrowsArgumentOutOfRangeException()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void Withdraw_MoreThanAvailableBalance_ThrowsArgumentException()
        {
            Assert.Fail();
        }
    }
} 