using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class WeatherSqlDAO
    {
        private readonly string connectionString;

        public WeatherSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public List<Weather> GetWeather()
        {

            IList<Weather> weatherList = new List<Weather>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM weather", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Weather weather = new Weather()
                        {
                            ParkCode = Convert.ToString(reader["parkCode"]),
                            FiveDayForecastValue = Convert.ToInt32(reader["fiveDayForecastValue"]),
                            Low = Convert.ToInt32(reader["low"]),
                            High = Convert.ToInt32(reader["high"]),
                            Forecast = Convert.ToString(reader["forecast"]),


                        };
                        weatherList.Add(weather);


                    }
                }
            }

            catch (SqlException ex) //TO DO add ex message
            {
                throw;
            }
            return weatherList;

        }
    }
}
