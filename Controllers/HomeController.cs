using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopDuhootWeb.Areas.Identity.Data;
using OnlineShopDuhootWeb.Models;
using System.Diagnostics;

namespace OnlineShopDuhootWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataManager dataManager;

        public HomeController(ILogger<HomeController> logger, DataManager adataManager)
        {
            _logger = logger;
            dataManager = adataManager;
        }

        public IActionResult Index()
        {
            return View(dataManager.ProductSiteCardRep.ProductSiteCards);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
