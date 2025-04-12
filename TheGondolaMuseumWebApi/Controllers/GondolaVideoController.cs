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
        public string GetSingleByVideoId()
        {
            return JsonConvert.SerializeObject(GondolaVideosDL.SelectSingleByVideoId(0));
        }

        [HttpGet("GetMultipleByTag")]
        public string GetMultipleByTag()
        {
            return JsonConvert.SerializeObject(GondolaVideosDL.SelectMultipleByTag(""));
        }
    }
}
