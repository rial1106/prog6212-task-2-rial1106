using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROG6212.Models
{
    // The StudyDate class holds all the information related to a day of studying.
    public class StudyDate
    {
        [Key]
        public int studyDateID { get; set; }
        public DateTime date { get; set; } // Set the date of studying to today.
        public double hoursStudied { get; set; } // How many hours were studied today.

    }
}
