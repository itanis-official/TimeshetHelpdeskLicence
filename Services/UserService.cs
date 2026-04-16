using HelpDeskAPI.Data;
using HelpDeskAPI.Models;
using Microsoft.EntityFrameworkCore;
using HelpDeskAPI.DTOs;
namespace HelpDeskAPI.Services
{
    public class UserService
    {
        private readonly HelpDeskContext _context;

        public UserService(HelpDeskContext context)
        {
            _context = context;
        }

        // =========================
        // 🔹 CREATE AGENT
        // =========================
        public async Task<Agent?> CreateAgentAsync(CreateAgentDto dto)
        {
            var serviceExists = await _context.Services.AnyAsync(s => s.ServiceId == dto.ServiceId);
            var microExists = await _context.MicroServices.AnyAsync(m => m.MicroServiceId == dto.MicroServiceId);

            if (!serviceExists || !microExists)
                return null;

            var agent = new Agent
            {
                Nom = dto.Nom,
                Prenom = dto.Prenom,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = UserRole.Agent,
                ServiceId = dto.ServiceId,
                MicroServiceId = dto.MicroServiceId
            };

            _context.Utilisateurs.Add(agent);
            await _context.SaveChangesAsync();

            return agent;
        }

        // =========================
        // 🔹 CREATE COLLABORATEUR
        // =========================
        public async Task<Collaborateur?> CreateCollaborateurAsync(CreateCollaborateurDto dto)
        {
            var clientExists = await _context.Clients.AnyAsync(c => c.ClientId == dto.ClientId);

            if (!clientExists)
                return null;

            var collab = new Collaborateur
            {
                Nom = dto.Nom,
                Prenom = dto.Prenom,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = UserRole.Collaborateur,

                ClientId = dto.ClientId,
                Statut = dto.Statut,
                PhotoProfil = dto.PhotoProfil
            };

            _context.Utilisateurs.Add(collab);
            await _context.SaveChangesAsync();

            return collab;
        }

        // =========================
        // 🔹 CREATE ADMIN
        // =========================
        public async Task<Admin> CreateAdminAsync(CreateAdminDto dto)
        {
            var admin = new Admin
            {
                Nom = dto.Nom,
                Prenom = dto.Prenom,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = UserRole.Admin
            };

            _context.Utilisateurs.Add(admin);
            await _context.SaveChangesAsync();

            return admin;
        }

        // =========================
        // 🔹 GET ALL USERS
        // =========================
        public async Task<List<Utilisateur>> GetAllUsersAsync()
        {
            return await _context.Utilisateurs.ToListAsync();
        }

        // =========================
        // 🔹 GET BY ID
        // =========================
        public async Task<Utilisateur?> GetUserByIdAsync(int id)
        {
            return await _context.Utilisateurs.FindAsync(id);
        }

        // =========================
        // 🔹 DELETE USER
        // =========================
        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Utilisateurs.FindAsync(id);

            if (user == null)
                return false;

            _context.Utilisateurs.Remove(user);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}