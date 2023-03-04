namespace BankProject
{
    public sealed class NotEnoughBalanceException : Exception
    {
        private const string ErrorMessage = "It's not possible to withdraw this amount. Not enough balance!";
        public NotEnoughBalanceException() : base(ErrorMessage)
        { }
    }

    public sealed class NegativeAmmountDepositException : Exception
    {
        private const string ErrorMessage = "It's not possible to deposit zero or a negative value.";
        public NegativeAmmountDepositException() : base(ErrorMessage)
        { }
    }
}