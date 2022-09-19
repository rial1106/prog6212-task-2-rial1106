using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG6212.Models
{
    internal class StudyDate
    {
        private DateTime date;
        private double hoursStudied;

        public StudyDate(DateTime date, double hoursStudied)
        {
            this.Date = date;
            this.HoursStudied = hoursStudied;
        }

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
