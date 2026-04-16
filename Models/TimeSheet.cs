using System;
using System.ComponentModel.DataAnnotations;

namespace HelpDeskAPI.Models
{
    public class TimeSheet
    {
        [Key]
        public int TimeSheetId { get; set; }

        // 🔹 Informations (optionnelles mais utiles)
        public string? Titre { get; set; }
        public string? Description { get; set; }

        // 🔥 Chrono réel (IMPORTANT pour TicketService)
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        // 🔹 Calcul automatique du temps
        public double TempsPasse
        {
            get
            {
                if (EndTime == null) return 0;
                return (EndTime.Value - StartTime).TotalHours;
            }
        }

        // 🔹 Date de création
        public DateTime DateCreation { get; set; } = DateTime.Now;

        // ----------------------
        // Relations
        // ----------------------

        // Utilisateur (Agent/Admin)
        public int UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; } = null!;

        // Ticket lié (OBLIGATOIRE pour ton scénario)
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; } = null!;
    }
}