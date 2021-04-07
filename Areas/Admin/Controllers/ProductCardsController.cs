using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopDuhootWeb.Areas.Identity.Data;
using OnlineShopDuhootWeb.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopDuhootWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductCardsController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductCardsController(DataManager adataManager, IWebHostEnvironment awebHostEnvironment)
        {
            dataManager = adataManager;
            webHostEnvironment = awebHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            var siteCard = id == default ? new ProductSiteCard() : dataManager.ProductSiteCardRep.GetSiteCardById(id);
            return View(siteCard);
        }

        [HttpPost]
        public IActionResult Edit(ProductSiteCard model, IFormFile formImageFile/*Добавить проверку на картинку*/)
        {
            if(ModelState.IsValid)
            {
                if(formImageFile != null)
                {
                    model.BackgroundImage = Path.Combine("images/cardBgs/", formImageFile.FileName);
                    using (var stream = new FileStream(Path.Combine(webHostEnvironment.WebRootPath, "images/cardBgs/", formImageFile.FileName), FileMode.Create))
                    {
                        formImageFile.CopyToAsync(stream);//Убрать Async
                    }
                }
                dataManager.ProductSiteCardRep.SaveSiteCard(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int cardId)
        {
            dataManager.ProductSiteCardRep.DeleteSiteCard(cardId);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }
}
