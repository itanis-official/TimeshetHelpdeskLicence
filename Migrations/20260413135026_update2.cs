using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpDeskAPI.Migrations
{
    /// <inheritdoc />
    public partial class update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
