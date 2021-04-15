using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopDuhootWeb.Areas.Identity.Data;
using OnlineShopDuhootWeb.Service;
using System.IO;

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
            return View(dataManager.ProductSiteCardRep.ProductSiteCards);
        }

        public IActionResult ProductCardEdit(int id)
        {
            var siteCard = dataManager.ProductSiteCardRep.GetSiteCardById(id);
            if(siteCard == null)
            {
                siteCard = dataManager.ProductSiteCardRep.CreateNewSiteCard(id);
            }    
            return View(siteCard);
        }

        [HttpPost]
        public IActionResult ProductCardEdit(ProductSiteCard model, IFormFile formImageFile/*Добавить проверку на картинку*/)
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
        public IActionResult ProductCardDelete(int cardId)
        {
            dataManager.ProductSiteCardRep.DeleteSiteCard(cardId);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }
}
