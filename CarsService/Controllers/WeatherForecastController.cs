using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarsService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static int idIndex = 0;

        private static List<WeatherForecast> weatherForecasts = CreateWeatherForecastsList();

        private static List<WeatherForecast> CreateWeatherForecastsList()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Id = ++idIndex,
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToList();
        }

        [HttpGet]
        public IActionResult GetWeatherForecastsList()
        {
            return Ok(weatherForecasts);
        }

        [HttpGet("{id}")]
        public IActionResult GetWeatherForecastById(int id)
        {
            var res = weatherForecasts.Where(x => x.Id == id).ToList();
            if (res.Count() == 0)
            {
                return NotFound();
            }

            return Ok(res);
        }

        [HttpPost]
        public IActionResult CreateWeatherForecast(WeatherForecast weatherForecast)
        {
            weatherForecast.Id = ++idIndex;
            weatherForecast.Date = DateTime.Now;
            weatherForecasts.Add(weatherForecast);

            return Ok(weatherForecast);
        }

        [HttpPut("{id}")]
        public IActionResult PutWeatherForecastById(int id, WeatherForecast changedWeatherForecast)
        {
            var listForCheckCorrectId = weatherForecasts.Where(x => x.Id == id).ToList();
            if (listForCheckCorrectId.Count() == 0)
            {
                return NotFound();
            }
            int indexOfOldWeatherForecast = weatherForecasts.IndexOf(listForCheckCorrectId[0]);
            weatherForecasts[indexOfOldWeatherForecast] = changedWeatherForecast;
            weatherForecasts[indexOfOldWeatherForecast].Id = id;
            weatherForecasts[indexOfOldWeatherForecast].Date = DateTime.Now;

            return Ok(weatherForecasts[indexOfOldWeatherForecast]);
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteWeatherForecastById(int id)
        {
            var listForCheckCorrectId = weatherForecasts.Where(x => x.Id == id).ToList();
            if (listForCheckCorrectId.Count() == 0)
            {
                return NotFound();
            }
            WeatherForecast deletedWeatherForecast = listForCheckCorrectId[0];
            weatherForecasts.Remove(deletedWeatherForecast);

            return Ok(deletedWeatherForecast);
        }
    }
}
