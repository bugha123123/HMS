using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HMS.Migrations
{
    /// <inheritdoc />
    public partial class addingDepartmentData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { 44, 5, "Gastroenterology" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 10);

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
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 15);

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
                table: "Departments",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 44);
        }
    }
}
