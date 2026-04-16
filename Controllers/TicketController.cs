using HelpDeskAPI.Models;
using HelpDeskAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelpDeskAPI.Controllers
{
    [ApiController]
    [Route("api/tickets")]
    public class TicketController : ControllerBase
    {
        private readonly TicketService _service;

        public TicketController(TicketService service)
        {
            _service = service;
        }

        // ===============================
        // 🔹 CREATE TICKET (IMPORTANT)
        // ===============================
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTicketDto dto)
        {
            var ticket = await _service.CreateTicketAsync(dto);
            return Ok(MapToDto(ticket));
        }

        // ===============================
        // 🔹 GET TICKET COMPLET
        // ===============================
        [HttpGet("{ticketId}")]
        public async Task<IActionResult> GetTicket(int ticketId)
        {
            var ticket = await _service.GetTicketCompletAsync(ticketId);

            if (ticket == null)
                return NotFound("Ticket introuvable");

            return Ok(MapToDto(ticket));
        }

        // ===============================
        // 🔹 ACCEPT
        // ===============================
        [HttpPost("{ticketId}/accept")]
        public async Task<IActionResult> Accept(int ticketId, [FromQuery] int agentId)
        {
            var ticket = await _service.AccepterTicketAsync(ticketId, agentId);

            if (ticket == null)
                return NotFound("Ticket introuvable");

            return Ok(MapToDto(ticket));
        }

        // ===============================
        // 🔹 REFUSE
        // ===============================
        [HttpPost("{ticketId}/refuse")]
        public async Task<IActionResult> Refuse(int ticketId)
        {
            var result = await _service.RefuserTicketAsync(ticketId);

            if (!result)
                return NotFound("Ticket introuvable");

            return Ok("Ticket refusé");
        }

        // ===============================
        // 🔹 START
        // ===============================
        [HttpPost("{ticketId}/start")]
        public async Task<IActionResult> Start(int ticketId, [FromQuery] int agentId)
        {
            var ticket = await _service.StartTicketAsync(ticketId, agentId);

            if (ticket == null)
                return NotFound("Ticket ou agent introuvable");

            return Ok(MapToDto(ticket));
        }

        // ===============================
        // 🔹 PAUSE
        // ===============================
        [HttpPost("{ticketId}/pause")]
        public async Task<IActionResult> Pause(int ticketId)
        {
            var result = await _service.PauseTicketAsync(ticketId);

            if (!result)
                return NotFound("Ticket introuvable");

            return Ok("Ticket en pause");
        }

        // ===============================
        // 🔹 RESUME
        // ===============================
        [HttpPost("{ticketId}/resume")]
        public async Task<IActionResult> Resume(int ticketId, [FromQuery] int agentId)
        {
            var ticket = await _service.ResumeTicketAsync(ticketId, agentId);

            if (ticket == null)
                return NotFound("Ticket introuvable");

            return Ok(MapToDto(ticket));
        }

        // ===============================
        // 🔹 STOP
        // ===============================
        [HttpPost("{ticketId}/stop")]
        public async Task<IActionResult> Stop(int ticketId)
        {
            var ticket = await _service.StopTicketAsync(ticketId);

            if (ticket == null)
                return NotFound("Ticket introuvable");

            return Ok(MapToDto(ticket));
        }

        // ===============================
        // 🔹 FERMER
        // ===============================
        [HttpPost("{ticketId}/fermer")]
        public async Task<IActionResult> Fermer(int ticketId, [FromBody] FermerTicketDto dto)
        {
            var ticket = await _service.FermerTicketAsync(ticketId, dto.TravailEffectue);

            if (ticket == null)
                return NotFound("Ticket introuvable");

            return Ok(MapToDto(ticket));
        }

        // ===============================
        // 🔹 COMMENTAIRE
        // ===============================
        [HttpPost("{ticketId}/commentaire")]
        public async Task<IActionResult> Commentaire(int ticketId, [FromBody] CommentaireDto dto)
        {
            var commentaire = await _service.AjouterCommentaireAsync(ticketId, dto.UserId, dto.Contenu);

            if (commentaire == null)
                return NotFound("Ticket ou utilisateur introuvable");

            return Ok(commentaire);
        }

        // ===============================
        // 🔹 MAPPING DTO SAFE
        // ===============================
        private TicketDto MapToDto(Ticket? t)
        {
            if (t == null)
                throw new ArgumentNullException(nameof(t));

            return new TicketDto
            {
                TicketId = t.TicketId,
                Reference = t.Reference,
                Titre = t.Titre,
                Description = t.Description,
                Statut = t.Statut.ToString(),
                Priorite = t.Priorite.ToString(),

                DateCreation = t.DateCreation,
                DateDebut = t.DateDebut,
                DateFin = t.DateFin,
                DatePrevueFin = t.DatePrevueFin,

                ServiceId = t.ServiceId,
                MicroServiceId = t.MicroServiceId,
                CreateurId = t.CreateurId,

                TempsTotalHeures = t.TempsTotalHeures,
                TicketFusionneAvecId = t.TicketFusionneAvecId,
                TravailEffectue = t.TravailEffectue,

                Service = t.Service?.Nom,
                MicroService = t.MicroService?.Nom,
                Createur = t.Createur?.Nom,

                Assignes = t.Assignes?
    .Where(a => a.Utilisateur != null)
    .Select(a => a.Utilisateur.Nom)
    .ToList()
            };
        }

        // ===============================
        // 🔸 DTO CREATE
        // ===============================
        public class CreateTicketDto
        {
            public string Reference { get; set; } = null!;
            public string Titre { get; set; } = null!;
            public string Description { get; set; } = null!;
            public string Priorite { get; set; } = null!;

            public int ServiceId { get; set; }
            public int MicroServiceId { get; set; }
            public int CreateurId { get; set; }
        }

        // ===============================
        // 🔸 DTO FERMER
        // ===============================
        public class FermerTicketDto
        {
            public string TravailEffectue { get; set; } = null!;
        }

        // ===============================
        // 🔸 DTO COMMENTAIRE
        // ===============================
        public class CommentaireDto
        {
            public int UserId { get; set; }
            public string Contenu { get; set; } = null!;
        }

        // ===============================
        // 🔸 DTO RESPONSE
        // ===============================
        public class TicketDto
        {
            public int TicketId { get; set; }

            public string Reference { get; set; } = null!;
            public string Titre { get; set; } = null!;
            public string Description { get; set; } = null!;
            public string Statut { get; set; } = null!;
            public string Priorite { get; set; } = null!;

            public DateTime DateCreation { get; set; }
            public DateTime? DateDebut { get; set; }
            public DateTime? DateFin { get; set; }
            public DateTime? DatePrevueFin { get; set; }

            public int? ServiceId { get; set; }
            public int? MicroServiceId { get; set; }
            public int? CreateurId { get; set; }

            public double TempsTotalHeures { get; set; }

            public int? TicketFusionneAvecId { get; set; }

            public string? TravailEffectue { get; set; }

            public string? Service { get; set; }
            public string? MicroService { get; set; }
            public string? Createur { get; set; }

            public List<string>? Assignes { get; set; }
        }
    }
}