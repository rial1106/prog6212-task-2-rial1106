using System;
using System.Collections.Generic;

namespace PROG6212.Test
{
    public partial class User
    {
        public User()
        {
            Modules = new HashSet<Module>();
            StudyDates = new HashSet<StudyDate>();
        }

        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Module> Modules { get; set; }
        public virtual ICollection<StudyDate> StudyDates { get; set; }
    }
}
