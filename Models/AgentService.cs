using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpDeskAPI.Models
{
    [Table("AgentServices")] // nom exact de la table SQL
    public class AgentService
    {
        [Key]
        public int AgentServiceID { get; set; }

        [ForeignKey("Utilisateurs")]
        public int AgentID { get; set; }

        [ForeignKey("Services")]
        public int ServiceID { get; set; }

        // Navigation (optionnel mais recommandé)
        public Utilisateur Utilisateurs { get; set; } = null!;
        public Service Services { get; set; } = null!;
    }
}