using HelpDeskAPI.Models;
using HelpDeskAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelpDeskAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly NotificationService _notificationService;

        public NotificationController(NotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        // Récupérer toutes les notifications d’un utilisateur
        [HttpGet("{utilisateurId}")]
        public async Task<ActionResult<List<Notification>>> GetNotifications(int utilisateurId, [FromQuery] bool seulementNonLues = false)
        {
            var notifications = await _notificationService.GetNotificationsAsync(utilisateurId, seulementNonLues);
            return Ok(notifications);
        }

        // Marquer une notification comme lue
        [HttpPost("mark-as-read/{notificationId}")]
        public async Task<ActionResult> MarkAsRead(int notificationId)
        {
            await _notificationService.MarquerCommeLueAsync(notificationId);
            return Ok(new { message = "Notification marquée comme lue." });
        }

        // Compter les notifications non lues
        [HttpGet("count/{utilisateurId}")]
        public async Task<ActionResult<int>> CountNonLues(int utilisateurId)
        {
            var count = await _notificationService.CompterNonLuesAsync(utilisateurId);
            return Ok(count);
        }
    }
}