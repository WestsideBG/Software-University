using System.ComponentModel.DataAnnotations;

namespace BillsPaymentSystem.Data.Models
{
    public class BankAccount
    {
        public int BankAccountId { get; set; }

        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Balance { get; set; }

        [MaxLength(50)]
        [Required]
        public string BankName { get; set; }

        [MaxLength(20)]
        [Required]
        public string SwiftCode { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

    }
}