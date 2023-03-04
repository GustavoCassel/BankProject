namespace BankProject
{
    public class Program
    {
        public static void Main()
        {
            CheckingAccount checkingAccount = new("John", "Doe", 2500.0m);
            SavingAccount savingAccount = new("Jane", "Doe", 0.025m, 1000.0m);

            DisplayBaseAccountInformation(checkingAccount);
            DisplayBaseAccountInformation(savingAccount);

            checkingAccount.Deposit(200.0m);
            savingAccount.Deposit(150.0m);

            DisplayBaseAccountInformation(checkingAccount);
            DisplayBaseAccountInformation(savingAccount);

            checkingAccount.Withdraw(50.0m);
            savingAccount.Withdraw(125.0m);

            DisplayBaseAccountInformation(checkingAccount);
            DisplayBaseAccountInformation(savingAccount);

            savingAccount.ApplyInterest();

            DisplayBaseAccountInformation(savingAccount);

            savingAccount.Withdraw(10.0m);
            savingAccount.Withdraw(20.0m);
            savingAccount.Withdraw(30.0m);

            DisplayBaseAccountInformation(checkingAccount);

            try
            {
                savingAccount.Withdraw(2000.0m);
            }
            catch (NotEnoughBalanceException ex)
            {
                Console.WriteLine(ex.Message);
            }

            checkingAccount.Withdraw(3000.0m);

            DisplayBaseAccountInformation(checkingAccount);
            DisplayBaseAccountInformation(savingAccount);
        }

        // Polymorphism example, where the class it's automatically passed as his super class
        private static void DisplayBaseAccountInformation(BaseAccount baseAccount)
        {
            // The format :C2 in the baseAccount.Balance are to format the value to currency type and with 2 decimal places.
            string formatedText = $"The account owner is: {baseAccount.AccountOwner}.\nThe current balance is: {baseAccount.Balance:C2}.\n";
            Console.WriteLine(formatedText);
        }
    }
}