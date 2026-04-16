using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpDeskAPI.Models
{
    public class MicroService
    {
        [Key]
        public int MicroServiceId { get; set; }

        public string Nom { get; set; } = null!;

        // Clé étrangère vers Service
        public int ServiceId { get; set; }
        public Service Service { get; set; } = null!;

        // Relation 1 MicroService -> plusieurs Agents
        public ICollection<Agent> Agents { get; set; } = new List<Agent>();
        // Relation 1 MicroService -> plusieurs Tickets
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}