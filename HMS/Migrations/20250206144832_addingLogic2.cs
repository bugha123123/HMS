using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.Migrations
{
    /// <inheritdoc />
    public partial class addingLogic2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WaitingLists_AspNetUsers_UserId",
                table: "WaitingLists");

            migrationBuilder.DropIndex(
                name: "IX_WaitingLists_UserId",
                table: "WaitingLists");

            migrationBuilder.DropColumn(
                name: "AdditionalInformation",
                table: "WaitingLists");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "WaitingLists");

            migrationBuilder.RenameColumn(
                name: "Profession",
                table: "WaitingLists",
                newName: "UserEmail");

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

            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "WaitingLists",
                newName: "Profession");

            migrationBuilder.AddColumn<string>(
                name: "AdditionalInformation",
                table: "WaitingLists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "WaitingLists",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_WaitingLists_UserId",
                table: "WaitingLists",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WaitingLists_AspNetUsers_UserId",
                table: "WaitingLists",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
