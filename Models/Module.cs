using System;
using System.Collections.Generic;
using System.ComponentModel;

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

        public Module()
        {
            credits = 10;
            classHoursPerWeek = 10;
            moduleCode = "Subject Code";
            moduleName = " Subject Name";
            hoursStudiedToday = 0;
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
                return hoursStudiedToday;
            }

            set
            {
                bool found = false;
                foreach(var i in studyDates)
                {
                    if(i.Date.Date == DateTime.Today)
                    {
                        i.HoursStudied = hoursStudiedToday;
                        found = true;
                        break;
                    }
                }

                if(!found)
                {
                    studyDates.Add(new StudyDate(DateTime.Now, value));
                }

                hoursStudiedToday = value;
                OnPropertyChanged(nameof(hoursStudiedToday));
            }
        }
    }
}
