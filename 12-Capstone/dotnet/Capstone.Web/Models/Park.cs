using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Park
    {
        public string ParkCode { get; set; }

        public string ParkName { get; set; }

        public string State { get; set; }
        [Display(Name = "Acreage")]
        public int Acreage { get; set; }
        [Display(Name = "Elevation in Feet")]
        public int ElevationInFeet { get; set; }
        [Display(Name = "Miles of Trail")]
        public int MilesOfTrail { get; set; }
        [Display(Name = "Number of Campsites")]
        public int NumberOfCampsites { get; set; }
        [Display(Name = "Climate")]
        public string Climate { get; set; }
        [Display(Name = "Year Founded")]
        public int YearFounded { get; set; }
        [Display(Name = "Annual Visitor Count")]
        public int AnnualVisitorCount { get; set; }
        
        public string InspirationalQuote { get; set; }
        
        public string InspirationalQuoteSource { get; set; }

        public string ParkDescription { get; set; }
        [Display(Name = "Entry Fee")]
        public decimal EntryFee { get; set; }
        [Display(Name = "Number of Animal Species")]
        public int NumberOfAnimalSpecies { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public IList<Weather> WeatherList { get; set; } = new List<Weather>(); 

     

    }
}
