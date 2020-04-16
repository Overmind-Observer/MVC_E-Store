using Microsoft.AspNetCore.Mvc;

namespace EStore_MVC_.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}