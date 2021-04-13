using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OnlineShopDuhootWeb.Areas.Identity.Data;
using OnlineShopDuhootWeb.Service;
using System;
using System.Collections.Generic;
using System.Collections;

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
            return View((dataManager.ProductRep.Products, GetContainCardList()));
        }

        private IEnumerable<bool> GetContainCardList()
        {
            var cards = dataManager.ProductSiteCardRep.ProductSiteCards.ToList();
            var products = dataManager.ProductRep.Products.ToList();
            List<bool> containCardList = new List<bool>();

            foreach (var product in products)
            {
                containCardList.Add(cards.Any(e => e.ProductId == product.ProductId));
            }
            return containCardList;
        }

        public IActionResult ProductEdit(int id)
        {
            var product = id == default ? dataManager.ProductRep.CreateNewProduct() : dataManager.ProductRep.GetProductById(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult ProductEdit(Product model)
        {
            if (ModelState.IsValid)
            {
                if (model.ProductId == default) model.ProductId = dataManager.ProductRep.CreateNewProduct().ProductId;
                dataManager.ProductRep.SaveProduct(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult ProductDelete(int productId)
        {
            dataManager.ProductRep.DeleteProduct(productId);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }
}
