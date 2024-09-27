using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Event.Migrations
{
    /// <inheritdoc />
    public partial class SeedingEventsForTesting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8dade0bc-ef74-463f-a8a6-f2c2d0f79120");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97c5afdd-051e-4de3-bf1f-abd99320632d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "13bae9ea-3b02-49ff-bf40-90b1f2ba611e", null, "Admin", "ADMIN" },
                    { "6f391c51-7a10-4e7c-a810-6109f4cc3789", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Category", "Date", "Description", "IsTicketed", "Location", "OrganizerId" },
                values: new object[,]
                {
                    { 1, "Concert", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A kindom invasion, bringing the presence of God the the lost sheep", false, null, null },
                    { 2, "Art", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lux amiga putting everyone on the dancing floor", true, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13bae9ea-3b02-49ff-bf40-90b1f2ba611e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f391c51-7a10-4e7c-a810-6109f4cc3789");

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8dade0bc-ef74-463f-a8a6-f2c2d0f79120", null, "User", "USER" },
                    { "97c5afdd-051e-4de3-bf1f-abd99320632d", null, "Admin", "ADMIN" }
                });
        }
    }
}
