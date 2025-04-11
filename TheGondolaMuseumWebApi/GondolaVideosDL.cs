using System;
using Microsoft.Data.SqlClient;
using TheGondolaMuseumWebApi.Models;

namespace TheGondolaMuseumWebApi
{
    public static class GondolaVideosDL
    {
        public static GondolaVideoItem SelectSingleByVideoId(int videoId)
        {
            GondolaVideoItem gondolaVideoItem = new GondolaVideoItem();

            // Connection string to connect to the local SQL Server instance
            string connectionString = "Server=localhost;Database=Gondola;Trusted_Connection=True;User ID=USER;Password=PASS;TrustServerCertificate=True;";

            // Create a connection object
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();
                    //Console.WriteLine("Connection to SQL Server established successfully.");

                    string query = $"EXEC [GondolaVideosSelectSingleByVideoId] {videoId}";

                    // Execute the query
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                gondolaVideoItem = gondolaVideoItem.ToGondolaVideoItem(reader);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }

            return gondolaVideoItem;
        }

        public static string SelectMultipleByTag(string tag)
        {
            string message = "";

            // Connection string to connect to the local SQL Server instance
            string connectionString = "Server=localhost;Database=Gondola;Trusted_Connection=True;User ID=USER;Password=PASS;TrustServerCertificate=True;";

            SelectSingleByVideoId(2);

            // Create a connection object
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();
                    //Console.WriteLine("Connection to SQL Server established successfully.");

                    string query = "EXEC [GondolaVideosSelectMultipleByTag] 'mario'";

                    // Execute the query
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var a = reader["VideoName"];
                                var b = 0;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }

            return message;
        }
    }
}
