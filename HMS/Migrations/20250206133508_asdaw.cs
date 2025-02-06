using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HMS.Migrations
{
    /// <inheritdoc />
    public partial class asdaw : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistories_Appointments_AppointmentId",
                table: "MedicalHistories");

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.AddColumn<int>(
                name: "AppointmentId1",
                table: "MedicalHistories",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "HospitalId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "HospitalId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                column: "HospitalId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                column: "HospitalId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                column: "HospitalId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 7,
                column: "HospitalId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 8,
                column: "HospitalId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 9,
                column: "HospitalId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 10,
                column: "HospitalId",
                value: 10);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistories_AppointmentId1",
                table: "MedicalHistories",
                column: "AppointmentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistories_Appointments_AppointmentId",
                table: "MedicalHistories",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistories_Appointments_AppointmentId1",
                table: "MedicalHistories",
                column: "AppointmentId1",
                principalTable: "Appointments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistories_Appointments_AppointmentId",
                table: "MedicalHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistories_Appointments_AppointmentId1",
                table: "MedicalHistories");

            migrationBuilder.DropIndex(
                name: "IX_MedicalHistories_AppointmentId1",
                table: "MedicalHistories");

            migrationBuilder.DropColumn(
                name: "AppointmentId1",
                table: "MedicalHistories");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "HospitalId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "HospitalId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                column: "HospitalId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                column: "HospitalId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                column: "HospitalId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 7,
                column: "HospitalId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 8,
                column: "HospitalId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 9,
                column: "HospitalId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 10,
                column: "HospitalId",
                value: 1);

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "HospitalId", "Name", "Type" },
                values: new object[,]
                {
                    { 11, 2, "Cardiovascular Medicine", 10 },
                    { 12, 2, "Neurology", 6 },
                    { 13, 2, "Orthopedic Surgery", 5 },
                    { 14, 2, "Gastroenterology and Hepatology", 11 },
                    { 15, 2, "Endocrinology", 12 },
                    { 16, 2, "Oncology", 13 },
                    { 17, 2, "Pulmonary Medicine", 14 },
                    { 18, 2, "Nephrology and Hypertension", 15 },
                    { 19, 2, "Rheumatology", 16 },
                    { 20, 2, "Dermatology", 17 }
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
                    { 7, 8, "Dr. William Harris", 2, "(507) 284-2511", "Cardiovascular Medicine" },
                    { 8, 7, "Dr. Olivia White", 2, "(507) 284-2512", "Neurology" },
                    { 12, 8, "Dr. Thomas Scott", 3, "(216) 444-2200", "Heart, Vascular & Thoracic Institute" },
                    { 13, 9, "Dr. Grace Martinez", 3, "(216) 444-2201", "Neurological Institute" },
                    { 14, 10, "Dr. Ethan Robinson", 3, "(216) 444-2202", "Orthopaedic & Rheumatologic Institute" },
                    { 15, 9, "Dr. Natalie Clark", 3, "(216) 444-2203", "Digestive Disease & Surgery Institute" },
                    { 16, 8, "Dr. Henry Lewis", 3, "(216) 444-2204", "Cancer Center / Taussig Cancer Institute" },
                    { 17, 8, "Dr. Alice Evans", 4, "(410) 955-5000", "Cardiology" },
                    { 18, 7, "Dr. Robert King", 4, "(410) 955-5001", "Neurology" },
                    { 20, 8, "Dr. Michael Taylor", 4, "(410) 955-5003", "Hematology" },
                    { 21, 8, "Dr. Ava Harris", 5, "(617) 726-2000", "Cardiology" },
                    { 22, 7, "Dr. James Hall", 5, "(617) 726-2001", "Neurology" },
                    { 24, 10, "Dr. Ethan Lopez", 5, "(617) 726-2003", "Orthopaedic Surgery" },
                    { 25, 8, "Dr. Lucas Martin", 5, "(617) 726-2004", "Oncology" },
                    { 26, 8, "Dr. Julia Ross", 6, "(310) 825-9111", "Cardiology" },
                    { 27, 7, "Dr. Robert Williams", 6, "(310) 825-9112", "Neurology" },
                    { 29, 10, "Dr. James White", 6, "(310) 825-9114", "Orthopaedic Surgery" },
                    { 30, 8, "Dr. Elizabeth Wright", 7, "(713) 790-3311", "Cardiology" },
                    { 31, 7, "Dr. Charles Moore", 7, "(713) 790-3312", "Neurology" },
                    { 32, 10, "Dr. Rachel Scott", 7, "(713) 790-3313", "Orthopaedic Surgery" },
                    { 33, 8, "Dr. Olivia Anderson", 8, "(212) 746-5454", "Cardiology" },
                    { 34, 7, "Dr. Kevin Parker", 8, "(212) 746-5455", "Neurology" },
                    { 35, 10, "Dr. Susan Moore", 8, "(212) 746-5456", "Orthopaedic Surgery" },
                    { 36, 8, "Dr. Daniel Brown", 9, "(310) 423-3277", "Cardiology" },
                    { 37, 7, "Dr. Anna Robinson", 9, "(310) 423-3278", "Neurology" },
                    { 38, 10, "Dr. Emily Harris", 9, "(310) 423-3279", "Orthopaedic Surgery" },
                    { 39, 8, "Dr. David Carter", 10, "(212) 241-6500", "Cardiology" },
                    { 40, 7, "Dr. Lily Baker", 10, "(212) 241-6501", "Neurology" },
                    { 41, 10, "Dr. John Davis", 10, "(212) 241-6502", "Orthopaedic Surgery" },
                    { 9, 13, "Dr. David Green", 2, "(507) 284-2513", "Orthopedic Surgery" },
                    { 10, 14, "Dr. Isabella Adams", 2, "(507) 284-2514", "Gastroenterology and Hepatology" },
                    { 11, 15, "Dr. Joseph Clark", 2, "(507) 284-2515", "Endocrinology" },
                    { 19, 13, "Dr. Lily Moore", 4, "(410) 955-5002", "Orthopaedic Surgery" },
                    { 23, 13, "Dr. Mia Young", 5, "(617) 726-2002", "Gastroenterology" },
                    { 28, 13, "Dr. Samantha Bennett", 6, "(310) 825-9113", "Gastroenterology" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistories_Appointments_AppointmentId",
                table: "MedicalHistories",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
