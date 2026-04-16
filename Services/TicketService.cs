using HelpDeskAPI.Data;
using HelpDeskAPI.Models;
using Microsoft.EntityFrameworkCore;
using static HelpDeskAPI.Controllers.TicketController;

namespace HelpDeskAPI.Services
{
    public class TicketService
    {
        private readonly HelpDeskContext _context;

        public TicketService(HelpDeskContext context)
        {
            _context = context;
        }

        // ===============================
        // 🔹 1. ACCEPTER TICKET
        // ===============================
        public async Task<Ticket?> AccepterTicketAsync(int ticketId, int agentId)
        {
            var ticket = await _context.Tickets
                .Include(t => t.Assignes)
                .FirstOrDefaultAsync(t => t.TicketId == ticketId);

            if (ticket == null) return null;

            ticket.Statut = StatutTicket.Assigne;
            ticket.DateDebut ??= DateTime.Now;

            var exists = await _context.TicketAssignations
                .AnyAsync(x => x.TicketId == ticketId && x.UtilisateurId == agentId);

            if (!exists)
            {
                _context.TicketAssignations.Add(new TicketAssignation
                {
                    TicketId = ticketId,
                    UtilisateurId = agentId,
                    DateAssignation = DateTime.Now
                });
            }

            await _context.SaveChangesAsync();
            return ticket;
        }

        // ===============================
        // 🔹 2. REFUSER
        // ===============================
        public async Task<bool> RefuserTicketAsync(int ticketId)
        {
            var ticket = await _context.Tickets.FindAsync(ticketId);
            if (ticket == null) return false;

            ticket.Statut = StatutTicket.Nouveau;

            await _context.SaveChangesAsync();
            return true;
        }

        // ===============================
        // 🔹 3. START
        // ===============================
        public async Task<Ticket?> StartTicketAsync(int ticketId, int agentId)
        {
            var ticket = await _context.Tickets.FindAsync(ticketId);
            if (ticket == null) return null;

            // ✅ check user exists
            var userExists = await _context.Utilisateurs
                .AnyAsync(u => u.UserId == agentId);

            if (!userExists) return null;

            ticket.Statut = StatutTicket.EnCours;
            ticket.DateDebut ??= DateTime.Now;

            _context.TimeSheets.Add(new TimeSheet
            {
                TicketId = ticketId,
                UtilisateurId = agentId,
                StartTime = DateTime.Now
            });

            await _context.SaveChangesAsync();
            return ticket;
        }

        // ===============================
        // 🔹 4. PAUSE
        // ===============================
        public async Task<bool> PauseTicketAsync(int ticketId)
        {
            var active = await _context.TimeSheets
                .Where(t => t.TicketId == ticketId && t.EndTime == null)
                .OrderByDescending(t => t.StartTime)
                .FirstOrDefaultAsync();

            if (active == null) return false;

            active.EndTime = DateTime.Now;

            var ticket = await _context.Tickets.FindAsync(ticketId);
            if (ticket != null)
                ticket.Statut = StatutTicket.EnPause;

            await _context.SaveChangesAsync();
            return true;
        }

        // ===============================
        // 🔹 5. RESUME
        // ===============================
        public async Task<Ticket?> ResumeTicketAsync(int ticketId, int agentId)
        {
            var ticket = await _context.Tickets.FindAsync(ticketId);
            if (ticket == null) return null;

            var userExists = await _context.Utilisateurs
                .AnyAsync(u => u.UserId == agentId);

            if (!userExists) return null;

            ticket.Statut = StatutTicket.EnCours;

            _context.TimeSheets.Add(new TimeSheet
            {
                TicketId = ticketId,
                UtilisateurId = agentId, // 🔥 مهم
                StartTime = DateTime.Now
            });

            await _context.SaveChangesAsync();
            return ticket;
        }

        // ===============================
        // 🔹 6. STOP
        // ===============================
        public async Task<Ticket?> StopTicketAsync(int ticketId)
        {
            var ticket = await _context.Tickets
                .Include(t => t.TimeSheets)
                .FirstOrDefaultAsync(t => t.TicketId == ticketId);

            if (ticket == null) return null;

            var active = ticket.TimeSheets
                .FirstOrDefault(t => t.EndTime == null);

            if (active != null)
                active.EndTime = DateTime.Now;

            ticket.Statut = StatutTicket.Resolu;
            ticket.DateFin = DateTime.Now;

            ticket.TempsTotalHeures = ticket.TimeSheets
                .Where(t => t.EndTime != null)
                .Sum(t => (t.EndTime!.Value - t.StartTime).TotalHours);

            await _context.SaveChangesAsync();
            return ticket;
        }

        // ===============================
        // 🔹 7. FERMER
        // ===============================
        public async Task<Ticket?> FermerTicketAsync(int ticketId, string travailEffectue)
        {
            var ticket = await _context.Tickets
                .Include(t => t.Service)
                .Include(t => t.Assignes)
                    .ThenInclude(a => a.Utilisateur)
                .FirstOrDefaultAsync(t => t.TicketId == ticketId);

            if (ticket == null) return null;

            ticket.Statut = StatutTicket.Ferme;
            ticket.TravailEffectue = travailEffectue;
            ticket.DateFin = DateTime.Now;

            var agent = ticket.Assignes.FirstOrDefault()?.Utilisateur;

            _context.StatistiquesTickets.Add(new StatistiqueTicket
            {
                Reference = ticket.Reference,
                Titre = ticket.Titre,
                NomAgent = agent?.Nom ?? "Inconnu",
                DateFin = ticket.DateFin ?? DateTime.Now,
                Service = ticket.Service?.Nom ?? "N/A",
                Duree = ticket.TempsTotalHeures,
                TicketId = ticket.TicketId,
                Statut = (ticket.DateFin ?? DateTime.Now) <=
                         (ticket.DatePrevueFin ?? DateTime.MaxValue)
                    ? StatutPerformance.ATemps
                    : StatutPerformance.Retard
            });

            await _context.SaveChangesAsync();
            return ticket;
        }

        // ===============================
        // 🔹 8. COMMENTAIRE
        // ===============================
        public async Task<Commentaire?> AjouterCommentaireAsync(int ticketId, int userId, string contenu)
        {
            var ticket = await _context.Tickets.FindAsync(ticketId);
            if (ticket == null)
                return null;

            var user = await _context.Utilisateurs.FindAsync(userId);
            if (user == null)
                return null;

            var commentaire = new Commentaire
            {
                TicketId = ticketId,
                UtilisateurId = userId,
                Contenu = contenu,
                DateCreation = DateTime.Now
            };

            _context.Commentaires.Add(commentaire);
            await _context.SaveChangesAsync();

            return commentaire;
        }

        // ===============================
        // 🔹 9. TRANSFERER
        // ===============================
        public async Task<bool> TransfererTicketAsync(int ticketId, int newAgentId)
        {
            var exists = await _context.TicketAssignations
                .AnyAsync(x => x.TicketId == ticketId && x.UtilisateurId == newAgentId);

            if (!exists)
            {
                _context.TicketAssignations.Add(new TicketAssignation
                {
                    TicketId = ticketId,
                    UtilisateurId = newAgentId,
                    DateAssignation = DateTime.Now
                });
            }

            await _context.SaveChangesAsync();
            return true;
        }

        // ===============================
        // 🔹 10. FUSIONNER
        // ===============================
        public async Task<bool> FusionnerTicketAsync(int ticketId, int autreTicketId)
        {
            var ticket = await _context.Tickets.FindAsync(ticketId);
            if (ticket == null) return false;

            ticket.TicketFusionneAvecId = autreTicketId;

            await _context.SaveChangesAsync();
            return true;
        }

        // ===============================
        // 🔹 GET FULL TICKET
        // ===============================
        public async Task<Ticket?> GetTicketCompletAsync(int ticketId)
        {
            return await _context.Tickets
                .Include(t => t.Service)
                .Include(t => t.MicroService)
                .Include(t => t.Createur)
                .Include(t => t.Assignes)
                    .ThenInclude(a => a.Utilisateur)
                .FirstOrDefaultAsync(t => t.TicketId == ticketId);
        }

        // ===============================
        // 🔹 CREATE TICKET (IMPORTANT)
        // ===============================
        public async Task<Ticket> CreateTicketAsync(CreateTicketDto dto)
        {
            var ticket = new Ticket
            {
                Reference = dto.Reference,
                Titre = dto.Titre,
                Description = dto.Description,
                Priorite = Enum.Parse<PrioriteTicket>(dto.Priorite),

                Statut = StatutTicket.Nouveau,
                DateCreation = DateTime.Now,

                ServiceId = dto.ServiceId,
                MicroServiceId = dto.MicroServiceId,
                CreateurId = dto.CreateurId
            };

            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();

            return ticket;
        }
    }
}