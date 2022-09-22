using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PROG6212.Models
{
    /* The module class holds all the information related to a module.
     * Implementing INotifyPropertyChanged allows the UI to get updates when a
     * value changes in an instance of this class. 
     */
    public class Module : INotifyPropertyChanged
    {

        private string moduleName; // Module name.
        private string moduleCode; // Module code.
        private int credits; // Module credits.
        private double classHoursPerWeek; // The number of class hours there are for a week.
        private double hoursStudiedToday; // How many hours of self studying were done today.
        private double hoursStudiedThisWeek; // How many hours of self studying were done today.
        private double recommendedStudyHours; // How many hours you should self study as per the formula.
        private List<StudyDate> studyDates = new List<StudyDate>(); // List of the dates and how many hours were studied.
        private double percentageCompleted; // Percentage of hours studied towards recommendedStudyHours for the ProgressBar.

        // Default constructor that provides defualts and hint text for the UI.
        public Module()
        {
            credits = 10;
            classHoursPerWeek = 10;
            moduleCode = "Subject Code";
            moduleName = " Subject Name";
            hoursStudiedToday = 0;
            hoursStudiedThisWeek = 0;
            PercentageCompleted = 0;

        }

        // An event that notifies the UI that a variable in this class has changed.
        public event PropertyChangedEventHandler? PropertyChanged;

        // This function tells INotifyPropertyChanged that a certain variable has been changed.
        private void OnPropertyChanged(string propertyName)
        {
            // Check if property has indeed been changed.
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Getters and Setters for fields.
        public string ModuleName
        {
            get
            {
                return moduleName;
            }

            set
            {
                moduleName = value;
                OnPropertyChanged(nameof(ModuleName)); // Notify that the value has changed.
            }
        }

        public string ModuleCode
        {
            get
            {
                return moduleCode;
            }

            set
            {
                moduleCode = value;
                OnPropertyChanged(nameof(ModuleCode)); // Notify that the value has changed.
            }
        }

        public int Credits
        {
            get
            {
                return credits;
            }

            set
            {
                credits = value;
                OnPropertyChanged(nameof(Credits)); // Notify that the value has changed.
            }
        }

        public double ClassHoursPerWeek
        {
            get
            {
                return classHoursPerWeek;
            }

            set
            {
                classHoursPerWeek = value;
                OnPropertyChanged(nameof(classHoursPerWeek)); // Notify that the value has changed.
            }
        }

        public double RecommendedStudyHours
        {
            get
            {
                return ((credits * 10) / Semester.NumberOfWeeks) - classHoursPerWeek; // Provided formula.
            }

            set
            {
                recommendedStudyHours = value;
                OnPropertyChanged(nameof(recommendedStudyHours)); // Notify that the value has changed.
            }
        }

        public double HoursStudiedToday
        {
            get
            {
                double hours = 0; // Sum of all hours studied for today.
                foreach (var i in studyDates) // Loop over all added study dates.
                {
                    if (i.Date.Date == DateTime.Today) // If the date is today.
                    {
                        hours += i.HoursStudied; // Add it to the sum of all hours studied for today.
                    }
                }

                return hours;
            }

            set
            {
                hoursStudiedToday = value;
                OnPropertyChanged(nameof(hoursStudiedToday)); // Notify that the value has changed.
            }
        }

        public double HoursStudiedThisWeek
        {
            get
            {
                double hours = 0; // Sum of all hours studied for this week.
                foreach (var i in studyDates) // Loop over all study dates.
                {
                    if (DatesAreInTheSameWeek(i.Date, DateTime.Now)) // If the date was this week.
                    {
                        hours += i.HoursStudied; // Add to the sum of all hours studied for this week.
                    }
                }

                return hours;
            }

            set
            {
                hoursStudiedThisWeek = value;
                OnPropertyChanged(nameof(hoursStudiedThisWeek)); // Notify that the value has changed.
            }
        }

        public double PercentageCompleted
        {
            get
            {
                if (RecommendedStudyHours == 0) return 0; // Prevents division by 0.

                return (HoursStudiedThisWeek / RecommendedStudyHours) * 100; // Get percentage of hours studied to the target.
            }

            set
            {
                percentageCompleted = value;
                OnPropertyChanged(nameof(percentageCompleted)); // Notify that the value has changed.
            }
        }

        /* Add a date and how many hours were studied to the list.
         * The function will also check if there is already an object in the list for today
         * and if there is it will instead update the hours studied on that one instead of adding
         * another StudyDate object.
         */
        public void AddStudyDate(StudyDate studyDate)
        {
            bool found = false; // If there is an object for todays date?
            foreach (var i in studyDates) // Loop over all added dates.
            {
                if (i.Date.Date == studyDate.Date.Date) // If there is a matching date in the list already.
                {
                    found = true; // There is an object for today.
                    i.HoursStudied = studyDate.HoursStudied; // Change the hours studied on the already added object.
                    break; // There should only be one for each day so we can break the loop.
                }
            }

            if (!found) // If there was not an object for the paramters date.
            {
                studyDates.Add(studyDate); // Add to the list.
            }

            OnPropertyChanged(nameof(studyDates)); // Notify that the value has changed.
            OnPropertyChanged(nameof(hoursStudiedToday)); // Notify that the value has changed.
            OnPropertyChanged(nameof(HoursStudiedThisWeek)); // Notify that the value has changed.
            OnPropertyChanged(nameof(percentageCompleted)); // Notify that the value has changed.
        }

        /* Checks if 2 dates are in the same week.
         * The week starts on a Monday.
         * Taken from https://stackoverflow.com/questions/25795254/check-if-a-datetime-is-in-same-week-as-other-datetime
         * Authored by Sparrow on Aug 5, 2016 at 14:55
         */
        private bool DatesAreInTheSameWeek(DateTime date1, DateTime date2)
        {
            var cal = System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar;
            var d1 = date1.Date.AddDays(-1 * (int)(cal.GetDayOfWeek(date1) - 1));
            var d2 = date2.Date.AddDays(-1 * (int)(cal.GetDayOfWeek(date2) - 1));

            return d1 == d2;
        }
    }
}
