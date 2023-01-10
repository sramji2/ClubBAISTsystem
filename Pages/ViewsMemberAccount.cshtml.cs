using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ClubBAISTsystem.Model.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClubBAISTsystem.Pages
{
   
    public class ViewsMemberAccountModel : PageModel
    {
        public string Message { get; set; }
        public PaymentProcess PaymentProcess { get; set; }

        public Member ActiveMember { get; set; }
        [BindProperty]
        public string MembershipLevel { get; set; }
        [BindProperty]
        public int MemberNumber { get; set; }
        [BindProperty]
        public string LastName { get; set; }
        [BindProperty]
        public string FirstName { get; set; }
        [BindProperty]
        public string HomeAddress { get; set; }
        [BindProperty]
        public string HomePostalCode { get; set; }
        [BindProperty]
        public string HomePhone { get; set; }
        [BindProperty]
       
        public string AlternatePhone { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Please enter an email address")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$")]
        public string Email { get; set; }
        [BindProperty]
        public string DateOfBirth { get; set; }
        [BindProperty]
        
        public string Occupation { get; set; }
        [BindProperty]
        public string CompanyName { get; set; }
        [BindProperty]
        public string CompanyAddress { get; set; }
        [BindProperty]
        public string CompanyPostalCode { get; set; }
        [BindProperty]
        public string CompanyPhone { get; set; }
        [BindProperty]
        public decimal AmountPaid { get; set; }
        [BindProperty]
        public decimal BalanceDue { get; set; }
        [BindProperty]
        public decimal BalanceOwing { get; set; }
        [BindProperty]
      
        public decimal MakeAPayment { get; set; }
        [BindProperty]
        public decimal AmountStillOwing { get; set; }
        [BindProperty]
        public decimal PaymentDueDate { get; set; }
        [BindProperty]
        public string DateCharged { get; set; }
        [BindProperty]
        public string PaymentDescription { get; set; }
        [BindProperty]
        public string Decription { get; set; }
        [BindProperty]
        public int CreditCardNumber{ get; set; }
        [BindProperty]
        public string ExpiryDate { get; set; }
        [BindProperty]
        public string Currency { get; set; }
        [BindProperty]
        public string Date { get; set; }
        [BindProperty]
        public int PaymentID { get; set; }
        
        public List<SelectListItem> CurrencyType { get; } = new List<SelectListItem>
        {
            new SelectListItem{Value="", Text="---> Select Currency<---"},
            new SelectListItem{Value="CAD", Text="CAD"},
        };
        
        public List<SelectListItem> PaymentDesc { get; } = new List<SelectListItem>
        {
            new SelectListItem{Value="", Text="---> Select Payment Discription<---"},
            new SelectListItem{Value="Entrance Fee", Text="Entrance Fee"},
            new SelectListItem{Value="Membership Fee", Text="Membership Fee"},
            new SelectListItem{Value="Club Share Purchase", Text="Club Share Purchase"},
            new SelectListItem{Value="Food and Beverage", Text="Food and Beverage"},

        };
        private List<Member> _memberAccountInfo = new List<Member>();
        public List<Member> MemberAcctInformation
        {
            get
            {
                return _memberAccountInfo;
            }
        }
        public Member Member { get; set; }
       

        public void OnPostSearch()
        {
            if(ModelState.IsValid)
            { 
            CBS memberManager = new CBS();
            ActiveMember = memberManager.FindMember(Email);
            if (ActiveMember != null)
            {
                Message = "Members Account Found";
                MemberNumber = ActiveMember.MemberNumber;
                MembershipLevel = ActiveMember.MembershipLevel;
                LastName = ActiveMember.LastName;
                FirstName = ActiveMember.FirstName;
                HomeAddress = ActiveMember.HomeAddress;
                HomePostalCode = ActiveMember.HomePostalCode;
                HomePhone = ActiveMember.HomePhone;
                AlternatePhone = ActiveMember.AlternatePhone;
                Email = ActiveMember.Email;
                DateOfBirth = ActiveMember.DateOfBirth;
                Occupation = ActiveMember.Occupation;
                CompanyName = ActiveMember.CompanyName;
                CompanyAddress = ActiveMember.CompanyAddress;
                CompanyPostalCode = ActiveMember.CompanyPostalCode;
                CompanyPhone = ActiveMember.CompanyPhone;
                DateCharged = ActiveMember.DateCharged;
                PaymentDescription = ActiveMember.PaymentDescription;
                AmountPaid = ActiveMember.AmountPaid;
                BalanceDue = ActiveMember.BalanceDue;
                BalanceOwing = ActiveMember.BalanceOwing;
                

            }
            else
            {

                Message = "Member account was not found";
            }

        }
    }
        //public void OnPostSubmit()
        //{
        //    if(ModelState.IsValid)
        //    { 
        //    CBS PaymentDirector = new CBS();
           
        //    PaymentProcess = new PaymentProcess();
        //    PaymentProcess.Date = Date;
        //    PaymentProcess.LastName = LastName;
        //    PaymentProcess.FirstName = FirstName;
        //    PaymentProcess.CreditCardNumber = CreditCardNumber;
        //    PaymentProcess.ExpiryDate = ExpiryDate;
        //    PaymentProcess.Currency = Currency;
        //    PaymentProcess.PaymentDescription = PaymentDescription;
        //    PaymentProcess.PaymentID = PaymentID;
        //    PaymentProcess.AmountPaid = AmountPaid;
        //    PaymentProcess = PaymentDirector.ProcessPayment(PaymentProcess);

        //    if (PaymentID > 0)
        //    {

        //        Message = "Payment has been processesed ";

        //    }

        //    else
        //    {

        //        Message = "Payment has not been processed";
        //    }
        //    ModelState.Clear();

        //}
        //}


        public void OnGet()
        {
        }
    }
}
