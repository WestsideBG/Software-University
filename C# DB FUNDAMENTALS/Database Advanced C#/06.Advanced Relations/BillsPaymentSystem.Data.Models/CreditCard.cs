namespace BillsPaymentSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Attributes;
    public class CreditCard
    {
        public int CreditCardId { get; set; }

        [ExpirationDate]
        public DateTime ExpirationDate { get; set; }

        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Limit { get; set; }

        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal MoneyOwed { get; set; }

        public decimal LimitLeft => this.Limit - this.MoneyOwed;

        public PaymentMethod PaymentMethod { get; set; }
    }
}