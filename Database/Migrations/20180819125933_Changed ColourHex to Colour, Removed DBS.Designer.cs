﻿// <auto-generated />
using System;
using Database.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Database.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20180819125933_Changed ColourHex to Colour, Removed DBS")]
    partial class ChangedColourHextoColourRemovedDBS
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Database.Models.Clockin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId");

                    b.Property<int>("SiteId");

                    b.Property<DateTime>("TimeIn");

                    b.Property<DateTime>("TimeOut");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("SiteId");

                    b.ToTable("Clockins");
                });

            modelBuilder.Entity("Database.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("Surname")
                        .IsRequired();

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Database.Models.EmployeeSite", b =>
                {
                    b.Property<int>("EmployeeId");

                    b.Property<int>("SiteId");

                    b.HasKey("EmployeeId", "SiteId");

                    b.HasIndex("SiteId");

                    b.ToTable("EmployeeSite");
                });

            modelBuilder.Entity("Database.Models.Screen", b =>
                {
                    b.Property<string>("TerminalId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(32);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("SiteId");

                    b.HasKey("TerminalId");

                    b.HasIndex("SiteId");

                    b.ToTable("Screens");
                });

            modelBuilder.Entity("Database.Models.Site", b =>
                {
                    b.Property<int>("SiteId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Colour")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("SiteId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Sites");
                });

            modelBuilder.Entity("Database.Models.Clockin", b =>
                {
                    b.HasOne("Database.Models.Employee", "Employee")
                        .WithMany("Clockins")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Database.Models.Site", "Site")
                        .WithMany("Clockins")
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Database.Models.EmployeeSite", b =>
                {
                    b.HasOne("Database.Models.Employee", "Employee")
                        .WithMany("Sites")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Database.Models.Site", "Site")
                        .WithMany("Employees")
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Database.Models.Screen", b =>
                {
                    b.HasOne("Database.Models.Site", "Site")
                        .WithMany("Screens")
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
