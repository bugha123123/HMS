using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.Migrations
{
    /// <inheritdoc />
    public partial class asdawdawdagdhwadwah : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorNotifications_Doctors_DoctorId",
                table: "DoctorNotifications");

            migrationBuilder.DropIndex(
                name: "IX_DoctorNotifications_DoctorId",
                table: "DoctorNotifications");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "DoctorNotifications",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "DoctorNotifications",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorNotifications_DoctorId",
                table: "DoctorNotifications",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorNotifications_Doctors_DoctorId",
                table: "DoctorNotifications",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
