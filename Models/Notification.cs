using System;
using System.ComponentModel.DataAnnotations;

namespace HelpDeskAPI.Models
{
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }

        public string Message { get; set; } = null!;

        public DateTime DateEnvoi { get; set; } = DateTime.Now;

        public bool EstLue { get; set; } = false;

        // ----------------------
        // Relations
        // ----------------------

        // Destinataire (qui reçoit la notification)
        public int UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; } = null!;

        // Optionnel : lié à un ticket
        public int? TicketId { get; set; }
        public Ticket? Ticket { get; set; }

        // Type de notification (optionnel mais utile)
        public TypeNotification Type { get; set; }
    }
}