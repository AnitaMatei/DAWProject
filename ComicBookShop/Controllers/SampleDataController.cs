using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ComicBookShop.Context;

namespace ComicShop.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private readonly MySqlContext mySqlContext;
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        public SampleDataController(MySqlContext context)
        {
            mySqlContext = context;
        }

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        [HttpGet("fuckme")]
        public IActionResult Users()
        {
            var users = mySqlContext.Users
                .Include(u => u.DeliveryAddress)
                .ToArray();

            var response = users.Select(u => new
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                Username = u.Username,
                DeliveryAddress = u.DeliveryAddress
            });

            return Ok(response);
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
