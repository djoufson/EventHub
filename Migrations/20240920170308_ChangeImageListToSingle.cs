using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Event.Migrations
{
    /// <inheritdoc />
    public partial class ChangeImageListToSingle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "afc00b66-4cb6-45aa-995a-81ee204dd157");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc77747b-5367-48a7-9b12-ad62d74f4c39");

            migrationBuilder.RenameColumn(
                name: "ImageUrls",
                table: "Events",
                newName: "ImageUrl");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "29393863-8491-4610-a306-70bc9aa9f26a", null, "Admin", "ADMIN" },
                    { "9a085806-4e33-42e7-9dc6-34eddbde9d5a", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29393863-8491-4610-a306-70bc9aa9f26a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a085806-4e33-42e7-9dc6-34eddbde9d5a");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Events",
                newName: "ImageUrls");

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
    }
}
