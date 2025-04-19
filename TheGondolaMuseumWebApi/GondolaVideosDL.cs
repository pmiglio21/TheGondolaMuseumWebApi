using System;
using Microsoft.Data.SqlClient;
using TheGondolaMuseumWebApi.Models;

namespace TheGondolaMuseumWebApi
{
    public static class GondolaVideosDL
    {
        private static string connectionString = "Server=localhost;Database=Gondola;Trusted_Connection=True;TrustServerCertificate=True;";

        public static GondolaVideoItem SelectSingleByVideoId(int videoId)
        {
            GondolaVideoItem gondolaVideoItem = new GondolaVideoItem();

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

            // Create a connection object
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();
                    //Console.WriteLine("Connection to SQL Server established successfully.");

                    string query = $"EXEC [GondolaVideosSelectMultipleByTag] '{tag}'";

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

        public static List<string> SelectAllDistinctTags()
        {
            HashSet<string> distinctTags = new HashSet<string>();

            // Create a connection object
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();
                    //Console.WriteLine("Connection to SQL Server established successfully.");

                    string query = "EXEC [GondolaVideosSelectAllTags]";

                    // Execute the query
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string tags = (string)reader["Tags"];

                                foreach(string tag in tags.Split("_"))
                                {
                                    if (!distinctTags.Contains(tag))
                                    {
                                        distinctTags.Add(tag);
                                    }
                                }
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

            List<string> distinctTagsList = distinctTags.ToList();

            distinctTagsList.Sort();

            return distinctTagsList;
        }
    }
}
