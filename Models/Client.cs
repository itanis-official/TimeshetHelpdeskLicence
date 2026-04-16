namespace HelpDeskAPI.Models
{
    public class Client
    {
        public int ClientId { get; set; }  // ✅ Clé primaire

        public string NomSociete { get; set; } = null!;
        public string Logo { get; set; } = null!;
        public string MatriculeFiscale { get; set; } = null!;
        public string Fax { get; set; } = null!;
        public string Telephone { get; set; } = null!;
        public string SiteWeb { get; set; } = null!;
        public string EmailContact { get; set; } = null!;
        public string Adresse { get; set; } = null!;

        // ✅ Relation : un client a plusieurs collaborateurs
        public ICollection<Collaborateur> Collaborateurs { get; set; } = new List<Collaborateur>();
    }
}