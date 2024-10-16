using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Event.Migrations
{
    /// <inheritdoc />
    public partial class IdForEventLike : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc452462-ec29-4456-8809-5fe2ad76f688");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f75d5a6f-51b8-4ee3-aad7-652aefdf8272");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1e2a5e86-aac3-435c-b0b0-aa32ba72f981", null, "User", "USER" },
                    { "dc7bca79-8f74-4571-b550-d19426b94d72", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e2a5e86-aac3-435c-b0b0-aa32ba72f981");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc7bca79-8f74-4571-b550-d19426b94d72");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "dc452462-ec29-4456-8809-5fe2ad76f688", null, "User", "USER" },
                    { "f75d5a6f-51b8-4ee3-aad7-652aefdf8272", null, "Admin", "ADMIN" }
                });
        }
    }
}
