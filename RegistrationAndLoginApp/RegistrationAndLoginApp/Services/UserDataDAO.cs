using RegistrationAndLoginApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationAndLoginApp.Services
{
    public class UserDataDAO
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=aspnet-KOOLKAY63-30274244-E812-47B0-87CD-505CF3EE5036;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public bool FindUserByNameAndPassword(UserModel userModel)
        {
            bool success = false;
            string sqlStatement = "SELECT * FROM dbo.UserData WHERE userName = @UserName AND password = @Password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.Add("@userName", System.Data.SqlDbType.VarChar, 25).Value = userModel.UserName;

                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 25).Value = userModel.Password;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        success = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return success;
            // return true if found
        }
        public int Insert(UserModel userModel)
        {
            int newId = -1;

            string sqlStatement = "INSERT INTO dbo.UserData (FirstName, LastName, Sex, Age, State,  Email, UserName, Password) VALUES (@FirstName,@LastName,@Sex,@Age,@State, @Email, @UserName, @Password)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.AddWithValue("@FirstName", userModel.FirstName);
                command.Parameters.AddWithValue("@LastName", userModel.LastName);
                command.Parameters.AddWithValue("@Sex", userModel.Sex);
                command.Parameters.AddWithValue("@Age", userModel.Age);
                command.Parameters.AddWithValue("@State", userModel.State);
                command.Parameters.AddWithValue("@Email", userModel.Email);
                command.Parameters.AddWithValue("@Password", userModel.Password);
                command.Parameters.AddWithValue("@UserName", userModel.UserName);


                try
                {
                    connection.Open();
                    newId = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return newId;
        }

    }
}
