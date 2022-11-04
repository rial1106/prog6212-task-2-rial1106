﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PROG6212.Data;

#nullable disable

namespace PROG6212.Migrations
{
    [DbContext(typeof(StudyTrackerContext))]
    [Migration("20221103192720_FixedNaming")]
    partial class FixedNaming
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PROG6212.Models.Module", b =>
                {
                    b.Property<string>("moduleCode")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("classHoursPerWeek")
                        .HasColumnType("float");

                    b.Property<int>("credits")
                        .HasColumnType("int");

                    b.Property<double?>("hoursStudiedThisWeek")
                        .HasColumnType("float");

                    b.Property<double?>("hoursStudiedToday")
                        .HasColumnType("float");

                    b.Property<string>("moduleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("semesterNumOfWeeks")
                        .HasColumnType("int");

                    b.Property<DateTime>("semesterStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("moduleCode");

                    b.HasIndex("username");

                    b.ToTable("modules");
                });

            modelBuilder.Entity("PROG6212.Models.StudyDate", b =>
                {
                    b.Property<int>("StudyDateID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudyDateID"), 1L, 1);

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<double>("hoursStudied")
                        .HasColumnType("float");

                    b.Property<string>("moduleCode")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("StudyDateID");

                    b.HasIndex("moduleCode");

                    b.ToTable("studyDates");
                });

            modelBuilder.Entity("PROG6212.Models.User", b =>
                {
                    b.Property<string>("username")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("username");

                    b.ToTable("users");
                });

            modelBuilder.Entity("PROG6212.Models.Module", b =>
                {
                    b.HasOne("PROG6212.Models.User", null)
                        .WithMany("modules")
                        .HasForeignKey("username");
                });

            modelBuilder.Entity("PROG6212.Models.StudyDate", b =>
                {
                    b.HasOne("PROG6212.Models.Module", null)
                        .WithMany("studyDates")
                        .HasForeignKey("moduleCode");
                });

            modelBuilder.Entity("PROG6212.Models.Module", b =>
                {
                    b.Navigation("studyDates");
                });

            modelBuilder.Entity("PROG6212.Models.User", b =>
                {
                    b.Navigation("modules");
                });
#pragma warning restore 612, 618
        }
    }
}
