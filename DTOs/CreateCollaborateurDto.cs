namespace HelpDeskAPI.DTOs
{
    public class CreateCollaborateurDto
    {
        public string Nom { get; set; } = null!;
        public string Prenom { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int ClientId { get; set; }
        public string Statut { get; set; } = null!;
        public string PhotoProfil { get; set; } = null!;
    }
}