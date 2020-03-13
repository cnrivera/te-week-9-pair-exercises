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
        
        //public int Low { get; set; }

        //public int High { get; set; }
        [Display(Name ="Forecast")]
        public string Forecast { get; set; }

        public bool IsFarenheit { get; set; }
        

        public int TemperatureLow { get; set; }

        public int TemperatureHigh { get; set; }

        public string Summary { get; set; }

        //public Weather (float temperatureLow, float temperatureHigh, string icon, string summary)
        //{
        //    TemperatureLow = temperatureLow;
        //    TemperatureHigh = temperatureHigh;
        //    Icon = icon;
        //    Summary = summary;
        //}
        [Display(Name = "Low")]
        public string DisplayLow
        {
            get
            {
                float fNum = TemperatureLow;
                float cNum = (int)((TemperatureLow - 32) / 1.8);
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
                float fNum = TemperatureHigh;
                float cNum = (int)((TemperatureHigh - 32) / 1.8);
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

      

       



