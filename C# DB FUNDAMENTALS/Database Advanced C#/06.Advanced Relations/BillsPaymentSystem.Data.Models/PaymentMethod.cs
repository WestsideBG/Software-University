using BillsPaymentSystem.Data.Models.Attributes;
using BillsPaymentSystem.Data.Models.Enums;

namespace BillsPaymentSystem.Data.Models
{
    public class PaymentMethod
    {
        public int Id { get; set; }

        [Xor(nameof(CreditCardId))]
        public int? BankAccountId { get; set; }
        public BankAccount BankAccount { get; set; }

        public int? CreditCardId { get; set; }
        public CreditCard CreditCard { get; set; }

        public Type Type { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        }
}