using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.Migrations
{
    /// <inheritdoc />
    public partial class removingprops : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Education",
                table: "WaitingLists");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "WaitingLists");

            migrationBuilder.DropColumn(
                name: "HospitalAffiliation",
                table: "WaitingLists");

            migrationBuilder.DropColumn(
                name: "Specialization",
                table: "WaitingLists");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Education",
                table: "WaitingLists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Experience",
                table: "WaitingLists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HospitalAffiliation",
                table: "WaitingLists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Specialization",
                table: "WaitingLists",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
