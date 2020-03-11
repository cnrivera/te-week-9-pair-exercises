using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{

    public interface IParksDAO
    {
        /// <summary>
        /// Returns a list of all parks.
        /// </summary>
        /// <returns></returns>
        IList<Park> GetAllParks();

        /// <summary>
        /// Returns a single park.
        /// </summary>
        /// <returns></returns>
        /// 
        Park GetPark(string ParkCode);

        /// <summary>
        /// Gets five day forcast for all parks.
        /// </summary>
        /// <returns></returns>
        ///
        IList<Weather> GetWeatherForASinglePark(string parkCode);








    }
}
