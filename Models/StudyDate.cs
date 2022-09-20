using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG6212.Models
{
    public class StudyDate
    {
        private DateTime date = DateTime.Now;
        private double hoursStudied;

        public StudyDate()
        {
            this.HoursStudied = 0;
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
