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
    public class BookTeeTimeModel : PageModel
    {
        //[BindProperty]
        //public TeeTime newTeeTime { get; set; }
        [BindProperty]
        public TeeTime AvailableTeeTime { get; set; }

        public string Message { get; set; }
        public string Message2 { get; set; }
        [BindProperty]
        public int ConfirmationNumber { get; set; }
        [BindProperty]
        
        public string Date { get; set; }
        [BindProperty]
        public string Time { get; set; }
        [BindProperty]
        public int MemberNumber { get; set; }
        [BindProperty]
        public string MembershipLevel { get; set; }
        [BindProperty]
        public string LastName { get; set; }
        [BindProperty]
        public string FirstName { get; set; }
        [BindProperty]
        public string EmployeeName { get; set; }
        [BindProperty]
        public string CheckedIn { get; set; }
        [BindProperty]
        [StringLength(15, MinimumLength = 10, ErrorMessage ="Home Phone must be XXX-XXX-XXXX")]
        public string HomePhone { get; set; }
        [BindProperty]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "Home Phone must be XXX-XXX-XXXX")]
        public string AlternatePhone { get; set; }
        [BindProperty]
        [Range(1, 4, ErrorMessage = "Number of Carts must be between 1-4")]
        public int NumberOfPlayers { get; set; }
        [BindProperty]
        [Range(1, 4, ErrorMessage = "Number of Carts must be between 1-4")]
        public int NumberOfCarts { get; set; }
        [BindProperty]
        public List<SelectListItem> TimeLists { get; set; }
        [BindProperty]
        public string Role { get; set; }
        public string DeserializedJson { get; private set; }

        //removed [Required]
        public void OnPostSearch()
        {
            ModelState["LastName"].ValidationState = ModelValidationState.Valid;
            ModelState["FirstName"].ValidationState = ModelValidationState.Valid;
            ModelState["HomePhone"].ValidationState = ModelValidationState.Valid;
            ModelState["AlternatePhone"].ValidationState = ModelValidationState.Valid;
            ModelState["NumberOfCarts"].ValidationState = ModelValidationState.Valid;
            ModelState["NumberOfPlayers"].ValidationState = ModelValidationState.Valid;

            if (ModelState.IsValid)
            {
               
                CBS teeTimeManager = new CBS();
                AvailableTeeTime = teeTimeManager.FindTeeTime(Date, Time);

                if (AvailableTeeTime != null)
                {
                    Message = $"Tee Time {Time} and Date {Date} is not available.";

                    HttpContext.Session.SetString("Date", Date);
                    HttpContext.Session.SetString("Time", Time);
                    HttpContext.Session.SetString("LastName", AvailableTeeTime.LastName);
                    HttpContext.Session.SetString("FirstName", AvailableTeeTime.FirstName);
                    HttpContext.Session.SetString("HomePhone", AvailableTeeTime.HomePhone);
                    HttpContext.Session.SetString("MembershipLevel", AvailableTeeTime.MembershipLevel);
                    //Date = AvailableTeeTime.Date;
                    //Time = AvailableTeeTime.Time;
                    //MembershipLevel = AvailableTeeTime.MembershipLevel;
                    //LastName = AvailableTeeTime.LastName;
                    //FirstName = AvailableTeeTime.FirstName;
                    //NumberOfPlayers = AvailableTeeTime.NumberOfPlayers;
                    //HomePhone = AvailableTeeTime.HomePhone;
                    //AlternatePhone = AvailableTeeTime.AlternatePhone;
                    //NumberOfCarts = AvailableTeeTime.NumberOfCarts;
                    //EmployeeName = AvailableTeeTime.EmployeeName;

                }
                else
                {
                    Message = $"Date: {Date} and Time: {Time} is available.";

                }
                //added this here
                ModelState.Clear();
            }
            DeserializedJson = HttpContext.Session.GetString("TimeLists");
            TimeLists = JsonSerializer.Deserialize<List<SelectListItem>>(DeserializedJson);
        }
        

        public void OnPostSubmit()
        {
            if (ModelState.IsValid)
            {

                CBS teeTimeManager = new CBS();

                ConfirmationNumber = teeTimeManager.BookTeeTime(AvailableTeeTime);
                if (ConfirmationNumber > 0)
                {
                    Message = $"Booked Tee Time is completed {ConfirmationNumber}";
                    AvailableTeeTime.ConfirmationNumber = ConfirmationNumber;
                    AvailableTeeTime.Date = AvailableTeeTime.Date;
                    AvailableTeeTime.Time = AvailableTeeTime.Time;
                    AvailableTeeTime.MembershipLevel = AvailableTeeTime.MembershipLevel;
                    AvailableTeeTime.LastName = AvailableTeeTime.LastName;
                    AvailableTeeTime.FirstName = AvailableTeeTime.FirstName;
                    AvailableTeeTime.HomePhone = AvailableTeeTime.HomePhone;
                    AvailableTeeTime.AlternatePhone = AvailableTeeTime.AlternatePhone;
                    AvailableTeeTime.NumberOfPlayers = AvailableTeeTime.NumberOfPlayers;
                    AvailableTeeTime.EmployeeName = AvailableTeeTime.EmployeeName;

                }
                else
                {
                    Message = "Booked Tee Time was not successful.";
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
                }
                if (claim.Type == ClaimTypes.Role)
                {
                    Role = claim.Value;
                    //newTeeTime.Role = claim.Value;
                }
            }

            if (MembershipLevel == "Gold")
            {
                TimeLists = new List<SelectListItem>
                {
                   new SelectListItem{Value="", Text="---> select Tee Time <---"},
                   new SelectListItem{Value="7:00 am", Text="7:00 am"},
                   new SelectListItem{Value="7:07 am", Text="7:07 am"},
                   new SelectListItem{Value="7:15 am", Text="7:15 am"},
                   new SelectListItem{Value="7:22 am", Text="7:22 am"},
                   new SelectListItem{Value="7:30 am", Text="7:30 am"},
                   new SelectListItem{Value="7:37 am", Text="7:37 am"},
                   new SelectListItem{Value="7:45 am", Text="7:45 am"},
                   new SelectListItem{Value="7:52 am", Text="7:52 am"},
                   new SelectListItem{Value="8:00 am", Text="8:00 am"},
                   new SelectListItem{Value="8:07 am", Text="8:07 am"},
                   new SelectListItem{Value="8:15 am", Text="8:15 am"},
                   new SelectListItem{Value="8:22 am", Text="8:22 am"},
                   new SelectListItem{Value="8:30 am", Text="8:30 am"},
                   new SelectListItem{Value="8:37 am", Text="8:37 am"},
                   new SelectListItem{Value="8:45 am", Text="8:45 am"},
                   new SelectListItem{Value="8:52 am", Text="8:52 am"},
                   new SelectListItem{Value="9:00 am", Text="9:00 am"},
                   new SelectListItem{Value="9:07 am", Text="9:07 am"},
                   new SelectListItem{Value="9:15 am", Text="9:15 am"},
                   new SelectListItem{Value="9:22 am", Text="9:22 am"},
                   new SelectListItem{Value="9:30 am", Text="9:30 am"},
                   new SelectListItem{Value="9:37 am", Text="9:37 am"},
                   new SelectListItem{Value="9:45 am", Text="9:45 am"},
                   new SelectListItem{Value="10:52 am", Text="10:52 am"},
                   new SelectListItem{Value="11:00 am", Text="11:00 am"},
                   new SelectListItem{Value="11:07 am", Text="11:07 am"},
                   new SelectListItem{Value="11:15 am", Text="11:15 am"},
                   new SelectListItem{Value="11:22 am", Text="11:22 am"},
                   new SelectListItem{Value="11:30 am", Text="11:30 am"},
                   new SelectListItem{Value="11:37 am", Text="11:37 am"},
                   new SelectListItem{Value="11:45 am", Text="11:45 am"},
                   new SelectListItem{Value="11:52 am", Text="11:52 am"},
                   new SelectListItem{Value="12:00 pm", Text="12:00 pm"},
                   new SelectListItem{Value="12:07 pm", Text="12:07 pm"},
                   new SelectListItem{Value="12:15 pm", Text="12:15 pm"},
                   new SelectListItem{Value="12:22 pm", Text="12:22 pm"},
                   new SelectListItem{Value="12:30 pm", Text="12:30 pm"},
                   new SelectListItem{Value="12:37 pm", Text="12:37 pm"},
                   new SelectListItem{Value="12:45 pm", Text="12:45 pm"},
                   new SelectListItem{Value="12:52 pm", Text="12:52 pm"},
                   new SelectListItem{Value="1:00 pm", Text="1:00 pm"},
                   new SelectListItem{Value="1:07 pm", Text="1:07 pm"},
                   new SelectListItem{Value="1:15 pm", Text="1:15 pm"},
                   new SelectListItem{Value="1:22 pm", Text="1:22 pm"},
                   new SelectListItem{Value="1:30 pm", Text="1:30 pm"},
                   new SelectListItem{Value="1:37 pm", Text="1:37 pm"},
                   new SelectListItem{Value="1:45 pm", Text="1:45 pm"},
                   new SelectListItem{Value="1:52 pm", Text="1:52 pm"},
                   new SelectListItem{Value="2:00 pm", Text="2:00 pm"},
                   new SelectListItem{Value="2:07 pm", Text="2:07 pm"},
                   new SelectListItem{Value="2:15 pm", Text="2:15 pm"},
                   new SelectListItem{Value="2:22 pm", Text="2:22 pm"},
                   new SelectListItem{Value="2:30 pm", Text="2:30 pm"},
                   new SelectListItem{Value="2:37 pm", Text="2:37 pm"},
                   new SelectListItem{Value="2:45 pm", Text="2:45 pm"},
                   new SelectListItem{Value="2:52 pm", Text="2:52 pm"},
                   new SelectListItem{Value="3:00 pm", Text="3:00 pm"},
                   new SelectListItem{Value="3:07 pm", Text="3:07 pm"},
                   new SelectListItem{Value="3:15 pm", Text="3:15 pm"},
                   new SelectListItem{Value="3:22 pm", Text="3:22 pm"},
                   new SelectListItem{Value="3:30 pm", Text="3:30 pm"},
                   new SelectListItem{Value="3:37 pm", Text="3:37 pm"},
                   new SelectListItem{Value="3:45 pm", Text="3:45 pm"},
                   new SelectListItem{Value="3:52 pm", Text="3:52 pm"},
                   new SelectListItem{Value="4:00 pm", Text="4:00 pm"},
                   new SelectListItem{Value="4:07 pm", Text="4:07 pm"},
                   new SelectListItem{Value="4:15 pm", Text="4:15 pm"},
                   new SelectListItem{Value="4:22 pm", Text="4:22 pm"},
                   new SelectListItem{Value="4:30 pm", Text="4:30 pm"},
                   new SelectListItem{Value="4:37 pm", Text="4:37 pm"},
                   new SelectListItem{Value="4:45 pm", Text="4:45 pm"},
                   new SelectListItem{Value="4:52 pm", Text="4:52 pm"},
                   new SelectListItem{Value="5:00 pm", Text="5:00 pm"},
                   new SelectListItem{Value="5:07 pm", Text="5:07 pm"},
                   new SelectListItem{Value="5:15 pm", Text="5:15 pm"},
                   new SelectListItem{Value="5:22 pm", Text="5:22 pm"},
                   new SelectListItem{Value="5:30 pm", Text="5:30 pm"},
                   new SelectListItem{Value="5:37 pm", Text="5:37 pm"},
                   new SelectListItem{Value="5:45 pm", Text="5:45 pm"},
                   new SelectListItem{Value="5:52 pm", Text="5:52 pm"},
                   new SelectListItem{Value="6:00 pm", Text="6:00 pm"},
                   new SelectListItem{Value="6:07 pm", Text="6:07 pm"},
                   new SelectListItem{Value="6:15 pm", Text="6:15 pm"},
                   new SelectListItem{Value="6:22 pm", Text="6:22 pm"},
                   new SelectListItem{Value="6:30 pm", Text="6:30 pm"},
                   new SelectListItem{Value="6:37 pm", Text="6:37 pm"},
                   new SelectListItem{Value="6:45 pm", Text="6:45 pm"},
                   new SelectListItem{Value="6:52 pm", Text="6:52 pm"},
                   new SelectListItem{Value="7:00 pm", Text="7:00 pm"},

                };
            }
            else if (MembershipLevel == "Silver")
            {
                TimeLists = new List<SelectListItem>
                    {
                       new SelectListItem{Value="", Text="---> select Tee Time <---"},
                       new SelectListItem{Value="7:00 am", Text="7:00 am"},
                       new SelectListItem{Value="7:07 am", Text="7:07 am"},
                       new SelectListItem{Value="7:15 am", Text="7:15 am"},
                       new SelectListItem{Value="7:22 am", Text="7:22 am"},
                       new SelectListItem{Value="7:30 am", Text="7:30 am"},
                       new SelectListItem{Value="7:37 am", Text="7:37 am"},
                       new SelectListItem{Value="7:45 am", Text="7:45 am"},
                       new SelectListItem{Value="7:52 am", Text="7:52 am"},
                       new SelectListItem{Value="8:00 am", Text="8:00 am"},
                       new SelectListItem{Value="8:07 am", Text="8:07 am"},
                       new SelectListItem{Value="8:15 am", Text="8:15 am"},
                       new SelectListItem{Value="8:22 am", Text="8:22 am"},
                       new SelectListItem{Value="8:30 am", Text="8:30 am"},
                       new SelectListItem{Value="8:37 am", Text="8:37 am"},
                       new SelectListItem{Value="8:45 am", Text="8:45 am"},
                       new SelectListItem{Value="8:52 am", Text="8:52 am"},
                       new SelectListItem{Value="9:00 am", Text="9:00 am"},
                       new SelectListItem{Value="9:00 am", Text="9:00 am"},
                       new SelectListItem{Value="9:07 am", Text="9:07 am"},
                       new SelectListItem{Value="9:15 am", Text="9:15 am"},
                       new SelectListItem{Value="9:22 am", Text="9:22 am"},
                       new SelectListItem{Value="9:30 am", Text="9:30 am"},
                       new SelectListItem{Value="9:37 am", Text="9:37 am"},
                       new SelectListItem{Value="9:45 am", Text="9:45 am"},
                       new SelectListItem{Value="10:52 am", Text="10:52 am"},
                       new SelectListItem{Value="11:00 am", Text="11:00 am"},
                       new SelectListItem{Value="11:07 am", Text="11:07 am"},
                       new SelectListItem{Value="11:15 am", Text="11:15 am"},
                       new SelectListItem{Value="11:22 am", Text="11:22 am"},
                       new SelectListItem{Value="11:30 am", Text="11:30 am"},
                       new SelectListItem{Value="11:37 am", Text="11:37 am"},
                       new SelectListItem{Value="11:45 am", Text="11:45 am"},
                       new SelectListItem{Value="11:52 am", Text="11:52 am"},
                       new SelectListItem{Value="12:00 pm", Text="12:00 pm"},
                       new SelectListItem{Value="12:07 pm", Text="12:07 pm"},
                       new SelectListItem{Value="12:15 pm", Text="12:15 pm"},
                       new SelectListItem{Value="12:22 pm", Text="12:22 pm"},
                       new SelectListItem{Value="12:30 pm", Text="12:30 pm"},
                       new SelectListItem{Value="12:37 pm", Text="12:37 pm"},
                       new SelectListItem{Value="12:45 pm", Text="12:45 pm"},
                       new SelectListItem{Value="12:52 pm", Text="12:52 pm"},
                       new SelectListItem{Value="1:00 pm", Text="1:00 pm"},
                       new SelectListItem{Value="1:07 pm", Text="1:07 pm"},
                       new SelectListItem{Value="1:15 pm", Text="1:15 pm"},
                       new SelectListItem{Value="1:22 pm", Text="1:22 pm"},
                       new SelectListItem{Value="1:30 pm", Text="1:30 pm"},
                       new SelectListItem{Value="1:37 pm", Text="1:37 pm"},
                       new SelectListItem{Value="1:45 pm", Text="1:45 pm"},
                       new SelectListItem{Value="1:52 pm", Text="1:52 pm"},
                       new SelectListItem{Value="2:00 pm", Text="2:00 pm"},
                       new SelectListItem{Value="2:07 pm", Text="2:07 pm"},
                       new SelectListItem{Value="2:15 pm", Text="2:15 pm"},
                       new SelectListItem{Value="2:22 pm", Text="2:22 pm"},
                       new SelectListItem{Value="2:30 pm", Text="2:30 pm"},
                       new SelectListItem{Value="2:37 pm", Text="2:37 pm"},
                       new SelectListItem{Value="2:45 pm", Text="2:45 pm"},
                       new SelectListItem{Value="2:52 pm", Text="2:52 pm"},
                       new SelectListItem{Value="5:37 pm", Text="5:37 pm"},
                       new SelectListItem{Value="5:45 pm", Text="5:45 pm"},
                       new SelectListItem{Value="5:52 pm", Text="5:52 pm"},
                       new SelectListItem{Value="6:00 pm", Text="6:00 pm"},
                       new SelectListItem{Value="6:07 pm", Text="6:07 pm"},
                       new SelectListItem{Value="6:15 pm", Text="6:15 pm"},
                       new SelectListItem{Value="6:22 pm", Text="6:22 pm"},
                       new SelectListItem{Value="6:30 pm", Text="6:30 pm"},
                       new SelectListItem{Value="6:37 pm", Text="6:37 pm"},
                       new SelectListItem{Value="6:45 pm", Text="6:45 pm"},
                       new SelectListItem{Value="6:52 pm", Text="6:52 pm"},
                       new SelectListItem{Value="7:00 pm", Text="7:00 pm"},

                    };
            }
            else if (MembershipLevel == "Bronze")
            {
                TimeLists = new List<SelectListItem>
                    {
                       new SelectListItem{Value="", Text="---> select Tee Time <---"},
                       new SelectListItem{Value="7:00 am", Text="7:00 am"},
                       new SelectListItem{Value="7:07 am", Text="7:07 am"},
                       new SelectListItem{Value="7:15 am", Text="7:15 am"},
                       new SelectListItem{Value="7:22 am", Text="7:22 am"},
                       new SelectListItem{Value="7:30 am", Text="7:30 am"},
                       new SelectListItem{Value="7:37 am", Text="7:37 am"},
                       new SelectListItem{Value="7:45 am", Text="7:45 am"},
                       new SelectListItem{Value="7:52 am", Text="7:52 am"},
                       new SelectListItem{Value="8:00 am", Text="8:00 am"},
                       new SelectListItem{Value="8:07 am", Text="8:07 am"},
                       new SelectListItem{Value="8:15 am", Text="8:15 am"},
                       new SelectListItem{Value="8:22 am", Text="8:22 am"},
                       new SelectListItem{Value="8:30 am", Text="8:30 am"},
                       new SelectListItem{Value="8:37 am", Text="8:37 am"},
                       new SelectListItem{Value="8:45 am", Text="8:45 am"},
                       new SelectListItem{Value="8:52 am", Text="8:52 am"},
                       new SelectListItem{Value="9:00 am", Text="9:00 am"},
                       new SelectListItem{Value="8:00 am", Text="8:00 am"},
                       new SelectListItem{Value="8:07 am", Text="8:07 am"},
                       new SelectListItem{Value="8:15 am", Text="8:15 am"},
                       new SelectListItem{Value="8:22 am", Text="8:22 am"},
                       new SelectListItem{Value="8:30 am", Text="8:30 am"},
                       new SelectListItem{Value="8:37 am", Text="8:37 am"},
                       new SelectListItem{Value="8:45 am", Text="8:45 am"},
                       new SelectListItem{Value="8:52 am", Text="8:52 am"},
                       new SelectListItem{Value="9:00 am", Text="9:00 am"},
                       new SelectListItem{Value="9:07 am", Text="9:07 am"},
                       new SelectListItem{Value="9:15 am", Text="9:15 am"},
                       new SelectListItem{Value="9:22 am", Text="9:22 am"},
                       new SelectListItem{Value="9:30 am", Text="9:30 am"},
                       new SelectListItem{Value="9:37 am", Text="9:37 am"},
                       new SelectListItem{Value="9:45 am", Text="9:45 am"},
                       new SelectListItem{Value="10:52 am", Text="10:52 am"},
                       new SelectListItem{Value="11:00 am", Text="11:00 am"},
                       new SelectListItem{Value="11:07 am", Text="11:07 am"},
                       new SelectListItem{Value="11:15 am", Text="11:15 am"},
                       new SelectListItem{Value="11:22 am", Text="11:22 am"},
                       new SelectListItem{Value="11:30 am", Text="11:30 am"},
                       new SelectListItem{Value="11:37 am", Text="11:37 am"},
                       new SelectListItem{Value="11:45 am", Text="11:45 am"},
                       new SelectListItem{Value="11:52 am", Text="11:52 am"},
                       new SelectListItem{Value="12:00 pm", Text="12:00 pm"},
                       new SelectListItem{Value="12:07 pm", Text="12:07 pm"},
                       new SelectListItem{Value="12:15 pm", Text="12:15 pm"},
                       new SelectListItem{Value="12:22 pm", Text="12:22 pm"},
                       new SelectListItem{Value="12:30 pm", Text="12:30 pm"},
                       new SelectListItem{Value="12:37 pm", Text="12:37 pm"},
                       new SelectListItem{Value="12:45 pm", Text="12:45 pm"},
                       new SelectListItem{Value="12:52 pm", Text="12:52 pm"},
                       new SelectListItem{Value="1:00 pm", Text="1:00 pm"},
                       new SelectListItem{Value="1:07 pm", Text="1:07 pm"},
                       new SelectListItem{Value="1:15 pm", Text="1:15 pm"},
                       new SelectListItem{Value="1:22 pm", Text="1:22 pm"},
                       new SelectListItem{Value="1:30 pm", Text="1:30 pm"},
                       new SelectListItem{Value="1:37 pm", Text="1:37 pm"},
                       new SelectListItem{Value="1:45 pm", Text="1:45 pm"},
                       new SelectListItem{Value="1:52 pm", Text="1:52 pm"},
                       new SelectListItem{Value="2:00 pm", Text="2:00 pm"},
                       new SelectListItem{Value="2:07 pm", Text="2:07 pm"},
                       new SelectListItem{Value="2:15 pm", Text="2:15 pm"},
                       new SelectListItem{Value="2:22 pm", Text="2:22 pm"},
                       new SelectListItem{Value="2:30 pm", Text="2:30 pm"},
                       new SelectListItem{Value="2:37 pm", Text="2:37 pm"},
                       new SelectListItem{Value="2:45 pm", Text="2:45 pm"},
                       new SelectListItem{Value="2:52 pm", Text="2:52 pm"},
                       new SelectListItem{Value="6:07 pm", Text="6:07 pm"},
                       new SelectListItem{Value="6:15 pm", Text="6:15 pm"},
                       new SelectListItem{Value="6:22 pm", Text="6:22 pm"},
                       new SelectListItem{Value="6:30 pm", Text="6:30 pm"},
                       new SelectListItem{Value="6:37 pm", Text="6:37 pm"},
                       new SelectListItem{Value="6:45 pm", Text="6:45 pm"},
                       new SelectListItem{Value="6:52 pm", Text="6:52 pm"},
                       new SelectListItem{Value="7:00 pm", Text="7:00 pm"},

                    };
            }
            else if (Role == "Clerk" || Role == "ProShop")
            {
                TimeLists = new List<SelectListItem>
                {
                   new SelectListItem{Value="", Text="---> select Tee Time <---"},
                   new SelectListItem{Value="7:00 am", Text="7:00 am"},
                   new SelectListItem{Value="7:07 am", Text="7:07 am"},
                   new SelectListItem{Value="7:15 am", Text="7:15 am"},
                   new SelectListItem{Value="7:22 am", Text="7:22 am"},
                   new SelectListItem{Value="7:30 am", Text="7:30 am"},
                   new SelectListItem{Value="7:37 am", Text="7:37 am"},
                   new SelectListItem{Value="7:45 am", Text="7:45 am"},
                   new SelectListItem{Value="7:52 am", Text="7:52 am"},
                   new SelectListItem{Value="8:00 am", Text="8:00 am"},
                   new SelectListItem{Value="8:07 am", Text="8:07 am"},
                   new SelectListItem{Value="8:15 am", Text="8:15 am"},
                   new SelectListItem{Value="8:22 am", Text="8:22 am"},
                   new SelectListItem{Value="8:30 am", Text="8:30 am"},
                   new SelectListItem{Value="8:37 am", Text="8:37 am"},
                   new SelectListItem{Value="8:45 am", Text="8:45 am"},
                   new SelectListItem{Value="8:52 am", Text="8:52 am"},
                   new SelectListItem{Value="9:00 am", Text="9:00 am"},
                   new SelectListItem{Value="9:07 am", Text="9:07 am"},
                   new SelectListItem{Value="9:15 am", Text="9:15 am"},
                   new SelectListItem{Value="9:22 am", Text="9:22 am"},
                   new SelectListItem{Value="9:30 am", Text="9:30 am"},
                   new SelectListItem{Value="9:37 am", Text="9:37 am"},
                   new SelectListItem{Value="9:45 am", Text="9:45 am"},
                   new SelectListItem{Value="10:52 am", Text="10:52 am"},
                   new SelectListItem{Value="11:00 am", Text="11:00 am"},
                   new SelectListItem{Value="11:07 am", Text="11:07 am"},
                   new SelectListItem{Value="11:15 am", Text="11:15 am"},
                   new SelectListItem{Value="11:22 am", Text="11:22 am"},
                   new SelectListItem{Value="11:30 am", Text="11:30 am"},
                   new SelectListItem{Value="11:37 am", Text="11:37 am"},
                   new SelectListItem{Value="11:45 am", Text="11:45 am"},
                   new SelectListItem{Value="11:52 am", Text="11:52 am"},
                   new SelectListItem{Value="12:00 pm", Text="12:00 pm"},
                   new SelectListItem{Value="12:07 pm", Text="12:07 pm"},
                   new SelectListItem{Value="12:15 pm", Text="12:15 pm"},
                   new SelectListItem{Value="12:22 pm", Text="12:22 pm"},
                   new SelectListItem{Value="12:30 pm", Text="12:30 pm"},
                   new SelectListItem{Value="12:37 pm", Text="12:37 pm"},
                   new SelectListItem{Value="12:45 pm", Text="12:45 pm"},
                   new SelectListItem{Value="12:52 pm", Text="12:52 pm"},
                   new SelectListItem{Value="1:00 pm", Text="1:00 pm"},
                   new SelectListItem{Value="1:07 pm", Text="1:07 pm"},
                   new SelectListItem{Value="1:15 pm", Text="1:15 pm"},
                   new SelectListItem{Value="1:22 pm", Text="1:22 pm"},
                   new SelectListItem{Value="1:30 pm", Text="1:30 pm"},
                   new SelectListItem{Value="1:37 pm", Text="1:37 pm"},
                   new SelectListItem{Value="1:45 pm", Text="1:45 pm"},
                   new SelectListItem{Value="1:52 pm", Text="1:52 pm"},
                   new SelectListItem{Value="2:00 pm", Text="2:00 pm"},
                   new SelectListItem{Value="2:07 pm", Text="2:07 pm"},
                   new SelectListItem{Value="2:15 pm", Text="2:15 pm"},
                   new SelectListItem{Value="2:22 pm", Text="2:22 pm"},
                   new SelectListItem{Value="2:30 pm", Text="2:30 pm"},
                   new SelectListItem{Value="2:37 pm", Text="2:37 pm"},
                   new SelectListItem{Value="2:45 pm", Text="2:45 pm"},
                   new SelectListItem{Value="2:52 pm", Text="2:52 pm"},
                   new SelectListItem{Value="3:00 pm", Text="3:00 pm"},
                   new SelectListItem{Value="3:07 pm", Text="3:07 pm"},
                   new SelectListItem{Value="3:15 pm", Text="3:15 pm"},
                   new SelectListItem{Value="3:22 pm", Text="3:22 pm"},
                   new SelectListItem{Value="3:30 pm", Text="3:30 pm"},
                   new SelectListItem{Value="3:37 pm", Text="3:37 pm"},
                   new SelectListItem{Value="3:45 pm", Text="3:45 pm"},
                   new SelectListItem{Value="3:52 pm", Text="3:52 pm"},
                   new SelectListItem{Value="4:00 pm", Text="4:00 pm"},
                   new SelectListItem{Value="4:07 pm", Text="4:07 pm"},
                   new SelectListItem{Value="4:15 pm", Text="4:15 pm"},
                   new SelectListItem{Value="4:22 pm", Text="4:22 pm"},
                   new SelectListItem{Value="4:30 pm", Text="4:30 pm"},
                   new SelectListItem{Value="4:37 pm", Text="4:37 pm"},
                   new SelectListItem{Value="4:45 pm", Text="4:45 pm"},
                   new SelectListItem{Value="4:52 pm", Text="4:52 pm"},
                   new SelectListItem{Value="5:00 pm", Text="5:00 pm"},
                   new SelectListItem{Value="5:07 pm", Text="5:07 pm"},
                   new SelectListItem{Value="5:15 pm", Text="5:15 pm"},
                   new SelectListItem{Value="5:22 pm", Text="5:22 pm"},
                   new SelectListItem{Value="5:30 pm", Text="5:30 pm"},
                   new SelectListItem{Value="5:37 pm", Text="5:37 pm"},
                   new SelectListItem{Value="5:45 pm", Text="5:45 pm"},
                   new SelectListItem{Value="5:52 pm", Text="5:52 pm"},
                   new SelectListItem{Value="6:00 pm", Text="6:00 pm"},
                   new SelectListItem{Value="6:07 pm", Text="6:07 pm"},
                   new SelectListItem{Value="6:15 pm", Text="6:15 pm"},
                   new SelectListItem{Value="6:22 pm", Text="6:22 pm"},
                   new SelectListItem{Value="6:30 pm", Text="6:30 pm"},
                   new SelectListItem{Value="6:37 pm", Text="6:37 pm"},
                   new SelectListItem{Value="6:45 pm", Text="6:45 pm"},
                   new SelectListItem{Value="6:52 pm", Text="6:52 pm"},
                   new SelectListItem{Value="7:00 pm", Text="7:00 pm"},

                };
            }
            string SerializedJson = JsonSerializer.Serialize(TimeLists);
            HttpContext.Session.SetString("TimeLists", SerializedJson);
        }
    }
}
