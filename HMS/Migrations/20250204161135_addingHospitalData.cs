using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HMS.Migrations
{
    /// <inheritdoc />
    public partial class addingHospitalData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hospitals",
                columns: new[] { "Id", "Address", "City", "Latitude", "Longitude", "Name", "NumberOfBeds", "Ownership", "PhoneNumber", "State", "Type", "Website", "ZipCode" },
                values: new object[,]
                {
                    { 1, "1001 Potrero Ave", "San Francisco", 37.755634000000001, -122.40374799999999, "San Francisco General Hospital", 284, "Public", "(415) 206-8000", "CA", "General", "https://zuckerbergsanfranciscogeneral.org", "94110" },
                    { 2, "200 1st St SW", "Rochester", 44.022705000000002, -92.467369000000005, "Mayo Clinic", 1265, "Non-profit", "(507) 284-2511", "MN", "Specialty", "https://www.mayoclinic.org", "55905" },
                    { 3, "9500 Euclid Ave", "Cleveland", 41.503200999999997, -81.621277000000006, "Cleveland Clinic", 1400, "Non-profit", "(216) 444-2200", "OH", "Specialty", "https://my.clevelandclinic.org", "44195" },
                    { 4, "1800 Orleans St", "Baltimore", 39.296317999999999, -76.592940999999996, "Johns Hopkins Hospital", 1000, "Non-profit", "(410) 955-5000", "MD", "Academic Medical Center", "https://www.hopkinsmedicine.org", "21287" },
                    { 5, "55 Fruit St", "Boston", 42.362400000000001, -71.069205999999994, "Massachusetts General Hospital", 1000, "Non-profit", "(617) 726-2000", "MA", "Teaching Hospital", "https://www.massgeneral.org", "02114" },
                    { 6, "757 Westwood Plaza", "Los Angeles", 34.066242000000003, -118.445328, "Ronald Reagan UCLA Medical Center", 520, "Non-profit", "(310) 825-9111", "CA", "Academic Medical Center", "https://www.uclahealth.org", "90095" },
                    { 7, "6565 Fannin St", "Houston", 29.709541000000002, -95.398605000000003, "Houston Methodist Hospital", 1000, "Non-profit", "(713) 790-3311", "TX", "Teaching Hospital", "https://www.houstonmethodist.org", "77030" },
                    { 8, "525 East 68th Street", "New York", 40.710254999999997, -74.005058000000005, "New York-Presbyterian Hospital", 2600, "Non-profit", "(212) 746-5454", "NY", "Teaching Hospital", "https://www.nyp.org", "10065" },
                    { 9, "8700 Beverly Blvd", "Los Angeles", 34.069206000000001, -118.377, "Cedars-Sinai Medical Center", 886, "Non-profit", "(310) 423-3277", "CA", "Teaching Hospital", "https://www.cedars-sinai.org", "90048" },
                    { 10, "1 Gustave L. Levy Place", "New York", 40.790275999999999, -73.952646000000001, "Mount Sinai Hospital", 1171, "Non-profit", "(212) 241-6500", "NY", "Teaching Hospital", "https://www.mountsinai.org", "10029" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
