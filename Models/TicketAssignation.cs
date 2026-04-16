
using System.Collections.Generic;
namespace HelpDeskAPI.Models
{
    public class TicketAssignation
    {
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; } = null!;

        public int UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; } = null!;

        // ✅ AJOUT IMPORTANT
        public DateTime DateAssignation { get; set; } = DateTime.Now;
    }
}
