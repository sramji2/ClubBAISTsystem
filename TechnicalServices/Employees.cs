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
    public class Employees
    {
        public Employee EmployeeUserLogin(string EmployeeNumber, string Password)
        {
            Employee ClubEmployee = null;

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
                CommandText = "uspClubEmployeeLogin"
            };

            SqlParameter emailParameter = new SqlParameter()
            {
                ParameterName = "@EmployeeNumber",
                SqlDbType = SqlDbType.NVarChar,
                SqlValue = EmployeeNumber,
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
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ClubEmployee = new Employee();

                    ClubEmployee.EmployeeNumber = reader["EmployeeNumber"].ToString();
                    ClubEmployee.EmployeeName = reader["EmployeeName"].ToString();
                    ClubEmployee.Email = reader["Email"].ToString();
                    ClubEmployee.Password = reader["Password"].ToString();
                    ClubEmployee.Role = reader["Role"].ToString();

                }

            }

            return ClubEmployee;

        }

    }
}

