namespace HelpDeskAPI.Models
{
    public class Collaborateur : Utilisateur   // ✅ héritage
    {
        public string Statut { get; set; } = null!;
        public string PhotoProfil { get; set; } = null!;

        // Clé étrangère
        public int ClientId { get; set; }

        // Navigation
        public Client Client { get; set; } = null!;
    }
}