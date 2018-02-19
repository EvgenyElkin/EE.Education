using Microsoft.AspNetCore.Mvc;

namespace EE.Education.Site.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
