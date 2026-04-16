namespace HelpDeskAPI.DTOs
{
    public class CreateAdminDto
    {
        public string Nom { get; set; } = null!;
        public string Prenom { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
