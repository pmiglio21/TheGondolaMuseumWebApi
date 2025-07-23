using TheGondolaMuseumWebApi.Models;

namespace TheGondolaMuseumWebApi
{
    public interface IGondolaVideosDL
    {
        public GondolaVideoItem SelectSingleByVideoId(int videoId);

        public List<GondolaVideoItem> SelectMultipleByTag(string tag);

        public List<GondolaVideoItem> SelectMultipleBySource(string source);

        public List<string> SelectAllDistinctTags();
    }
}
