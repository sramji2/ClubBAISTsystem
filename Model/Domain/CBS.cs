using ClubBAISTsystem.TechnicalServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubBAISTsystem.Model.Domain
{
    public class CBS
    {
        public int BookStandingTeeTime(StandingTeeTime newStandingTeeTime)
        {

            int PriorityNumber;

            StandingTeeTimes teeTimeManager = new StandingTeeTimes();
            PriorityNumber = teeTimeManager.AddStandingTeeTime(newStandingTeeTime);

            return PriorityNumber;
        }
        public bool RemoveStandingTeeTime(string RequestedStartDate, string RequestedTeeTime)
        {
            bool Confirmation = false;
            StandingTeeTimes teeTimeManager = new StandingTeeTimes();
            Confirmation = teeTimeManager.DeleteStandingTeeTime(RequestedStartDate, RequestedTeeTime);
            return Confirmation;
        }
        public decimal GetHandicapIndex(string Email)
        {
            decimal handicapIndex;
            PlayerScores playerScoreManager = new PlayerScores();
            handicapIndex = playerScoreManager.FindHandicapIndex(Email);
            return handicapIndex;
        }
        public Player FindPlayer(string Email)
        {
            Players playerManager = new Players();
            Player golfPlayer = playerManager.GetPlayer(Email);
  
            return golfPlayer;


        }
        public Player CalculateHoleByHoleScore(Player golfPlayer)
        {
            
            PlayerScores scoreManager = new PlayerScores();
            return scoreManager.CalculateHoleScore(golfPlayer);
            
        }
        public Member FindMember (string Email)
        {
            Members memberManager = new Members();
            Member activeMember = memberManager.GetMember(Email);
            return activeMember;
        }
        public bool ModifyApplication (Member memberApplication)
        {
            Members memberManager = new Members();
            bool Confirmation = memberManager.UpdateApplication(memberApplication);
            return Confirmation;
        }
        public Member FindApplication (string ApplicationStatus)
        {
            Members memberManager = new Members();
            Member MembershipApplication = memberManager.GetApplication(ApplicationStatus);
            return MembershipApplication;
        }
        public Member RecordMembership (Member newMember)
        {
            Member returnMember;
            Members memberManager = new Members();
            returnMember = memberManager.AddMember(newMember);
            return returnMember;
        }
        public bool RemoveTeeTime(string Date, string Time)
        {
            TeeTimes teeTimeManager = new TeeTimes();
            bool Confirmation = teeTimeManager.DeleteTeeTime(Date, Time);
            return Confirmation;
        }
        public bool ModifyTeeTime (TeeTime availableTeeTime)
        {
            TeeTimes teeTimeManager = new TeeTimes();
            bool Confirmation = teeTimeManager.UpdateTeeTime(availableTeeTime);
            return Confirmation;
        }
        public PaymentProcess ProcessPayment(PaymentProcess paymentProcess)
        {
            //int PaymentID;
            //PaymentProcesses paymentManager = new PaymentProcesses();
            //PaymentID = paymentManager.ProcessMemberPayment(paymentProcess);
            //return PaymentID;

            PaymentProcesses paymentManager = new PaymentProcesses();
            return paymentManager.ProcessMemberPayment(paymentProcess);
        }
        public bool ModifyStandingTeeTime(StandingTeeTime standingTeeTime)
        {
            StandingTeeTimes standingTeeTimeManager = new StandingTeeTimes();
            bool Confirmation = standingTeeTimeManager.UpdateStandingTeeTime(standingTeeTime);
            return Confirmation;
        }
        public int BookTeeTime(TeeTime AvailableTeeTime)
        {
           
            int ConfirmationNumber;

            TeeTimes teeTimeManager = new TeeTimes();
            ConfirmationNumber = teeTimeManager.AddTeeTime(AvailableTeeTime);

            return ConfirmationNumber;
        }
        //public List<TeeTime> FindTeeTimes(string Date)
        //{
        //    List<TeeTime> teeTimeList = new List<TeeTime>();
        //    TeeTimes teeTimeManager = new TeeTimes();
        //    teeTimeList.Add(teeTimeManager.GetTeeTimes(Date));
        //    return teeTimeList;

        //}
        public TeeTime FindTeeTime (string Date, string Time)
        {
            TeeTimes teeTimeManager = new TeeTimes();
            TeeTime GolfTeeTime = teeTimeManager.GetTeeTime(Date, Time);
            return GolfTeeTime;
        }
        public StandingTeeTime FindStandingTeeTime(string RequestedStartDate, string RequestedTeeTime)
        {
            StandingTeeTimes teeTimeManager = new StandingTeeTimes();
            StandingTeeTime GolfTeeTime = teeTimeManager.GetStandingTeeTime(RequestedStartDate, RequestedTeeTime);
            return GolfTeeTime;
        }
        public Player UserLogin(string Email, string Password)
        {
            
            Players loginManager = new Players();
            Player GolfPlayers = loginManager.UserLogin(Email, Password);
            return GolfPlayers;
        }
        public Employee EmployeeLogin(string EmployeeNumber, string Password)
        {

            Employees loginManager = new Employees();
            Employee ClubEmployee = loginManager.EmployeeUserLogin(EmployeeNumber, Password);
            return ClubEmployee;
        }
    }
}
