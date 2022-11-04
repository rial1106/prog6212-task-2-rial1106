using EntityFramework.Exceptions.SqlServer;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PROG6212.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG6212.Data
{
    public class StudyTrackerContext : DbContext
    {
        public DbSet<User> users { get; set; } = null!;
        public DbSet<Module> modules { get; set; } = null!;
        public DbSet<StudyDate> studyDates { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source = ML - RefVm - 631348\\SQLEXPRESS; Database = StudyTracker ; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
            optionsBuilder.UseSqlServer("data source=ML-RefVm-631348\\SQLEXPRESS;initial catalog=StudyTracker;trusted_connection=true;TrustServerCertificate=True");
            optionsBuilder.UseExceptionProcessor();
        }
    }
}
