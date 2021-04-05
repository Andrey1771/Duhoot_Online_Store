using Microsoft.AspNetCore.Mvc;
using OnlineShopDuhootWeb.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopDuhootWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly DataManager dataManager;

        public HomeController(DataManager adataManager)
        {
            dataManager = adataManager;
        }
        public IActionResult Index()
        {
            return View(dataManager.ProductSiteCardRep.ProductSiteCards);
        }
    }
}
