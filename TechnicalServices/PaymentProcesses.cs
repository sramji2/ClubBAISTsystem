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
    public class PaymentProcesses
    {
        public PaymentProcess ProcessMemberPayment(PaymentProcess paymentProcess)
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

            SqlCommand addPaymentCommand = new SqlCommand()
            {
                Connection = dbConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "uspAddMemberPayment"
            };
            SqlParameter dateParameter = new SqlParameter()
            {
                ParameterName = "@Date",
                SqlDbType = SqlDbType.NVarChar,
                Size = 25,
                SqlValue = paymentProcess.Date,
                Direction = ParameterDirection.Input

            };
            addPaymentCommand.Parameters.Add(dateParameter);

            SqlParameter lastNameParameter = new SqlParameter()
            {
                ParameterName = "@LastName",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                SqlValue = paymentProcess.LastName
            };

            addPaymentCommand.Parameters.Add(lastNameParameter);

            SqlParameter creditCardParameter = new SqlParameter()
            {
                ParameterName = "@CreditCardNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = paymentProcess.CreditCardNumber
            };
            addPaymentCommand.Parameters.Add(creditCardParameter);

            SqlParameter expiryDateParameter = new SqlParameter()
            {
                ParameterName = "@ExpirDate",
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                SqlValue = paymentProcess.ExpiryDate
            };
            addPaymentCommand.Parameters.Add(expiryDateParameter);

            SqlParameter currencyParameter = new SqlParameter()
            {
                ParameterName = "@Currency",
                SqlDbType = SqlDbType.NVarChar,
                Size = 10,
                Direction = ParameterDirection.Input,
                SqlValue = paymentProcess.Currency
            };

            addPaymentCommand.Parameters.Add(currencyParameter);

            SqlParameter paymentDescriptionParameter = new SqlParameter()
            {
                ParameterName = "@PaymentDescription",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                SqlValue = paymentProcess.PaymentDescription
            };

            addPaymentCommand.Parameters.Add(paymentDescriptionParameter);

            SqlParameter amountPaidParameter = new SqlParameter()
            {
                ParameterName = "@AmountPaid",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = paymentProcess.AmountPaid
            };

            addPaymentCommand.Parameters.Add(amountPaidParameter);

            SqlParameter balanceDueParameter = new SqlParameter()
            {
                ParameterName = "@BalanceDue",
                SqlDbType = SqlDbType.Decimal,
                Direction = ParameterDirection.Input,
                SqlValue = paymentProcess.BalanceDue
            };

            addPaymentCommand.Parameters.Add(balanceDueParameter);

            SqlParameter balanceOwingParameter = new SqlParameter()
            {
                ParameterName = "@BalanceOwing",
                SqlDbType = SqlDbType.Decimal,
                Direction = ParameterDirection.Input,
                SqlValue = paymentProcess.BalanceOwing
            };

            addPaymentCommand.Parameters.Add(balanceOwingParameter);

            SqlParameter returnStatusParameter = new SqlParameter()
            {
                ParameterName = "@ReturnStatus",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.ReturnValue
            };

            addPaymentCommand.Parameters.Add(returnStatusParameter);

            SqlDataReader reader = addPaymentCommand.ExecuteReader();
            PaymentProcess PaymentProcess;
            while (reader.Read())
            {
                PaymentProcess = new PaymentProcess();
                PaymentProcess.Date = reader["Date"].ToString();
                PaymentProcess.LastName = reader["LastName"].ToString();
                PaymentProcess.FirstName = reader["FirstName"].ToString();
                PaymentProcess.CreditCardNumber = (int)reader["CreditCardNumber"];
                PaymentProcess.ExpiryDate = reader["ExpiryDate"].ToString();
                PaymentProcess.Currency = reader["Currency"].ToString();
                PaymentProcess.PaymentDescription = reader["PaymentDescription"].ToString();
                PaymentProcess.AmountPaid = (decimal)reader["AmountPaid"];
                PaymentProcess.BalanceOwing = (decimal)reader["BalanceOwing"];
                PaymentProcess.BalanceDue = (decimal)reader["BalanceDue"];

                PaymentProcess.CalculateMemberPayment();


                //paymentProcess.ListScores.Add(PlayerScore);
            }
            dbConnection.Close();

            return paymentProcess;
        }

            


        }
    }

