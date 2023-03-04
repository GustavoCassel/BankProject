namespace BankProject
{
    /// <summary>
    /// <para>Rules of this class:</para>
    /// <list type="number">
    ///     <item>
    ///         <description>It is not possible to withdraw beyond the balance.</description>
    ///     </item>
    ///     <item>
    ///         <description>Have a limit on withdrawal operations.</description>
    ///     </item>
    ///     <item>
    ///         <description>If you go over the withdrawal limit, it adds a $2 fee on every withdrawal.</description>
    ///     </item>
    /// </list>
    /// </summary>
    public class SavingAccount : BaseAccount
    {
        private const decimal WithdrawalCharge = 2.0m;
        private const int WithdrawalLimit = 3;

        private readonly decimal _interestRate;
        private int _withdrawCount;

        public SavingAccount(string firstName, string lastName, decimal interestRate, decimal balance)
            : base(firstName, lastName, balance)
        {
            this._withdrawCount = 0;
            this._interestRate = interestRate;
        }

        public void ApplyInterest()
        {
            base._balance += base._balance * this._interestRate;
        }

        public override void Withdraw(decimal amount)
        {
            if (this._withdrawCount >= WithdrawalLimit)
                amount += WithdrawalCharge;

            if (this._balance - amount <= 0)
            {
                throw new NotEnoughBalanceException();
            }

            base.Withdraw(amount);

            this._withdrawCount++;
        }
    }
}