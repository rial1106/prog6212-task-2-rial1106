using System;
using System.Collections.Generic;

namespace PROG6212.Test
{
    public partial class Module
    {
        public int ModuleId { get; set; }
        public string Username { get; set; } = null!;
        public string ModuleName { get; set; } = null!;
        public string ModuleCode { get; set; } = null!;
        public int Credits { get; set; }
        public double? ClassHoursPerWeek { get; set; }
        public double? HoursStudiedToday { get; set; }
        public double? HoursStudiedThisWeek { get; set; }
        public double? RecommendedStudyHours { get; set; }
        public int? StudyDatesId { get; set; }

        public virtual StudyDate? StudyDates { get; set; }
        public virtual User UsernameNavigation { get; set; } = null!;
    }
}
