using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSVenta.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
       
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            List<WeatherForecast> forecasts = new List<WeatherForecast>();

            forecasts.Add(new WeatherForecast() { id = 5, name="Carlos" });
            forecasts.Add(new WeatherForecast() { id = 6, name = "Pedro" });

            return forecasts;
        }
    }
}
