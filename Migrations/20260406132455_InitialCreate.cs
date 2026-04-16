using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HelpDeskAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomSociete = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatriculeFiscale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiteWeb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailContact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.ServiceId);
                });

            migrationBuilder.CreateTable(
                name: "MicroService",
                columns: table => new
                {
                    MicroServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MicroService", x => x.MicroServiceId);
                    table.ForeignKey(
                        name: "FK_MicroService_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Utilisateurs",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserType = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Agent_Statut = table.Column<int>(type: "int", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: true),
                    MicroServiceId = table.Column<int>(type: "int", nullable: true),
                    Statut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoProfil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateurs", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Utilisateurs_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Utilisateurs_MicroService_MicroServiceId",
                        column: x => x.MicroServiceId,
                        principalTable: "MicroService",
                        principalColumn: "MicroServiceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Utilisateurs_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priorite = table.Column<int>(type: "int", nullable: false),
                    Statut = table.Column<int>(type: "int", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateDebut = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateFin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DatePrevueFin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    MicroServiceId = table.Column<int>(type: "int", nullable: false),
                    CreateurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_MicroService_MicroServiceId",
                        column: x => x.MicroServiceId,
                        principalTable: "MicroService",
                        principalColumn: "MicroServiceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Utilisateurs_CreateurId",
                        column: x => x.CreateurId,
                        principalTable: "Utilisateurs",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Calendriers",
                columns: table => new
                {
                    CalendrierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateurId = table.Column<int>(type: "int", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendriers", x => x.CalendrierId);
                    table.ForeignKey(
                        name: "FK_Calendriers_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "TicketId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Calendriers_Utilisateurs_CreateurId",
                        column: x => x.CreateurId,
                        principalTable: "Utilisateurs",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Commentaires",
                columns: table => new
                {
                    CommentaireId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contenu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    UtilisateurId = table.Column<int>(type: "int", nullable: false),
                    PublieKnowledgeBase = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commentaires", x => x.CommentaireId);
                    table.ForeignKey(
                        name: "FK_Commentaires_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "TicketId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commentaires_Utilisateurs_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "Utilisateurs",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contenu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateEnvoi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstLu = table.Column<bool>(type: "bit", nullable: false),
                    ExpediteurId = table.Column<int>(type: "int", nullable: false),
                    DestinataireId = table.Column<int>(type: "int", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Messages_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "TicketId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Messages_Utilisateurs_DestinataireId",
                        column: x => x.DestinataireId,
                        principalTable: "Utilisateurs",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_Utilisateurs_ExpediteurId",
                        column: x => x.ExpediteurId,
                        principalTable: "Utilisateurs",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    NotificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateEnvoi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstLue = table.Column<bool>(type: "bit", nullable: false),
                    UtilisateurId = table.Column<int>(type: "int", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.NotificationId);
                    table.ForeignKey(
                        name: "FK_Notifications_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "TicketId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Notifications_Utilisateurs_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "Utilisateurs",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PiecesJointes",
                columns: table => new
                {
                    PieceJointeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomFichier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Chemin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PiecesJointes", x => x.PieceJointeId);
                    table.ForeignKey(
                        name: "FK_PiecesJointes_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "TicketId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StatistiquesTickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomAgent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Service = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duree = table.Column<double>(type: "float", nullable: false),
                    Statut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatistiquesTickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatistiquesTickets_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "TicketId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketAssignations",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    UtilisateurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketAssignations", x => new { x.TicketId, x.UtilisateurId });
                    table.ForeignKey(
                        name: "FK_TicketAssignations_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "TicketId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketAssignations_Utilisateurs_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "Utilisateurs",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeSheets",
                columns: table => new
                {
                    TimeSheetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TempsPasse = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HeureDebut = table.Column<TimeSpan>(type: "time", nullable: false),
                    HeureFin = table.Column<TimeSpan>(type: "time", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UtilisateurId = table.Column<int>(type: "int", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSheets", x => x.TimeSheetId);
                    table.ForeignKey(
                        name: "FK_TimeSheets_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "TicketId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_TimeSheets_Utilisateurs_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "Utilisateurs",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CalendrierUtilisateurs",
                columns: table => new
                {
                    CalendrierId = table.Column<int>(type: "int", nullable: false),
                    UtilisateurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendrierUtilisateurs", x => new { x.CalendrierId, x.UtilisateurId });
                    table.ForeignKey(
                        name: "FK_CalendrierUtilisateurs_Calendriers_CalendrierId",
                        column: x => x.CalendrierId,
                        principalTable: "Calendriers",
                        principalColumn: "CalendrierId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CalendrierUtilisateurs_Utilisateurs_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "Utilisateurs",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Service",
                columns: new[] { "ServiceId", "Nom" },
                values: new object[,]
                {
                    { 1, "Microsoft" },
                    { 2, "HelpDesk" },
                    { 3, "Développement" },
                    { 4, "Autre" }
                });

            migrationBuilder.InsertData(
                table: "MicroService",
                columns: new[] { "MicroServiceId", "Nom", "ServiceId" },
                values: new object[,]
                {
                    { 1, "Power Apps", 1 },
                    { 2, "Power Automate", 1 },
                    { 3, "Power BI", 1 },
                    { 4, "Power Pages", 1 },
                    { 5, "Copilot", 1 },
                    { 6, "SharePoint", 1 },
                    { 7, "Réseaux et sécurité", 2 },
                    { 8, "Gestion serveur", 2 },
                    { 9, "Support et maintenance", 2 },
                    { 10, "Stockage et sauvegarde", 2 },
                    { 11, "Conseil et suivi", 2 },
                    { 12, "Développement web", 3 },
                    { 13, "Développement mobile", 3 },
                    { 14, "Design UI/UX", 3 },
                    { 15, "Conception graphique", 3 },
                    { 16, "Autre (espace libre)", 4 }
                });

            migrationBuilder.InsertData(
                table: "Utilisateurs",
                columns: new[] { "UserId", "DateCreation", "Email", "MicroServiceId", "Nom", "PasswordHash", "Prenom", "Role", "ServiceId", "Agent_Statut", "UserType" },
                values: new object[,]
                {
                    { 101, new DateTime(2026, 4, 6, 14, 24, 54, 699, DateTimeKind.Local).AddTicks(2490), "jean.dubois@itanis.com", 1, "Dubois", "$2a$11$McJoOBk35Q9cRRj5HrzGRuSsU0LJXKJuG6si6ZeVQDwxd1DnrYfZC", "Jean", "Agent", 1, 0, "Agent" },
                    { 102, new DateTime(2026, 4, 6, 14, 24, 54, 812, DateTimeKind.Local).AddTicks(6747), "sophie.martin@itanis.com", 8, "Martin", "$2a$11$gF7qaB83fsGF1eIl2yfv/uCauX2QhfzeIOCZu31wDf5i6vYS2Ag0K", "Sophie", "Agent", 2, 0, "Agent" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calendriers_CreateurId",
                table: "Calendriers",
                column: "CreateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendriers_TicketId",
                table: "Calendriers",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendrierUtilisateurs_UtilisateurId",
                table: "CalendrierUtilisateurs",
                column: "UtilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Commentaires_TicketId",
                table: "Commentaires",
                column: "TicketId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Commentaires_UtilisateurId",
                table: "Commentaires",
                column: "UtilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_DestinataireId",
                table: "Messages",
                column: "DestinataireId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ExpediteurId",
                table: "Messages",
                column: "ExpediteurId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_TicketId",
                table: "Messages",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_MicroService_ServiceId",
                table: "MicroService",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_TicketId",
                table: "Notifications",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UtilisateurId",
                table: "Notifications",
                column: "UtilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_PiecesJointes_TicketId",
                table: "PiecesJointes",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_StatistiquesTickets_TicketId",
                table: "StatistiquesTickets",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketAssignations_UtilisateurId",
                table: "TicketAssignations",
                column: "UtilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CreateurId",
                table: "Tickets",
                column: "CreateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_MicroServiceId",
                table: "Tickets",
                column: "MicroServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ServiceId",
                table: "Tickets",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSheets_TicketId",
                table: "TimeSheets",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSheets_UtilisateurId",
                table: "TimeSheets",
                column: "UtilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_ClientId",
                table: "Utilisateurs",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_MicroServiceId",
                table: "Utilisateurs",
                column: "MicroServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_ServiceId",
                table: "Utilisateurs",
                column: "ServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalendrierUtilisateurs");

            migrationBuilder.DropTable(
                name: "Commentaires");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "PiecesJointes");

            migrationBuilder.DropTable(
                name: "StatistiquesTickets");

            migrationBuilder.DropTable(
                name: "TicketAssignations");

            migrationBuilder.DropTable(
                name: "TimeSheets");

            migrationBuilder.DropTable(
                name: "Calendriers");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Utilisateurs");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "MicroService");

            migrationBuilder.DropTable(
                name: "Service");
        }
    }
}
