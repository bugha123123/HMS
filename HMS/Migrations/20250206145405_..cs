using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.Migrations
{
    /// <inheritdoc />
    public partial class _ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorApplicationId",
                table: "WaitingLists",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WaitingLists_DoctorApplicationId",
                table: "WaitingLists",
                column: "DoctorApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_WaitingLists_doctorApplications_DoctorApplicationId",
                table: "WaitingLists",
                column: "DoctorApplicationId",
                principalTable: "doctorApplications",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WaitingLists_doctorApplications_DoctorApplicationId",
                table: "WaitingLists");

            migrationBuilder.DropIndex(
                name: "IX_WaitingLists_DoctorApplicationId",
                table: "WaitingLists");

            migrationBuilder.DropColumn(
                name: "DoctorApplicationId",
                table: "WaitingLists");
        }
    }
}
