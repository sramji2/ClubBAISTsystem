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
        
    public class ModifyTeeTimeModel : PageModel
    {
        public string Message { get; set; }
        [BindProperty]
        public int ConfirmationNumber { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Please enter a Date")]
        public string Date { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Please enter a Tee Time")]
        [RegularExpression(@"^*(1[0-2]|[1-9]):[0-5][0-9] *(a|p|A|P)(m|M)*$", ErrorMessage ="Time must follow proper format followed by AM/PM.")]
        public string Time { get; set; }
        [BindProperty]
        public string LastName { get; set; }
        [BindProperty]
        public string FirstName { get; set; }
        [BindProperty]
        public int NumberOfPlayers {get; set;}
        [BindProperty]
        public string Phone { get; set; }
        [BindProperty]
        public string AlternatePhone { get; set; }
        [BindProperty]
        public string HomePhone { get; set; }
        [BindProperty]
        public int NumberOfCarts { get; set; }
        [BindProperty]
        public string EmployeeName { get; set; }
        [BindProperty]
        public bool CheckedIn { get; set; }
        //[BindProperty]
        //public TeeTime newTeeTime { get; set; }
        //[BindProperty]
        public TeeTime AvailableTeeTime { get; set; }
        [BindProperty]
        public string MembershipLevel { get; set; }
        [BindProperty]
        public int MemberNumber { get; set; }

        public void OnPostSearch()
        {
           
            if (ModelState.IsValid)
            {
                CBS teeTimeManager = new CBS();
                AvailableTeeTime = teeTimeManager.FindTeeTime(Date, Time);
                if (AvailableTeeTime != null)
                {

                    Message = $"Tee Time {Time} and Date {Date} has been found.";
                    string SerializedAvailableTeeTime = JsonSerializer.Serialize(AvailableTeeTime);
                    HttpContext.Session.SetString("AvailableTeeTime", SerializedAvailableTeeTime);

                    ConfirmationNumber = AvailableTeeTime.ConfirmationNumber;
                    Date = AvailableTeeTime.Date;
                    Time = AvailableTeeTime.Time;
                    MembershipLevel = AvailableTeeTime.MembershipLevel;
                    LastName = AvailableTeeTime.LastName;
                    FirstName = AvailableTeeTime.FirstName;
                    NumberOfPlayers = AvailableTeeTime.NumberOfPlayers;
                    HomePhone = AvailableTeeTime.HomePhone;
                    AlternatePhone = AvailableTeeTime.AlternatePhone;
                    NumberOfCarts = AvailableTeeTime.NumberOfCarts;
                    EmployeeName = AvailableTeeTime.EmployeeName;
                    CheckedIn = AvailableTeeTime.CheckedIn;
                    
                }
                else
                {
                    Message = $"Date: {Date} and Time: {Time} has not been found.";

                }
                //added this here
                ModelState.Clear();
            }
        }





        public void OnPostUpdate()
        {
            ModelState["Date"].ValidationState = ModelValidationState.Valid;
            ModelState["Time"].ValidationState = ModelValidationState.Valid;
            if (ModelState.IsValid)
            {
                CBS teeTimeManager = new CBS();
                AvailableTeeTime = new TeeTime();
                string DeserializedJson = HttpContext.Session.GetString("AvailableTeeTime");
                AvailableTeeTime = JsonSerializer.Deserialize<TeeTime>(DeserializedJson);
                //HTML controls are bound to AvailableTeeTime. Should populate. 

                AvailableTeeTime.CheckedIn = CheckedIn;
                AvailableTeeTime.NumberOfPlayers = NumberOfPlayers;
                AvailableTeeTime.NumberOfCarts = NumberOfCarts;
                bool Confirmation = teeTimeManager.ModifyTeeTime(AvailableTeeTime);

                if (Confirmation)
                {

                    Message = "Tee Time Reservation has been updated was successful";

                }

                else
                {

                    Message = "Tee Time Reservation was not updated";
                }
                ModelState.Clear();
            }
        }
        public IActionResult OnPostClear()
        {
            ModelState["Date"].ValidationState = ModelValidationState.Valid;
            ModelState["Time"].ValidationState = ModelValidationState.Valid;
            if (ModelState.IsValid)
            {
                CBS teeTimeManager = new CBS();
                AvailableTeeTime = new TeeTime();
                string DeserializedJson = HttpContext.Session.GetString("AvailableTeeTime");
                AvailableTeeTime = JsonSerializer.Deserialize<TeeTime>(DeserializedJson);
                ConfirmationNumber = AvailableTeeTime.ConfirmationNumber;
                Date = AvailableTeeTime.Date;
                Time = AvailableTeeTime.Time;
                //AvailableTeeTime.ConfirmationNumber = ConfirmationNumber;
                //AvailableTeeTime.Date = Date;
                //AvailableTeeTime.Time = Time;
                bool Confirmation = teeTimeManager.RemoveTeeTime(Date, Time);
                ModelState.Clear();
                if (Confirmation)
                {
                    ConfirmationNumber = 0;
                    Message = "Tee Time Reservation has been deleted";
                    return Page();

                }
                else
                {

                    Message = "Tee Time Reservation was not deleted";
                }
                
                //Moved Modestate.clear to above. Test and change it back if necessary.
            }
            return Page();

        }

        public void OnGet()
        {
        }
    }
}
