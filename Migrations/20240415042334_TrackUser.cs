using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace COMP2139_Assignment.Migrations
{
    /// <inheritdoc />
    public partial class TrackUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 1,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 2,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "CarRentals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvailableFrom", "AvailableUntil" },
                values: new object[] { new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CarRentals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvailableFrom", "AvailableUntil" },
                values: new object[] { new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Local) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Bookings");

            migrationBuilder.UpdateData(
                table: "CarRentals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvailableFrom", "AvailableUntil" },
                values: new object[] { new DateTime(2024, 4, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 13, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CarRentals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvailableFrom", "AvailableUntil" },
                values: new object[] { new DateTime(2024, 4, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 13, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
