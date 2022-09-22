using System;

namespace PROG6212.Models
{
    /* The Semester class holds all the information related to a semester.
     * The class is static as we will only be needing one throughout the lifetime of the program.
     */
    internal static class Semester
    {

        private static DateTime startDate = DateTime.Now; // Semster start date, with today as the default.
        private static int numberOfWeeks = 3; // How many weeks long the semester is.

        // Getters and Setters.
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
