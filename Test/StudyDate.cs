using System;
using System.Collections.Generic;

namespace PROG6212.Test
{
    public partial class StudyDate
    {
        public StudyDate()
        {
            Modules = new HashSet<Module>();
        }

        public int StudyDatesId { get; set; }
        public string Username { get; set; } = null!;
        public DateTime Studydate1 { get; set; }
        public int HoursStudied { get; set; }

        public virtual User UsernameNavigation { get; set; } = null!;
        public virtual ICollection<Module> Modules { get; set; }
    }
}
