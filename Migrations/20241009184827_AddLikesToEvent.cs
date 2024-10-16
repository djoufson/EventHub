using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Event.Migrations
{
    /// <inheritdoc />
    public partial class AddLikesToEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6fc984b2-2818-4b8d-84bb-fd7ae870d664");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc3e2036-60c5-41b0-8305-3acb6f3e0a13");

            migrationBuilder.AddColumn<int>(
                name: "LikesCount",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "292c5ae9-9f02-40c5-9aef-57482e0edc6f", null, "User", "USER" },
                    { "ce08980f-0b19-41a9-abd9-929092a51cd1", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "LikesCount",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "LikesCount",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "292c5ae9-9f02-40c5-9aef-57482e0edc6f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce08980f-0b19-41a9-abd9-929092a51cd1");

            migrationBuilder.DropColumn(
                name: "LikesCount",
                table: "Events");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6fc984b2-2818-4b8d-84bb-fd7ae870d664", null, "Admin", "ADMIN" },
                    { "dc3e2036-60c5-41b0-8305-3acb6f3e0a13", null, "User", "USER" }
                });
        }
    }
}
