using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClubBAISTsystem.Model.Domain
{
    public class PaymentProcess
    {
        [Required]
        public int CreditCardNumber { get; set; }
        [Required]
        public int PaymentID { get; set; }
        [Required]
        public string ExpiryDate { get; set; }
        [Required]
        public string Currency { get; set; }
        [Required]
        public decimal AmountPaid { get; set; }
        [Required]
        public decimal BalanceOwing { get; set; }
        [Required]
        public decimal BalanceDue { get; set; }
        [Required]
        public string DateCharged { get; set; }
        [Required]
        public string PaymentDescription { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Date { get; set; }

        public void CalculateMemberPayment()
        {
            BalanceDue = AmountPaid - BalanceOwing;
        }
    }
}
