using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopDuhootWeb.Areas.Admin.Controllers
{
    public class ProductCardsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
