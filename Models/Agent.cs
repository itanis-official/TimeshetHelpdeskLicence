using HelpDeskAPI.Models;

public class Agent : Utilisateur
{
    public AgentStatut Statut { get; set; } = AgentStatut.Disponible;

    public int ServiceId { get; set; }
    public Service Service { get; set; } = null!;

    public int MicroServiceId { get; set; }
    public MicroService MicroService { get; set; } = null!;
}