using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace COMP2139_Labs.Migrations
{
    /// <inheritdoc />
    public partial class AddPersonAndCarsToBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarRentalId",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonCount",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 1,
                columns: new[] { "CarRentalId", "PersonCount" },
                values: new object[] { null, 1 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 2,
                columns: new[] { "CarRentalId", "PersonCount" },
                values: new object[] { null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CarRentalId",
                table: "Bookings",
                column: "CarRentalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_CarRentals_CarRentalId",
                table: "Bookings",
                column: "CarRentalId",
                principalTable: "CarRentals",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_CarRentals_CarRentalId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_CarRentalId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "CarRentalId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "PersonCount",
                table: "Bookings");
        }
    }
}
