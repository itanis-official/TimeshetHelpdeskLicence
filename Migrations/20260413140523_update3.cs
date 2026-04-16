using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpDeskAPI.Migrations
{
    /// <inheritdoc />
    public partial class update3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Utilisateurs",
                keyColumn: "UserId",
                keyValue: 101,
                columns: new[] { "DateCreation", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 13, 15, 5, 23, 274, DateTimeKind.Local).AddTicks(5955), "$2a$11$zZtEPEt5p9E9UyXLJmRzVeNzajOD.ZdIWyK11Gwe/drZVAvmV0X2e" });

            migrationBuilder.UpdateData(
                table: "Utilisateurs",
                keyColumn: "UserId",
                keyValue: 102,
                columns: new[] { "DateCreation", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 13, 15, 5, 23, 389, DateTimeKind.Local).AddTicks(7771), "$2a$11$KgTTAR1KBb.KSf6Tt6j4OOcpELye5Lix92IB7/wbi/9r2sHFqC60C" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Utilisateurs",
                keyColumn: "UserId",
                keyValue: 101,
                columns: new[] { "DateCreation", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 13, 14, 50, 25, 916, DateTimeKind.Local).AddTicks(3438), "$2a$11$dnj0w2AbbIYFTNYVt/b/qucLPZnvIGt8euFrWFtkOLSDkz9k/XNXK" });

            migrationBuilder.UpdateData(
                table: "Utilisateurs",
                keyColumn: "UserId",
                keyValue: 102,
                columns: new[] { "DateCreation", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 13, 14, 50, 26, 31, DateTimeKind.Local).AddTicks(6342), "$2a$11$zdqGEV0OxyyDsfLP.WpAN./dfg7jwGGKUXFXWr/edAYB0NUqpgsHm" });
        }
    }
}
