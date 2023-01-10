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
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using System.Text.Json;

namespace ClubBAISTsystem.Pages
{
    public class MakesStandingTeeTimeRequestModel : PageModel
    {
        [BindProperty]
        public StandingTeeTime newStandingTeeTime { get; set; }
        public string Message { get; set; }
        public string Message2 { get; set; }
        [BindProperty]
        public int MemberNumber { get; set; }
        [BindProperty]
        public string MembershipLevel { get; set; }
        [BindProperty]
        public string Role { get; set; }
        [BindProperty]
        public string RequestedDayOfWeek { get; set; }
        [BindProperty]
        public string RequestedStartDate { get; set; }
        [BindProperty]
        public string RequestedEndDate { get; set; }
        [BindProperty]
        public string RequestedTeeTime { get; set; }
        [BindProperty]
        public string MemberName { get; set; }
        [BindProperty]
        public string MemberName2 { get; set; }
        [BindProperty]
        public string MemberName3 { get; set; }
        [BindProperty]
        public string MemberName4 { get; set; }
        [BindProperty]
        public int MemberNumber2 { get; set; }
        [BindProperty]
        public int MemberNumber3 { get; set; }
        [BindProperty]
        public int MemberNumber4 { get; set; }
        public string ApprovedBy { get; set; }
        public bool CanceledBy { get; set; }
        public string ApprovedDate { get; set; }
        public string ApprovedTeeTime { get; set; }
        [BindProperty]
        public int PriorityNumber { get; set; }
   

       

        public void OnPostSubmit()
        {
            if(ModelState.IsValid)
            {
                CBS teeTimeManager = new CBS();
                
                PriorityNumber = teeTimeManager.BookStandingTeeTime(newStandingTeeTime);
                newStandingTeeTime.MembershipLevel = "Gold";
                //newStandingTeeTime.Role = "Shareholder";
                if (PriorityNumber > 0)
                {

                Message = $"Standing Tee Time has been requested {PriorityNumber}";
                newStandingTeeTime.MembershipLevel = "Gold";
                newStandingTeeTime.Role = Role;
                newStandingTeeTime.RequestedDayOfWeek = RequestedDayOfWeek;
                newStandingTeeTime.RequestedStartDate = RequestedStartDate;
                newStandingTeeTime.RequestedEndDate = RequestedEndDate;
                newStandingTeeTime.RequestedTeeTime = RequestedTeeTime;
                newStandingTeeTime.MemberNumber = MemberNumber;
                newStandingTeeTime.MemberName = MemberName;
                newStandingTeeTime.MemberNumber2 = MemberNumber2;
                newStandingTeeTime.MemberName2 = MemberName2;
                newStandingTeeTime.MemberNumber3 = MemberNumber3;
                newStandingTeeTime.MemberName3 = MemberName3;
                newStandingTeeTime.MemberNumber4 = MemberNumber4;
                newStandingTeeTime.MemberName4 = MemberName4; 
                newStandingTeeTime.PriorityNumber = PriorityNumber;

                    //removed = ...newstandingTeeTime...
                    //moved ModelState.Clear(); to bottom

                }
            
                else
                {
                    Message2 = "Standing Tee Time was not successful.";
                }
                ModelState.Clear();
            }
        }


        public void OnGet()
        {
            foreach (Claim claim in User.Claims)
            {
                if (claim.Type == ClaimTypes.NameIdentifier)
                {
                    MemberNumber = Convert.ToInt32(claim.Value);
                }
                if (claim.Type == ClaimTypes.UserData)
                {
                    MembershipLevel = claim.Value;
                    //newStandingTeeTime.MembershipLevel = claim.Value;
                }
                if (claim.Type == ClaimTypes.Role)
                {
                    Role = claim.Value;
                    //newStandingTeeTime.Role = claim.Value;
                }
            }
            if (MembershipLevel == "Gold" || Role == "Shareholder")
            {
                Message = "Welcome";
            }
            else
            {
                Message = "You are not allowed to access this page";
                RedirectToPage("/Welcome");
            }
        }
    }
}
