using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpDeskAPI.Migrations
{
    /// <inheritdoc />
    public partial class update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Tickets_TicketId1",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeSheets_Tickets_TicketId1",
                table: "TimeSheets");

            migrationBuilder.DropIndex(
                name: "IX_TimeSheets_TicketId1",
                table: "TimeSheets");

            migrationBuilder.DropIndex(
                name: "IX_Messages_TicketId1",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "TicketId1",
                table: "TimeSheets");

            migrationBuilder.DropColumn(
                name: "TicketId1",
                table: "Messages");

            migrationBuilder.UpdateData(
                table: "Utilisateurs",
                keyColumn: "UserId",
                keyValue: 101,
                columns: new[] { "DateCreation", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 13, 13, 33, 27, 363, DateTimeKind.Local).AddTicks(7966), "$2a$11$8OkIKYk.SdNgLAzreue62O2rZxiIC/LFEs.ulftBKyvn83BH3yGsG" });

            migrationBuilder.UpdateData(
                table: "Utilisateurs",
                keyColumn: "UserId",
                keyValue: 102,
                columns: new[] { "DateCreation", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 13, 13, 33, 27, 478, DateTimeKind.Local).AddTicks(8022), "$2a$11$mkgeCCq/c9R4V2zeFOaNhu2VzcPisaWtZw5L6desnYjQuVT4jdHba" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TicketId1",
                table: "TimeSheets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TicketId1",
                table: "Messages",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Utilisateurs",
                keyColumn: "UserId",
                keyValue: 101,
                columns: new[] { "DateCreation", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 13, 13, 24, 40, 947, DateTimeKind.Local).AddTicks(5641), "$2a$11$6MefuMz1tFfJ8w7jXMTAfu3pVkiLF/Yca49AWwwjWO33Gpiqq5qeG" });

            migrationBuilder.UpdateData(
                table: "Utilisateurs",
                keyColumn: "UserId",
                keyValue: 102,
                columns: new[] { "DateCreation", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 13, 13, 24, 41, 60, DateTimeKind.Local).AddTicks(9683), "$2a$11$63mLeYlYw1bWornSSfhQWO4NYODhbZSryUBntoJPA8F4UUXLOJwii" });

            migrationBuilder.CreateIndex(
                name: "IX_TimeSheets_TicketId1",
                table: "TimeSheets",
                column: "TicketId1");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_TicketId1",
                table: "Messages",
                column: "TicketId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Tickets_TicketId1",
                table: "Messages",
                column: "TicketId1",
                principalTable: "Tickets",
                principalColumn: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSheets_Tickets_TicketId1",
                table: "TimeSheets",
                column: "TicketId1",
                principalTable: "Tickets",
                principalColumn: "TicketId");
        }
    }
}
