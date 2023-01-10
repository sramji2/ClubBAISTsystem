using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClubBAISTsystem.Model.Domain
{
    public class Player
    {

        public int MemberNumber { get; set; }        
        
        public string MembershipLevel { get; set; }
        [Required]        
        public string LastName { get; set; }
        [Required]       
        public string FirstName { get; set; }
        [Required]        
        public string HomeAddress { get; set; }
        
        public string HomePostalCode { get; set; }
        [Required]       
        public string HomePhone { get; set; }
        [Required]        
        public string AlternatePhone { get; set; }
        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessage = "Please enter a valid Email format email@email.com")]
        public string Email { get; set; }
        [Required]        
        public string Password { get; set; }
        [Required]        
        public string DateOfBirth { get; set; }
        [Required]
        public string Occupation { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]        
        public string CompanyAddress { get; set; }
        [Required]
        public string CompanyPostalCode { get; set; }
        [Required]
        public string CompanyPhone { get; set; }
        [Required]
        public string Role { get; set; }
        public string ScoreDate { get; set; }
        //look into. Change to public
        private List<Player> _golfPlayers = new List<Player>();
        public List<Player> GolfPlayers
        {
            get => _golfPlayers; //only get no set because its a read only
        }

        public List<PlayerScore> ListScores = new List<PlayerScore>();
        public PlayerScore PlayerScore { get; set; } = new PlayerScore();

       

        public void GetLast20Avg()
        {
            decimal runningTotal = 0;
            for (int i = 0 ; i< 20; i++)
            {
                runningTotal += ListScores[i].AdjustedGrossScore;
            }
            PlayerScore.Last20Average = runningTotal / 20;
                
        }
        public void CalculateBest8Avg()
        {
            decimal runningTotal = 0;
            //decimal Best8;
            for (int i=0; i<=8; i++)
            {
                runningTotal += ListScores[i].AdjustedGrossScore;
            }
            //Best8=runningTotal / 8;
            PlayerScore.Best8Average = runningTotal / 8;
        }
        public void CalculateHandicapIndex()
        {
            //handicap index is the sum of score diff/8

            decimal handicapIndex = 0;
            for (int i = 0; i <= 8; i++)
            {
                
                handicapIndex += ListScores[i].ScoreDifferential;
            }
           //handicapIndex = handicapIndex / 8;
            PlayerScore.HandicapIndex = Math.Round(handicapIndex / 8, 2);
        }
    }
}
