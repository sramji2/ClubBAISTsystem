using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ClubBAISTsystem.Model.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClubBAISTsystem.Pages
{
    [BindProperties]
    public class RecordsMembershipApplicationModel : PageModel
    {
        public string Message { get; set; }
     
        public Member newMember { get; set; }
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
        public string AlternativePhone { get; set; }
        [BindProperty]
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
        public string Date { get; set; }
        [BindProperty]
        public string ShareholderName1 { get; set; }
        [BindProperty]
        public string ShareholderDate1 { get; set; }
        [BindProperty]
        public string ShareholderName2 { get; set; }
        [BindProperty]
        public string ShareholderDate2 { get; set; }
        [BindProperty]
        public string ApplicationStatus { get; set; }
        [BindProperty]
        public int ApplicationID { get; set; }
        [BindProperty]
        public string MembershipLevel { get; set; }
        [BindProperty]
        public string HomeProvince { get; set; }

        public List<SelectListItem> Level { get; } = new List<SelectListItem>
        {
            new SelectListItem{Value="", Text="---> Select Membership Level<---"},
            new SelectListItem{Value="Gold", Text="Gold"},
            new SelectListItem{Value="Silver", Text="Silver"},
            new SelectListItem{Value="Bronze", Text="Bronze"},
            new SelectListItem{Value="Cooper", Text="Cooper"}
        };
        public List<SelectListItem> HProvince { get; } = new List<SelectListItem>
        {
            new SelectListItem{Value="", Text="---> Select Home Province<---"},
            new SelectListItem{Value="Alberta", Text="Alberta"},
            new SelectListItem{Value="British Columbia", Text="British Columbia"},
            new SelectListItem{Value="Manitoba", Text="Manitoba"},
            new SelectListItem{Value="Newfoundland and Labrador", Text="Newfoundland and Labrador"},
            new SelectListItem{Value="Nova Scotia", Text="Nova Scotia"},
            new SelectListItem{Value="Ontario", Text="Ontario"},
            new SelectListItem{Value="Prince Edward Island", Text="Prince Edward Island"},
            new SelectListItem{Value="Quebec", Text="Quebec"},
            new SelectListItem{Value="Saskatchewan", Text="Saskatchewan"},
            new SelectListItem{Value="Northwest Territories", Text="Northwest Territories"},
            new SelectListItem{Value="Nunavut", Text="Nunavut"},
            new SelectListItem{Value="Yukon", Text="Yukon"},
        };
        public List<SelectListItem> CProvince { get; } = new List<SelectListItem>
        {
            new SelectListItem{Value="", Text="---> Select Home Province<---"},
            new SelectListItem{Value="Alberta", Text="Alberta"},
            new SelectListItem{Value="British Columbia", Text="British Columbia"},
            new SelectListItem{Value="Manitoba", Text="Manitoba"},
            new SelectListItem{Value="Newfoundland and Labrador", Text="Newfoundland and Labrador"},
            new SelectListItem{Value="Nova Scotia", Text="Nova Scotia"},
            new SelectListItem{Value="Ontario", Text="Ontario"},
            new SelectListItem{Value="Prince Edward Island", Text="Prince Edward Island"},
            new SelectListItem{Value="Quebec", Text="Quebec"},
            new SelectListItem{Value="Saskatchewan", Text="Saskatchewan"},
            new SelectListItem{Value="Northwest Territories", Text="Northwest Territories"},
            new SelectListItem{Value="Nunavut", Text="Nunavut"},
            new SelectListItem{Value="Yukon", Text="Yukon"},
        };

        public void OnPostSubmit()
        {
            if (ModelState.IsValid)
            { 
                CBS membershipManager = new CBS();

                newMember = membershipManager.RecordMembership(newMember);
                newMember.ApplicationStatus = "On-Hold";
                 if (newMember != null)
                {
                    Message = $"Your application to Club BAIST has been successfully completed." +
                    $" Here is your ApplicationID: {newMember.ApplicationID} and your Application Status {newMember.ApplicationStatus}";
                    HttpContext.Session.SetInt32("ApplicationID", ApplicationID);
                    newMember.MembershipLevel = MembershipLevel;
                    newMember.LastName = "";
                    newMember.FirstName = "";
                    newMember.HomeAddress = "";
                    newMember.HomeCity = "";
                    newMember.HomeProvince = HomeProvince;
                    newMember.HomePostalCode = "";
                    newMember.HomePhone = "";
                    newMember.AlternatePhone = "";
                    newMember.Email = "";
                    newMember.DateOfBirth = "";
                    newMember.Occupation = "";
                    newMember.CompanyName = "";
                    newMember.CompanyAddress = "";
                    newMember.CompanyPostalCode = "";
                    newMember.CompanyPhone = "";
                    newMember.Date = "";
                    newMember.ShareholderName1 = "";
                    newMember.ShareholderName2 = "";
                    newMember.ApplicationStatus = "On-Hold";
                    newMember.ApplicationID = ApplicationID;
                    

            }
            
            else
            {
                Message = "Member Application was not successful";
            }
            ModelState.Clear();
        }
        }
        public void OnGet()
        {
        }
    }
}
