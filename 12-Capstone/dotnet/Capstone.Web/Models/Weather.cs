using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Weather
    {

        public string ParkCode { get; set; }

        public int FiveDayForecastValue { get; set; }
        
        public int Low { get; set; }

        public int High { get; set; }
        [Display(Name ="Forecast")]
        public string Forecast { get; set; }

        public bool IsFarenheit { get; set; }
        [Display(Name ="Low")]
        public string DisplayLow
        {
            get
            {
                int fNum = Low;
                int cNum = (int)((Low-32) / 1.8);
                if (IsFarenheit)
                {
                    return $"{fNum} F";
                }
                else
                {
                    return $"{cNum} C";
                }

                
            }
        }
        [Display(Name = "High")]
        public string DisplayHigh
        {
            get
            {
                int fNum = High;
                int cNum = (int)((High - 32) / 1.8);
                if (IsFarenheit)
                {
                    return $"{fNum} F";
                }
                else
                {
                    return $"{cNum} C";
                }
            }
        }
    }


  
}

      

       



