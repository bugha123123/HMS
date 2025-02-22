using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.Migrations
{
    /// <inheritdoc />
    public partial class addingNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Chats",
                newName: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_AppointmentId",
                table: "Chats",
                column: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Appointments_AppointmentId",
                table: "Chats",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Appointments_AppointmentId",
                table: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_Chats_AppointmentId",
                table: "Chats");

            migrationBuilder.RenameColumn(
                name: "AppointmentId",
                table: "Chats",
                newName: "UserId");
        }
    }
}
