using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;

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
        
        public IActionResult Detail(string parkCode)
        {
            Park detail = parkDAO.GetPark(parkCode);
            return View(detail);
        }


      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
