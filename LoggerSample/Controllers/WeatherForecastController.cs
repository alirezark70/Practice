using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Xml.Linq;

namespace LoggerSample.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly HttpClient _httpClient;

        private readonly HttpRequest _httpClientRequest;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, HttpClient httpClient, HttpRequest httpClientRequest)
        {
            _logger = logger;
            _httpClient = httpClient;
            _httpClientRequest = httpClientRequest;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("redirect")]
        public async Task<IActionResult> Redirect()
        {
            var currentUrl= _httpClientRequest.GetDisplayUrl;
            var url = Url.Action(nameof(UserController.User), "User");
            var path = Path.Combine($"/{nameof(UserController)}/{nameof(UserController.User)}", $"?id={11}&name=bn");
            var response =await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {

                return Redirect(url);
            }
            else
            {
                return StatusCode((int)response.StatusCode, "Error occurred while calling Controller B.");
            }
        }
    }
}
