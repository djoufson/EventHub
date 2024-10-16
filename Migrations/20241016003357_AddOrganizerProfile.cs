using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Event.Migrations
{
    /// <inheritdoc />
    public partial class AddOrganizerProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e2a5e86-aac3-435c-b0b0-aa32ba72f981");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc7bca79-8f74-4571-b550-d19426b94d72");

            migrationBuilder.AddColumn<string>(
                name: "ProfileImageUrl",
                table: "Organizers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5ef4b288-777e-414c-9162-281c14968195", null, "User", "USER" },
                    { "7fe837b0-0fe4-45c4-85e9-28186fa9d3e6", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ef4b288-777e-414c-9162-281c14968195");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7fe837b0-0fe4-45c4-85e9-28186fa9d3e6");

            migrationBuilder.DropColumn(
                name: "ProfileImageUrl",
                table: "Organizers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1e2a5e86-aac3-435c-b0b0-aa32ba72f981", null, "User", "USER" },
                    { "dc7bca79-8f74-4571-b550-d19426b94d72", null, "Admin", "ADMIN" }
                });
        }
    }
}
