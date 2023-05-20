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
        public readonly static decimal OverLimitWithdrawalCharge = 2.0m;
        public readonly static int WithdrawalLimitWithoutFee = 3;

        private readonly decimal _interestRate;
        private int _withdrawCount;

        public SavingAccount(string firstName, string lastName, decimal interestRate, decimal balance)
            : base(firstName, lastName, balance)
        {
            _withdrawCount = 0;
            _interestRate = interestRate;
        }

        public void ApplyInterest()
        {
            _balance += _balance * _interestRate;
        }

        public override void Withdraw(decimal amount)
        {
            if (_withdrawCount >= WithdrawalLimitWithoutFee)
            {
                amount += OverLimitWithdrawalCharge;
            }

            if (_balance - amount <= 0)
            {
                throw new NotEnoughBalanceException();
            }

            base.Withdraw(amount);

            _withdrawCount++;
        }
    }
}