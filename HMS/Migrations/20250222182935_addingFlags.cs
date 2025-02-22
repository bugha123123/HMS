using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.Migrations
{
    /// <inheritdoc />
    public partial class addingFlags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DoctorJoined",
                table: "Chats",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DoctorLeft",
                table: "Chats",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PatientJoined",
                table: "Chats",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PatientLeft",
                table: "Chats",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoctorJoined",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "DoctorLeft",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "PatientJoined",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "PatientLeft",
                table: "Chats");
        }
    }
}
