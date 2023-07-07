using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankProject.Tests;

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