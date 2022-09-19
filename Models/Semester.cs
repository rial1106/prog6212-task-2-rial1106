using System;

namespace PROG6212.Models
{
    internal static class Semester
    {

        private static DateTime startDate = DateTime.Now;
        private static int numberOfWeeks = 3;

        public static DateTime StartDate
        {
            get
            {
                return startDate;
            }

            set
            {
                startDate = value;
            }
        }

        public static int NumberOfWeeks
        {
            get
            {
                return numberOfWeeks;
            }

            set
            {
                numberOfWeeks = value;
            }
        }

    }
}
