using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HelpDeskAPI.Models
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }

        [Required]
        public string Reference { get; set; } = "#" + Guid.NewGuid().ToString().Substring(0, 8);

        [Required]
        public string Titre { get; set; } = null!;

        public string Description { get; set; } = null!;

        [Required]
        public PrioriteTicket Priorite { get; set; } = PrioriteTicket.Moyenne;

        [Required]
        public StatutTicket Statut { get; set; } = StatutTicket.Nouveau;

        // 🕒 Dates importantes
        public DateTime DateCreation { get; set; } = DateTime.Now;
        public DateTime? DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public DateTime? DatePrevueFin { get; set; }

        // ⏱️ Temps total (optionnel si tu utilises TimeSheet)
        public double TempsTotalHeures { get; set; } = 0;

        // 🧾 Résolution
        public string? TravailEffectue { get; set; } // message envoyé au client

        // 🔗 Fusion de ticket
        public int? TicketFusionneAvecId { get; set; }
        public Ticket? TicketFusionneAvec { get; set; }

        // ----------------------
        // Relations
        // ----------------------

        // Service
        public int ServiceId { get; set; }
        public Service Service { get; set; } = null!;

        // MicroService
        public int MicroServiceId { get; set; }
        public MicroService MicroService { get; set; } = null!;

        // Créateur (Client / Agent / Admin)
        public int CreateurId { get; set; }
        public Utilisateur Createur { get; set; } = null!;

        // Assignations (agents qui travaillent sur le ticket)
        public ICollection<TicketAssignation> Assignes { get; set; } = new List<TicketAssignation>();

        // Pièces jointes
        public ICollection<PieceJointe> PiecesJointes { get; set; } = new List<PieceJointe>();

        // Messages (chat avec client)
        public ICollection<Message> Messages { get; set; } = new List<Message>();

        // Time tracking
        public ICollection<TimeSheet> TimeSheets { get; set; } = new List<TimeSheet>();

        // Commentaire (knowledge base)
        public Commentaire? Commentaire { get; set; }



    }
}