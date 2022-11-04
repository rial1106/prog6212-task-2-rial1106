using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROG6212.Models
{
    /* The module class holds all the information related to a module.
     * Implementing INotifyPropertyChanged allows the UI to get updates when a
     * value changes in an instance of this class. 
     */
    public class Module
    {

        [Key]
        [MaxLength(50)]
        public string moduleCode { get; set; } = null!; // Module code.
        [MaxLength(50)]
        public string moduleName { get; set; } = null!; // Module name.
        public int credits { get; set; } // Module credits.
        public double classHoursPerWeek { get; set; } // The number of class hours there are for a week.
        public double? hoursStudiedToday { get; set; } // How many hours of self studying were done today.
        public double? hoursStudiedThisWeek { get; set; } // How many hours you should self study as per the formula.
        public int semesterNumOfWeeks { get; set; } // How many weeks in a semester
        public DateTime semesterStartDate { get; set; } // When does the semester starts
        [NotMapped]
        public double? percentageCompleted { get; set; } // Percentage of hours studied towards recommendedStudyHours for the ProgressBar.

        public ICollection<StudyDate> studyDates { get; set; } = null!;

    }
}
