namespace BankAccountMethods
{
    public class BankAccount
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }

        public override string ToString()
        {
            return $"Account {this.Id}, balance {this.Balance:F2}";
        }
    }
}
