namespace BankProject
{
    // Abstract means that this class can't be instantiated, only inherited
    public abstract class BaseAccount
    {
        // Two read-only properties
        public decimal Balance => this._balance;

        public string AccountOwner
        {
            get => $"{this._firstName} {this._lastName}";
        }

        // protected fields, means that this and every other child class can access this field.
        protected string _firstName;
        protected string _lastName;
        protected decimal _balance;
        public BaseAccount(string firstName, string lastName, decimal balance)
        {
            this._firstName = firstName;
            this._lastName = lastName;
            this._balance = balance;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new NegativeAmmountDepositException();
            }

            this._balance += amount;
        }

        public virtual void Withdraw(decimal amount)
        {
            this._balance -= amount;
        }
    }
}