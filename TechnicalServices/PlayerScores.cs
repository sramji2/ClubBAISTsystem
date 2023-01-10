using ClubBAISTsystem.Model;
using ClubBAISTsystem.Model.Domain;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ClubBAISTsystem.TechnicalServices
{
    public class PlayerScores
    {
        
        public Player CalculateHoleScore(Player golfPlayer)
        {
            
            var jsonSource = new JsonConfigurationSource()
            {
                Path = "appsettings.json"
            };
            var builder = new ConfigurationBuilder().Add(jsonSource);
            var cfg = builder.Build();
            string dbConnectionString = cfg.GetSection("ConnectionStrings:BaistDatabaseServer").Value;

            SqlConnection dbConnection = new SqlConnection()
            {
                ConnectionString = dbConnectionString
            };

            dbConnection.Open();
            SqlCommand addHoleScoreCommand = new SqlCommand()
            {
                Connection = dbConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "uspGetTop20Rounds"
            };
            SqlParameter emailCommandParameter = new SqlParameter
            {
                ParameterName = "@Email",
                SqlDbType = SqlDbType.NVarChar,
                Size = 100,
                Direction = ParameterDirection.Input,
                SqlValue = golfPlayer.Email
            };
            addHoleScoreCommand.Parameters.Add(emailCommandParameter);

            SqlParameter returnStatusParameter = new SqlParameter()
            {
                ParameterName = "@ReturnStatus",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.ReturnValue
            };

            addHoleScoreCommand.Parameters.Add(returnStatusParameter);

            SqlDataReader reader = addHoleScoreCommand.ExecuteReader();

            //int result = (int)addHoleScoreCommand.ExecuteNonQuery();
            //Parameter has the value. Not in the command.  
            //List<PlayerScore> PlayerScores = new List<PlayerScore>();

            PlayerScore PlayerScore;
           while (reader.Read())
            {
                PlayerScore = new PlayerScore();
                PlayerScore.CourseRating = (decimal)reader["CourseRating"];
                PlayerScore.SlopeRating = (decimal)reader["SlopeRating"];
                PlayerScore.PCCAdjustment = (decimal)reader["PCCAdjustment"];
                PlayerScore.Date = reader["Date"].ToString();
                PlayerScore.Hole1 = (int)reader["Hole1"];
                PlayerScore.Hole2 = (int)reader["Hole2"];
                PlayerScore.Hole3 = (int)reader["Hole3"];
                PlayerScore.Hole4 = (int)reader["Hole4"];
                PlayerScore.Hole5 = (int)reader["Hole5"];
                PlayerScore.Hole6 = (int)reader["Hole6"];
                PlayerScore.Hole7 = (int)reader["Hole7"];
                PlayerScore.Hole8 = (int)reader["Hole8"];
                PlayerScore.Hole9 = (int)reader["Hole9"];
                PlayerScore.Hole10 = (int)reader["Hole10"];
                PlayerScore.Hole11 = (int)reader["Hole11"];
                PlayerScore.Hole12 = (int)reader["Hole12"];
                PlayerScore.Hole13 = (int)reader["Hole13"];
                PlayerScore.Hole14 = (int)reader["Hole14"];
                PlayerScore.Hole15 = (int)reader["Hole15"];
                PlayerScore.Hole16 = (int)reader["Hole16"];
                PlayerScore.Hole17 = (int)reader["Hole17"];
                PlayerScore.Hole18 = (int)reader["Hole18"];

                PlayerScore.CalculatePlayerScore();


                golfPlayer.ListScores.Add(PlayerScore);
            }
            dbConnection.Close();

            return golfPlayer;
        }
        public decimal FindHandicapIndex(string Email)
        {
            decimal Handicap = 0;
            var jsonSource = new JsonConfigurationSource()
            {
                Path = "appsettings.json"
            };
            var builder = new ConfigurationBuilder().Add(jsonSource);
            var cfg = builder.Build();
            string dbConnectionString = cfg.GetSection("ConnectionStrings:BaistDatabaseServer").Value;

            SqlConnection dbConnection = new SqlConnection()
            {
                ConnectionString = dbConnectionString
            };

            dbConnection.Open();
            SqlCommand getHandicapIndexCommand = new SqlCommand()
            {
                Connection = dbConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "uspGetHandicapIndex"
            };
            SqlParameter memberCommandParameter = new SqlParameter
            {
                ParameterName = "@Email",
                SqlDbType = SqlDbType.Int,
                Size = 50,
                Direction = ParameterDirection.Input,
                SqlValue = Email
            };
            getHandicapIndexCommand.Parameters.Add(memberCommandParameter);

            SqlDataReader reader = getHandicapIndexCommand.ExecuteReader();
            if (reader.Read())
            {
                Handicap = decimal.Parse(reader["HandicapIndex"].ToString());
            }

            return Handicap;

        }
    }
    
}

