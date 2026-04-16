using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpDeskAPI.Migrations
{
    /// <inheritdoc />
    public partial class update4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MicroService_Service_ServiceId",
                table: "MicroService");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_MicroService_MicroServiceId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Service_ServiceId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Utilisateurs_MicroService_MicroServiceId",
                table: "Utilisateurs");

            migrationBuilder.DropForeignKey(
                name: "FK_Utilisateurs_Service_ServiceId",
                table: "Utilisateurs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Service",
                table: "Service");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MicroService",
                table: "MicroService");

            migrationBuilder.RenameTable(
                name: "Service",
                newName: "Services");

            migrationBuilder.RenameTable(
                name: "MicroService",
                newName: "MicroServices");

            migrationBuilder.RenameIndex(
                name: "IX_MicroService_ServiceId",
                table: "MicroServices",
                newName: "IX_MicroServices_ServiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Services",
                table: "Services",
                column: "ServiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MicroServices",
                table: "MicroServices",
                column: "MicroServiceId");

            migrationBuilder.UpdateData(
                table: "Utilisateurs",
                keyColumn: "UserId",
                keyValue: 101,
                columns: new[] { "DateCreation", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 14, 11, 27, 28, 698, DateTimeKind.Local).AddTicks(5269), "$2a$11$0GkDCB2zVR2m9PrpLtWLB.20NkOYe09ArWHzMItro6I6JIZa9gomy" });

            migrationBuilder.UpdateData(
                table: "Utilisateurs",
                keyColumn: "UserId",
                keyValue: 102,
                columns: new[] { "DateCreation", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 14, 11, 27, 28, 818, DateTimeKind.Local).AddTicks(7993), "$2a$11$5R7OJfFYHm7vkC5FtHR1wOMTz6moLwl9k3HDeUal3.D86k3A0c4g6" });

            migrationBuilder.AddForeignKey(
                name: "FK_MicroServices_Services_ServiceId",
                table: "MicroServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_MicroServices_MicroServiceId",
                table: "Tickets",
                column: "MicroServiceId",
                principalTable: "MicroServices",
                principalColumn: "MicroServiceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Services_ServiceId",
                table: "Tickets",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Utilisateurs_MicroServices_MicroServiceId",
                table: "Utilisateurs",
                column: "MicroServiceId",
                principalTable: "MicroServices",
                principalColumn: "MicroServiceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Utilisateurs_Services_ServiceId",
                table: "Utilisateurs",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MicroServices_Services_ServiceId",
                table: "MicroServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_MicroServices_MicroServiceId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Services_ServiceId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Utilisateurs_MicroServices_MicroServiceId",
                table: "Utilisateurs");

            migrationBuilder.DropForeignKey(
                name: "FK_Utilisateurs_Services_ServiceId",
                table: "Utilisateurs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Services",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MicroServices",
                table: "MicroServices");

            migrationBuilder.RenameTable(
                name: "Services",
                newName: "Service");

            migrationBuilder.RenameTable(
                name: "MicroServices",
                newName: "MicroService");

            migrationBuilder.RenameIndex(
                name: "IX_MicroServices_ServiceId",
                table: "MicroService",
                newName: "IX_MicroService_ServiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Service",
                table: "Service",
                column: "ServiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MicroService",
                table: "MicroService",
                column: "MicroServiceId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_MicroService_Service_ServiceId",
                table: "MicroService",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_MicroService_MicroServiceId",
                table: "Tickets",
                column: "MicroServiceId",
                principalTable: "MicroService",
                principalColumn: "MicroServiceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Service_ServiceId",
                table: "Tickets",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Utilisateurs_MicroService_MicroServiceId",
                table: "Utilisateurs",
                column: "MicroServiceId",
                principalTable: "MicroService",
                principalColumn: "MicroServiceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Utilisateurs_Service_ServiceId",
                table: "Utilisateurs",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
