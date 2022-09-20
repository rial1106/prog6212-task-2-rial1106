using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media.Animation;

namespace PROG6212.Models
{
    public class Module : INotifyPropertyChanged
    {

        private string moduleName;
        private string moduleCode;
        private int credits;
        private double classHoursPerWeek;
        private double hoursStudiedToday;
        private double hoursStudiedThisWeek;
        private double recommendedStudyHours;
        private List<StudyDate> studyDates = new List<StudyDate>();
        private double percentageCompleted;

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


        public event PropertyChangedEventHandler? PropertyChanged;

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
                return ((credits * 10) / Semester.NumberOfWeeks) - classHoursPerWeek;
            }

            set
            {
                recommendedStudyHours = value;
                OnPropertyChanged(nameof(recommendedStudyHours));
            }
        }

        public double HoursStudiedToday
        {
            get
            {
                double hours = 0;
                foreach (var i in studyDates)
                {
                    if (i.Date.Date == DateTime.Today)
                    {
                        hours += i.HoursStudied;
                    }
                }

                return hours;
            }

            set
            {
                hoursStudiedToday = value;
                OnPropertyChanged(nameof(hoursStudiedToday));
            }
        }

        public double HoursStudiedThisWeek
        {
            get
            {
                double hours = 0;
                foreach (var i in studyDates)
                {
                    if (DatesAreInTheSameWeek(i.Date, DateTime.Now))
                    {
                        hours += i.HoursStudied;
                    }
                }

                return hours;
            }

            set
            {
                hoursStudiedThisWeek = value;
                OnPropertyChanged(nameof(hoursStudiedThisWeek));
            }
        }

        public double PercentageCompleted
        {
            get
            {
                if (RecommendedStudyHours == 0) return 0;

                return (HoursStudiedThisWeek / RecommendedStudyHours) * 100;
            }

            set
            {
                percentageCompleted = value;
                OnPropertyChanged(nameof(percentageCompleted));
            }
        }

        public void AddStudyDate(StudyDate studyDate)
        {
            bool found = false;
            foreach(var i in studyDates)
            {
                if(i.Date.Date == studyDate.Date.Date)
                {
                    found = true;
                    i.HoursStudied = studyDate.HoursStudied;
                    break;
                }
            }

            if (!found)
            {
                studyDates.Add(studyDate);
            }

            OnPropertyChanged(nameof(studyDates));
            OnPropertyChanged(nameof(hoursStudiedToday));
            OnPropertyChanged(nameof(HoursStudiedThisWeek));
            OnPropertyChanged(nameof(percentageCompleted));
        }

        private bool DatesAreInTheSameWeek(DateTime date1, DateTime date2)
        {
            var cal = System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar;
            var d1 = date1.Date.AddDays(-1 * (int)(cal.GetDayOfWeek(date1) - 1));
            var d2 = date2.Date.AddDays(-1 * (int)(cal.GetDayOfWeek(date2) - 1));

            return d1 == d2;
        }
    }
}
