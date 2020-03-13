using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class ParksSqlDAO : IParksDAO
    {
        private readonly string connectionString;

        public ParksSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }


        public IList<Park> GetAllParks()
        {
            IList<Park> parks = new List<Park>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM park", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Park park = new Park()
                        {
                            ParkCode = Convert.ToString(reader["parkCode"]),
                            ParkName = Convert.ToString(reader["parkName"]),
                            State = Convert.ToString(reader["state"]),
                            Acreage = Convert.ToInt32(reader["acreage"]),
                            ElevationInFeet = Convert.ToInt32(reader["elevationInFeet"]),
                            MilesOfTrail = Convert.ToInt32(reader["milesOfTrail"]),
                            NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]),
                            Climate = Convert.ToString(reader["climate"]),
                            YearFounded = Convert.ToInt32(reader["yearFounded"]),
                            AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]),
                            InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]),
                            InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]),
                            ParkDescription = Convert.ToString(reader["parkDescription"]),
                            EntryFee = Convert.ToDecimal(reader["entryFee"]),
                            NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]),
                            Latitude = Convert.ToDecimal(reader["latitude"]),
                            Longitude = Convert.ToDecimal(reader["longitude"]),

                        };

                        parks.Add(park);


                    }
                }
            }

            catch (SqlException ex) //TO DO add ex message
            {
                throw;
            }
            return parks;


        }


        //public IList<Weather> GetWeatherForASinglePark(string parkCode)
        //{
        //    IList<Weather> weatherList = new List<Weather>();

        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();
        //            SqlCommand cmd = new SqlCommand("SELECT * FROM weather Where parkCode = @parkCode", conn);
        //            cmd.Parameters.AddWithValue("@parkCode", parkCode);
        //            SqlDataReader reader = cmd.ExecuteReader();

        //            while (reader.Read())
        //            {
        //                Weather weather = new Weather()
        //                {
        //                    ParkCode = Convert.ToString(reader["parkCode"]),
        //                    FiveDayForecastValue = Convert.ToInt32(reader["fiveDayForecastValue"]),
        //                    Low = Convert.ToInt32(reader["low"]),
        //                    High = Convert.ToInt32(reader["high"]),
        //                    Forecast = Convert.ToString(reader["forecast"]),

        //                };
        //                weatherList.Add(weather);


        //            }
        //        }
        //    }

        //    catch (SqlException ex) //TO DO add ex message
        //    {
        //        throw;
        //    }
        //    return weatherList;
        //}


        public Park GetPark(string parkCode)
        {
            return GetAllParks().FirstOrDefault(p => p.ParkCode == parkCode);
        }







    }

}


