using System;
using System.ComponentModel.DataAnnotations;

namespace HelpDeskAPI.Models
{
    public class Utilisateur
    {
        [Key]  // ✅ clé primaire unique
        public int UserId { get; set; }

        public string Nom { get; set; } = null!;
        public string Prenom { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public DateTime DateCreation { get; set; } = DateTime.Now;

        // ⚠️ IMPORTANT : éviter conflit avec TPH
        public UserRole Role { get; set; }
    }
}