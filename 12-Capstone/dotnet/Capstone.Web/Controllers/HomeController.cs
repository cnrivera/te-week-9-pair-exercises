using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;
using Microsoft.AspNetCore.Http;
using SessionCart.Web.Extensions;
using static Capstone.Web.Models.WeatherFromJSON;
using System.Net.Http;
using Newtonsoft.Json;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        private IParksDAO parkDAO;

        public HomeController(IParksDAO parkDAO)
        {
            this.parkDAO = parkDAO;
            
            
        }

        [HttpGet]
        public IActionResult Index()
        {
            var parks = parkDAO.GetAllParks();
            return View(parks);
        }
        
        [HttpGet]
        public async Task<IActionResult> Detail(string parkCode)
        {
            Park detail = parkDAO.GetPark(parkCode);
            
            //"latitude,longitude?exclude=currently,minutely,hourly,alerts,flags"
            using (var client = new HttpClient())
            {
                string latitude = detail.Latitude.ToString();
                string longitude = detail.Longitude.ToString();
                client.BaseAddress = new Uri("https://api.darksky.net/forecast/c68734a812ca6301d221b45dcbb39281/");
                //HTTP GET
                var responseTask = client.GetAsync(latitude + "," + longitude + "?exclude=currently,minutely,hourly,alerts,flags");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    string content = await result.Content.ReadAsStringAsync();
                    var arrayOfWeather = JsonConvert.DeserializeObject<Rootobject>(content).daily.data;

                    for (int i = 0; i < 5; i++)
                    {
                        Weather apiWeather = new Weather();
                        apiWeather.TemperatureLow = (int)arrayOfWeather[i].temperatureLow;
                        apiWeather.TemperatureHigh = (int)arrayOfWeather[i].temperatureHigh;
                        apiWeather.Forecast = arrayOfWeather[i].icon;
                        apiWeather.Summary = arrayOfWeather[i].summary;
                        detail.WeatherList.Add(apiWeather);
                    }


                }
            }

            bool isFarenheit = HttpContext.Session.Get<bool>("isFarenheit");

            if (HttpContext.Session.Keys.Contains("isFarenheit") == false)
            {
                HttpContext.Session.Set("isFarenheit", true);
            }

            
                foreach(Weather w in detail.WeatherList)
                {
                    w.IsFarenheit = HttpContext.Session.Get<bool>("isFarenheit");
                }
            

            return View(detail);
        }


        [HttpPost]
        public IActionResult SwitchTemperatureType(string parkCode)
        {
            bool isFarenheit = HttpContext.Session.Get<bool>("isFarenheit");
            HttpContext.Session.Set("isFarenheit", !isFarenheit);

            return RedirectToAction("Detail","Home", new { parkCode = parkCode });
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
