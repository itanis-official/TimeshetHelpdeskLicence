namespace HelpDeskAPI.DTOs
{
    public class CreateAgentDto
    {
        public string Nom { get; set; } = null!;
        public string Prenom { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int ServiceId { get; set; }
        public int MicroServiceId { get; set; }
    }
}