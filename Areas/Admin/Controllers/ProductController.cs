using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OnlineShopDuhootWeb.Areas.Identity.Data;
using OnlineShopDuhootWeb.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopDuhootWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductController(DataManager adataManager, IWebHostEnvironment awebHostEnvironment)
        {
            dataManager = adataManager;
            webHostEnvironment = awebHostEnvironment;
        }

        public IActionResult Index()
        {
            return View(dataManager.ProductRep.Products);
        }

        public IActionResult ProductEdit(int id)
        {
            var product = id == default ? new Product() : dataManager.ProductRep.GetProductById(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult ProductDelete(int productId)
        {
            dataManager.ProductRep.DeleteProduct(productId);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }
}
