using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Event.Migrations
{
    /// <inheritdoc />
    public partial class AddEventLikes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "292c5ae9-9f02-40c5-9aef-57482e0edc6f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce08980f-0b19-41a9-abd9-929092a51cd1");

            migrationBuilder.CreateTable(
                name: "EventLikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    LikedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventLikes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventLikes_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "dc452462-ec29-4456-8809-5fe2ad76f688", null, "User", "USER" },
                    { "f75d5a6f-51b8-4ee3-aad7-652aefdf8272", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventLikes_EventId",
                table: "EventLikes",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventLikes_UserId",
                table: "EventLikes",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventLikes");

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
                    { "292c5ae9-9f02-40c5-9aef-57482e0edc6f", null, "User", "USER" },
                    { "ce08980f-0b19-41a9-abd9-929092a51cd1", null, "Admin", "ADMIN" }
                });
        }
    }
}
