using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HMS.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hospitals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    NumberOfBeds = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ownership = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HospitalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Hospitals_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Hospitals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HospitalId = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctors_Hospitals_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Hospitals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    AppointmentTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    HospitalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HospitalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_AspNetUsers_PatientId",
                        column: x => x.PatientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Hospitals_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Hospitals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MedicalHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AppointmentId = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Treatment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalHistories_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalHistories_AspNetUsers_PatientId",
                        column: x => x.PatientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Hospitals",
                columns: new[] { "Id", "Address", "City", "Latitude", "Longitude", "Name", "NumberOfBeds", "Ownership", "PhoneNumber", "State", "Type", "Website", "ZipCode" },
                values: new object[,]
                {
                    { 1, "1001 Potrero Ave", "San Francisco", 37.755634000000001, -122.40374799999999, "San Francisco General Hospital", 284, "Public", "(415) 206-8000", "CA", "General", "https://zuckerbergsanfranciscogeneral.org", "94110" },
                    { 2, "200 1st St SW", "Rochester", 44.022705000000002, -92.467369000000005, "Mayo Clinic", 1265, "Non-profit", "(507) 284-2511", "MN", "Specialty", "https://www.mayoclinic.org", "55905" },
                    { 3, "9500 Euclid Ave", "Cleveland", 41.503200999999997, -81.621277000000006, "Cleveland Clinic", 1400, "Non-profit", "(216) 444-2200", "OH", "Specialty", "https://my.clevelandclinic.org", "44195" },
                    { 4, "1800 Orleans St", "Baltimore", 39.296317999999999, -76.592940999999996, "Johns Hopkins Hospital", 1000, "Non-profit", "(410) 955-5000", "MD", "Academic Medical Center", "https://www.hopkinsmedicine.org", "21287" },
                    { 5, "55 Fruit St", "Boston", 42.362400000000001, -71.069205999999994, "Massachusetts General Hospital", 1000, "Non-profit", "(617) 726-2000", "MA", "Teaching Hospital", "https://www.massgeneral.org", "02114" },
                    { 6, "757 Westwood Plaza", "Los Angeles", 34.066242000000003, -118.445328, "Ronald Reagan UCLA Medical Center", 520, "Non-profit", "(310) 825-9111", "CA", "Academic Medical Center", "https://www.uclahealth.org", "90095" },
                    { 7, "6565 Fannin St", "Houston", 29.709541000000002, -95.398605000000003, "Houston Methodist Hospital", 1000, "Non-profit", "(713) 790-3311", "TX", "Teaching Hospital", "https://www.houstonmethodist.org", "77030" },
                    { 8, "525 East 68th Street", "New York", 40.710254999999997, -74.005058000000005, "New York-Presbyterian Hospital", 2600, "Non-profit", "(212) 746-5454", "NY", "Teaching Hospital", "https://www.nyp.org", "10065" },
                    { 9, "8700 Beverly Blvd", "Los Angeles", 34.069206000000001, -118.377, "Cedars-Sinai Medical Center", 886, "Non-profit", "(310) 423-3277", "CA", "Teaching Hospital", "https://www.cedars-sinai.org", "90048" },
                    { 10, "1 Gustave L. Levy Place", "New York", 40.790275999999999, -73.952646000000001, "Mount Sinai Hospital", 1171, "Non-profit", "(212) 241-6500", "NY", "Teaching Hospital", "https://www.mountsinai.org", "10029" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "HospitalId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Emergency Medicine" },
                    { 2, 1, "General Medicine" },
                    { 3, 1, "Surgery" },
                    { 4, 1, "Pediatrics" },
                    { 5, 1, "Obstetrics and Gynecology" },
                    { 6, 1, "Orthopedic Surgery" },
                    { 7, 1, "Neurology" },
                    { 8, 1, "Cardiology" },
                    { 9, 1, "Psychiatry" },
                    { 10, 1, "Radiology" },
                    { 11, 2, "Cardiovascular Medicine" },
                    { 12, 2, "Neurology" },
                    { 13, 2, "Orthopedic Surgery" },
                    { 14, 2, "Gastroenterology and Hepatology" },
                    { 15, 2, "Endocrinology" },
                    { 16, 2, "Oncology" },
                    { 17, 2, "Pulmonary Medicine" },
                    { 18, 2, "Nephrology and Hypertension" },
                    { 19, 2, "Rheumatology" },
                    { 20, 2, "Dermatology" },
                    { 21, 3, "Heart, Vascular & Thoracic Institute" },
                    { 22, 3, "Neurological Institute" },
                    { 23, 3, "Orthopaedic & Rheumatologic Institute" },
                    { 24, 3, "Digestive Disease & Surgery Institute" },
                    { 25, 3, "Cancer Center / Taussig Cancer Institute" },
                    { 26, 3, "Pediatric Institute" },
                    { 27, 3, "Endocrinology & Metabolism Institute" },
                    { 28, 3, "Urology & Kidney Institute" },
                    { 29, 3, "Respiratory Institute" },
                    { 30, 3, "Anesthesiology & Pain Management" },
                    { 31, 4, "Anesthesiology and Critical Care Medicine" },
                    { 32, 4, "Cardiology" },
                    { 33, 4, "Endocrinology, Diabetes and Metabolism" },
                    { 34, 4, "Gastroenterology and Hepatology" },
                    { 35, 4, "Hematology" },
                    { 36, 4, "Neurology" },
                    { 37, 4, "Obstetrics and Gynecology" },
                    { 38, 4, "Orthopaedic Surgery" },
                    { 39, 4, "Otolaryngology – Head and Neck Surgery" },
                    { 40, 4, "Pediatrics" },
                    { 41, 5, "Cardiology" },
                    { 42, 5, "Neurology" },
                    { 43, 5, "Orthopaedic Surgery" },
                    { 44, 5, "Gastroenterology" },
                    { 45, 5, "Endocrinology, Diabetes and Metabolism" },
                    { 46, 5, "Oncology" },
                    { 47, 5, "Pediatric Neurology" },
                    { 48, 5, "Pulmonary Medicine" },
                    { 49, 5, "Transplant Surgery" },
                    { 50, 5, "Radiology" },
                    { 51, 6, "Cardiology" },
                    { 52, 6, "Gastroenterology" },
                    { 53, 6, "Neurology" },
                    { 54, 6, "Oncology" },
                    { 55, 6, "Orthopaedic Surgery" },
                    { 56, 6, "Pediatric Surgery" },
                    { 57, 6, "Psychiatry" },
                    { 58, 6, "Pulmonary Medicine" },
                    { 59, 6, "Rheumatology" },
                    { 60, 6, "Surgery" },
                    { 61, 7, "Cardiology" },
                    { 62, 7, "Gastroenterology" },
                    { 63, 7, "Neurology" },
                    { 64, 7, "Orthopaedic Surgery" },
                    { 65, 7, "Oncology" },
                    { 66, 7, "Pediatric Surgery" },
                    { 67, 7, "Pulmonary Medicine" },
                    { 68, 7, "Radiology" },
                    { 69, 7, "Rheumatology" },
                    { 70, 7, "Transplant Surgery" },
                    { 71, 8, "Cardiology" },
                    { 72, 8, "Neurosurgery" },
                    { 73, 8, "Orthopaedic Surgery" },
                    { 74, 8, "Gastroenterology" },
                    { 75, 8, "Oncology" },
                    { 76, 8, "Pediatrics" },
                    { 77, 8, "Psychiatry" },
                    { 78, 8, "Pulmonary Medicine" },
                    { 79, 8, "Surgery" },
                    { 80, 8, "Radiology" },
                    { 81, 9, "Cardiology" },
                    { 82, 9, "Endocrinology" },
                    { 83, 9, "Gastroenterology" },
                    { 84, 9, "Neurology" },
                    { 85, 9, "Oncology" },
                    { 86, 9, "Orthopaedic Surgery" },
                    { 87, 9, "Pediatrics" },
                    { 88, 9, "Radiology" },
                    { 89, 9, "Rheumatology" },
                    { 90, 9, "Surgery" },
                    { 91, 10, "Cardiology" },
                    { 92, 10, "Endocrinology" },
                    { 93, 10, "Gastroenterology" },
                    { 94, 10, "Neurology" },
                    { 95, 10, "Orthopaedic Surgery" },
                    { 96, 10, "Oncology" },
                    { 97, 10, "Pediatrics" },
                    { 98, 10, "Pulmonary Medicine" },
                    { 99, 10, "Radiology" },
                    { 100, 10, "Surgery" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "DepartmentId", "FullName", "HospitalId", "PhoneNumber", "Specialization" },
                values: new object[,]
                {
                    { 1, 1, "Dr. John Doe", 1, "(415) 206-8000", "Emergency Medicine" },
                    { 2, 2, "Dr. Jane Smith", 1, "(415) 206-8001", "General Medicine" },
                    { 3, 3, "Dr. Emily Johnson", 1, "(415) 206-8002", "Surgery" },
                    { 4, 4, "Dr. Mark Brown", 1, "(415) 206-8003", "Pediatrics" },
                    { 5, 5, "Dr. Sarah Lee", 1, "(415) 206-8004", "Obstetrics and Gynecology" },
                    { 6, 6, "Dr. Michael Wang", 1, "(415) 206-8005", "Orthopedic Surgery" },
                    { 7, 11, "Dr. William Harris", 2, "(507) 284-2511", "Cardiovascular Medicine" },
                    { 8, 12, "Dr. Olivia White", 2, "(507) 284-2512", "Neurology" },
                    { 9, 13, "Dr. David Green", 2, "(507) 284-2513", "Orthopedic Surgery" },
                    { 10, 14, "Dr. Isabella Adams", 2, "(507) 284-2514", "Gastroenterology and Hepatology" },
                    { 11, 15, "Dr. Joseph Clark", 2, "(507) 284-2515", "Endocrinology" },
                    { 12, 21, "Dr. Thomas Scott", 3, "(216) 444-2200", "Heart, Vascular & Thoracic Institute" },
                    { 13, 22, "Dr. Grace Martinez", 3, "(216) 444-2201", "Neurological Institute" },
                    { 14, 23, "Dr. Ethan Robinson", 3, "(216) 444-2202", "Orthopaedic & Rheumatologic Institute" },
                    { 15, 24, "Dr. Natalie Clark", 3, "(216) 444-2203", "Digestive Disease & Surgery Institute" },
                    { 16, 25, "Dr. Henry Lewis", 3, "(216) 444-2204", "Cancer Center / Taussig Cancer Institute" },
                    { 17, 32, "Dr. Alice Evans", 4, "(410) 955-5000", "Cardiology" },
                    { 18, 33, "Dr. Robert King", 4, "(410) 955-5001", "Neurology" },
                    { 19, 38, "Dr. Lily Moore", 4, "(410) 955-5002", "Orthopaedic Surgery" },
                    { 20, 35, "Dr. Michael Taylor", 4, "(410) 955-5003", "Hematology" },
                    { 21, 41, "Dr. Ava Harris", 5, "(617) 726-2000", "Cardiology" },
                    { 22, 42, "Dr. James Hall", 5, "(617) 726-2001", "Neurology" },
                    { 23, 43, "Dr. Mia Young", 5, "(617) 726-2002", "Gastroenterology" },
                    { 24, 44, "Dr. Ethan Lopez", 5, "(617) 726-2003", "Orthopaedic Surgery" },
                    { 25, 46, "Dr. Lucas Martin", 5, "(617) 726-2004", "Oncology" },
                    { 26, 51, "Dr. Julia Ross", 6, "(310) 825-9111", "Cardiology" },
                    { 27, 52, "Dr. Robert Williams", 6, "(310) 825-9112", "Neurology" },
                    { 28, 53, "Dr. Samantha Bennett", 6, "(310) 825-9113", "Gastroenterology" },
                    { 29, 54, "Dr. James White", 6, "(310) 825-9114", "Orthopaedic Surgery" },
                    { 30, 61, "Dr. Elizabeth Wright", 7, "(713) 790-3311", "Cardiology" },
                    { 31, 62, "Dr. Charles Moore", 7, "(713) 790-3312", "Neurology" },
                    { 32, 63, "Dr. Rachel Scott", 7, "(713) 790-3313", "Orthopaedic Surgery" },
                    { 33, 71, "Dr. Olivia Anderson", 8, "(212) 746-5454", "Cardiology" },
                    { 34, 72, "Dr. Kevin Parker", 8, "(212) 746-5455", "Neurology" },
                    { 35, 73, "Dr. Susan Moore", 8, "(212) 746-5456", "Orthopaedic Surgery" },
                    { 36, 81, "Dr. Daniel Brown", 9, "(310) 423-3277", "Cardiology" },
                    { 37, 82, "Dr. Anna Robinson", 9, "(310) 423-3278", "Neurology" },
                    { 38, 83, "Dr. Emily Harris", 9, "(310) 423-3279", "Orthopaedic Surgery" },
                    { 39, 91, "Dr. David Carter", 10, "(212) 241-6500", "Cardiology" },
                    { 40, 92, "Dr. Lily Baker", 10, "(212) 241-6501", "Neurology" },
                    { 41, 93, "Dr. John Davis", 10, "(212) 241-6502", "Orthopaedic Surgery" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_HospitalId",
                table: "Appointments",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_HospitalId",
                table: "Departments",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DepartmentId",
                table: "Doctors",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_HospitalId",
                table: "Doctors",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistories_AppointmentId",
                table: "MedicalHistories",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistories_PatientId",
                table: "MedicalHistories",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "MedicalHistories");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Hospitals");
        }
    }
}
