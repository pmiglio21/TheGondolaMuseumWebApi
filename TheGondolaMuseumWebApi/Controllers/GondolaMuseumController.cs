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
        public string GetStringFromApi()
        {
            return "The Gondola Museum API is up and running!";
        }
    }
}
