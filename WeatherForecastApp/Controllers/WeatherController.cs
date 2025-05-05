using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using WeatherForecastApp.Models;

namespace WeatherForecastApp.Controllers
{
    public class WeatherController : Controller
    {
        private readonly string apiKey = "bb986919904c4b997ccb0bcf156ef41d"; // Replace with your OpenWeatherMap key

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                ViewBag.Error = "Please enter a city name.";
                return View();
            }

            WeatherModel model = new WeatherModel();
            using (HttpClient client = new HttpClient())
            {
                string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    JObject data = JObject.Parse(json);

                    model.City = data["name"].ToString();
                    model.Description = data["weather"][0]["description"].ToString();
                    model.Temperature = float.Parse(data["main"]["temp"].ToString());
                    model.Humidity = int.Parse(data["main"]["humidity"].ToString());

                    return View(model);
                }
                else
                {
                    ViewBag.Error = "City not found.";
                }
            }

            return View();
        }
    }
}