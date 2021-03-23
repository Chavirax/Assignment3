using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models
{
    public static class MovieList
    {
        private static List<ApplicationResponse> applications = new List<ApplicationResponse>();
        public static IEnumerable<ApplicationResponse> Application => applications;
        public static void AddApplication (ApplicationResponse application)
        {
            if (application.Title != "Independence Day")
            {
                applications.Add(application);
            }
           //This allows the class to exclude the movie Independence day to be added
        }
    }
}
