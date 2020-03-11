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
        public IActionResult Detail(string parkCode)
        {
            Park detail = parkDAO.GetPark(parkCode);

            bool isFarenheit = HttpContext.Session.Get<bool>("isFarenheit");

            if(isFarenheit == false)
            {
                foreach(Weather w in detail.WeatherList)
                {
                    w.IsFarenheit = false;
                }
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
