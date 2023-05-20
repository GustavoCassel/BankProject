namespace BankProject
{
    /// <summary>
    /// Rules of this class:
    /// <list type="number">
    ///     <item>
    ///         <description>Can withdraw beyond the balance.</description>
    ///     </item>
    ///     <item>
    ///         <description>But with a charge of $35 every withdraw with negative balance.</description>
    ///     </item>
    /// </list>
    /// </summary>
    public class CheckingAccount : BaseAccount
    {
        public readonly static decimal OverdrawCharge = 35.0m;

        public CheckingAccount(string firstName, string lastName, decimal balance)
            : base(firstName, lastName, balance)
        { }

        public override void Withdraw(decimal amount)
        {
            if (_balance - amount < 0)
            {
                amount += OverdrawCharge;
            }

            base.Withdraw(amount);
        }
    }
}