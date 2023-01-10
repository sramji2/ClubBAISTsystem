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
    public class Players
    {
        public Player GetPlayer(string Email)
        {
            Player currentPlayer = null;

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

            SqlCommand getMemberCommand = new SqlCommand()
            {
                Connection = dbConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "uspFindPlayer"
            };
            SqlParameter emailParameter = new SqlParameter()
            {
                ParameterName = "@Email",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                SqlValue = Email,
                Direction = ParameterDirection.Input

            };
            getMemberCommand.Parameters.Add(emailParameter);

            SqlDataReader reader = getMemberCommand.ExecuteReader();
            if (reader.Read())
            {
                currentPlayer = new Player();
                currentPlayer.MemberNumber = (int)reader["MemberNumber"];
                currentPlayer.MembershipLevel = reader["MembershipLevel"].ToString();
                currentPlayer.LastName = reader["LastName"].ToString();
                currentPlayer.FirstName = reader["FirstName"].ToString();
                currentPlayer.Email = reader["Email"].ToString();
                currentPlayer.HomePhone = reader["Phone"].ToString();


            }

            return currentPlayer;

        }
    
    

        public Player UserLogin(string Email, string Password)
        {
            Player GolfPlayer = null;

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

            SqlCommand getUserCommand = new SqlCommand()
            {
                Connection = dbConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "uspClubUserLogin"
            };

            SqlParameter emailParameter = new SqlParameter()
            {
                ParameterName = "@Email",
                SqlDbType = SqlDbType.NVarChar,
                SqlValue = Email,
                Size = 50,
                Direction = ParameterDirection.Input

            };

            getUserCommand.Parameters.Add(emailParameter);

            SqlParameter passwordParameter = new SqlParameter()
            {
                ParameterName = "@Password",
                SqlDbType = SqlDbType.VarChar,
                SqlValue = Password,
                Size = 100,
                Direction = ParameterDirection.Input

            };

            getUserCommand.Parameters.Add(passwordParameter);

            SqlDataReader reader = getUserCommand.ExecuteReader();
            if(reader.HasRows)
            {
                while (reader.Read())
                {
                    GolfPlayer = new Player();

                    GolfPlayer.MemberNumber = (int)reader["MemberNumber"];
                    GolfPlayer.LastName = reader["LastName"].ToString();
                    GolfPlayer.FirstName = reader["FirstName"].ToString();
                    GolfPlayer.HomePhone = reader["HomePhone"].ToString();
                    GolfPlayer.AlternatePhone = reader["AlternatePhone"].ToString();
                    GolfPlayer.Email = reader["Email"].ToString();
                    GolfPlayer.Password = reader["Password"].ToString();
                    GolfPlayer.Role = reader["Role"].ToString();
                    GolfPlayer.MembershipLevel = reader["MembershipLevel"].ToString();

                }

            }

            return GolfPlayer;

        }

    }
}
