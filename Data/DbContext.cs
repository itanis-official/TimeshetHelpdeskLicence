using HelpDeskAPI.Models;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace HelpDeskAPI.Data
{
    public class HelpDeskContext : DbContext
    {
        public HelpDeskContext(DbContextOptions<HelpDeskContext> options)
            : base(options)
        {
        }

        public DbSet<Utilisateur> Utilisateurs { get; set; } = null!;
        public DbSet<Collaborateur> Collaborateurs { get; set; }

        public DbSet<Agent> Agents { get; set; } = null!;
        public DbSet<Admin> Admins { get; set; } = null!;
        public DbSet<Client> Clients { get; set; } = null!;
              

        // Tickets et autres
        public DbSet<Ticket> Tickets { get; set; } = null!;
        public DbSet<PieceJointe> PiecesJointes { get; set; } = null!;
        public DbSet<TicketAssignation> TicketAssignations { get; set; } = null!;
        public DbSet<Notification> Notifications { get; set; } = null!;
        public DbSet<Commentaire> Commentaires { get; set; } = null!;
        public DbSet<Message> Messages { get; set; } = null!;
        public DbSet<Calendrier> Calendriers { get; set; } = null!;
        public DbSet<CalendrierUtilisateur> CalendrierUtilisateurs { get; set; } = null!;
        public DbSet<TimeSheet> TimeSheets { get; set; } = null!;
        public DbSet<StatistiqueTicket> StatistiquesTickets { get; set; } = null!;
        public DbSet<Service> Services { get; set; }
        public DbSet<MicroService> MicroServices { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // -----------------------------
            // Héritage TPH : Utilisateur -> Admin / Agent / Collaborateur
            // -----------------------------
            modelBuilder.Entity<Utilisateur>()
                .HasDiscriminator<string>("UserType")
                .HasValue<Utilisateur>("Utilisateur")
                .HasValue<Admin>("Admin")
                .HasValue<Agent>("Agent")
                .HasValue<Collaborateur>("Collaborateur");

            // Conversion enum Role
            modelBuilder.Entity<Utilisateur>()
                .Property(u => u.Role)
                .HasConversion<string>();

            // -----------------------------
            // Relation Collaborateur -> Client
            // -----------------------------
            modelBuilder.Entity<Collaborateur>()
                .HasOne(c => c.Client)
                .WithMany(c => c.Collaborateurs)
                .HasForeignKey(c => c.ClientId)
                .OnDelete(DeleteBehavior.Cascade);
            // -----------------------------
            // Configurations Services / MicroServices / Agents
            // -----------------------------
            modelBuilder.Entity<Service>()
                .HasMany(s => s.MicroServices)
                .WithOne(ms => ms.Service)
                .HasForeignKey(ms => ms.ServiceId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Service>()
                .HasMany(s => s.Agents)
                .WithOne(a => a.Service)
                .HasForeignKey(a => a.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MicroService>()
                .HasMany(ms => ms.Agents)
                .WithOne(a => a.MicroService)
                .HasForeignKey(a => a.MicroServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            // -----------------------------
            // Configurations Tickets
            // -----------------------------

            // Ticket 1-n PiecesJointes
            modelBuilder.Entity<Ticket>()
                .HasMany(t => t.PiecesJointes)
                .WithOne(pj => pj.Ticket)
                .HasForeignKey(pj => pj.TicketId)
                .OnDelete(DeleteBehavior.Cascade);

            // Ticket N-M Utilisateurs assignés
            modelBuilder.Entity<TicketAssignation>()
                .HasKey(ta => new { ta.TicketId, ta.UtilisateurId });

            modelBuilder.Entity<TicketAssignation>()
                .HasOne(ta => ta.Ticket)
                .WithMany(t => t.Assignes)
                .HasForeignKey(ta => ta.TicketId);

            modelBuilder.Entity<TicketAssignation>()
                .HasOne(ta => ta.Utilisateur)
                .WithMany()
                .HasForeignKey(ta => ta.UtilisateurId);

            modelBuilder.Entity<Ticket>()
    .HasOne(t => t.TicketFusionneAvec)
    .WithMany()
    .HasForeignKey(t => t.TicketFusionneAvecId)
    .OnDelete(DeleteBehavior.NoAction);

            // Ticket 1 Service
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Service)
                .WithMany(s => s.Tickets)
                .HasForeignKey(t => t.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            // Ticket 1 MicroService
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.MicroService)
                .WithMany(ms => ms.Tickets)
                .HasForeignKey(t => t.MicroServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            // Ticket 1 Createur (Utilisateur)
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Createur)
                .WithMany()
                .HasForeignKey(t => t.CreateurId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Notification>()
                .HasOne(n => n.Utilisateur)
                .WithMany()
                .HasForeignKey(n => n.UtilisateurId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Notification>()
                .HasOne(n => n.Ticket)
                .WithMany()
                .HasForeignKey(n => n.TicketId)
                .OnDelete(DeleteBehavior.SetNull);
            // -----------------------------

            // Notification -> Utilisateur (N-1)
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.Utilisateur)
                .WithMany()
                .HasForeignKey(n => n.UtilisateurId)
                .OnDelete(DeleteBehavior.Cascade);

            // Notification -> Ticket (optionnel)
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.Ticket)
                .WithMany()
                .HasForeignKey(n => n.TicketId)
                .OnDelete(DeleteBehavior.SetNull);

            // Enum TypeNotification en string (optionnel mais recommandé)
            modelBuilder.Entity<Notification>()
                .Property(n => n.Type)
                .HasConversion<string>();
            // -----------------------------
            // Configurations Commentaires
            // -----------------------------

            // Commentaire -> Ticket (1-1)
            // -----------------------------
            modelBuilder.Entity<Commentaire>()
                .HasOne(c => c.Ticket)
                .WithOne(t => t.Commentaire)
                .HasForeignKey<Commentaire>(c => c.TicketId)
                .OnDelete(DeleteBehavior.Cascade);

            // Commentaire -> Utilisateur (N-1)
            modelBuilder.Entity<Commentaire>()
                .HasOne(c => c.Utilisateur)
                .WithMany()
                .HasForeignKey(c => c.UtilisateurId)
                .OnDelete(DeleteBehavior.Restrict);
            // -----------------------------
            // Configurations Messages
            // -----------------------------

            // Message -> Expediteur
            modelBuilder.Entity<Message>()
                .HasOne(m => m.Expediteur)
                .WithMany()
                .HasForeignKey(m => m.ExpediteurId)
                .OnDelete(DeleteBehavior.Restrict);

            // Message -> Destinataire
            modelBuilder.Entity<Message>()
                .HasOne(m => m.Destinataire)
                .WithMany()
                .HasForeignKey(m => m.DestinataireId)
                .OnDelete(DeleteBehavior.Restrict);

            // Message -> Ticket (optionnel)
            modelBuilder.Entity<Message>()
     .HasOne(m => m.Ticket)
     .WithMany(t => t.Messages)
     .HasForeignKey(m => m.TicketId)
     .OnDelete(DeleteBehavior.SetNull);
            // -----------------------------
            // Configurations Calendrier
            // -----------------------------

            // Calendrier -> Createur
            modelBuilder.Entity<Calendrier>()
                .HasOne(c => c.Createur)
                .WithMany()
                .HasForeignKey(c => c.CreateurId)
                .OnDelete(DeleteBehavior.Restrict);

            // Calendrier -> Ticket (optionnel)
            modelBuilder.Entity<Calendrier>()
                .HasOne(c => c.Ticket)
                .WithMany()
                .HasForeignKey(c => c.TicketId)
                .OnDelete(DeleteBehavior.SetNull);

            // Relation N-M Calendrier <-> Utilisateur (visibilité)
            modelBuilder.Entity<CalendrierUtilisateur>()
                .HasKey(cu => new { cu.CalendrierId, cu.UtilisateurId });

            modelBuilder.Entity<CalendrierUtilisateur>()
                .HasOne(cu => cu.Calendrier)
                .WithMany(c => c.Utilisateurs)
                .HasForeignKey(cu => cu.CalendrierId);

            modelBuilder.Entity<CalendrierUtilisateur>()
                .HasOne(cu => cu.Utilisateur)
                .WithMany()
                .HasForeignKey(cu => cu.UtilisateurId);
            // -----------------------------
            // Configurations TimeSheet
            // -----------------------------

            // TimeSheet -> Utilisateur
            modelBuilder.Entity<TimeSheet>()
                .HasOne(t => t.Utilisateur)
                .WithMany()
                .HasForeignKey(t => t.UtilisateurId)
                .OnDelete(DeleteBehavior.Restrict);

            // TimeSheet -> Ticket (optionnel)
            modelBuilder.Entity<TimeSheet>()
       .HasOne(t => t.Ticket)
       .WithMany(t => t.TimeSheets)
       .HasForeignKey(t => t.TicketId)
       .OnDelete(DeleteBehavior.SetNull);
            // -----------------------------
            // Configurations Statistiques
            // -----------------------------

            modelBuilder.Entity<StatistiqueTicket>()
                .HasOne(s => s.Ticket)
                .WithMany()
                .HasForeignKey(s => s.TicketId)
                .OnDelete(DeleteBehavior.Cascade);

            // Enum en string
            modelBuilder.Entity<StatistiqueTicket>()
                .Property(s => s.Statut)
                .HasConversion<string>();

   


            // -----------------------------
            // Seed Data
            // -----------------------------
            modelBuilder.Entity<Service>().HasData(
                new Service { ServiceId = 1, Nom = "Microsoft" },
                new Service { ServiceId = 2, Nom = "HelpDesk" },
                new Service { ServiceId = 3, Nom = "Développement" },
                new Service { ServiceId = 4, Nom = "Autre" }
            );

            modelBuilder.Entity<MicroService>().HasData(
                new MicroService { MicroServiceId = 1, Nom = "Power Apps", ServiceId = 1 },
                new MicroService { MicroServiceId = 2, Nom = "Power Automate", ServiceId = 1 },
                new MicroService { MicroServiceId = 3, Nom = "Power BI", ServiceId = 1 },
                new MicroService { MicroServiceId = 4, Nom = "Power Pages", ServiceId = 1 },
                new MicroService { MicroServiceId = 5, Nom = "Copilot", ServiceId = 1 },
                new MicroService { MicroServiceId = 6, Nom = "SharePoint", ServiceId = 1 },

                new MicroService { MicroServiceId = 7, Nom = "Réseaux et sécurité", ServiceId = 2 },
                new MicroService { MicroServiceId = 8, Nom = "Gestion serveur", ServiceId = 2 },
                new MicroService { MicroServiceId = 9, Nom = "Support et maintenance", ServiceId = 2 },
                new MicroService { MicroServiceId = 10, Nom = "Stockage et sauvegarde", ServiceId = 2 },
                new MicroService { MicroServiceId = 11, Nom = "Conseil et suivi", ServiceId = 2 },

                new MicroService { MicroServiceId = 12, Nom = "Développement web", ServiceId = 3 },
                new MicroService { MicroServiceId = 13, Nom = "Développement mobile", ServiceId = 3 },
                new MicroService { MicroServiceId = 14, Nom = "Design UI/UX", ServiceId = 3 },
                new MicroService { MicroServiceId = 15, Nom = "Conception graphique", ServiceId = 3 },

                new MicroService { MicroServiceId = 16, Nom = "Autre (espace libre)", ServiceId = 4 }
            );

            // ⚠️ Agents : utiliser UserId unique provenant de la table Utilisateurs
            // ✅ Nouveau seed (complet)
            modelBuilder.Entity<Agent>().HasData(
                new Agent
                {
                    UserId = 101,
                    Nom = "Dubois",
                    Prenom = "Jean",
                    Email = "jean.dubois@itanis.com",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Agent@123"), // ou un hash simple pour le seed
                    DateCreation = DateTime.Now,
                    Role = UserRole.Agent,
                    Statut = AgentStatut.Disponible,
                    ServiceId = 1,
                    MicroServiceId = 1
                },
                new Agent
                {
                    UserId = 102,
                    Nom = "Martin",
                    Prenom = "Sophie",
                    Email = "sophie.martin@itanis.com",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Agent@123"),
                    DateCreation = DateTime.Now,
                    Role = UserRole.Agent,
                    Statut = AgentStatut.Disponible,
                    ServiceId = 2,
                    MicroServiceId = 8
                }
            
            );
        }
    }
}