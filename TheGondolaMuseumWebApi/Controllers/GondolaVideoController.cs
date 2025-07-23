using Azure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace TheGondolaMuseumWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GondolaVideoController : ControllerBase
    {
        private readonly ILogger<GondolaVideoController> _logger;
        private IGondolaVideosDL _gondolaVideosDL;

        public GondolaVideoController(ILogger<GondolaVideoController> logger, IGondolaVideosDL gondolaVideosDL)
        {
            _logger = logger;
            _gondolaVideosDL = gondolaVideosDL;
        }

        [HttpGet("GetSingleByVideoId")]
        public string GetSingleByVideoId(int videoId)
        {
            if (videoId > 0)
            {
                return JsonConvert.SerializeObject(_gondolaVideosDL.SelectSingleByVideoId(videoId));
            }
            else
            {
                return string.Empty;
            }
        }

        [HttpGet("GetMultipleByTag")]
        public string GetMultipleByTag(string tag)
        {
            return JsonConvert.SerializeObject(_gondolaVideosDL.SelectMultipleByTag(tag));
        }

        [HttpGet("GetMultipleBySource")]
        public string GetMultipleBySource(string source)
        {
            return JsonConvert.SerializeObject(_gondolaVideosDL.SelectMultipleBySource(source));
        }

        [HttpGet("GetAllDistinctTags")]
        public string GetAllDistinctTags()
        {
            return JsonConvert.SerializeObject(_gondolaVideosDL.SelectAllDistinctTags());
        }
    }
}
