using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Event.Migrations
{
    /// <inheritdoc />
    public partial class AddListOfImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29393863-8491-4610-a306-70bc9aa9f26a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a085806-4e33-42e7-9dc6-34eddbde9d5a");

            migrationBuilder.AddColumn<string>(
                name: "SecondaryImageUrls",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6fc984b2-2818-4b8d-84bb-fd7ae870d664", null, "Admin", "ADMIN" },
                    { "dc3e2036-60c5-41b0-8305-3acb6f3e0a13", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "SecondaryImageUrls",
                value: "[]");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "SecondaryImageUrls",
                value: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6fc984b2-2818-4b8d-84bb-fd7ae870d664");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc3e2036-60c5-41b0-8305-3acb6f3e0a13");

            migrationBuilder.DropColumn(
                name: "SecondaryImageUrls",
                table: "Events");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "29393863-8491-4610-a306-70bc9aa9f26a", null, "Admin", "ADMIN" },
                    { "9a085806-4e33-42e7-9dc6-34eddbde9d5a", null, "User", "USER" }
                });
        }
    }
}
