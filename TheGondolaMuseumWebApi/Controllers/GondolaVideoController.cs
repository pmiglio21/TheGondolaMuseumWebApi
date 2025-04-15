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
            return JsonConvert.SerializeObject(GondolaVideosDL.SelectSingleByVideoId(videoId));
        }

        [HttpGet("GetMultipleByTag")]
        public string GetMultipleByTag()
        {
            return JsonConvert.SerializeObject(GondolaVideosDL.SelectMultipleByTag(""));
        }
    }
}
