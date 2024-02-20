using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace COMP2139_Labs.Migrations
{
    /// <inheritdoc />
    public partial class AddFlights : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FlightId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Airline = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    DepartureFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartureTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightId);
                });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 1,
                column: "FlightId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 2,
                column: "FlightId",
                value: 2);

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "FlightId", "Airline", "DepartureFrom", "DepartureTo", "Destination", "Price", "ReturnFrom", "ReturnTo", "Source" },
                values: new object[,]
                {
                    { 1, "Air Canada", new DateTime(2024, 5, 13, 7, 10, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 13, 10, 10, 0, 0, DateTimeKind.Unspecified), "Varadero", 300.0, new DateTime(2024, 5, 27, 7, 10, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 27, 10, 10, 0, 0, DateTimeKind.Unspecified), "Toronto" },
                    { 2, "Air Canada", new DateTime(2024, 4, 13, 7, 10, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 13, 10, 10, 0, 0, DateTimeKind.Unspecified), "Varadero", 249.0, new DateTime(2024, 4, 27, 7, 10, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 27, 10, 10, 0, 0, DateTimeKind.Unspecified), "Toronto" },
                    { 3, "Nippon Airways", new DateTime(2024, 4, 13, 7, 10, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 13, 10, 10, 0, 0, DateTimeKind.Unspecified), "Tokyo", 1699.0, new DateTime(2024, 4, 27, 7, 10, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 27, 10, 10, 0, 0, DateTimeKind.Unspecified), "Toronto" },
                    { 4, "Lufthansa", new DateTime(2024, 4, 13, 7, 10, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 13, 10, 10, 0, 0, DateTimeKind.Unspecified), "Munich", 1070.0, new DateTime(2024, 4, 27, 7, 10, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 27, 10, 10, 0, 0, DateTimeKind.Unspecified), "Toronto" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Amentities", "Image", "Location", "Name", "Price", "Reviews" },
                values: new object[,]
                {
                    { 3, "All-inclusive resort with beach access", "", "Varadero", "Playa Azul", 229.99000000000001, 4.0999999999999996 },
                    { 4, "Island resort with bungalows", "", "Varadero", "Hotel Cubana", 249.49000000000001, 4.0 },
                    { 5, "In historical part of the town", "", "Munich", "Hotel Excellent", 149.00999999999999, 4.0999999999999996 },
                    { 6, "Cute mountain hotel", "", "Munich", "Le Daufin", 180.00999999999999, 4.0999999999999996 },
                    { 7, "Old luxury hotel in the heart of the city", "", "Munich", "Kaiser Hotel", 499.0, 5.0 },
                    { 8, "Authentic Japanese hotel", "", "Tokyo", "Sakura Tower", 179.00999999999999, 4.7999999999999998 },
                    { 9, "Authentic Japanese hotel", "", "Tokyo", "Shinjuku Hotel", 129.99000000000001, 3.6000000000000001 },
                    { 10, "Newly built modern hotel with gym and indoor pool", "", "Tokyo", "Gojira Hotel", 299.99000000000001, 4.5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_FlightId",
                table: "Bookings",
                column: "FlightId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Flights_FlightId",
                table: "Bookings",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "FlightId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Flights_FlightId",
                table: "Bookings");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_FlightId",
                table: "Bookings");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "FlightId",
                table: "Bookings");
        }
    }
}
