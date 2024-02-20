using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace COMP2139_Labs.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Amentities", "Image", "Location", "Name", "Price", "Reviews" },
                values: new object[,]
                {
                    { 1, "All-inclusive resort with outdoor pool and beach access", "", "Varadero", "Villa Coco", 299.99000000000001, 4.5 },
                    { 2, "All-inclusive resort with beach access", "", "Varadero", "Hotel Varadero", 199.99000000000001, 3.7000000000000002 }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingId", "EndDate", "HotelId", "StartDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2024, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2024, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2024, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 2);
        }
    }
}
