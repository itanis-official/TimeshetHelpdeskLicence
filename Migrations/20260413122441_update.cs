using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpDeskAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTimeSheets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeureDebut",
                table: "TimeSheets");

            migrationBuilder.DropColumn(
                name: "HeureFin",
                table: "TimeSheets");

            migrationBuilder.DropColumn(
                name: "TempsPasse",
                table: "TimeSheets");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "TimeSheets",
                newName: "StartTime");

            migrationBuilder.AlterColumn<string>(
                name: "Titre",
                table: "TimeSheets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "TicketId",
                table: "TimeSheets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TimeSheets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "TimeSheets",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TicketId1",
                table: "TimeSheets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TempsTotalHeures",
                table: "Tickets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "TicketFusionneAvecId",
                table: "Tickets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TravailEffectue",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAssignation",
                table: "TicketAssignations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateFin",
                table: "StatistiquesTickets",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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
                name: "IX_Tickets_TicketFusionneAvecId",
                table: "Tickets",
                column: "TicketFusionneAvecId");

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
                name: "FK_Tickets_Tickets_TicketFusionneAvecId",
                table: "Tickets",
                column: "TicketFusionneAvecId",
                principalTable: "Tickets",
                principalColumn: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSheets_Tickets_TicketId1",
                table: "TimeSheets",
                column: "TicketId1",
                principalTable: "Tickets",
                principalColumn: "TicketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Tickets_TicketId1",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Tickets_TicketFusionneAvecId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeSheets_Tickets_TicketId1",
                table: "TimeSheets");

            migrationBuilder.DropIndex(
                name: "IX_TimeSheets_TicketId1",
                table: "TimeSheets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_TicketFusionneAvecId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Messages_TicketId1",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "TimeSheets");

            migrationBuilder.DropColumn(
                name: "TicketId1",
                table: "TimeSheets");

            migrationBuilder.DropColumn(
                name: "TempsTotalHeures",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TicketFusionneAvecId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TravailEffectue",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "DateAssignation",
                table: "TicketAssignations");

            migrationBuilder.DropColumn(
                name: "TicketId1",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "TimeSheets",
                newName: "Date");

            migrationBuilder.AlterColumn<string>(
                name: "Titre",
                table: "TimeSheets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TicketId",
                table: "TimeSheets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TimeSheets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HeureDebut",
                table: "TimeSheets",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HeureFin",
                table: "TimeSheets",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<double>(
                name: "TempsPasse",
                table: "TimeSheets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateFin",
                table: "StatistiquesTickets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Utilisateurs",
                keyColumn: "UserId",
                keyValue: 101,
                columns: new[] { "DateCreation", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 6, 14, 24, 54, 699, DateTimeKind.Local).AddTicks(2490), "$2a$11$McJoOBk35Q9cRRj5HrzGRuSsU0LJXKJuG6si6ZeVQDwxd1DnrYfZC" });

            migrationBuilder.UpdateData(
                table: "Utilisateurs",
                keyColumn: "UserId",
                keyValue: 102,
                columns: new[] { "DateCreation", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 6, 14, 24, 54, 812, DateTimeKind.Local).AddTicks(6747), "$2a$11$gF7qaB83fsGF1eIl2yfv/uCauX2QhfzeIOCZu31wDf5i6vYS2Ag0K" });
        }
    }
}
