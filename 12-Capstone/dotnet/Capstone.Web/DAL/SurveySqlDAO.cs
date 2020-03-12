using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class SurveySqlDAO : ISurveyDAO
    {

        private string connectionString;

        public SurveySqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void PostSurveys(Survey surveyPost)
        {
            //$"INSERT into survey_result (@parkCode, @emailAddress, @state, @activityLevel)"
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT into survey_result Values(@parkCode, @emailAddress, @state, @activityLevel)", conn);

                    cmd.Parameters.AddWithValue("@parkCode", surveyPost.ParkCode);
                    cmd.Parameters.AddWithValue("@emailAddress", surveyPost.EmailAddress);
                    cmd.Parameters.AddWithValue("@state", surveyPost.State);
                    cmd.Parameters.AddWithValue("@activityLevel", surveyPost.ActivityLevel);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {

                throw;
            }
        }

        public IList<SurveyResult> SurveyResults()

        {
            try
            {
                IList<SurveyResult> surveyResults = new List<SurveyResult>();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT count(survey_result.parkCode) AS 'count', park.parkName, park.parkCode FROM survey_result JOIN park on park.parkCode = survey_result.parkCode GROUP BY park.parkName, park.parkCode", conn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        surveyResults.Add(MapRowToSurvey(reader));
                    }

                }
                return surveyResults;

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        private SurveyResult MapRowToSurvey(SqlDataReader reader)
        {
            return new SurveyResult()
            {
                ParkName = Convert.ToString(reader["parkName"]),
                Count = Convert.ToInt32(reader["count"]),
                ParkCode = Convert.ToString(reader["parkCode"]),
            };
        }

       

    }
}
