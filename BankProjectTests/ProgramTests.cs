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
    public class SavingAccountTests
    {
        [TestMethod]
        public void ExceedWithdrawLimitAndFeeTests()
        {
            SavingAccount savingAccount = new("firstNameTest", "secondNameTest", 0, 1000.0m);

            // To use all withdraws with no fee
            for (int i = 0; i < SavingAccount.WithdrawalLimitWithoutFee; i++)
            {
                savingAccount.Withdraw(10m);
            }

            const decimal ExpectedBalanceWithNoFee = 970.0m;
            Assert.AreEqual(ExpectedBalanceWithNoFee, savingAccount.Balance, "Error while trying to make 3 withdraws with no fee.");

            savingAccount.Withdraw(10m);

            decimal ExpectedBalanceWithFee = 960.0m - SavingAccount.OverLimitWithdrawalCharge;
            Assert.AreEqual(ExpectedBalanceWithFee, savingAccount.Balance, "Error while trying to make a withdraws with fee.");
        }

        [TestMethod]
        public void ApplyInterestTests()
        {
            // Instantiated with 2.5% of interest
            SavingAccount savingAccount = new("firstNameTest", "secondNameTest", 0.025m, 1000.0m);

            savingAccount.ApplyInterest();

            const decimal ExpectedBalanceWithInterest = 1025.0m;
            Assert.AreEqual(ExpectedBalanceWithInterest, savingAccount.Balance, "Error while calculating and adding the interest.");
        }
    }

    [TestClass]
    public class CheckingAccountTests
    {
        [TestMethod]
        public void OverdrawTests()
        {
            CheckingAccount checkingAccount = new("firstNameTest", "secondNameTest", 1000.0m);

            checkingAccount.Withdraw(1001.0m);

            decimal ExpectedBalanceWithOverdrawCharge = -(CheckingAccount.OverdrawCharge + 1m);
            Assert.AreEqual(ExpectedBalanceWithOverdrawCharge, checkingAccount.Balance, "Error while calculate and adding the overdraw charge");
        }
    }

    [TestClass]
    public class MainProgramTests
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
        public void BasicWithdrawDepositAndConsultTests()
        {
            SavingAccount savingAccount = new("firstNameTest", "secondNameTest", 0, 1000.0m);

            const decimal ExpectedWithdrawBalance = 875.0m;
            savingAccount.Withdraw(125.0m);
            Assert.AreEqual(ExpectedWithdrawBalance, savingAccount.Balance, "Error while trying to withdraw.");

            const decimal ExpectedDepositBalance = 1000.0m;
            savingAccount.Deposit(125.0m);
            Assert.AreEqual(ExpectedDepositBalance, savingAccount.Balance, "Error while trying to deposit.");

            const decimal ExpectedBalance = 1000.0m;
            Assert.AreEqual(ExpectedBalance, savingAccount.Balance, "Error while trying to consult the current balance.");
        }

        [TestMethod]
        public void BasicOwnerGet()
        {
            const string firstName = "firstNameTest";
            const string lastName = "lastNameTest";
            CheckingAccount checkingAccount = new(firstName, lastName, 0m);

            const string accountOwnerName = $"{firstName} {lastName}";
            Assert.AreEqual(accountOwnerName, checkingAccount.AccountOwner, "Error while recieving the owner name.");
        }
    }
}