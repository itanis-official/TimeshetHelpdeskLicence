using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HelpDeskAPI.Models
{
    public class Calendrier
    {
        [Key]
        public int CalendrierId { get; set; }
//test
        public string Titre { get; set; } = null!;
        public string Description { get; set; } = null!;

        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }

        public DateTime DateCreation { get; set; } = DateTime.Now;

        // Qui a créé l’événement (Admin ou Agent)
        public int CreateurId { get; set; }
        public Utilisateur Createur { get; set; } = null!;

        // Ticket lié (optionnel)
        public int? TicketId { get; set; }
        public Ticket? Ticket { get; set; }

        // Liste des utilisateurs qui peuvent voir cet événement
        public ICollection<CalendrierUtilisateur> Utilisateurs { get; set; } = new List<CalendrierUtilisateur>();
    }
}