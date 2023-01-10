using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClubBAISTsystem.Model.Domain
{
    public class StandingTeeTime
    {
        
        [Required]
        public int MemberNumber { get; set; }
        public string Role { get; set; }
        [Required(ErrorMessage = "Please enter a Requested End Date")]
        public string RequestedEndDate { get; set; }
        [Required(ErrorMessage = "Please enter a Requested Tee Time")]
        public string RequestedTeeTime { get; set; }
        public string RequestedDayOfWeek { get; set; }
        [Required(ErrorMessage = "Please enter a Requested Start Date")]
        public string RequestedStartDate { get; set; }
        [Required(ErrorMessage = "Please enter a Shareholders Name")]
        [MaxLength(50, ErrorMessage = "Member Name is longer than 50 characters.")]
        [MinLength(2, ErrorMessage = "Member Name is shorter than 2 characters.")]
        public string MemberName { get; set; }
        [Required(ErrorMessage = "Please enter a Member's Name")]
        [MaxLength(50, ErrorMessage = "Member Name 2 is longer than 50 characters.")]
        [MinLength(2, ErrorMessage = "Member Name 2 is shorter than 2 characters.")]
        public string MemberName2 { get; set; }
        [Required(ErrorMessage = "Please enter a Member's Name")]
        [MaxLength(50, ErrorMessage = "Member Name 3 is longer than 50 characters.")]
        [MinLength(2, ErrorMessage = "Member Name 3 is shorter than 2 characters.")]
        public string MemberName3 { get; set; }
        [Required(ErrorMessage = "Please enter a Member's Name")]
        [MaxLength(50, ErrorMessage = "Member Name 4 is longer than 50 characters.")]
        [MinLength(2, ErrorMessage = "Member Name 4 is shorter than 2 characters.")]
        public string MemberName4 { get; set; }
        [Required]
        public int MemberNumber2 { get; set; }
        [Required]
        public int MemberNumber3 { get; set; }
        [Required]
        public int MemberNumber4 { get; set; }
        public string ApprovedBy { get; set; }
        public bool CanceledBy { get; set; }
        public string ApprovedDate { get; set; }
        public string ApprovedTeeTime { get; set; }
        public int PriorityNumber { get; set; }
        public string MembershipLevel { get; set; }
    }
}
