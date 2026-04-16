using System;
using System.ComponentModel.DataAnnotations;

namespace HelpDeskAPI.Models
{
    public class Commentaire
    {
        [Key]
        public int CommentaireId { get; set; }

        public string Contenu { get; set; } = null!;

        public DateTime DateCreation { get; set; } = DateTime.Now;

        // ----------------------
        // Relations
        // ----------------------

        // Ticket lié
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; } = null!;

        // Auteur (Agent ou Admin)
        public int UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; } = null!;

        // Publication dans Knowledge Base
        public bool PublieKnowledgeBase { get; set; } = false;
    }
}