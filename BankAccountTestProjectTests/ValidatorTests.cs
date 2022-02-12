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
    public class ValidatorTests
    {
        [TestMethod()]
        [DataRow(0, 100, 0)]
        [DataRow(0, 100, 100)]
        [DataRow(0, 100, 49.99)]
        [TestCategory("Validator")]
        public void IsWithinRangeTest_InclusiveRange_ReturnsTrue(double min, double max, double test)
        {
            bool result = Validator.IsWithinRange(min, max, test);

            Assert.IsTrue(result);
        }

        [TestMethod()]
        [DataRow(0, 100, -.01)]
        [DataRow(0, 100, 100.01)]
        [TestCategory("Validator")]
        public void IsWithinRangeTest_ExclusiveRange_ReturnsTrue(double min, double max, double test)
        {
            bool result = Validator.IsWithinRange(min, max, test);

            Assert.IsFalse(result);
        }
    }
}