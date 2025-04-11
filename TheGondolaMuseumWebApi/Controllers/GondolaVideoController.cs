using Microsoft.AspNetCore.Mvc;

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
            GondolaVideosDL.SelectSingleByVideoId(0);

            return "The Gondola Museum API is up and running!";
        }

        [HttpGet("GetMultipleByTag")]
        public string GetMultipleByTag()
        {
            GondolaVideosDL.SelectMultipleByTag("");

            return "The Gondola Museum API is up and running!";
        }
    }
}
