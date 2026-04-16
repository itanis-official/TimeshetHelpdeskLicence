using Microsoft.AspNetCore.Mvc;

namespace HelpDeskAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
