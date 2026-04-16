using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpDeskAPI.Models
{
    public class PieceJointe
    {
        [Key]
        public int PieceJointeId { get; set; }

        public string NomFichier { get; set; } = null!;
        public string Chemin { get; set; } = null!;

        // Clé étrangère vers Ticket
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; } = null!;
    }
}