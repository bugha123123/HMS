﻿// <auto-generated />
using System;
using HMS.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HMS.Migrations
{
    [DbContext(typeof(AppDbContextion))]
    [Migration("20250204161957_addingDepartmentData")]
    partial class addingDepartmentData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HMS.Model.Appointment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("HMS.Model.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("HospitalId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HospitalId");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            HospitalId = 1,
                            Name = "Emergency Medicine"
                        },
                        new
                        {
                            Id = 2,
                            HospitalId = 1,
                            Name = "General Medicine"
                        },
                        new
                        {
                            Id = 3,
                            HospitalId = 1,
                            Name = "Surgery"
                        },
                        new
                        {
                            Id = 4,
                            HospitalId = 1,
                            Name = "Pediatrics"
                        },
                        new
                        {
                            Id = 5,
                            HospitalId = 1,
                            Name = "Obstetrics and Gynecology"
                        },
                        new
                        {
                            Id = 6,
                            HospitalId = 1,
                            Name = "Orthopedic Surgery"
                        },
                        new
                        {
                            Id = 7,
                            HospitalId = 1,
                            Name = "Neurology"
                        },
                        new
                        {
                            Id = 8,
                            HospitalId = 1,
                            Name = "Cardiology"
                        },
                        new
                        {
                            Id = 9,
                            HospitalId = 1,
                            Name = "Psychiatry"
                        },
                        new
                        {
                            Id = 10,
                            HospitalId = 1,
                            Name = "Radiology"
                        },
                        new
                        {
                            Id = 11,
                            HospitalId = 2,
                            Name = "Cardiovascular Medicine"
                        },
                        new
                        {
                            Id = 12,
                            HospitalId = 2,
                            Name = "Neurology"
                        },
                        new
                        {
                            Id = 13,
                            HospitalId = 2,
                            Name = "Orthopedic Surgery"
                        },
                        new
                        {
                            Id = 14,
                            HospitalId = 2,
                            Name = "Gastroenterology and Hepatology"
                        },
                        new
                        {
                            Id = 15,
                            HospitalId = 2,
                            Name = "Endocrinology"
                        },
                        new
                        {
                            Id = 16,
                            HospitalId = 2,
                            Name = "Oncology"
                        },
                        new
                        {
                            Id = 17,
                            HospitalId = 2,
                            Name = "Pulmonary Medicine"
                        },
                        new
                        {
                            Id = 18,
                            HospitalId = 2,
                            Name = "Nephrology and Hypertension"
                        },
                        new
                        {
                            Id = 19,
                            HospitalId = 2,
                            Name = "Rheumatology"
                        },
                        new
                        {
                            Id = 20,
                            HospitalId = 2,
                            Name = "Dermatology"
                        },
                        new
                        {
                            Id = 21,
                            HospitalId = 3,
                            Name = "Heart, Vascular & Thoracic Institute"
                        },
                        new
                        {
                            Id = 22,
                            HospitalId = 3,
                            Name = "Neurological Institute"
                        },
                        new
                        {
                            Id = 23,
                            HospitalId = 3,
                            Name = "Orthopaedic & Rheumatologic Institute"
                        },
                        new
                        {
                            Id = 24,
                            HospitalId = 3,
                            Name = "Digestive Disease & Surgery Institute"
                        },
                        new
                        {
                            Id = 25,
                            HospitalId = 3,
                            Name = "Cancer Center / Taussig Cancer Institute"
                        },
                        new
                        {
                            Id = 26,
                            HospitalId = 3,
                            Name = "Pediatric Institute"
                        },
                        new
                        {
                            Id = 27,
                            HospitalId = 3,
                            Name = "Endocrinology & Metabolism Institute"
                        },
                        new
                        {
                            Id = 28,
                            HospitalId = 3,
                            Name = "Urology & Kidney Institute"
                        },
                        new
                        {
                            Id = 29,
                            HospitalId = 3,
                            Name = "Respiratory Institute"
                        },
                        new
                        {
                            Id = 30,
                            HospitalId = 3,
                            Name = "Anesthesiology & Pain Management"
                        },
                        new
                        {
                            Id = 31,
                            HospitalId = 4,
                            Name = "Anesthesiology and Critical Care Medicine"
                        },
                        new
                        {
                            Id = 32,
                            HospitalId = 4,
                            Name = "Cardiology"
                        },
                        new
                        {
                            Id = 33,
                            HospitalId = 4,
                            Name = "Endocrinology, Diabetes and Metabolism"
                        },
                        new
                        {
                            Id = 34,
                            HospitalId = 4,
                            Name = "Gastroenterology and Hepatology"
                        },
                        new
                        {
                            Id = 35,
                            HospitalId = 4,
                            Name = "Hematology"
                        },
                        new
                        {
                            Id = 36,
                            HospitalId = 4,
                            Name = "Neurology"
                        },
                        new
                        {
                            Id = 37,
                            HospitalId = 4,
                            Name = "Obstetrics and Gynecology"
                        },
                        new
                        {
                            Id = 38,
                            HospitalId = 4,
                            Name = "Orthopaedic Surgery"
                        },
                        new
                        {
                            Id = 39,
                            HospitalId = 4,
                            Name = "Otolaryngology – Head and Neck Surgery"
                        },
                        new
                        {
                            Id = 40,
                            HospitalId = 4,
                            Name = "Pediatrics"
                        },
                        new
                        {
                            Id = 41,
                            HospitalId = 5,
                            Name = "Cardiology"
                        },
                        new
                        {
                            Id = 42,
                            HospitalId = 5,
                            Name = "Neurology"
                        },
                        new
                        {
                            Id = 43,
                            HospitalId = 5,
                            Name = "Orthopaedic Surgery"
                        },
                        new
                        {
                            Id = 44,
                            HospitalId = 5,
                            Name = "Gastroenterology"
                        });
                });

            modelBuilder.Entity("HMS.Model.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HospitalId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("HospitalId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("HMS.Model.Hospital", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfBeds")
                        .HasColumnType("int");

                    b.Property<string>("Ownership")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Hospitals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "1001 Potrero Ave",
                            City = "San Francisco",
                            Latitude = 37.755634000000001,
                            Longitude = -122.40374799999999,
                            Name = "San Francisco General Hospital",
                            NumberOfBeds = 284,
                            Ownership = "Public",
                            PhoneNumber = "(415) 206-8000",
                            State = "CA",
                            Type = "General",
                            Website = "https://zuckerbergsanfranciscogeneral.org",
                            ZipCode = "94110"
                        },
                        new
                        {
                            Id = 2,
                            Address = "200 1st St SW",
                            City = "Rochester",
                            Latitude = 44.022705000000002,
                            Longitude = -92.467369000000005,
                            Name = "Mayo Clinic",
                            NumberOfBeds = 1265,
                            Ownership = "Non-profit",
                            PhoneNumber = "(507) 284-2511",
                            State = "MN",
                            Type = "Specialty",
                            Website = "https://www.mayoclinic.org",
                            ZipCode = "55905"
                        },
                        new
                        {
                            Id = 3,
                            Address = "9500 Euclid Ave",
                            City = "Cleveland",
                            Latitude = 41.503200999999997,
                            Longitude = -81.621277000000006,
                            Name = "Cleveland Clinic",
                            NumberOfBeds = 1400,
                            Ownership = "Non-profit",
                            PhoneNumber = "(216) 444-2200",
                            State = "OH",
                            Type = "Specialty",
                            Website = "https://my.clevelandclinic.org",
                            ZipCode = "44195"
                        },
                        new
                        {
                            Id = 4,
                            Address = "1800 Orleans St",
                            City = "Baltimore",
                            Latitude = 39.296317999999999,
                            Longitude = -76.592940999999996,
                            Name = "Johns Hopkins Hospital",
                            NumberOfBeds = 1000,
                            Ownership = "Non-profit",
                            PhoneNumber = "(410) 955-5000",
                            State = "MD",
                            Type = "Academic Medical Center",
                            Website = "https://www.hopkinsmedicine.org",
                            ZipCode = "21287"
                        },
                        new
                        {
                            Id = 5,
                            Address = "55 Fruit St",
                            City = "Boston",
                            Latitude = 42.362400000000001,
                            Longitude = -71.069205999999994,
                            Name = "Massachusetts General Hospital",
                            NumberOfBeds = 1000,
                            Ownership = "Non-profit",
                            PhoneNumber = "(617) 726-2000",
                            State = "MA",
                            Type = "Teaching Hospital",
                            Website = "https://www.massgeneral.org",
                            ZipCode = "02114"
                        },
                        new
                        {
                            Id = 6,
                            Address = "757 Westwood Plaza",
                            City = "Los Angeles",
                            Latitude = 34.066242000000003,
                            Longitude = -118.445328,
                            Name = "Ronald Reagan UCLA Medical Center",
                            NumberOfBeds = 520,
                            Ownership = "Non-profit",
                            PhoneNumber = "(310) 825-9111",
                            State = "CA",
                            Type = "Academic Medical Center",
                            Website = "https://www.uclahealth.org",
                            ZipCode = "90095"
                        },
                        new
                        {
                            Id = 7,
                            Address = "6565 Fannin St",
                            City = "Houston",
                            Latitude = 29.709541000000002,
                            Longitude = -95.398605000000003,
                            Name = "Houston Methodist Hospital",
                            NumberOfBeds = 1000,
                            Ownership = "Non-profit",
                            PhoneNumber = "(713) 790-3311",
                            State = "TX",
                            Type = "Teaching Hospital",
                            Website = "https://www.houstonmethodist.org",
                            ZipCode = "77030"
                        },
                        new
                        {
                            Id = 8,
                            Address = "525 East 68th Street",
                            City = "New York",
                            Latitude = 40.710254999999997,
                            Longitude = -74.005058000000005,
                            Name = "New York-Presbyterian Hospital",
                            NumberOfBeds = 2600,
                            Ownership = "Non-profit",
                            PhoneNumber = "(212) 746-5454",
                            State = "NY",
                            Type = "Teaching Hospital",
                            Website = "https://www.nyp.org",
                            ZipCode = "10065"
                        },
                        new
                        {
                            Id = 9,
                            Address = "8700 Beverly Blvd",
                            City = "Los Angeles",
                            Latitude = 34.069206000000001,
                            Longitude = -118.377,
                            Name = "Cedars-Sinai Medical Center",
                            NumberOfBeds = 886,
                            Ownership = "Non-profit",
                            PhoneNumber = "(310) 423-3277",
                            State = "CA",
                            Type = "Teaching Hospital",
                            Website = "https://www.cedars-sinai.org",
                            ZipCode = "90048"
                        },
                        new
                        {
                            Id = 10,
                            Address = "1 Gustave L. Levy Place",
                            City = "New York",
                            Latitude = 40.790275999999999,
                            Longitude = -73.952646000000001,
                            Name = "Mount Sinai Hospital",
                            NumberOfBeds = 1171,
                            Ownership = "Non-profit",
                            PhoneNumber = "(212) 241-6500",
                            State = "NY",
                            Type = "Teaching Hospital",
                            Website = "https://www.mountsinai.org",
                            ZipCode = "10029"
                        });
                });

            modelBuilder.Entity("HMS.Model.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MedicalHistory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("HMS.Model.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("HMS.Model.Appointment", b =>
                {
                    b.HasOne("HMS.Model.Doctor", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HMS.Model.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("HMS.Model.Department", b =>
                {
                    b.HasOne("HMS.Model.Hospital", "Hospital")
                        .WithMany("Departments")
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hospital");
                });

            modelBuilder.Entity("HMS.Model.Doctor", b =>
                {
                    b.HasOne("HMS.Model.Department", "Department")
                        .WithMany("Doctors")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HMS.Model.Hospital", null)
                        .WithMany("Doctors")
                        .HasForeignKey("HospitalId");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("HMS.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("HMS.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HMS.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("HMS.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HMS.Model.Department", b =>
                {
                    b.Navigation("Doctors");
                });

            modelBuilder.Entity("HMS.Model.Doctor", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("HMS.Model.Hospital", b =>
                {
                    b.Navigation("Departments");

                    b.Navigation("Doctors");
                });

            modelBuilder.Entity("HMS.Model.Patient", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
