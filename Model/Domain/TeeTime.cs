using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClubBAISTsystem.Model.Domain
{
    public class TeeTime
    {
        //Add [Required] and Regex
       
        [Required]
        public int ConfirmationNumber { get; set; }
        
        [Required]
        public string Date { get; set; }
        
        [Required]
        public string Time { get; set; }

        public string MembershipLevel { get; set; }
        
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
      
        public string EmployeeName { get; set; }
        [Required]
        [RegularExpression(@"^[2-9]\d{2}-\d{3}-\d{4}$", ErrorMessage = "Home Phone format does not match XXX-XXX-XXXX")]
        public string HomePhone { get; set; }
        [Required]
        [RegularExpression(@"^[2-9]\d{2}-\d{3}-\d{4}$", ErrorMessage = "Home Phone format does not match XXX-XXX-XXXX")]
        public string AlternatePhone { get; set; }
        [Required]
        [Range(1,4)]
        public int NumberOfPlayers { get; set; }
        public bool CheckedIn { get; set; }
        [Required]
        [Range(1, 4)]
        public int NumberOfCarts { get; set; }
        //public Player GolfPlayer { get; set; } = new Player();
        //public string Role { get; set; }
        //removed [BindProperty] from all the attributes.

        [BindProperty]
        public List<string> SilverTimes { get; set; } = new List<string>();
        [BindProperty]
        public List<string> BronzeTimes { get; set; } = new List<string>();

        public bool CheckSilverTimes(string teetime)
        {
            SilverTimes.Add("7:00 am");
            SilverTimes.Add("7:07 am");
            SilverTimes.Add("7:15 am");
            SilverTimes.Add("7:22 am");
            SilverTimes.Add("7:30 am");
            SilverTimes.Add("7:37 am");
            SilverTimes.Add("7:45 am");
            SilverTimes.Add("7:52 am");
            SilverTimes.Add("8:00 am");
            SilverTimes.Add("8:07 am");
            SilverTimes.Add("8:15 am");
            SilverTimes.Add("8:22 am");
            SilverTimes.Add("8:30 am");
            SilverTimes.Add("8:37 am");
            SilverTimes.Add("8:45 am");
            SilverTimes.Add("8:52 am");
            SilverTimes.Add("9:00 am");
            SilverTimes.Add("9:07 am");
            SilverTimes.Add("9:15 am");
            SilverTimes.Add("9:22 am");
            SilverTimes.Add("9:30 am");
            SilverTimes.Add("9:37 am");
            SilverTimes.Add("9:45 am");
            SilverTimes.Add("9:52 am");
            SilverTimes.Add("10:00 am");
            SilverTimes.Add("10:07 am");
            SilverTimes.Add("10:15 am");
            SilverTimes.Add("10:22 am");
            SilverTimes.Add("10:30 am");
            SilverTimes.Add("10:37 am");
            SilverTimes.Add("10:45 am");
            SilverTimes.Add("10:52 am");
            SilverTimes.Add("11:00 am");
            SilverTimes.Add("11:07 am");
            SilverTimes.Add("11:15 am");
            SilverTimes.Add("11:22 am");
            SilverTimes.Add("11:30 am");
            SilverTimes.Add("11:37 am");
            SilverTimes.Add("11:45 am");
            SilverTimes.Add("11:52 am");
            SilverTimes.Add("12:00 pm");
            SilverTimes.Add("12:07 pm");
            SilverTimes.Add("12:15 pm");
            SilverTimes.Add("12:22 pm");
            SilverTimes.Add("12:30 pm");
            SilverTimes.Add("12:37 pm");
            SilverTimes.Add("12:45 pm");
            SilverTimes.Add("12:52 pm");
            SilverTimes.Add("1:00 pm");
            SilverTimes.Add("1:07 pm");
            SilverTimes.Add("1:15 pm");
            SilverTimes.Add("1:22 pm");
            SilverTimes.Add("1:30 pm");
            SilverTimes.Add("1:37 pm");
            SilverTimes.Add("1:45 pm");
            SilverTimes.Add("1:52 pm");
            SilverTimes.Add("2:00 pm");
            SilverTimes.Add("2:07 pm");
            SilverTimes.Add("2:15 pm");
            SilverTimes.Add("2:22 pm");
            SilverTimes.Add("2:30 pm");
            SilverTimes.Add("2:37 pm");
            SilverTimes.Add("2:45 pm");
            SilverTimes.Add("2:52 pm");
            SilverTimes.Add("5:30 pm");
            SilverTimes.Add("5:37 pm");
            SilverTimes.Add("5:45 pm");
            SilverTimes.Add("5:52 pm");
            SilverTimes.Add("6:00 pm");
            SilverTimes.Add("6:07 pm");
            SilverTimes.Add("6:15 pm");
            SilverTimes.Add("6:22 pm");
            SilverTimes.Add("6:30 pm");
            SilverTimes.Add("6:37 pm");
            SilverTimes.Add("6:45 pm");
            SilverTimes.Add("6:52 pm");
            SilverTimes.Add("7:00 pm");

            bool found = false;

            foreach (string time in SilverTimes)
            { 
                if(time.Equals(teetime))
                    found = true;
            }

            return found;
        }
        public bool CheckBronzeTimes(string teetime)
        {
            BronzeTimes.Add("7:00 am");
            BronzeTimes.Add("7:07 am");
            BronzeTimes.Add("7:15 am");
            BronzeTimes.Add("7:22 am");
            BronzeTimes.Add("7:30 am");
            BronzeTimes.Add("7:37 am");
            BronzeTimes.Add("7:45 am");
            BronzeTimes.Add("7:52 am");
            BronzeTimes.Add("8:00 am");
            BronzeTimes.Add("8:07 am");
            BronzeTimes.Add("8:15 am");
            BronzeTimes.Add("8:22 am");
            BronzeTimes.Add("8:30 am");
            BronzeTimes.Add("8:37 am");
            BronzeTimes.Add("8:45 am");
            BronzeTimes.Add("8:52 am");
            BronzeTimes.Add("9:00 am");
            BronzeTimes.Add("9:07 am");
            BronzeTimes.Add("9:15 am");
            BronzeTimes.Add("9:22 am");
            BronzeTimes.Add("9:30 am");
            BronzeTimes.Add("9:37 am");
            BronzeTimes.Add("9:45 am");
            BronzeTimes.Add("9:52 am");
            BronzeTimes.Add("10:00 am");
            BronzeTimes.Add("10:07 am");
            BronzeTimes.Add("10:15 am");
            BronzeTimes.Add("10:22 am");
            BronzeTimes.Add("10:30 am");
            BronzeTimes.Add("10:37 am");
            BronzeTimes.Add("10:45 am");
            BronzeTimes.Add("10:52 am");
            BronzeTimes.Add("11:00 am");
            BronzeTimes.Add("11:07 am");
            BronzeTimes.Add("11:15 am");
            BronzeTimes.Add("11:22 am");
            BronzeTimes.Add("11:30 am");
            BronzeTimes.Add("11:37 am");
            BronzeTimes.Add("11:45 am");
            BronzeTimes.Add("11:52 am");
            BronzeTimes.Add("12:00 pm");
            BronzeTimes.Add("12:07 pm");
            BronzeTimes.Add("12:15 pm");
            BronzeTimes.Add("12:22 pm");
            BronzeTimes.Add("12:30 pm");
            BronzeTimes.Add("12:37 pm");
            BronzeTimes.Add("12:45 pm");
            BronzeTimes.Add("12:52 pm");
            BronzeTimes.Add("1:00 pm");
            BronzeTimes.Add("1:07 pm");
            BronzeTimes.Add("1:15 pm");
            BronzeTimes.Add("1:22 pm");
            BronzeTimes.Add("1:30 pm");
            BronzeTimes.Add("1:37 pm");
            BronzeTimes.Add("1:45 pm");
            BronzeTimes.Add("1:52 pm");
            BronzeTimes.Add("2:00 pm");
            BronzeTimes.Add("2:07 pm");
            BronzeTimes.Add("2:15 pm");
            BronzeTimes.Add("2:22 pm");
            BronzeTimes.Add("2:30 pm");
            BronzeTimes.Add("2:37 pm");
            BronzeTimes.Add("2:45 pm");
            BronzeTimes.Add("2:52 pm");
            BronzeTimes.Add("6:00 pm");
            BronzeTimes.Add("6:07 pm");
            BronzeTimes.Add("6:15 pm");
            BronzeTimes.Add("6:22 pm");
            BronzeTimes.Add("6:30 pm");
            BronzeTimes.Add("6:37 pm");
            BronzeTimes.Add("6:45 pm");
            BronzeTimes.Add("6:52 pm");
            BronzeTimes.Add("7:00 pm");

            bool found = false;

            foreach (string time in BronzeTimes)
            {
                if (time.Equals(teetime))
                    found = true;
            }

            return found;
        }
    }
}
