using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace COMP2139_Labs.Migrations
{
    /// <inheritdoc />
    public partial class CarRentalsInitiation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarRentals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PricePerDay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    AvailableFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AvailableUntil = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarRentals", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CarRentals",
                columns: new[] { "Id", "AvailableFrom", "AvailableUntil", "Color", "IsAvailable", "Make", "Model", "PricePerDay", "Year" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 21, 0, 0, 0, 0, DateTimeKind.Local), "Blue", true, "Toyota", "Camry", 50.00m, 2020 },
                    { 2, new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 21, 0, 0, 0, 0, DateTimeKind.Local), "White", true, "Ford", "Focus", 45.00m, 2019 },
                    { 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Red", true, "Honda", "Civic", 40.00m, 2018 },
                    { 4, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Black", true, "Chevrolet", "Malibu", 55.00m, 2019 },
                    { 5, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yellow", true, "Ford", "Mustang", 75.00m, 2020 },
                    { 6, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "White", true, "Tesla", "Model 3", 85.00m, 2021 },
                    { 7, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Blue", true, "BMW", "3 Series", 90.00m, 2019 },
                    { 8, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grey", true, "Audi", "A4", 95.00m, 2020 },
                    { 9, new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Black", true, "Mercedes", "Benz C-Class", 100.00m, 2021 },
                    { 10, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Silver", true, "Nissan", "Altima", 50.00m, 2018 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarRentals");
        }
    }
}
