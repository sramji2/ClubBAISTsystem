using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ClubBAISTsystem.Model.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClubBAISTsystem.Pages
{
    public class ReviewsMembershipApplicationModel : PageModel
    {
        public string Message { get; set; }

        //[BindProperty]
        public Member MemberApplication { get; set; }
        [BindProperty]
        public int ApplicationID { get; set; }
        [BindProperty]
        public string LastName { get; set; }
        [BindProperty]    
        public string FirstName { get; set; }
        [BindProperty]        
        public string MembershipLevel { get; set; }
        [BindProperty]       
        public string HomeAddress { get; set; }
        [BindProperty]
        public string HomeCity { get; set; }
        [BindProperty]
        public string HomeProvince { get; set; }
        [BindProperty]       
        public string HomePostalCode { get; set; }
        [BindProperty]
        public string HomePhone { get; set; }
        [BindProperty]      
        public string AlternatePhone { get; set; }
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
        public string CompanyCity { get; set; }
        [BindProperty]
        public string CompanyProvince { get; set; }
        [BindProperty]        
        public string CompanyPostalCode { get; set; }
        [BindProperty]        
        public string CompanyPhone { get; set; }
        [BindProperty]       
        public string ShareholderName1 { get; set; }
        [BindProperty]        
        public string ShareholderName2 { get; set; }
        [BindProperty]
        public string Date { get; set; }
        [BindProperty]        
        public string ApprovedBy { get; set; }
        [BindProperty]        
        public string ApplicationStatus { get; set; }
        [BindProperty]
        public List<SelectListItem> Status { get; } = new List<SelectListItem>
        {
            new SelectListItem{Value="", Text="---> Select Application Status<---"},
            new SelectListItem{Value="Accepted", Text="Accepted"},
            new SelectListItem{Value="Denied", Text="Denied"},
            new SelectListItem{Value="On-Hold", Text="On-Hold"},
            new SelectListItem{Value="Waitlisted", Text="Waitlisted"}
        };
        public void OnPostSearch()
        {
            
            if (ModelState.IsValid)
            {
                CBS memberManager = new CBS();
                Member MemberApplication = memberManager.FindApplication(ApplicationStatus);
                string SerializedActivePlayer = JsonSerializer.Serialize(MemberApplication);
                HttpContext.Session.SetString("MemberApplication", SerializedActivePlayer);

                if (MemberApplication != null)
                {
                    Message = "Application found";
                    ApplicationID = MemberApplication.ApplicationID;
                    ApplicationStatus = MemberApplication.ApplicationStatus;
                    MembershipLevel = MemberApplication.MembershipLevel;
                    LastName = MemberApplication.LastName;
                    FirstName = MemberApplication.FirstName;
                    HomeAddress = MemberApplication.HomeAddress;
                    HomeCity = MemberApplication.HomeCity;
                    HomeProvince = MemberApplication.HomeProvince;
                    HomePostalCode = MemberApplication.HomePostalCode;
                    HomePhone = MemberApplication.HomePhone;
                    AlternatePhone = MemberApplication.AlternatePhone;
                    Email = MemberApplication.Email;
                    DateOfBirth = MemberApplication.DateOfBirth;
                    Occupation = MemberApplication.Occupation;
                    CompanyName = MemberApplication.CompanyName;
                    CompanyAddress = MemberApplication.CompanyAddress;
                    CompanyCity = MemberApplication.CompanyCity;
                    CompanyProvince = MemberApplication.CompanyProvince;
                    CompanyPostalCode = MemberApplication.CompanyPostalCode;
                    CompanyPhone = MemberApplication.CompanyPhone;
                    Date = MemberApplication.Date;
                    ShareholderName1 = MemberApplication.ShareholderName1;
                    ShareholderName2 = MemberApplication.ShareholderName2;
                    ApprovedBy = MemberApplication.ApprovedBy;
                    HttpContext.Session.SetInt32("ApplicationID", ApplicationID);



                }
                else
                {

                    Message = "Member Application was not found";
                }


            }
        }

        public void OnPostUpdate()
        {
            if (ModelState.IsValid)
            {

                CBS memberManager = new CBS();
                MemberApplication = new Member();

                string DeserializedJson = HttpContext.Session.GetString("MemberApplication");
                MemberApplication = JsonSerializer.Deserialize<Member>(DeserializedJson);

                MemberApplication.ApplicationID = (int)HttpContext.Session.GetInt32("ApplicationID");
                MemberApplication.ApplicationStatus = ApplicationStatus;
                MemberApplication.MembershipLevel = MembershipLevel;
                MemberApplication.LastName = LastName;
                MemberApplication.FirstName = FirstName;
                MemberApplication.HomeAddress = HomeAddress;
                MemberApplication.HomeCity = HomeCity;
                MemberApplication.HomeProvince= HomeProvince;
                MemberApplication.HomePostalCode = HomePostalCode;
                MemberApplication.AlternatePhone = AlternatePhone;
                MemberApplication.Email = Email;
                MemberApplication.DateOfBirth = DateOfBirth;
                MemberApplication.Occupation = Occupation;
                MemberApplication.CompanyName = CompanyName;
                MemberApplication.CompanyAddress = CompanyAddress;
                MemberApplication.CompanyCity = CompanyCity;
                MemberApplication.CompanyProvince = CompanyProvince;
                MemberApplication.CompanyPostalCode = CompanyPostalCode;
                MemberApplication.Date = Date;
                MemberApplication.ShareholderName1 = ShareholderName1;
                MemberApplication.ShareholderName2 = ShareholderName2;
                MemberApplication.ApprovedBy = ApprovedBy;
                bool Confirmation = memberManager.ModifyApplication(MemberApplication);

                if (Confirmation)
                {

                    Message = $"Member Application for {Email} has been updated.";



                }
                else
                {

                    Message = "Member Application has not been updated";
                }
            }
        }
            
        public void OnGet()
        {
          
        }
    }
}
