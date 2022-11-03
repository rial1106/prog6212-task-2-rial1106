using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PROG6212.Test
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Module> Modules { get; set; } = null!;
        public virtual DbSet<StudyDate> StudyDates { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=ML-RefVm-631348\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Database=DB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Module>(entity =>
            {
                entity.ToTable("MODULE");

                entity.Property(e => e.ModuleId)
                    .ValueGeneratedNever()
                    .HasColumnName("MODULE_ID");

                entity.Property(e => e.ClassHoursPerWeek).HasColumnName("CLASS_HOURS_PER_WEEK");

                entity.Property(e => e.Credits).HasColumnName("CREDITS");

                entity.Property(e => e.HoursStudiedThisWeek).HasColumnName("HOURS_STUDIED_THIS_WEEK");

                entity.Property(e => e.HoursStudiedToday).HasColumnName("HOURS_STUDIED_TODAY");

                entity.Property(e => e.ModuleCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MODULE_CODE");

                entity.Property(e => e.ModuleName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MODULE_NAME");

                entity.Property(e => e.RecommendedStudyHours).HasColumnName("RECOMMENDED_STUDY_HOURS");

                entity.Property(e => e.StudyDatesId).HasColumnName("STUDY_DATES_ID");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");

                entity.HasOne(d => d.StudyDates)
                    .WithMany(p => p.Modules)
                    .HasForeignKey(d => d.StudyDatesId)
                    .HasConstraintName("FK__MODULE__STUDY_DA__3C69FB99");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Modules)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MODULE__USERNAME__3B75D760");
            });

            modelBuilder.Entity<StudyDate>(entity =>
            {
                entity.HasKey(e => e.StudyDatesId)
                    .HasName("PK__STUDY_DA__155156A2135CEB58");

                entity.ToTable("STUDY_DATES");

                entity.Property(e => e.StudyDatesId)
                    .ValueGeneratedNever()
                    .HasColumnName("STUDY_DATES_ID");

                entity.Property(e => e.HoursStudied).HasColumnName("HOURS_STUDIED");

                entity.Property(e => e.Studydate1)
                    .HasColumnType("date")
                    .HasColumnName("STUDYDATE");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.StudyDates)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__STUDY_DAT__USERN__38996AB5");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__USERS__B15BE12FD2866A86");

                entity.ToTable("USERS");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");

                entity.Property(e => e.Password)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD")
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
