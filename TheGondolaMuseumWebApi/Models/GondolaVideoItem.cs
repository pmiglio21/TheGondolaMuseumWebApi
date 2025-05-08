using Microsoft.Data.SqlClient;
using Newtonsoft.Json.Linq;

namespace TheGondolaMuseumWebApi.Models
{
    public class GondolaVideoItem
    {
        public long VideoId { get; set; }
        public string? VideoName { get; set; }
        public bool IsFavorite { get; set; }
        public string? OriginalFileName { get; set; }
        public string[]? Tags { get; set; }
        public string? MusicOrigin { get; set; }
        public string? MusicName { get; set; }
        public string? BackgroundArtOrigin { get; set; }
        public string? GondolaCreator { get; set; }
        public int EarliestFoundDateOfPosting { get; set; }
        public int[]? SimilarVideos { get; set; }
        public string? RippedFrom { get; set; }

        public GondolaVideoItem ToGondolaVideoItem(SqlDataReader reader)
        {
            GondolaVideoItem gondolaVideoItem = new GondolaVideoItem
            {
                VideoId = (long)reader["VideoId"],
                VideoName = ConvertFromDBVal<string>(reader["VideoName"]),
                IsFavorite = ConvertFromDBVal<string>(reader["Favorite"]) == "x",
                OriginalFileName = ConvertFromDBVal<string>(reader["VideoName"]),
                Tags = new string[0], // Initialize with an empty array
                MusicOrigin = ConvertFromDBVal<string>(reader["MusicOrigin"]),
                MusicName = ConvertFromDBVal<string>(reader["MusicName"]),
                BackgroundArtOrigin = ConvertFromDBVal<string>(reader["BackgroundArtOrigin"]),
                GondolaCreator = ConvertFromDBVal<string>(reader["GondolaCreator"]),
                EarliestFoundDateOfPosting = (int)reader["EarliestFoundDateOfPosting"],
                SimilarVideos = new int[0], // Initialize with an empty array
                RippedFrom = ConvertFromDBVal<string>(reader["RippedFrom"]),
            };

            string allTags = ConvertFromDBVal<string>(reader["Tags"]);

            if (allTags != null)
            {
                gondolaVideoItem.Tags = allTags.Split("_");
            }

            string allSimilarVideos = ConvertFromDBVal<string>(reader["SimilarTo"]);

            if (allSimilarVideos != null)
            {
                string[] similarVideoStrings = allSimilarVideos.Split("_");
                List<int> similarVideosList = new List<int>();

                foreach (string similarVideoId in similarVideoStrings)
                {
                    similarVideosList.Add(int.Parse(similarVideoId));
                }

                gondolaVideoItem.SimilarVideos = similarVideosList.ToArray();
            }

            return gondolaVideoItem;
        }

        private static T ConvertFromDBVal<T>(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return default(T); // returns the default value for the type
            }
            else
            {
                return (T)obj;
            }
        }
    }
}
