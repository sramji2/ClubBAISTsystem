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
    public class Members
    {
        public Member GetMember(string Email)
        {
            Member activeMember = null;
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
                CommandText = "uspFindMember"
            };
            SqlParameter memberNumberParameter = new SqlParameter()
            {
                ParameterName = "@Email",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                SqlValue = Email,
                Direction = ParameterDirection.Input

            };
            getMemberCommand.Parameters.Add(memberNumberParameter);

            SqlDataReader reader = getMemberCommand.ExecuteReader();
            if (reader.Read())
            {
                activeMember = new Member();
                activeMember.MemberNumber = (int)reader["MemberNumber"];
                activeMember.MembershipLevel = reader["MembershipLevel"].ToString();
                activeMember.LastName = reader["LastName"].ToString();
                activeMember.FirstName = reader["FirstName"].ToString();
                activeMember.HomeAddress = reader["HomeAddress"].ToString();
                activeMember.HomePostalCode = reader["HomePostalCode"].ToString();
                activeMember.HomePhone = reader["HomePhone"].ToString();
                activeMember.AlternatePhone = reader["AlternatePhone"].ToString();
                activeMember.Email = reader["Email"].ToString();
                activeMember.DateOfBirth = reader["DateOfBirth"].ToString();
                activeMember.Occupation = reader["Occupation"].ToString();
                activeMember.CompanyName = reader["CompanyName"].ToString();
                activeMember.CompanyAddress = reader["CompanyAddress"].ToString();
                activeMember.CompanyPostalCode = reader["CompanyPostalCode"].ToString();
                activeMember.CompanyPhone = reader["CompanyPhone"].ToString();
                activeMember.DateCharged = reader["DateCharged"].ToString();
                activeMember.PaymentDescription = reader["PaymentDescription"].ToString();
                activeMember.AmountPaid = (decimal)reader["AmountPaid"];
                activeMember.BalanceDue = (decimal)reader["BalanceDue"];
                activeMember.BalanceOwing = (decimal)reader["BalanceOwing"];


            }

            return activeMember;

        }
        public bool UpdateApplication(Member memberApplication)
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

            SqlCommand updateApplicationCommand = new SqlCommand()
            {
                Connection = dbConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "uspUpdateMemberApplication"
            };

            SqlParameter applicationIDParameter = new SqlParameter()
            {
                ParameterName = "@ApplicationID",
                SqlDbType = SqlDbType.Int,
                SqlValue = memberApplication.ApplicationID,
                Direction = ParameterDirection.Input,

            };

            updateApplicationCommand.Parameters.Add(applicationIDParameter);

            SqlParameter applicationStatusParameter = new SqlParameter()
            {
                ParameterName = "@ApplicationStatus",
                SqlDbType = SqlDbType.NVarChar,
                Size = 15,
                SqlValue = memberApplication.ApplicationStatus,
                Direction = ParameterDirection.Input

            };
            updateApplicationCommand.Parameters.Add(applicationStatusParameter);

            SqlParameter membershipLevelParameter = new SqlParameter()
            {
                ParameterName = "@MembershipLevel",
                SqlDbType = SqlDbType.NVarChar,
                Size = 25,
                SqlValue = memberApplication.MembershipLevel,
                Direction = ParameterDirection.Input,
                
            };

            updateApplicationCommand.Parameters.Add(membershipLevelParameter);

            SqlParameter approvedByParameter = new SqlParameter()
            {
                ParameterName = "@ApprovedBy",
                SqlDbType = SqlDbType.NVarChar,
                Size = 25,
                Direction = ParameterDirection.Input,
                SqlValue = memberApplication.ApprovedBy
            };

            updateApplicationCommand.Parameters.Add(approvedByParameter);

            SqlParameter returnStatusParameter = new SqlParameter()
            {
                ParameterName = "@ReturnStatus",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.ReturnValue
            };

            updateApplicationCommand.Parameters.Add(returnStatusParameter);
            // Execute. Return one record

            updateApplicationCommand.ExecuteNonQuery();

            if ((int)returnStatusParameter.Value == 0)
            {
                Success = true;
                dbConnection.Close();
            }


            return Success;

        }
        public Member GetApplication(string ApplicationStatus)
        {
            //Member membershipApplication = new Member();
            Member membershipApplication = null;

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

            SqlCommand applicationCommand = new SqlCommand
            {
                Connection = dbConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "uspFindMembershipApplication"
            };

            SqlParameter applicationParameter = new SqlParameter
            {
                ParameterName = "@ApplicationStatus",
                SqlDbType = SqlDbType.NVarChar,
                Size = 15,
                Direction = ParameterDirection.Input,
                SqlValue = ApplicationStatus
            };
            applicationCommand.Parameters.Add(applicationParameter);
            
           SqlDataReader reader = applicationCommand.ExecuteReader();

            if (reader.Read())
            {

                    membershipApplication = new Member();
                    membershipApplication.ApplicationID = (int)reader["ApplicationID"];
                    membershipApplication.ApplicationStatus = reader["ApplicationStatus"].ToString();
                    membershipApplication.MembershipLevel = reader["MembershipLevel"].ToString();
                    membershipApplication.LastName = reader["LastName"].ToString();
                    membershipApplication.FirstName = reader["FirstName"].ToString();
                    membershipApplication.HomeAddress = reader["HomeAddress"].ToString();
                    membershipApplication.HomeCity = reader["HomeCity"].ToString();
                    membershipApplication.HomeProvince = reader["HomeProvince"].ToString();
                    membershipApplication.HomePostalCode = reader["HomePostalCode"].ToString();
                    membershipApplication.HomePhone = reader["HomePhone"].ToString();
                    membershipApplication.AlternatePhone = reader["AlternatePhone"].ToString();
                    membershipApplication.Email = reader["Email"].ToString();
                    membershipApplication.DateOfBirth = reader["DateOfBirth"].ToString();
                    membershipApplication.Occupation = reader["Occupation"].ToString();
                    membershipApplication.CompanyName = reader["CompanyName"].ToString();
                    membershipApplication.CompanyAddress = reader["CompanyAddress"].ToString();
                    membershipApplication.CompanyCity = reader["CompanyCity"].ToString();
                    membershipApplication.CompanyProvince = reader["CompanyProvince"].ToString();
                    membershipApplication.CompanyPostalCode = reader["CompanyPostalCode"].ToString();
                    membershipApplication.CompanyPhone = reader["CompanyPhone"].ToString();
                    membershipApplication.Date = reader["Date"].ToString();
                    membershipApplication.ShareholderName1 = reader["ShareholderName1"].ToString();
                    membershipApplication.ShareholderName2 = reader["ShareholderName2"].ToString();
                    membershipApplication.ApprovedBy = reader["ApprovedBy"].ToString();

                
                
            }
           

            return membershipApplication;
            //dbConnection.Close();
        }
        public Member AddMember(Member newMember)
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

            SqlCommand addMemberCommand = new SqlCommand()
            {
                Connection = dbConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "uspAddMember"
            };
            SqlParameter membershipLevelParameter = new SqlParameter()
            {
                ParameterName = "@MembershipLevel",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                SqlValue = newMember.MembershipLevel
            };
            addMemberCommand.Parameters.Add(membershipLevelParameter);

            SqlParameter lastNameParameter = new SqlParameter()
            {
                ParameterName = "@LastName",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                SqlValue = newMember.LastName
            };
            addMemberCommand.Parameters.Add(lastNameParameter);

            SqlParameter firstNameParameter = new SqlParameter()
            {
                ParameterName = "@FirstName",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                SqlValue = newMember.FirstName
            };
            addMemberCommand.Parameters.Add(firstNameParameter);

            SqlParameter homeAddressParameter = new SqlParameter()
            {
                ParameterName = "@HomeAddress",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                SqlValue = newMember.HomeAddress
            };

            addMemberCommand.Parameters.Add(homeAddressParameter);

            SqlParameter cityParameter = new SqlParameter()
            {
                ParameterName = "@HomeCity",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                SqlValue = newMember.HomeCity
            };

            addMemberCommand.Parameters.Add(cityParameter);

            SqlParameter homeProvinceCode = new SqlParameter()
            {
                ParameterName = "@HomeProvince",
                SqlDbType = SqlDbType.NVarChar,
                Size = 10,
                Direction = ParameterDirection.Input,
                SqlValue = newMember.HomeProvince
            };

            addMemberCommand.Parameters.Add(homeProvinceCode);

            SqlParameter homePostalCodeParameter = new SqlParameter()
            {
                ParameterName = "@HomePostalCode",
                SqlDbType = SqlDbType.NVarChar,
                Size = 10,
                Direction = ParameterDirection.Input,
                SqlValue = newMember.HomePostalCode
            };

            addMemberCommand.Parameters.Add(homePostalCodeParameter);

            SqlParameter homePhoneParameter = new SqlParameter()
            {
                ParameterName = "@HomePhone",
                SqlDbType = SqlDbType.NVarChar,
                Size = 15,
                Direction = ParameterDirection.Input,
                SqlValue = newMember.HomePhone
            };

            addMemberCommand.Parameters.Add(homePhoneParameter);

            SqlParameter alternativePhoneParameter = new SqlParameter()
            {
                ParameterName = "@AlternatePhone",
                SqlDbType = SqlDbType.NVarChar,
                Size = 15,
                Direction = ParameterDirection.Input,
                SqlValue = newMember.AlternatePhone
            };

            addMemberCommand.Parameters.Add(alternativePhoneParameter);

            SqlParameter emailParameter = new SqlParameter()
            {
                ParameterName = "@Email",
                SqlDbType = SqlDbType.NVarChar,
                Size = 100,
                Direction = ParameterDirection.Input,
                SqlValue = newMember.Email
            };

            addMemberCommand.Parameters.Add(emailParameter);

            SqlParameter dateOfBirthParameter = new SqlParameter()
            {
                ParameterName = "@DateOfBirth",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                SqlValue = newMember.DateOfBirth
            };

            addMemberCommand.Parameters.Add(dateOfBirthParameter);

            SqlParameter occupationParameter = new SqlParameter()
            {
                ParameterName = "@Occupation",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                SqlValue = newMember.Occupation
            };

            addMemberCommand.Parameters.Add(occupationParameter);

            SqlParameter companyNameParameter = new SqlParameter()
            {
                ParameterName = "@CompanyName",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                SqlValue = newMember.CompanyName
            };

            addMemberCommand.Parameters.Add(companyNameParameter);

            SqlParameter companyAddressParameter = new SqlParameter()
            {
                ParameterName = "@CompanyAddress",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                SqlValue = newMember.CompanyAddress
            };

            addMemberCommand.Parameters.Add(companyAddressParameter);

            SqlParameter companyCityParameter = new SqlParameter()
            {
                ParameterName = "@CompanyCity",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                SqlValue = newMember.CompanyCity
            };

            addMemberCommand.Parameters.Add(companyCityParameter);

            SqlParameter companyProvinceParameter = new SqlParameter()
            {
                ParameterName = "@CompanyProvince",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                SqlValue = newMember.CompanyProvince
            };

            addMemberCommand.Parameters.Add(companyProvinceParameter);

            SqlParameter companyPostalCodeParameter = new SqlParameter()
            {
                ParameterName = "@CompanyPostalCode",
                SqlDbType = SqlDbType.NVarChar,
                Size = 10,
                Direction = ParameterDirection.Input,
                SqlValue = newMember.CompanyName
            };

            addMemberCommand.Parameters.Add(companyPostalCodeParameter);

            SqlParameter companyPhoneParameter = new SqlParameter()
            {
                ParameterName = "@CompanyPhone",
                SqlDbType = SqlDbType.NVarChar,
                Size = 10,
                Direction = ParameterDirection.Input,
                SqlValue = newMember.CompanyPhone
            };

            addMemberCommand.Parameters.Add(companyPhoneParameter);

            SqlParameter dateParameter = new SqlParameter()
            {
                ParameterName = "@Date",
                SqlDbType = SqlDbType.NVarChar,
                Size = 25,
                Direction = ParameterDirection.Input,
                SqlValue = newMember.Date
            };

            addMemberCommand.Parameters.Add(dateParameter);

            SqlParameter shareholderName1Parameter = new SqlParameter()
            {
                ParameterName = "@ShareholderName1",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                SqlValue = newMember.ShareholderName1
            };

            addMemberCommand.Parameters.Add(shareholderName1Parameter);

            SqlParameter shareholderName2Parameter = new SqlParameter()
            {
                ParameterName = "@ShareholderName2",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                SqlValue = newMember.ShareholderName2
            };

            addMemberCommand.Parameters.Add(shareholderName2Parameter);

            SqlParameter applicationIDParameter = new SqlParameter()
            {
                ParameterName = "@ApplicationID",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            addMemberCommand.Parameters.Add(applicationIDParameter);

            SqlParameter applicationStatusParameter = new SqlParameter()
            {
                ParameterName = "@ApplicationStatus",
                SqlDbType = SqlDbType.NVarChar,
                Size = 15,
                Direction = ParameterDirection.Output
            };

            addMemberCommand.Parameters.Add(applicationStatusParameter);

            SqlParameter returnStatusParameter = new SqlParameter()
            {
                ParameterName = "@ReturnStatus",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.ReturnValue
            };

            addMemberCommand.Parameters.Add(returnStatusParameter);

           int result = (int)addMemberCommand.ExecuteNonQuery();
           newMember.ApplicationID = (int)addMemberCommand.Parameters["@ApplicationID"].Value;
           //newMember.ApplicationStatus = (string)addMemberCommand.Parameters["@ApplicationStatus"].Value;

            if ((int)returnStatusParameter.Value == 0)
            {
                
                dbConnection.Close();
            }

            return newMember;
            
        }


    }

}
