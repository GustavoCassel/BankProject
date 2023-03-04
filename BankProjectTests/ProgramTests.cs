using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void CustomExceptionsTests()
        {
            SavingAccount savingAccount = new("firstNameTest", "secondNameTest", 0, 1000.0m);

            void depositNegative() { savingAccount.Deposit(-1m); }
            Assert.ThrowsException<NegativeAmmountDepositException>
                (depositNegative, "Error while trying to deposit negative value.");

            void depositZero() { savingAccount.Deposit(0m); }
            Assert.ThrowsException<NegativeAmmountDepositException>
                (depositZero, "Error while trying to deposit value equal zero.");

            void withdrawMoreThanBalance() { savingAccount.Withdraw(1001.0m); }
            Assert.ThrowsException<NotEnoughBalanceException>
                (withdrawMoreThanBalance, "Error while trying to withdraw more than current balance.");
        }

        [TestMethod]
        public void BasicWithdrawAndDepositTests()
        {
            SavingAccount savingAccount = new("firstNameTest", "secondNameTest", 0, 1000.0m);

            const decimal ExpectedWithdrawBalance = 875.0m;
            savingAccount.Withdraw(125.0m);
            Assert.AreEqual(ExpectedWithdrawBalance, savingAccount.Balance, "Error while trying to withdraw.");

            const decimal ExpectedDepositBalance = 1000.0m;
            savingAccount.Deposit(125.0m);
            Assert.AreEqual(ExpectedDepositBalance, savingAccount.Balance, "Error while trying to deposit.");
        }

        [TestMethod]
        public void ExceedWithDrawLimitAndFeeTests()
        {
            SavingAccount savingAccount = new("firstNameTest", "secondNameTest", 0, 1000.0m);

            const int SavingAccountWithdrawalLimit = 3;
            for (int i = 0; i < SavingAccountWithdrawalLimit; i++)
            {
                savingAccount.Withdraw(10m);
            }

            const decimal ExpectedBalanceWithNoFee = 970.0m;
            Assert.AreEqual(ExpectedBalanceWithNoFee, savingAccount.Balance, "Error while trying to make 3 withdraws with no fee.");

            savingAccount.Withdraw(10m);
            const decimal SavingAccountFeeOverLimit = 2.0m;
            const decimal ExpectedBalanceWithFee = 960.0m - SavingAccountFeeOverLimit;
            Assert.AreEqual(ExpectedBalanceWithFee, savingAccount.Balance, "Error while trying to make a withdraws with fee.");
        }
    }
}