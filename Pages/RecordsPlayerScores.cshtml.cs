using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ClubBAISTsystem.Model.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClubBAISTsystem.Pages
{
    public class RecordsPlayerScoresModel : PageModel
    {
        public string Message { get; set; }
        public string Message2 { get; set; }
     
        public Player activePlayer { get; set; }
        [BindProperty]
        public PlayerScore newGolfGame { get; set; }
        [BindProperty]
        public int Hole1 { get; set; }
        [BindProperty]
        
        public int Hole2 { get; set; }
        [BindProperty]
        
        public int Hole3 { get; set; }
        [BindProperty]
        
        public int Hole4 { get; set; }
        [BindProperty]
       
        public int Hole5 { get; set; }
        [BindProperty]
        
        public int Hole6 { get; set; }
        [BindProperty]
        
        public int Hole7 { get; set; }
        [BindProperty]
       
        public int Hole8 { get; set; }
        [BindProperty]
        
        public int Hole9 { get; set; }
        [BindProperty]
       
        public int Hole10 { get; set; }
        [BindProperty]
       
        public int Hole11 { get; set; }
        [BindProperty]
       
        public int Hole12 { get; set; }
        [BindProperty]
        
        public int Hole13 { get; set; }
        [BindProperty]
        public int Hole14 { get; set; }
        [BindProperty]
        
        public int Hole15 { get; set; }
        [BindProperty]
       
        public int Hole16 { get; set; }
        [BindProperty]

        public int Hole17 { get; set; }
        [BindProperty]
        
        public int Hole18 { get; set; }
        [BindProperty]

        public int MemberNumber { get; set; }
        [BindProperty]

        public string GolfCourse { get; set; }
        [BindProperty]
        public string Date { get; set; }
        [BindProperty]
        
        public decimal CourseRating { get; set; }
        [BindProperty]
        public decimal SlopeRating { get; set; }
        public int Total { get; set; }
        [BindProperty]
       
        public string Email { get; set; }
        [BindProperty]
       
        public string MembershipLevel { get; set; }
        [BindProperty]
        
        public string LastName { get; set; }
        [BindProperty]
        
        public string FirstName { get; set; }
        [BindProperty]
        public int AdjustedGrossScore { get; set; }
        [BindProperty]
        public string Phone { get; set; }
        [BindProperty]
        public int ScoreID { get; set; }
        [BindProperty]
        public decimal ScoreDifferential { get; set; }
        [BindProperty]
        public decimal PCCAdjustment { get; set; }




        public void OnPostSearch()
        {
            if (ModelState.IsValid)
            {
                CBS memberManager = new CBS();
                activePlayer = memberManager.FindPlayer(Email);

                if (activePlayer != null)
                {
                    Message = "Members Account Found";
                    MemberNumber = activePlayer.MemberNumber;
                    MembershipLevel = activePlayer.MembershipLevel;
                    LastName = activePlayer.LastName;
                    FirstName = activePlayer.FirstName;
                    Email = activePlayer.Email;
                    Phone = activePlayer.HomePhone;
                    HttpContext.Session.SetString("Email", Email);
                }
                else
                {
                    Message = "Account was not found.";
                }
                ModelState.Clear();
            }
        }
        
        public void OnPostCalculate()
        {
            
            CBS scoreMember = new CBS();
            
            //activePlayer.Email = HttpContext.Session.GetString("Email");
            //Not pulling anything from the DB. No need to execute usp...
            newGolfGame.CalculatePlayerScore(); 
            if (newGolfGame != null)
            {
                Message2 = $"Your Hole By Hole Score has been Calculated {newGolfGame.AdjustedGrossScore}" +
                    $"and your score differential is {newGolfGame.ScoreDifferential}";
                AdjustedGrossScore = newGolfGame.AdjustedGrossScore;
                ScoreDifferential = newGolfGame.ScoreDifferential;
                
            }
            if (AdjustedGrossScore < CourseRating)
            {

                Message = $"Score Differential is {ScoreDifferential}";
                Message2 = $"Your Adjusted Gross Score is: { AdjustedGrossScore}";
               
            }
        }
        public void OnGet()

        {
        }
    }
}
