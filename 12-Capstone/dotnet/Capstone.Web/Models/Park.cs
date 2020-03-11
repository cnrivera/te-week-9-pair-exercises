﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Park
    {
        public string ParkCode { get; set; }

        public string ParkName { get; set; }

        public string State { get; set; }

        public int Acreage { get; set; }

        public int ElevationInFeet { get; set; }

        public int MilesOfTrail { get; set; }

        public int NumberOfCampsites { get; set; }

        public string Climate { get; set; }

        public int YearFounded { get; set; }

        public int AnnualVisitorCount { get; set; }

        public string InspirationalQuote { get; set; }

        public string InspirationalQuoteSource { get; set; }

        public string ParkDescription { get; set; }

        public decimal EntryFee { get; set; }

        public int NumberOfAnimalSpecies { get; set; }

        public IList<Weather> WeatherList { get; set; }

        //public List<Weather> DailyWeather
        //{
        //    get
        //    {
        //        List<Weather> dailyWeather = new List<Weather>();
        //        while (ParkCode == Weather)
        //        {
        //            foreach (Weather detail in WeatherList)
        //            {
        //                dailyWeather.Add(detail);
        //            }
        //            return dailyWeather;
        //        }
        //    }



        //}

    }
}