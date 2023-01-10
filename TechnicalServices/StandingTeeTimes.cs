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
    public class StandingTeeTimes
    {
        public bool DeleteStandingTeeTime(string RequestedStartDate, string RequestedTeeTime)
        {
            bool Success = false;
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

            SqlCommand deleteTeeTimeCommand = new SqlCommand
            {
                Connection = dbConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "uspDeleteStandingTeeTime"
            };

            SqlParameter requestedStartDateParameter;
            requestedStartDateParameter = new SqlParameter
            {
                ParameterName = "@RequestedStartDate",
                SqlDbType = SqlDbType.NVarChar,
                Size = 25,
                Direction = ParameterDirection.Input,
                SqlValue = RequestedStartDate
            };
            deleteTeeTimeCommand.Parameters.Add(requestedStartDateParameter);

            SqlParameter requestedTeeTimeParameter;
            requestedTeeTimeParameter = new SqlParameter
            {
                ParameterName = "@RequestedTeeTime",
                SqlDbType = SqlDbType.NVarChar,
                Size = 25,
                Direction = ParameterDirection.Input,
                SqlValue = RequestedTeeTime
            };
            deleteTeeTimeCommand.Parameters.Add(requestedTeeTimeParameter);

            SqlParameter returnStatusParameter = new SqlParameter()
            {
                ParameterName = "@ReturnStatus",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.ReturnValue
            };

            deleteTeeTimeCommand.Parameters.Add(returnStatusParameter);

            deleteTeeTimeCommand.ExecuteNonQuery();
            // Execute. Return one record

            if ((int)returnStatusParameter.Value == 0)
            {
                Success = true;
                dbConnection.Close();
            }

            return Success;

        }
        public bool UpdateStandingTeeTime(StandingTeeTime availableStandingTeeTime)
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

            SqlCommand updateStandingTeeTimeCommand = new SqlCommand()
            {
                Connection = dbConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "uspUpdateStandingTeeTime"
            };
            //Not too sure if I need this
            SqlParameter priorityNumberParameter = new SqlParameter()
            {
                ParameterName = "@PriorityNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = availableStandingTeeTime.PriorityNumber
            };
            updateStandingTeeTimeCommand.Parameters.Add(priorityNumberParameter);

            SqlParameter approvedTeeTimeParameter = new SqlParameter()
            {
                ParameterName = "@ApprovedTeeTime",
                SqlDbType = SqlDbType.NVarChar,
                Size = 25,
                Direction = ParameterDirection.Input,
                SqlValue = availableStandingTeeTime.ApprovedTeeTime
            };

            updateStandingTeeTimeCommand.Parameters.Add(approvedTeeTimeParameter);

            SqlParameter approvedByParameter = new SqlParameter()
            {
                ParameterName = "@ApprovedBy",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                SqlValue = availableStandingTeeTime.ApprovedBy
            };

            updateStandingTeeTimeCommand.Parameters.Add(approvedByParameter);

            SqlParameter approvedDateParameter = new SqlParameter()
            {
                ParameterName = "@ApprovedDate",
                SqlDbType = SqlDbType.NVarChar,
                Size = 25,
                Direction = ParameterDirection.Input,
                SqlValue = availableStandingTeeTime.ApprovedDate
            };

            updateStandingTeeTimeCommand.Parameters.Add(approvedDateParameter);

            SqlParameter returnStatusParameter = new SqlParameter()
            {
                ParameterName = "@ReturnStatus",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.ReturnValue
            };

            updateStandingTeeTimeCommand.Parameters.Add(returnStatusParameter);
            // Execute. Return one record

            //updateStandingTeeTimeCommand.ExecuteNonQuery();
            int result = (int)updateStandingTeeTimeCommand.ExecuteNonQuery();
            int PrioirtyNumber = (int)updateStandingTeeTimeCommand.Parameters["@PrioirtyNumber"].Value;
            if ((int)returnStatusParameter.Value == 0)
            {
                Success = true;
                dbConnection.Close();
            }


            return Success;

        }
        public StandingTeeTime GetStandingTeeTime(string RequestedStartDate, string RequestedTeeTime)
        {
            StandingTeeTime SubmittedTeeTime = null;

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
                CommandText = "uspFindStandingTeeTime"
            };
            SqlParameter startDateParameter = new SqlParameter()
            {
                ParameterName = "@RequestedStartDate",
                SqlDbType = SqlDbType.NVarChar,
                Size= 25,
                SqlValue = RequestedStartDate,
                Direction = ParameterDirection.Input

            };
            getTeeTimeCommnd.Parameters.Add(startDateParameter);

            SqlParameter teeTimeParameter = new SqlParameter()
            {
                ParameterName = "@RequestedTeeTime",
                SqlDbType = SqlDbType.NVarChar,
                Size = 25,
                SqlValue = RequestedTeeTime,
                Direction = ParameterDirection.Input

            };
            getTeeTimeCommnd.Parameters.Add(teeTimeParameter);

            SqlDataReader reader = getTeeTimeCommnd.ExecuteReader();

            if (reader.Read())
            {
                SubmittedTeeTime = new StandingTeeTime();

                SubmittedTeeTime.PriorityNumber = (int)reader["PriorityNumber"];
                SubmittedTeeTime.MembershipLevel = reader["MembershipLevel"].ToString();
                SubmittedTeeTime.Role = reader["Role"].ToString();
                SubmittedTeeTime.RequestedDayOfWeek = reader["RequestedDayOfWeek"].ToString();
                SubmittedTeeTime.RequestedStartDate = reader["RequestedStartDate"].ToString();
                SubmittedTeeTime.RequestedEndDate = reader["RequestedEndDate"].ToString();
                SubmittedTeeTime.RequestedTeeTime = reader["RequestedTeeTime"].ToString();
                SubmittedTeeTime.MemberNumber = (int)reader["MemberNumber"];
                SubmittedTeeTime.MemberName = reader["MemberName"].ToString();
                SubmittedTeeTime.MemberNumber2 = (int)reader["MemberNumber2"];
                SubmittedTeeTime.MemberName2 = reader["MemberName2"].ToString();
                SubmittedTeeTime.MemberNumber3 = (int)reader["MemberNumber3"];
                SubmittedTeeTime.MemberName3 = reader["MemberName3"].ToString();
                SubmittedTeeTime.MemberNumber4 = (int)reader["MemberNumber4"];
                SubmittedTeeTime.MemberName4 = reader["MemberName4"].ToString();
                SubmittedTeeTime.ApprovedTeeTime = reader["ApprovedTeeTime"].ToString();
                SubmittedTeeTime.ApprovedBy = reader["ApprovedBy"].ToString();
                SubmittedTeeTime.ApprovedDate = reader["ApprovedDate"].ToString();

            }
            return SubmittedTeeTime;

        }
        public int AddStandingTeeTime(StandingTeeTime newStandingTeeTime)
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

            SqlCommand addStandingTeeTimeCommand = new SqlCommand()
            {
                Connection = dbConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "uspAddStandingTeeTime"
            };
            //SqlParameter roleParameter = new SqlParameter()
            //{
            //    ParameterName = "@Role",
            //    SqlDbType = SqlDbType.VarChar,
            //    Size = 25,
            //    Direction = ParameterDirection.Input,
            //    SqlValue = newStandingTeeTime.Role
            //};

            //addStandingTeeTimeCommand.Parameters.Add(roleParameter);

            SqlParameter membershipParameter = new SqlParameter()
            {
                ParameterName = "@MembershipLevel",
                SqlDbType = SqlDbType.NVarChar,
                Size = 25,
                Direction = ParameterDirection.Input,
                SqlValue = newStandingTeeTime.MembershipLevel
            };

            addStandingTeeTimeCommand.Parameters.Add(membershipParameter);

            SqlParameter dayOfWeekParameter = new SqlParameter()
            {
                ParameterName = "@RequestedDayOfWeek",
                SqlDbType = SqlDbType.NVarChar,
                Size = 25,
                Direction = ParameterDirection.Input,
                SqlValue = newStandingTeeTime.RequestedDayOfWeek
            };
            addStandingTeeTimeCommand.Parameters.Add(dayOfWeekParameter);

            SqlParameter startDateParameter = new SqlParameter()
            {
                ParameterName = "@RequestedStartDate",
                SqlDbType = SqlDbType.NVarChar,
                Size = 25,
                Direction = ParameterDirection.Input,
                SqlValue = newStandingTeeTime.RequestedStartDate
            };
            addStandingTeeTimeCommand.Parameters.Add(startDateParameter);

            SqlParameter endDateParameter = new SqlParameter()
            {
                ParameterName = "@RequestedEndDate",
                SqlDbType = SqlDbType.NVarChar,
                Size = 25,
                Direction = ParameterDirection.Input,
                SqlValue = newStandingTeeTime.RequestedEndDate
            };
            addStandingTeeTimeCommand.Parameters.Add(endDateParameter);

            SqlParameter teeTimeParameter = new SqlParameter()
            {
                ParameterName = "@RequestedTeeTime",
                SqlDbType = SqlDbType.NVarChar,
                Size = 25,
                Direction = ParameterDirection.Input,
                SqlValue = newStandingTeeTime.RequestedTeeTime
            };

            addStandingTeeTimeCommand.Parameters.Add(teeTimeParameter);


            SqlParameter memberNumberParameter = new SqlParameter()
            {
                ParameterName = "@MemberNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = newStandingTeeTime.MemberNumber
            };

            addStandingTeeTimeCommand.Parameters.Add(memberNumberParameter);

            SqlParameter shareholderNameParameter = new SqlParameter()
            {
                ParameterName = "@MemberName",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                SqlValue = newStandingTeeTime.MemberName
            };

            addStandingTeeTimeCommand.Parameters.Add(shareholderNameParameter);

            SqlParameter memeberNumber2Parameter = new SqlParameter()
            {
                ParameterName = "@MemberNumber2",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = newStandingTeeTime.MemberNumber2
            };

            addStandingTeeTimeCommand.Parameters.Add(memeberNumber2Parameter);

            SqlParameter memberName2Parameter = new SqlParameter()
            {
                ParameterName = "@MemberName2",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                SqlValue = newStandingTeeTime.MemberName2
            };

            addStandingTeeTimeCommand.Parameters.Add(memberName2Parameter);

            SqlParameter memberNumber3Parameter = new SqlParameter()
            {
                ParameterName = "@MemberNumber3",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = newStandingTeeTime.MemberNumber3
            };

            addStandingTeeTimeCommand.Parameters.Add(memberNumber3Parameter);

            SqlParameter memberName3Parameter = new SqlParameter()
            {
                ParameterName = "@MemberName3",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                SqlValue = newStandingTeeTime.MemberName3
            };

            addStandingTeeTimeCommand.Parameters.Add(memberName3Parameter);
            SqlParameter memberNumber4Parameter = new SqlParameter()
            {
                ParameterName = "@MemberNumber4",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = newStandingTeeTime.MemberNumber4
            };

            addStandingTeeTimeCommand.Parameters.Add(memberNumber4Parameter);

            SqlParameter memberName4Parameter = new SqlParameter()
            {
                ParameterName = "@MemberName4",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                SqlValue = newStandingTeeTime.MemberName4
            };

            addStandingTeeTimeCommand.Parameters.Add(memberName4Parameter);
            //more for an update. Might change later.
            SqlParameter approvedTeeTimeParameter = new SqlParameter()
            {
                ParameterName = "@ApprovedTeeTime",
                SqlDbType = SqlDbType.NVarChar,
                Size = 25,
                Direction = ParameterDirection.Input,
                SqlValue = newStandingTeeTime.ApprovedTeeTime
            };

            addStandingTeeTimeCommand.Parameters.Add(approvedTeeTimeParameter);

            SqlParameter approvedByParameter = new SqlParameter()
            {
                ParameterName = "@ApprovedBy",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                SqlValue = newStandingTeeTime.ApprovedBy
            };

            addStandingTeeTimeCommand.Parameters.Add(approvedByParameter);

            SqlParameter approvedDateParameter = new SqlParameter()
            {
                ParameterName = "@ApprovedDate",
                SqlDbType = SqlDbType.NVarChar,
                Size = 25,
                Direction = ParameterDirection.Input,
                SqlValue = newStandingTeeTime.ApprovedDate
            };

            addStandingTeeTimeCommand.Parameters.Add(approvedDateParameter);


            SqlParameter returnStatusParameter = new SqlParameter()
            {
                ParameterName = "@ReturnStatus",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.ReturnValue
            };

            addStandingTeeTimeCommand.Parameters.Add(returnStatusParameter);

            SqlParameter priorityNumberParameter = new SqlParameter()
            {
                ParameterName = "@PriorityNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            addStandingTeeTimeCommand.Parameters.Add(priorityNumberParameter);

             int result = (int)addStandingTeeTimeCommand.ExecuteNonQuery();
            int PriorityNumber = (int) addStandingTeeTimeCommand.Parameters["@PriorityNumber"].Value;
            if ((int)returnStatusParameter.Value == 0)
            {
                
                dbConnection.Close();
            }

            return PriorityNumber;
        }
    }
}
