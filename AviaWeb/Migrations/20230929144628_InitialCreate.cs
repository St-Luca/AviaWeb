using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AviaWeb.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patronical = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AirTickets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Departure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Arrival = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfConclusion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassengerId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirTickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AirTickets_Passengers_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "Passengers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassengerId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_Passengers_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "Passengers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Passengers",
                columns: new[] { "Id", "FirstName", "LastName", "Patronical" },
                values: new object[,]
                {
                    { 1L, "FN1", "LN1", "PAT1" },
                    { 2L, "FN2", "LN2", "PAT2" },
                    { 3L, "FN3", "LN3", "PAT3" },
                    { 4L, "FN4", "LN4", "PAT4" },
                    { 5L, "FN5", "LN5", "PAT5" }
                });

            migrationBuilder.InsertData(
                table: "AirTickets",
                columns: new[] { "Id", "Arrival", "ArrivalDate", "Company", "DateOfConclusion", "Departure", "DepartureDate", "PassengerId" },
                values: new object[,]
                {
                    { 1L, "SaintPetersburg", new DateTime(2023, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "AeroFlight", new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moscow", new DateTime(2023, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L },
                    { 2L, "Moscow", new DateTime(2023, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "TopAirlines", new DateTime(2023, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Samara", new DateTime(2023, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L },
                    { 3L, "Ekaterinburg", new DateTime(2023, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "AeroFlight", new DateTime(2023, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tumen", new DateTime(2023, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L },
                    { 4L, "Ekaterinburg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TopAirlines", new DateTime(2023, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tumen", new DateTime(2023, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 3L },
                    { 5L, "Moscow", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SevenAirlines", new DateTime(2023, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kurgan", new DateTime(2023, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L }
                });

            migrationBuilder.InsertData(
                table: "Documents",
                columns: new[] { "Id", "PassengerId", "Type" },
                values: new object[,]
                {
                    { 1L, 1L, "Passport1" },
                    { 2L, 1L, "Passport2" },
                    { 3L, 2L, "Passport3" },
                    { 4L, 3L, "Passport4" },
                    { 5L, 3L, "Passport5" },
                    { 6L, 3L, "Passport6" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AirTickets_PassengerId",
                table: "AirTickets",
                column: "PassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_PassengerId",
                table: "Documents",
                column: "PassengerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirTickets");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Passengers");
        }
    }
}
