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

        public static List<GondolaVideoItem> SelectMultipleByTag(string tag)
        {
            List<GondolaVideoItem> gondolaVideoItems = new List<GondolaVideoItem>();

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

                    string query = "EXEC [GondolaVideosSelectMultipleByTag] 'mario'";

                    // Execute the query
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                GondolaVideoItem gondolaVideoItem = new GondolaVideoItem();
                                
                                gondolaVideoItems.Add(gondolaVideoItem.ToGondolaVideoItem(reader));
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

            return gondolaVideoItems;
        }
    }
}
