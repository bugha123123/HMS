using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.Migrations
{
    /// <inheritdoc />
    public partial class asdawdawdhwaduyhawdwad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppointmentId",
                table: "DoctorNotifications",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DoctorNotifications_AppointmentId",
                table: "DoctorNotifications",
                column: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorNotifications_Appointments_AppointmentId",
                table: "DoctorNotifications",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorNotifications_Appointments_AppointmentId",
                table: "DoctorNotifications");

            migrationBuilder.DropIndex(
                name: "IX_DoctorNotifications_AppointmentId",
                table: "DoctorNotifications");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "DoctorNotifications");
        }
    }
}
