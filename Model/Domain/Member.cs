using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClubBAISTsystem.Model.Domain
{
    public class Member
    {
        public int ApplicationID { get; set; }
        [Required(ErrorMessage = "Please enter your Last Name")]
        [MaxLength(50, ErrorMessage="Last Name is longer than 50 characters.")]
        [MinLength(2, ErrorMessage = "Last Name is shorter than 2 characters.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter your First Name")]
        [MaxLength(50, ErrorMessage = "First Name is longer than 50 characters.")]
        [MinLength(2, ErrorMessage = "First Name is shorter than 2 characters.")]
        public string FirstName { get; set; }
        [Required]
        public string MembershipLevel { get; set; }
        [Required(ErrorMessage = "Please enter your First Name")]
        [MaxLength(50, ErrorMessage = "Address is longer than 50 characters.")]
        [MinLength(2, ErrorMessage = "Address is shorter than 2 characters.")]
        public string HomeAddress { get; set; }
        [Required(ErrorMessage = "Please enter your Postal Code")]
        [RegularExpression(@"^[a-zA-Z]{1}[0-9]{1}[a-zA-Z]{1}(\-| |){1}[0-9]{1}[a-zA-Z]{1}[0-9]{1}$", ErrorMessage ="Please enter a valid Postal Code format.")]
        public string HomePostalCode { get; set; }
        [Required]
        [RegularExpression(@"^[2-9]\d{2}-\d{3}-\d{4}$", ErrorMessage= "Home Phone format does not match XXX-XXX-XXXX")]
        public string HomePhone { get; set; }
        [Required]
        [RegularExpression(@"^[2-9]\d{2}-\d{3}-\d{4}$", ErrorMessage = "Home Phone format does not match XXX-XXX-XXXX")]
        public string AlternatePhone { get; set; }
        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessage ="Please enter a valid Email format email@email.com")]
        public string Email { get; set; }
        [Required]
        public string DateOfBirth { get; set; }
        [Required(ErrorMessage = "Please enter your Date of Birth")]
        public string Occupation { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string CompanyAddress { get; set; }
        //[Required]
        [RegularExpression(@"^[a-zA-Z]{1}[0-9]{1}[a-zA-Z]{1}(\-| |){1}[0-9]{1}[a-zA-Z]{1}[0-9]{1}$", ErrorMessage = "Please enter a valid Postal Code format.")]
        public string CompanyPostalCode { get; set; }
        [Required]
        public string CompanyPhone { get; set; }
        [Required(ErrorMessage = "Please enter a Shareholder's Name")]
        [MaxLength(50, ErrorMessage = "Address is longer than 50 characters.")]
        [MinLength(2, ErrorMessage = "Address is shorter than 2 characters.")]
        public string ShareholderName1 { get; set; }
        [Required(ErrorMessage = "Please enter a Shareholder's Name")]
        [MaxLength(50, ErrorMessage = "Address is longer than 50 characters.")]
        [MinLength(2, ErrorMessage = "Address is shorter than 2 characters.")]
        public string ShareholderName2 { get; set; }
        [Required]
        public string Date { get; set; }
        public string ApprovedBy { get; set; }
        public string ApplicationStatus { get; set; }
       
        public int MemberNumber { get; set; }
       
        [Required]
        public string HomeCity { get; set; }
        [Required]
        public string HomeProvince { get; set; }
        [Required]
        public string CompanyCity { get; set; }
        [Required]
        public string CompanyProvince { get; set; }
        public decimal AmountPaid { get; set; }
        public string DateCharged { get; set; }
        public string PaymentDescription { get; set; }
        public decimal BalanceDue { get; set; }
        public decimal BalanceOwing { get; set; }


        private List<Member> _appliedMember = new List<Member>();
        public List<Member> AppliedMember
        {
            get => _appliedMember; //only get no set because its a read only
        }

    }
}
