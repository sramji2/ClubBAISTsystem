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
    public class TeeTimes
    {
        public bool DeleteTeeTime(string Date, string Time)
        {
            bool Success = true;


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

            SqlCommand deleteTeeTimeCommand = new SqlCommand()
            {
                Connection = dbConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "uspDeleteATeeTime"
            };
            SqlParameter dateParameter = new SqlParameter()
            {
                ParameterName = "@Date",
                SqlDbType = SqlDbType.NVarChar,
                Size = 25,
                SqlValue = Date,
                Direction = ParameterDirection.Input

            };
            deleteTeeTimeCommand.Parameters.Add(dateParameter);

            SqlParameter timeParameter = new SqlParameter()
            {
                ParameterName = "@Time",
                SqlDbType = SqlDbType.NVarChar,
                Size = 25,
                Direction = ParameterDirection.Input,
                SqlValue = Time
            };

            deleteTeeTimeCommand.Parameters.Add(timeParameter);

            SqlParameter returnStatusParameter = new SqlParameter()
            {
                ParameterName = "@ReturnStatus",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.ReturnValue
            };

            deleteTeeTimeCommand.Parameters.Add(returnStatusParameter);
            // Execute. Return one record

            deleteTeeTimeCommand.ExecuteNonQuery();

            if ((int)returnStatusParameter.Value == 0)
            {
                Success = true;
                dbConnection.Close();
            }

            return Success;

        }

        public bool UpdateTeeTime(TeeTime availableTeeTime)
        {
            bool Success = true;

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

            SqlCommand updateTeeTimeCommand = new SqlCommand()
            {
                Connection = dbConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "uspUpdateTeeTime"
            };
            SqlParameter dateParameter = new SqlParameter()
            {
                ParameterName = "@Date",
                SqlDbType = SqlDbType.NVarChar,
                Size = 25,
                SqlValue = availableTeeTime.Date,
                Direction = ParameterDirection.Input

            };
            updateTeeTimeCommand.Parameters.Add(dateParameter);

            SqlParameter timeParameter = new SqlParameter()
            {
                ParameterName = "@Time",
                SqlDbType = SqlDbType.NVarChar,
                Size = 25,
                Direction = ParameterDirection.Input,
                SqlValue = availableTeeTime.Time
            };

            updateTeeTimeCommand.Parameters.Add(timeParameter);

            SqlParameter membershipLevelParameter = new SqlParameter()
            {
                ParameterName = "@MembershipLevel",
                SqlDbType = SqlDbType.NVarChar,
                Size = 25,
                Direction = ParameterDirection.Input,
                SqlValue = availableTeeTime.MembershipLevel
            };
            updateTeeTimeCommand.Parameters.Add(membershipLevelParameter);

            SqlParameter confirmationNumberParameter = new SqlParameter()
            {
                ParameterName = "@ConfirmationNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = availableTeeTime.ConfirmationNumber
            };
            updateTeeTimeCommand.Parameters.Add(confirmationNumberParameter);

            SqlParameter lastNameParameter = new SqlParameter()
            {
                ParameterName = "@LastName",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                SqlValue = availableTeeTime.LastName
            };

            updateTeeTimeCommand.Parameters.Add(lastNameParameter);

            SqlParameter firstNameParameter = new SqlParameter()
            {
                ParameterName = "@FirstName",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                SqlValue = availableTeeTime.FirstName
            };

            updateTeeTimeCommand.Parameters.Add(firstNameParameter);

            SqlParameter numberOfPlayersParameter = new SqlParameter()
            {
                ParameterName = "@NumberOfPlayers",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = availableTeeTime.NumberOfPlayers
            };

            updateTeeTimeCommand.Parameters.Add(numberOfPlayersParameter);

            SqlParameter phoneParameter = new SqlParameter()
            {
                ParameterName = "@Phone",
                SqlDbType = SqlDbType.NVarChar,
                Size = 25,
                Direction = ParameterDirection.Input,
                SqlValue = availableTeeTime.HomePhone
            };

            updateTeeTimeCommand.Parameters.Add(phoneParameter);

            SqlParameter alternatePhoneParameter = new SqlParameter()
            {
                ParameterName = "@AlternatePhone",
                SqlDbType = SqlDbType.NVarChar,
                Size = 25,
                Direction = ParameterDirection.Input,
                SqlValue = availableTeeTime.AlternatePhone
            };

            updateTeeTimeCommand.Parameters.Add(alternatePhoneParameter);

            SqlParameter numberOfCartsParameter = new SqlParameter()
            {
                ParameterName = "@NumberOfCarts",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = availableTeeTime.NumberOfCarts
            };
            updateTeeTimeCommand.Parameters.Add(numberOfCartsParameter);

            SqlParameter employeeNameParameter = new SqlParameter()
            {
                ParameterName = "@EmployeeName",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                SqlValue = availableTeeTime.EmployeeName
            };

            updateTeeTimeCommand.Parameters.Add(employeeNameParameter);

            SqlParameter checkInParameter = new SqlParameter()
            {
                ParameterName = "@CheckIn",
                SqlDbType = SqlDbType.Bit,
                Direction = ParameterDirection.Input,
                SqlValue = availableTeeTime.CheckedIn 
            };

            updateTeeTimeCommand.Parameters.Add(checkInParameter);

            SqlParameter returnStatusParameter = new SqlParameter()
            {
                ParameterName = "@ReturnStatus",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.ReturnValue
            };

            updateTeeTimeCommand.Parameters.Add(returnStatusParameter);
            // Execute. Return one record

            updateTeeTimeCommand.ExecuteNonQuery();
            if ((int)returnStatusParameter.Value == 0)
            {
                Success = true;
                dbConnection.Close();
            }


            return Success;

        }
        public int AddTeeTime(TeeTime AvailableTeeTime)
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

            SqlCommand addTeeTimeCommand = new SqlCommand()
            {
                Connection = dbConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "uspAddTeeTime"
            };

            SqlParameter dateParameter = new SqlParameter()
            {
                ParameterName = "@Date",
                SqlDbType = SqlDbType.NVarChar,
                Size = 25,
                Direction = ParameterDirection.Input,
                SqlValue = AvailableTeeTime.Date
            };
            addTeeTimeCommand.Parameters.Add(dateParameter);

            SqlParameter timeParameter = new SqlParameter()
            {
                ParameterName = "@Time",
                SqlDbType = SqlDbType.NVarChar,
                Size = 25,
                Direction = ParameterDirection.Input,
                SqlValue = AvailableTeeTime.Time
            };
            addTeeTimeCommand.Parameters.Add(timeParameter);

            SqlParameter membershipLevelParameter = new SqlParameter()
            {
                ParameterName = "@MembershipLevel",
                SqlDbType = SqlDbType.NVarChar,
                Size = 25,
                Direction = ParameterDirection.Input,
                SqlValue = AvailableTeeTime.MembershipLevel
            };
            addTeeTimeCommand.Parameters.Add(membershipLevelParameter);

            SqlParameter lastNameParameter = new SqlParameter()
            {
                ParameterName = "@LastName",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                SqlValue = AvailableTeeTime.LastName
            };

            addTeeTimeCommand.Parameters.Add(lastNameParameter);

            SqlParameter firstNameParameter = new SqlParameter()
            {
                ParameterName = "@FirstName",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                SqlValue = AvailableTeeTime.FirstName
            };

            addTeeTimeCommand.Parameters.Add(firstNameParameter);

            SqlParameter phoneParameter = new SqlParameter()
            {
                ParameterName = "@Phone",
                SqlDbType = SqlDbType.NVarChar,
                Size = 25,
                Direction = ParameterDirection.Input,
                SqlValue = AvailableTeeTime.HomePhone
            };

            addTeeTimeCommand.Parameters.Add(phoneParameter);

            SqlParameter alternatePhoneParameter = new SqlParameter()
            {
                ParameterName = "@AlternatePhone",
                SqlDbType = SqlDbType.NVarChar,
                Size = 25,
                Direction = ParameterDirection.Input,
                SqlValue = AvailableTeeTime.AlternatePhone
            };

            addTeeTimeCommand.Parameters.Add(alternatePhoneParameter);

            SqlParameter numberOfCartsParameter = new SqlParameter()
            {
                ParameterName = "@NumberOfCarts",
                SqlDbType = SqlDbType.Int,
                
                Direction = ParameterDirection.Input,
                SqlValue = AvailableTeeTime.NumberOfCarts
            };

            addTeeTimeCommand.Parameters.Add(numberOfCartsParameter);

            SqlParameter numberOfPlayerParameter = new SqlParameter()
            {
                ParameterName = "@NumberOfPlayers",
                SqlDbType = SqlDbType.Int,

                Direction = ParameterDirection.Input,
                SqlValue = AvailableTeeTime.NumberOfPlayers
            };

            addTeeTimeCommand.Parameters.Add(numberOfPlayerParameter);

            SqlParameter employeeNameParameter = new SqlParameter()
            {
                ParameterName = "@EmployeeName",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                SqlValue = AvailableTeeTime.EmployeeName
            };

            addTeeTimeCommand.Parameters.Add(employeeNameParameter);

            SqlParameter returnStatusParameter = new SqlParameter()
            {
                ParameterName = "@ReturnStatus",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.ReturnValue
            };

            addTeeTimeCommand.Parameters.Add(returnStatusParameter);

            SqlParameter confirmationNumberParameter = new SqlParameter()
            {
                ParameterName = "@ConfirmationNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            addTeeTimeCommand.Parameters.Add(confirmationNumberParameter);

            int result = (int) addTeeTimeCommand.ExecuteNonQuery();
            int ConfirmationNumber = (int)addTeeTimeCommand.Parameters["@ConfirmationNumber"].Value;

            if ((int)returnStatusParameter.Value == 0)
            {
               
                dbConnection.Close();
            }

            return ConfirmationNumber;
        }
        public TeeTime GetTeeTime(string Date, string Time)
        {
            TeeTime AvailableTeeTime = null;

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

            SqlCommand getTeeTimeCommnd = new SqlCommand()
            {
                Connection = dbConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "uspFindTeeTime"
            };
            SqlParameter dateParameter = new SqlParameter()
            {
                ParameterName = "@Date",
                SqlDbType = SqlDbType.NVarChar,
                Size = 25,
                SqlValue = Date,
                Direction = ParameterDirection.Input

            };
            getTeeTimeCommnd.Parameters.Add(dateParameter);

            SqlParameter timeParameter = new SqlParameter()
            {
                ParameterName = "@Time",
                SqlDbType = SqlDbType.NVarChar,
                Size = 25,
                SqlValue = Time,
                Direction = ParameterDirection.Input

            };
            getTeeTimeCommnd.Parameters.Add(timeParameter);

            SqlDataReader reader = getTeeTimeCommnd.ExecuteReader();
           
                if (reader.Read())
                {
                    AvailableTeeTime = new TeeTime();

                    AvailableTeeTime.ConfirmationNumber = (int)reader["ConfirmationNumber"];
                    AvailableTeeTime.Date = reader["Date"].ToString();
                    AvailableTeeTime.Time = reader["Time"].ToString();
                    AvailableTeeTime.MembershipLevel = reader["MembershipLevel"].ToString();
                    AvailableTeeTime.LastName = reader["LastName"].ToString();
                    AvailableTeeTime.FirstName = reader["FirstName"].ToString();
                    AvailableTeeTime.NumberOfPlayers = (int)reader["NumberOfPlayers"];
                    AvailableTeeTime.HomePhone = reader["Phone"].ToString();
                    AvailableTeeTime.AlternatePhone = reader["AlternatePhone"].ToString();
                    AvailableTeeTime.NumberOfCarts = (int)reader["NumberOfCarts"];
                    AvailableTeeTime.EmployeeName = reader["EmployeeName"].ToString();
                    AvailableTeeTime.CheckedIn = (bool)reader["CheckIn"];

                }
            return AvailableTeeTime;

        }
    }
}
