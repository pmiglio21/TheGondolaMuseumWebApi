using Microsoft.AspNetCore.Mvc;

namespace TheGondolaMuseumWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GondolaMuseumController : ControllerBase
    {
        private readonly ILogger<GondolaMuseumController> _logger;

        public GondolaMuseumController(ILogger<GondolaMuseumController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetStringFromApi")]
        public string GetSingleByVideoId()
        {
            GondolaVideosDL.SelectSingleByVideoId(0);

            return "The Gondola Museum API is up and running!";
        }

        [HttpGet(Name = "GetStringFromApi")]
        public string GetMultipleByTag()
        {
            GondolaVideosDL.SelectMultipleByTag("");

            return "The Gondola Museum API is up and running!";
        }
    }
}
