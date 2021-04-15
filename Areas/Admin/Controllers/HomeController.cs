using Microsoft.AspNetCore.Mvc;

namespace OnlineShopDuhootWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public HomeController()
        {
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
