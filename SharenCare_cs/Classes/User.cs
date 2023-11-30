using Npgsql;
using System;
using System.Data;
using System.Windows;

namespace SharenCare_cs
{
    public class User
    {
        private readonly NpgsqlConnection connection;

        public User(NpgsqlConnection connection)
        {
            this.connection = connection;
        }

        public bool Register(string username, string displayName, string email, string location, string password)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT insert_user(@_userName, @_displayName, @_email, @_location, @_password)", connection))
                {
                    cmd.Parameters.AddWithValue("@_userName", username);
                    cmd.Parameters.AddWithValue("@_displayName", displayName);
                    cmd.Parameters.AddWithValue("@_email", email);
                    cmd.Parameters.AddWithValue("@_location", location);
                    cmd.Parameters.AddWithValue("@_password", password);

                    int result = (int)cmd.ExecuteScalar();

                    return result == 1; // If result is 1, the user was registered successfully.
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool Login(string username, string password)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT COUNT(*) FROM snc_users WHERE username = @username AND password = @password", connection))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    return count > 0; // If count is greater than 0, the user with the provided username and password exists.
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        private void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}