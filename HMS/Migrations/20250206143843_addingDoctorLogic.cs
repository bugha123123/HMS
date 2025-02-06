using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.Migrations
{
    /// <inheritdoc />
    public partial class addingDoctorLogic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdditionalInformation",
                table: "WaitingLists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "Education",
                table: "WaitingLists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Experience",
                table: "WaitingLists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HospitalAffiliation",
                table: "WaitingLists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Specialization",
                table: "WaitingLists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "doctorApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalLicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearsOfExperience = table.Column<int>(type: "int", nullable: false),
                    PracticeDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MedicalSchool = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DegreeOrCertification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GraduationYear = table.Column<int>(type: "int", nullable: false),
                    BoardCertification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimaryHospitalAffiliation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondaryHospitalAffiliation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctorApplications", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "doctorApplications");

            migrationBuilder.DropColumn(
                name: "AdditionalInformation",
                table: "WaitingLists");

            migrationBuilder.DropColumn(
                name: "Education",
                table: "WaitingLists");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "WaitingLists");

            migrationBuilder.DropColumn(
                name: "HospitalAffiliation",
                table: "WaitingLists");

            migrationBuilder.DropColumn(
                name: "Specialization",
                table: "WaitingLists");
        }
    }
}
