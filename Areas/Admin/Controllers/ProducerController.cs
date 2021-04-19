using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OnlineShopDuhootWeb.Areas.Identity.Data;
using OnlineShopDuhootWeb.Service;

namespace OnlineShopDuhootWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProducerController : Controller 
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProducerController(DataManager adataManager, IWebHostEnvironment awebHostEnvironment)
        {
            dataManager = adataManager;
            webHostEnvironment = awebHostEnvironment;
        }

        public IActionResult Index()
        {
            return View(dataManager.ProducerRep.Producers);
        }

        public IActionResult ProducerEdit(int id)
        {
            var producer = dataManager.ProducerRep.GetProducerById(id);
            if (producer == null)
            {
                producer = dataManager.ProducerRep.CreateNewProducer();
            }
            return View(producer);
        }

        [HttpPost]
        public IActionResult ProducerEdit(Producer model)
        {
            if (ModelState.IsValid)
            {
                if (model.ProducerId == default) model.ProducerId = dataManager.ProducerRep.CreateNewProducer().ProducerId;
                dataManager.ProducerRep.SaveProducer(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult ProducerDelete(int id)
        {
            dataManager.ProducerRep.DeleteProducer(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }
}
