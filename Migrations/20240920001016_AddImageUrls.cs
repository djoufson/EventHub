using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Event.Migrations
{
    /// <inheritdoc />
    public partial class AddImageUrls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13bae9ea-3b02-49ff-bf40-90b1f2ba611e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f391c51-7a10-4e7c-a810-6109f4cc3789");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrls",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "afc00b66-4cb6-45aa-995a-81ee204dd157", null, "User", "USER" },
                    { "cc77747b-5367-48a7-9b12-ad62d74f4c39", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrls",
                value: "[]");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrls",
                value: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "afc00b66-4cb6-45aa-995a-81ee204dd157");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc77747b-5367-48a7-9b12-ad62d74f4c39");

            migrationBuilder.DropColumn(
                name: "ImageUrls",
                table: "Events");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "13bae9ea-3b02-49ff-bf40-90b1f2ba611e", null, "Admin", "ADMIN" },
                    { "6f391c51-7a10-4e7c-a810-6109f4cc3789", null, "User", "USER" }
                });
        }
    }
}
