using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClubBAISTsystem.Model
{
    public class RoundOfGolf
    {
        [Required]
        public int Hole { get; set; }
        [Required]
        public int Score { get; set; }
        [Required]
        public decimal Rating { get; set; }
        [Required]
        public decimal Slope { get; set; }
    }
}
