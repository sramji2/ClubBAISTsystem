using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using ClubBAISTsystem.Model.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClubBAISTsystem.Pages
{
    public class CancelsStandingTeeTimeRequestModel : PageModel
    {
        public string Message { get; set; }
        //[BindProperty]
        public StandingTeeTime RequestSTT { get; set; }
        [BindProperty]
        public int PriorityNumber { get; set; }
        [BindProperty]
        public int MemberNumber { get; set; }
        [BindProperty]
        public string Time { get; set; }
        [BindProperty]
        public string Date { get; set; }
        [BindProperty]
        public string MembershipLevel { get; set; }
        [BindProperty]
         public string Email { get; set; }
        [BindProperty]
        public string Role { get; set; }
        [BindProperty]
        public string RequestedDayOfWeek { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Please enter a Requested Start Date")]
        public string RequestedStartDate { get; set; }
        [BindProperty]
        public string RequestedEndDate { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Please enter a Requested Tee Time")]
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

        private List<StandingTeeTime> _requestedStandingTeeTime = new List<StandingTeeTime>();
        StandingTeeTime requestStandingTeeTime = new StandingTeeTime();

        public List<StandingTeeTime> RequestedStandingTeeTime
        {
            get
            {
                return _requestedStandingTeeTime;
            }
        }
        public void OnPostSearch()
        {
            if (ModelState.IsValid)
            {
                CBS RequestDirector = new CBS();
                StandingTeeTime RequestSTT = RequestDirector.FindStandingTeeTime(RequestedStartDate, RequestedTeeTime);
                if (RequestSTT != null)
                {
                    Message = $"Standing Tee Time Request Found {RequestedStartDate} and {RequestedTeeTime}";
                   
                    MembershipLevel = RequestSTT.MembershipLevel;
                    Role = RequestSTT.Role;
                    RequestedDayOfWeek = RequestSTT.RequestedDayOfWeek;
                    RequestedStartDate = RequestSTT.RequestedStartDate;
                    RequestedEndDate = RequestSTT.RequestedEndDate;
                    RequestedTeeTime = RequestSTT.RequestedTeeTime;
                    MemberNumber = RequestSTT.MemberNumber;
                    MemberName = RequestSTT.MemberName;
                    MemberNumber2 = RequestSTT.MemberNumber2;
                    MemberName2 = RequestSTT.MemberName2;
                    MemberNumber3 = RequestSTT.MemberNumber3;
                    MemberName3 = RequestSTT.MemberName3;
                    MemberNumber4 = RequestSTT.MemberNumber4;
                    MemberName4 = RequestSTT.MemberName4;
                    ApprovedTeeTime = RequestSTT.ApprovedTeeTime;
                    ApprovedBy = RequestSTT.ApprovedBy;
                    ApprovedDate = RequestSTT.ApprovedDate;
                    PriorityNumber = RequestSTT.PriorityNumber;
                    HttpContext.Session.SetInt32("PriorityNumber", PriorityNumber);
                    HttpContext.Session.SetString("RequestedStartDate", RequestedStartDate);
                    HttpContext.Session.SetString("RequestedTeeTime", RequestedTeeTime);

                }
                //This else statement doesn't catch
                else
                {
                    Message = $"{RequestedStartDate} and {RequestedTeeTime} Not Found.";
                }
                ModelState.Clear();
            }
        }

        public void OnPostClear()
        {
            ModelState["RequestedStartDate"].ValidationState = ModelValidationState.Valid;
            ModelState["RequestedTeeTime"].ValidationState = ModelValidationState.Valid;
            if (ModelState.IsValid)
            {
                CBS RequestDirector = new CBS();
                RequestSTT = new StandingTeeTime();

                RequestedStartDate = HttpContext.Session.GetString("RequestedStartDate");
                RequestedTeeTime = HttpContext.Session.GetString("RequestedTeeTime");
                bool Confirmation = RequestDirector.RemoveStandingTeeTime(RequestedStartDate, RequestedTeeTime);

                if (Confirmation)
                {

                    Message = $"Standing Tee Time Request has been deleted {RequestedStartDate} and {RequestedTeeTime}.";

                }
                else
                {

                    Message = $"Standing Tee Time Request was not deleted {RequestedStartDate} and {RequestedTeeTime}.";
                }
                ModelState.Clear();
            }
        }

        public void OnPostUpdate()
        {

            CBS teeTimeManager = new CBS();

            bool Confirmation = teeTimeManager.ModifyStandingTeeTime(RequestSTT);
            ModelState.Clear();

            if (Confirmation)
            {

                Message = $"Update Standing Tee Time {PriorityNumber} was successful";



            }
            else
            {

                Message = "Standing Tee Time Reservation was not updated";
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
        
    

