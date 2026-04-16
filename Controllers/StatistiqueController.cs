using HelpDeskAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelpDeskAPI.Controllers
{
    [ApiController]
    [Route("api/statistiques")]
    public class StatistiqueController : ControllerBase
    {
        private readonly StatistiqueService _service;

        public StatistiqueController(StatistiqueService service)
        {
            _service = service;
        }

        [HttpGet("global")]
        public IActionResult Global() => Ok(_service.GetGlobalStats());

        [HttpGet("service")]
        public IActionResult ParService() => Ok(_service.GetStatsParService());

        [HttpGet("agent")]
        public IActionResult ParAgent() => Ok(_service.GetStatsParAgent());
    }
}