using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HelpDeskAPI.Models
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }

        public string Nom { get; set; } = null!;

        // Relation 1 Service -> plusieurs MicroServices
        public ICollection<MicroService> MicroServices { get; set; } = new List<MicroService>();

        // Relation 1 Service -> plusieurs Agents
        public ICollection<Agent> Agents { get; set; } = new List<Agent>();
        // Relation 1 MicroService -> plusieurs Tickets
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}