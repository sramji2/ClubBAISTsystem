using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClubBAISTsystem.Model.Domain
{
    public class PlayerScore
    {
      
        [Required]
        public decimal HandicapIndex { get; set; }
        [Required]
        public decimal Last20Average { get; set; }
        [Required]
        public decimal Best8Average { get; set; }
      
       
        public List<int> Last20RoundScore = new List<int>();
        public int Hole1 { get; set; }
        public int Hole2 { get; set; }
        public int Hole3 { get; set; }
        public int Hole4 { get; set; }
        public int Hole5 { get; set; }
        public int Hole6 { get; set; }
        public int Hole7 { get; set; }
        public int Hole8 { get; set; }
        public int Hole9 { get; set; }
        public int Hole10 { get; set; }
        public int Hole11 { get; set; }
        public int Hole12 { get; set; }
        public int Hole13 { get; set; }
        public int Hole14 { get; set; }
        public int Hole15 { get; set; }
        public int Hole16 { get; set; }
        public int Hole17 { get; set; }
        public int Hole18 { get; set; }
        public int AdjustedGrossScore { get; set; }
        public string GolfCourse { get; set; }

        public string Date { get; set; }

        public int ScoreID { get; set; }

        public decimal CourseRating { get; set; }

        public decimal SlopeRating { get; set; }

        public decimal ScoreDifferential { get; set; }
        public decimal PCCAdjustment { get; set; }
        

        private int GrossScore { get; set; }
        //calculate score diff and adjusted gross score

        public void CalculatePlayerScore()
        {
            AdjustedGrossScore = Hole1 + Hole2 + Hole3 + Hole4 + Hole5 + Hole6 + Hole7 + Hole8 + Hole9 + Hole10 + Hole11 + Hole12
                + Hole13 + Hole14 + Hole15 + Hole16 + Hole17 + Hole18;
            ScoreDifferential = (113 / SlopeRating) * (AdjustedGrossScore - CourseRating - PCCAdjustment);
            ScoreDifferential = Math.Round(ScoreDifferential, 2);
           
        }
        
    }
}
