using Npgsql;
using NpgsqlTypes;
using System;
using System.Data;
using System.Windows;

namespace SharenCare_cs
{
    public class Item
    {
        private readonly NpgsqlConnection connection;

        public Item(NpgsqlConnection connection)
        {
            this.connection = connection;
        }

        public bool Donate(string itemName, string itemCategory, DateTime expireDate, int quantity, string donor, string note)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT insert_item(@_itemname, @_itemcategory, @_expiredate, @_quantity, @_donor, @_note )", connection))
                {
                    cmd.Parameters.AddWithValue("@_itemname", itemName);
                    cmd.Parameters.AddWithValue("@_itemcategory", itemCategory);
                    cmd.Parameters.AddWithValue("@_expiredate", NpgsqlDbType.Date, expireDate);
                    cmd.Parameters.AddWithValue("@_quantity", NpgsqlDbType.Integer, quantity);
                    cmd.Parameters.AddWithValue("@_donor", donor);
                    cmd.Parameters.AddWithValue("@_note", note);

                    int result = (int)cmd.ExecuteScalar();

                    return result == 1; // If result is 1, the item was donated successfully.
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