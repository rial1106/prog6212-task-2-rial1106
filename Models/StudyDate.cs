using System;

namespace PROG6212.Models
{
    // The StudyDate class holds all the information related to a day of studying.
    public class StudyDate
    {
        private DateTime date = DateTime.Now; // Set the date of studying to today.
        private double hoursStudied; // How many hours were studied today.

        // Default constructor for the class.
        public StudyDate()
        {
            this.HoursStudied = 0; // 0 hours as the default time studied today.
        }

        // Getters and Setters
        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }

        public double HoursStudied
        {
            get
            {
                return hoursStudied;
            }

            set
            {
                hoursStudied = value;
            }
        }
    }
}
