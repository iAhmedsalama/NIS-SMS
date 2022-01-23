using Microsoft.AspNetCore.Mvc;

namespace Day2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
