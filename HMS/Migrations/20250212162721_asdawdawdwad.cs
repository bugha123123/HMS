using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.Migrations
{
    /// <inheritdoc />
    public partial class asdawdawdwad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistories_Appointments_AppointmentId",
                table: "MedicalHistories");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistories_Appointments_AppointmentId",
                table: "MedicalHistories",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistories_Appointments_AppointmentId",
                table: "MedicalHistories");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistories_Appointments_AppointmentId",
                table: "MedicalHistories",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id");
        }
    }
}
