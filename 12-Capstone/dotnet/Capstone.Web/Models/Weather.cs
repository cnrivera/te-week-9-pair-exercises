using System;
using System.Collections.Generic;
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

        public string Forecast { get; set; }

        public bool IsFarenheit { get; set; }

        public int DisplayCelsiusLow
        {
            get
            {
                if (IsFarenheit)
                {
                    return Low;
                }
                else
                {
                    return (int)((Low - 32) / 1.8);
                }
            }
        }
        public int DisplayCelsiusHigh
        {
            get
            {
                if (IsFarenheit)
                {
                    return High;
                }
                else
                {
                    return (int)((High - 32) / 1.8);
                }
            }
        }
    }


  
}

      

       


    }
}
