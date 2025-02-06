using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.Migrations
{
    /// <inheritdoc />
    public partial class asdhajw : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorApplicationId",
                table: "WaitingLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WaitingLists_DoctorApplicationId",
                table: "WaitingLists",
                column: "DoctorApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_WaitingLists_doctorApplications_DoctorApplicationId",
                table: "WaitingLists",
                column: "DoctorApplicationId",
                principalTable: "doctorApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
