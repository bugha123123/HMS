using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HMS.Migrations
{
    /// <inheritdoc />
    public partial class DBSeedingDone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "HospitalId", "Name" },
                values: new object[,]
                {
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
                    { 1, 1, "Dr. John Doe", null, "(415) 206-8000", "Emergency Medicine" },
                    { 2, 2, "Dr. Jane Smith", null, "(415) 206-8001", "General Medicine" },
                    { 3, 3, "Dr. Emily Johnson", null, "(415) 206-8002", "Surgery" },
                    { 4, 4, "Dr. Mark Brown", null, "(415) 206-8003", "Pediatrics" },
                    { 5, 5, "Dr. Sarah Lee", null, "(415) 206-8004", "Obstetrics and Gynecology" },
                    { 6, 6, "Dr. Michael Wang", null, "(415) 206-8005", "Orthopedic Surgery" },
                    { 7, 11, "Dr. William Harris", null, "(507) 284-2511", "Cardiovascular Medicine" },
                    { 8, 12, "Dr. Olivia White", null, "(507) 284-2512", "Neurology" },
                    { 9, 13, "Dr. David Green", null, "(507) 284-2513", "Orthopedic Surgery" },
                    { 10, 14, "Dr. Isabella Adams", null, "(507) 284-2514", "Gastroenterology and Hepatology" },
                    { 11, 15, "Dr. Joseph Clark", null, "(507) 284-2515", "Endocrinology" },
                    { 12, 21, "Dr. Thomas Scott", null, "(216) 444-2200", "Heart, Vascular & Thoracic Institute" },
                    { 13, 22, "Dr. Grace Martinez", null, "(216) 444-2201", "Neurological Institute" },
                    { 14, 23, "Dr. Ethan Robinson", null, "(216) 444-2202", "Orthopaedic & Rheumatologic Institute" },
                    { 15, 24, "Dr. Natalie Clark", null, "(216) 444-2203", "Digestive Disease & Surgery Institute" },
                    { 16, 25, "Dr. Henry Lewis", null, "(216) 444-2204", "Cancer Center / Taussig Cancer Institute" },
                    { 17, 32, "Dr. Alice Evans", null, "(410) 955-5000", "Cardiology" },
                    { 18, 33, "Dr. Robert King", null, "(410) 955-5001", "Neurology" },
                    { 19, 38, "Dr. Lily Moore", null, "(410) 955-5002", "Orthopaedic Surgery" },
                    { 20, 35, "Dr. Michael Taylor", null, "(410) 955-5003", "Hematology" },
                    { 21, 41, "Dr. Ava Harris", null, "(617) 726-2000", "Cardiology" },
                    { 22, 42, "Dr. James Hall", null, "(617) 726-2001", "Neurology" },
                    { 23, 43, "Dr. Mia Young", null, "(617) 726-2002", "Gastroenterology" },
                    { 24, 44, "Dr. Ethan Lopez", null, "(617) 726-2003", "Orthopaedic Surgery" },
                    { 25, 46, "Dr. Lucas Martin", null, "(617) 726-2004", "Oncology" },
                    { 26, 51, "Dr. Julia Ross", null, "(310) 825-9111", "Cardiology" },
                    { 27, 52, "Dr. Robert Williams", null, "(310) 825-9112", "Neurology" },
                    { 28, 53, "Dr. Samantha Bennett", null, "(310) 825-9113", "Gastroenterology" },
                    { 29, 54, "Dr. James White", null, "(310) 825-9114", "Orthopaedic Surgery" },
                    { 30, 61, "Dr. Elizabeth Wright", null, "(713) 790-3311", "Cardiology" },
                    { 31, 62, "Dr. Charles Moore", null, "(713) 790-3312", "Neurology" },
                    { 32, 63, "Dr. Rachel Scott", null, "(713) 790-3313", "Orthopaedic Surgery" },
                    { 33, 71, "Dr. Olivia Anderson", null, "(212) 746-5454", "Cardiology" },
                    { 34, 72, "Dr. Kevin Parker", null, "(212) 746-5455", "Neurology" },
                    { 35, 73, "Dr. Susan Moore", null, "(212) 746-5456", "Orthopaedic Surgery" },
                    { 36, 81, "Dr. Daniel Brown", null, "(310) 423-3277", "Cardiology" },
                    { 37, 82, "Dr. Anna Robinson", null, "(310) 423-3278", "Neurology" },
                    { 38, 83, "Dr. Emily Harris", null, "(310) 423-3279", "Orthopaedic Surgery" },
                    { 39, 91, "Dr. David Carter", null, "(212) 241-6500", "Cardiology" },
                    { 40, 92, "Dr. Lily Baker", null, "(212) 241-6501", "Neurology" },
                    { 41, 93, "Dr. John Davis", null, "(212) 241-6502", "Orthopaedic Surgery" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 100);

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
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 93);
        }
    }
}
