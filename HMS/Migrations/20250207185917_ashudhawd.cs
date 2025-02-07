using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.Migrations
{
    /// <inheritdoc />
    public partial class ashudhawd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistories_Appointments_AppointmentId",
                table: "MedicalHistories",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistories_Appointments_AppointmentId",
                table: "MedicalHistories");

            migrationBuilder.AddColumn<int>(
                name: "AppointmentId1",
                table: "MedicalHistories",
                type: "int",
                nullable: true);

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
    }
}
