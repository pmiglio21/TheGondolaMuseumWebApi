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

        public GondolaVideoController(ILogger<GondolaVideoController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetSingleByVideoId")]
        public string GetSingleByVideoId(int videoId)
        {
            if (videoId > 0)
            {
                return JsonConvert.SerializeObject(GondolaVideosDL.SelectSingleByVideoId(videoId));
            }
            else
            {
                return string.Empty;
            }
        }

        [HttpGet("GetMultipleByTag")]
        public string GetMultipleByTag(string tag)
        {
            return JsonConvert.SerializeObject(GondolaVideosDL.SelectMultipleByTag(tag));

            //if (!string.IsNullOrWhiteSpace(tag))
            //{
                
            //}
            //else
            //{
            //    return string.Empty;
            //}
        }

        [HttpGet("GetMultipleBySource")]
        public string GetMultipleBySource(string source)
        {
            return JsonConvert.SerializeObject(GondolaVideosDL.SelectMultipleBySource(source));

            //if (!string.IsNullOrWhiteSpace(source))
            //{
                
            //}
            //else
            //{
            //    return string.Empty;
            //}
        }

        [HttpGet("GetAllDistinctTags")]
        public string GetAllDistinctTags()
        {
            return JsonConvert.SerializeObject(GondolaVideosDL.SelectAllDistinctTags());
        }
    }
}
