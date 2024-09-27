using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Event.Migrations
{
    /// <inheritdoc />
    public partial class AddOrganizerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Organizer_OrganizerId",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organizer",
                table: "Organizer");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7348c0e-e96d-4810-8a86-8b5d8ac8672d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1796d9b-3742-4ed5-82c2-63dd5609a15e");

            migrationBuilder.RenameTable(
                name: "Organizer",
                newName: "Organizers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organizers",
                table: "Organizers",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8dade0bc-ef74-463f-a8a6-f2c2d0f79120", null, "User", "USER" },
                    { "97c5afdd-051e-4de3-bf1f-abd99320632d", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Organizers_OrganizerId",
                table: "Events",
                column: "OrganizerId",
                principalTable: "Organizers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Organizers_OrganizerId",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organizers",
                table: "Organizers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8dade0bc-ef74-463f-a8a6-f2c2d0f79120");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97c5afdd-051e-4de3-bf1f-abd99320632d");

            migrationBuilder.RenameTable(
                name: "Organizers",
                newName: "Organizer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organizer",
                table: "Organizer",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c7348c0e-e96d-4810-8a86-8b5d8ac8672d", null, "User", "USER" },
                    { "f1796d9b-3742-4ed5-82c2-63dd5609a15e", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Organizer_OrganizerId",
                table: "Events",
                column: "OrganizerId",
                principalTable: "Organizer",
                principalColumn: "Id");
        }
    }
}
