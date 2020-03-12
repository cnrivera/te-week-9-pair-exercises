using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public interface ISurveyDAO
    {
        /// <summary>
        /// Inserts a survey into the database
        /// </summary>
        /// <param name="surveyPost"></param>
        /// <returns></returns>
        void PostSurveys(Survey surveyPost);

        IList<SurveyResult> SurveyResults();

    
    }
}
