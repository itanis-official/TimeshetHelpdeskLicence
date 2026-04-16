using System;
using System.ComponentModel.DataAnnotations;

namespace HelpDeskAPI.Models
{
    public class StatistiqueTicket
    {
        [Key]
        public int Id { get; set; }

        public string Reference { get; set; } = null!;
        public string Titre { get; set; } = null!;

        public string NomAgent { get; set; } = null!;

        public DateTime? DateFin { get; set; }

        public string Service { get; set; } = null!;

        // Durée en heures
        public double Duree { get; set; }

        // Statut : retard ou à temps
        public StatutPerformance Statut { get; set; }

        // Lien avec Ticket
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; } = null!;
    }
}