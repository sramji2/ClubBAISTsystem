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

namespace ClubBAISTsystem.Pages
{
    public class ViewPlayerHandicapModel : PageModel
    {
       
        public Player activePlayer { get; set; } = new Player();
        [BindProperty]
        public DateTime HandicapIndexDate { get; set; }
        //[BindProperty]
        public PlayerScore playerScore { get; set; }
        public string Message { get; set; }
        [BindProperty]
        public string LastName { get; set; }
        [BindProperty]
        public string FirstName { get; set; }
        [BindProperty]
        public decimal HandicapIndex { get; set; }
        [BindProperty]
        public decimal Last20Average { get; set; }
        [BindProperty]
        public decimal Best8Total { get; set; }
        [BindProperty]
        public int Last20RoundScores { get; set; }
        [BindProperty]
        public decimal AdjustedGolfScore { get; set; }
        [BindProperty]
        public decimal ScoreDifferential { get; set; }
        [BindProperty]
        public decimal AdjustedGrossScore { get; set; }
        [BindProperty]
        public decimal SlopRating { get; set; }
        [BindProperty]
        public decimal CourseRating { get; set; }
        [BindProperty]
        public decimal PCCAdjustment { get; set; }
        [BindProperty]
        public int MemberNumber { get; set; }
        [BindProperty]
        public string MembershipLevel { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Please enter an email address")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$")]
        public string Email { get; set; }
        [BindProperty]
        public string Phone { get; set; }
        [BindProperty]
        //Having date is required doesn't work with validation.
        public string Date { get; set; }
        [BindProperty]
        public IEnumerable<int> Last20Scores { get; set; } = Enumerable.Empty<int>();


        public List<PlayerScore> handicapIndex = new List<PlayerScore>();

        private List<int> _playerScoreInfo = new List<int>();
        [BindProperty]
        public List<int> PlayerScoreInformation
        {
            get
            {
                return _playerScoreInfo;
            }
        }

        public void OnPostSearch()
        {
            if (ModelState.IsValid)
            {
                CBS RequestDirector = new CBS();
                Player activePlayer = RequestDirector.FindPlayer(Email);
                HttpContext.Session.SetString("Email", Email);

                string SerializedActivePlayer = JsonSerializer.Serialize(activePlayer);
                HttpContext.Session.SetString("activePlayer", SerializedActivePlayer);

                activePlayer.Email = Email;
                if (activePlayer != null)
                {
                    Message = "Welcome Club BIAST Member";
                    MemberNumber = activePlayer.MemberNumber;
                    MembershipLevel = activePlayer.MembershipLevel;
                    LastName = activePlayer.LastName;
                    FirstName = activePlayer.FirstName;
                    Email = activePlayer.Email;
                    Phone = activePlayer.HomePhone;


                }

                else
                {

                    Message = "Sorry we can't find your account. Please re-enter the information of call 780-555-5555.";
                }
            }
        }
       

        public void OnGet()
        {
          
           
        }
        public void OnPostSubmit()
        {
            ModelState["Email"].ValidationState = ModelValidationState.Valid;
            if (ModelState.IsValid)
            { 
            CBS RequestDirector = new CBS();

            activePlayer.Email = HttpContext.Session.GetString("Email");
            string DeserializedJson = HttpContext.Session.GetString("activePlayer");
            activePlayer = JsonSerializer.Deserialize<Player>(DeserializedJson);
            activePlayer.ScoreDate = HandicapIndexDate.ToShortDateString();

            MembershipLevel = activePlayer.MembershipLevel;
            MemberNumber = activePlayer.MemberNumber;
            LastName = activePlayer.LastName;
            FirstName = activePlayer.FirstName;
            Email = activePlayer.Email;
            Phone = activePlayer.HomePhone;
            Date = activePlayer.ScoreDate;
            Last20Scores = activePlayer.ListScores.Select(s => s.AdjustedGrossScore).Take(20);
            activePlayer = RequestDirector.CalculateHoleByHoleScore(activePlayer);
            activePlayer.CalculateBest8Avg();
            activePlayer.GetLast20Avg();
            activePlayer.CalculateHandicapIndex();
        }
            else
            {
                Message = "Player Handicap not found.";
            }
            ModelState.Clear();
        }
    }
}
