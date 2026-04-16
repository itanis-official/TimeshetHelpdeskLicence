using HelpDeskAPI.Models;
using HelpDeskAPI.Services;
using Microsoft.AspNetCore.Mvc;
using HelpDeskAPI.DTOs;
namespace HelpDeskAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;

        public UserController(UserService service)
        {
            _service = service;
        }

        // =========================
        // 🔹 CREATE AGENT
        // =========================
        [HttpPost("agent")]
        public async Task<IActionResult> CreateAgent([FromBody] CreateAgentDto dto)
        {
            var agent = await _service.CreateAgentAsync(dto);

            if (agent == null)
                return BadRequest("Service ou MicroService invalide");

            return Ok(agent);
        }

        // =========================
        // 🔹 CREATE COLLABORATEUR
        // =========================
        [HttpPost("collaborateur")]
        public async Task<IActionResult> CreateCollaborateur([FromBody] CreateCollaborateurDto dto)
        {
            var collab = await _service.CreateCollaborateurAsync(dto);

            if (collab == null)
                return BadRequest("Client invalide");

            return Ok(collab);
        }

        // =========================
        // 🔹 CREATE ADMIN
        // =========================
        [HttpPost("admin")]
        public async Task<IActionResult> CreateAdmin([FromBody] CreateAdminDto dto)
        {
            var admin = await _service.CreateAdminAsync(dto);
            return Ok(admin);
        }

        // =========================
        // 🔹 GET ALL USERS
        // =========================
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllUsersAsync());
        }

        // =========================
        // 🔹 GET BY ID
        // =========================
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _service.GetUserByIdAsync(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // =========================
        // 🔹 DELETE
        // =========================
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteUserAsync(id);

            if (!result)
                return NotFound();

            return Ok("Utilisateur supprimé");
        }
    }
}