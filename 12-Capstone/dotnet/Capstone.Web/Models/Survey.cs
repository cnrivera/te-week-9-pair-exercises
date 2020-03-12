using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Survey
    {

        public int SurveyId { get; set; }

        
        public string ParkCode { get; set; }

       
        [Required, EmailAddress(ErrorMessage = "Please enter your email address")]
        public string EmailAddress { get; set; }

        
        public string State { get; set; }

        
        public string ActivityLevel { get; set; }

        public static List<SelectListItem> activityLevel = new List<SelectListItem>()
        {
            new SelectListItem() {Text = "inactive"},
            new SelectListItem() {Text = "sedentary"},
            new SelectListItem() {Text = "active"},
            new SelectListItem() {Text = "extremely active"},

        };

        public static List<SelectListItem> states = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "AL" },
            new SelectListItem() { Text = "AK" },
            new SelectListItem() { Text = "AZ" },
            new SelectListItem() { Text = "AR" },
            new SelectListItem() { Text = "CA" },
            new SelectListItem() { Text = "CO" },
            new SelectListItem() { Text = "CT" },
            new SelectListItem() { Text = "DE" },
            new SelectListItem() { Text = "FL" },
            new SelectListItem() { Text = "GA" },
            new SelectListItem() { Text = "HI" },
            new SelectListItem() { Text = "ID" },
            new SelectListItem() { Text = "IN" },
            new SelectListItem() { Text = "IA" },
            new SelectListItem() { Text = "KS" },
            new SelectListItem() { Text = "KY" },
            new SelectListItem() { Text = "LA" },
            new SelectListItem() { Text = "ME" },
            new SelectListItem() { Text = "MD" },
            new SelectListItem() { Text = "MA" },
            new SelectListItem() { Text = "MI" },
            new SelectListItem() { Text = "MN" },
            new SelectListItem() { Text = "MS" },
            new SelectListItem() { Text = "MO" },
            new SelectListItem() { Text = "MT" },
            new SelectListItem() { Text = "NE" },
            new SelectListItem() { Text = "NV" },
            new SelectListItem() { Text = "NH" },
            new SelectListItem() { Text = "NJ" },
            new SelectListItem() { Text = "NM" },
            new SelectListItem() { Text = "NY" },
            new SelectListItem() { Text = "NC" },
            new SelectListItem() { Text = "ND" },
            new SelectListItem() { Text = "OH" },
            new SelectListItem() { Text = "OK" },
            new SelectListItem() { Text = "OR" },
            new SelectListItem() { Text = "PA" },
            new SelectListItem() { Text = "RI" },
            new SelectListItem() { Text = "SC" },
            new SelectListItem() { Text = "SD" },
            new SelectListItem() { Text = "TN" },
            new SelectListItem() { Text = "TX" },
            new SelectListItem() { Text = "UT" },
            new SelectListItem() { Text = "VT" },
            new SelectListItem() { Text = "VA" },
            new SelectListItem() { Text = "WA" },
            new SelectListItem() { Text = "WV" },
            new SelectListItem() { Text = "WI" },
            new SelectListItem() { Text = "WY" },
        };

    }
}
