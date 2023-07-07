using BankProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankProjectTests;

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
