using BankProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankProjectTests;

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