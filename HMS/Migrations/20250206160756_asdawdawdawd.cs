using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.Migrations
{
    /// <inheritdoc />
    public partial class asdawdawdawd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WaitingLists");

            migrationBuilder.AddColumn<int>(
                name: "DoctorApplicationId",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DoctorApplicationId",
                table: "Doctors",
                column: "DoctorApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_doctorApplications_DoctorApplicationId",
                table: "Doctors",
                column: "DoctorApplicationId",
                principalTable: "doctorApplications",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_doctorApplications_DoctorApplicationId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_DoctorApplicationId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "DoctorApplicationId",
                table: "Doctors");

            migrationBuilder.CreateTable(
                name: "WaitingLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorApplicationId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaitingLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WaitingLists_doctorApplications_DoctorApplicationId",
                        column: x => x.DoctorApplicationId,
                        principalTable: "doctorApplications",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WaitingLists_DoctorApplicationId",
                table: "WaitingLists",
                column: "DoctorApplicationId");
        }
    }
}
