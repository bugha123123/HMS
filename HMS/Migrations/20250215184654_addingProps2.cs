using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.Migrations
{
    /// <inheritdoc />
    public partial class addingProps2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PatientId",
                table: "DoctorNotifications",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorNotifications_PatientId",
                table: "DoctorNotifications",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorNotifications_AspNetUsers_PatientId",
                table: "DoctorNotifications",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorNotifications_AspNetUsers_PatientId",
                table: "DoctorNotifications");

            migrationBuilder.DropIndex(
                name: "IX_DoctorNotifications_PatientId",
                table: "DoctorNotifications");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "DoctorNotifications");
        }
    }
}
