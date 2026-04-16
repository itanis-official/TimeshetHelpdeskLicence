using System;
using System.ComponentModel.DataAnnotations;

namespace HelpDeskAPI.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        public string Contenu { get; set; } = null!;

        public DateTime DateEnvoi { get; set; } = DateTime.Now;

        public bool EstLu { get; set; } = false;

        // ----------------------
        // Relations
        // ----------------------

        // Expéditeur
        public int ExpediteurId { get; set; }
        public Utilisateur Expediteur { get; set; } = null!;

        // Destinataire
        public int DestinataireId { get; set; }
        public Utilisateur Destinataire { get; set; } = null!;

        // Ticket lié (optionnel mais recommandé)
        public int? TicketId { get; set; }
        public Ticket? Ticket { get; set; }
    }
}