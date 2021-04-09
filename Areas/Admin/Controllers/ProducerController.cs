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
            var producer = id == default ? new Producer() : dataManager.ProducerRep.GetProducerById(id);
            return View(producer);
        }

        [HttpPost]
        public IActionResult ProducerDelete(int producerId)
        {
            dataManager.ProducerRep.DeleteProducer(producerId);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }
}
