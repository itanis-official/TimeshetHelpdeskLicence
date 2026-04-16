namespace HelpDeskAPI.Models
{
    public class CalendrierUtilisateur
    {
        public int CalendrierId { get; set; }
        public Calendrier Calendrier { get; set; } = null!;

        public int UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; } = null!;
    }
}