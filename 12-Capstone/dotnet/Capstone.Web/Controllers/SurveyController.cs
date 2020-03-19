using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {

        private ISurveyDAO dao;

        private IParksDAO parkDAO;


        public SurveyController(ISurveyDAO surveyDAO, IParksDAO parksDAO)
        {
            this.dao = surveyDAO;
            parkDAO = parksDAO;
        }

        [HttpGet]
        public IActionResult Index(Survey survey) // what does this need to be?
        {
            IList<Park> parks = parkDAO.GetAllParks();
            ViewData["parkData"] = parks;
            return View(survey);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostSurvey(Survey sendSurvey)
        {
            if (!ModelState.IsValid)
            {
                IList<Park> parks = parkDAO.GetAllParks();
                ViewData["parkData"] = parks;
                return View("Index",sendSurvey);

            }
            dao.PostSurveys(sendSurvey);
            TempData["msg"] = "Your survey has been sent!";
            return RedirectToAction("SurveyResults","Survey");
        }

        public IActionResult SurveyResults()
        {
            var surveyResult = dao.SurveyResults();

            return View(surveyResult);
        }
    }
}