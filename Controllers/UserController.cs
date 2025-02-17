using Microsoft.AspNetCore.Mvc;

namespace RockPaperScissors.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
