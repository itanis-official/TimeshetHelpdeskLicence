namespace HelpDeskAPI.Models
{
    public enum AgentStatut
    {
        Disponible,
        Conge,   // Pas d’accent pour éviter les problèmes avec EF Core
        Occupe
    }
}
