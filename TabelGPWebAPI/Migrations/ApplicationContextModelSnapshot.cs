﻿// <auto-generated />

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TabelGPWebAPI.Data;

namespace TabelGPWebAPI.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("TabelGPWebAPI.Entities.AppUser", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid");

                b.Property<byte[]>("PasswordHash")
                    .HasColumnType("bytea");

                b.Property<byte[]>("PasswordSalt")
                    .HasColumnType("bytea");

                b.Property<string>("UserName")
                    .HasColumnType("text");

                b.HasKey("Id");

                b.ToTable("Users");
            });

            modelBuilder.Entity("TabelGPWebAPI.Entities.Employee", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid");

                b.Property<Guid>("AppUserId")
                    .HasColumnType("uuid");

                b.Property<int>("Grade")
                    .HasColumnType("integer");

                b.Property<string>("Name")
                    .HasColumnType("text");

                b.Property<string>("Patronymic")
                    .HasColumnType("text");

                b.Property<string>("Surname")
                    .HasColumnType("text");

                b.Property<string>("TabelNum")
                    .HasColumnType("text");

                b.HasKey("Id");

                b.HasIndex("AppUserId");

                b.ToTable("Employees");
            });

            modelBuilder.Entity("TabelGPWebAPI.Entities.EmployeeTime", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid");

                b.Property<float>("DoublePayTime")
                    .HasColumnType("real");

                b.Property<Guid>("EmployeeId")
                    .HasColumnType("uuid");

                b.Property<int>("Grade")
                    .HasColumnType("integer");

                b.Property<float>("NightTime")
                    .HasColumnType("real");

                b.Property<float>("PprTime")
                    .HasColumnType("real");

                b.Property<float>("PrikTime")
                    .HasColumnType("real");

                b.Property<float>("ProstTime")
                    .HasColumnType("real");

                b.Property<float>("SdelTime")
                    .HasColumnType("real");

                b.Property<Guid>("ShiftId")
                    .HasColumnType("uuid");

                b.Property<float>("SrednTime")
                    .HasColumnType("real");

                b.HasKey("Id");

                b.HasIndex("EmployeeId");

                b.HasIndex("ShiftId");

                b.ToTable("EmployeeTimes");
            });

            modelBuilder.Entity("TabelGPWebAPI.Entities.Machine", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid");

                b.Property<string>("MachineName")
                    .HasColumnType("text");

                b.HasKey("Id");

                b.ToTable("Machines");
            });

            modelBuilder.Entity("TabelGPWebAPI.Entities.Norma", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid");

                b.Property<float>("Amount")
                    .HasColumnType("real");

                b.Property<string>("GroupDiff")
                    .HasColumnType("text");

                b.Property<Guid>("MachineId")
                    .HasColumnType("uuid");

                b.Property<Guid>("UserId")
                    .HasColumnType("uuid");

                b.HasKey("Id");

                b.HasIndex("MachineId");

                b.HasIndex("UserId");

                b.ToTable("Norms");
            });

            modelBuilder.Entity("TabelGPWebAPI.Entities.Report", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid");

                b.Property<Guid>("AppUserId")
                    .HasColumnType("uuid");

                b.Property<DateTime>("DateReport")
                    .HasColumnType("timestamp without time zone");

                b.Property<Guid>("MachineId")
                    .HasColumnType("uuid");

                b.Property<string>("NumShiftReport")
                    .HasColumnType("text");

                b.Property<float>("PercentOfReport")
                    .HasColumnType("real");

                b.HasKey("Id");

                b.HasIndex("AppUserId");

                b.HasIndex("MachineId");

                b.ToTable("Reports");
            });

            modelBuilder.Entity("TabelGPWebAPI.Entities.Shift", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid");

                b.Property<Guid>("AppUserId")
                    .HasColumnType("uuid");

                b.Property<DateTime>("DateShift")
                    .HasColumnType("timestamp without time zone");

                b.Property<Guid>("MachineId")
                    .HasColumnType("uuid");

                b.Property<string>("NumShift")
                    .HasColumnType("text");

                b.HasKey("Id");

                b.HasIndex("AppUserId");

                b.HasIndex("MachineId");

                b.ToTable("Shifts");
            });

            modelBuilder.Entity("TabelGPWebAPI.Entities.WorkReport", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid");

                b.Property<float>("AmountPiecesDone")
                    .HasColumnType("real");

                b.Property<string>("EndWorkTime")
                    .HasColumnType("text");

                b.Property<float>("GroupDifficulty")
                    .HasColumnType("real");

                b.Property<string>("NameOrder")
                    .HasColumnType("text");

                b.Property<string>("NumOrder")
                    .HasColumnType("text");

                b.Property<Guid>("ReportId")
                    .HasColumnType("uuid");

                b.Property<string>("StartWorkTime")
                    .HasColumnType("text");

                b.Property<string>("TypeWork")
                    .HasColumnType("text");

                b.HasKey("Id");

                b.HasIndex("ReportId");

                b.ToTable("WorkReports");
            });

            modelBuilder.Entity("TabelGPWebAPI.Entities.WorkerReport", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid");

                b.Property<Guid>("EmployeeId")
                    .HasColumnType("uuid");

                b.Property<int>("Grade")
                    .HasColumnType("integer");

                b.Property<Guid>("ReportId")
                    .HasColumnType("uuid");

                b.HasKey("Id");

                b.HasIndex("EmployeeId");

                b.HasIndex("ReportId");

                b.ToTable("WorkerReports");
            });

            modelBuilder.Entity("TabelGPWebAPI.Entities.Employee", b =>
            {
                b.HasOne("TabelGPWebAPI.Entities.AppUser", "AppUser")
                    .WithMany("EmployeesByUser")
                    .HasForeignKey("AppUserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("AppUser");
            });

            modelBuilder.Entity("TabelGPWebAPI.Entities.EmployeeTime", b =>
            {
                b.HasOne("TabelGPWebAPI.Entities.Employee", "Employee")
                    .WithMany("EmployeeTimes")
                    .HasForeignKey("EmployeeId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("TabelGPWebAPI.Entities.Shift", "Shift")
                    .WithMany("EmployeeTimes")
                    .HasForeignKey("ShiftId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Employee");

                b.Navigation("Shift");
            });

            modelBuilder.Entity("TabelGPWebAPI.Entities.Norma", b =>
            {
                b.HasOne("TabelGPWebAPI.Entities.Machine", "Machine")
                    .WithMany("NormsByMashine")
                    .HasForeignKey("MachineId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("TabelGPWebAPI.Entities.AppUser", "User")
                    .WithMany("NormsByUser")
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Machine");

                b.Navigation("User");
            });

            modelBuilder.Entity("TabelGPWebAPI.Entities.Report", b =>
            {
                b.HasOne("TabelGPWebAPI.Entities.AppUser", "AppUser")
                    .WithMany("Reports")
                    .HasForeignKey("AppUserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("TabelGPWebAPI.Entities.Machine", "Machine")
                    .WithMany("Reports")
                    .HasForeignKey("MachineId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("AppUser");

                b.Navigation("Machine");
            });

            modelBuilder.Entity("TabelGPWebAPI.Entities.Shift", b =>
            {
                b.HasOne("TabelGPWebAPI.Entities.AppUser", "AppUser")
                    .WithMany("ShiftsByUser")
                    .HasForeignKey("AppUserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("TabelGPWebAPI.Entities.Machine", "Machine")
                    .WithMany()
                    .HasForeignKey("MachineId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("AppUser");

                b.Navigation("Machine");
            });

            modelBuilder.Entity("TabelGPWebAPI.Entities.WorkReport", b =>
            {
                b.HasOne("TabelGPWebAPI.Entities.Report", "Report")
                    .WithMany("WorksOfReport")
                    .HasForeignKey("ReportId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Report");
            });

            modelBuilder.Entity("TabelGPWebAPI.Entities.WorkerReport", b =>
            {
                b.HasOne("TabelGPWebAPI.Entities.Employee", "Employee")
                    .WithMany("WorkerReports")
                    .HasForeignKey("EmployeeId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("TabelGPWebAPI.Entities.Report", "Report")
                    .WithMany("WorkersOfReport")
                    .HasForeignKey("ReportId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Employee");

                b.Navigation("Report");
            });

            modelBuilder.Entity("TabelGPWebAPI.Entities.AppUser", b =>
            {
                b.Navigation("EmployeesByUser");

                b.Navigation("NormsByUser");

                b.Navigation("Reports");

                b.Navigation("ShiftsByUser");
            });

            modelBuilder.Entity("TabelGPWebAPI.Entities.Employee", b =>
            {
                b.Navigation("EmployeeTimes");

                b.Navigation("WorkerReports");
            });

            modelBuilder.Entity("TabelGPWebAPI.Entities.Machine", b =>
            {
                b.Navigation("NormsByMashine");

                b.Navigation("Reports");
            });

            modelBuilder.Entity("TabelGPWebAPI.Entities.Report", b =>
            {
                b.Navigation("WorkersOfReport");

                b.Navigation("WorksOfReport");
            });

            modelBuilder.Entity("TabelGPWebAPI.Entities.Shift", b => { b.Navigation("EmployeeTimes"); });
#pragma warning restore 612, 618
        }
    }
}