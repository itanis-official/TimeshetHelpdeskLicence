using HelpDeskAPI.Data;
using HelpDeskAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HelpDeskAPI.Services
{
    public class NotificationService
    {
        private readonly HelpDeskContext _context;

        public NotificationService(HelpDeskContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Crée une notification pour un utilisateur.
        /// </summary>
        public async Task<Notification> CreerNotificationAsync(int utilisateurId, string message, TypeNotification type, int? ticketId = null)
        {
            var notification = new Notification
            {
                UtilisateurId = utilisateurId,
                Message = message,
                Type = type,
                TicketId = ticketId,
                DateEnvoi = DateTime.Now,
                EstLue = false
            };

            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();

            return notification;
        }

        /// <summary>
        /// Récupère toutes les notifications pour un utilisateur.
        /// </summary>
        public async Task<List<Notification>> GetNotificationsAsync(int utilisateurId, bool seulementNonLues = false)
        {
            var query = _context.Notifications
                .Include(n => n.Ticket)
                .Where(n => n.UtilisateurId == utilisateurId)
                .AsQueryable();

            if (seulementNonLues)
                query = query.Where(n => !n.EstLue);

            return await query.OrderByDescending(n => n.DateEnvoi).ToListAsync();
        }

        /// <summary>
        /// Marque une notification comme lue.
        /// </summary>
        public async Task MarquerCommeLueAsync(int notificationId)
        {
            var notif = await _context.Notifications.FindAsync(notificationId);
            if (notif != null)
            {
                notif.EstLue = true;
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Compte les notifications non lues d’un utilisateur.
        /// </summary>
        public async Task<int> CompterNonLuesAsync(int utilisateurId)
        {
            return await _context.Notifications.CountAsync(n => n.UtilisateurId == utilisateurId && !n.EstLue);
        }
    }
}