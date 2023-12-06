using Microsoft.AspNetCore.Mvc;
using ProyectoMerck.Helpers;
using ProyectoMerck.Models;

namespace ProyectoMerck.Controllers
{


    public class FertilityController : Controller
    {

        private string ClientId { get; } = "596993924917-cami1o35mfiup4onvk9ara225sbii8c4.apps.googleusercontent.com";
        private string ClientSecret { get; } = "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";
        private string RedirectUrl { get; } = "";
        private string FileId { get; }  = "1P6_hfHWoKNW8rAiKnthiCUxl2oH5Zm5_\r\n";

        [HttpGet]
        public IActionResult Index()
        {

            FertilityVM model = new FertilityVM();




            return View(model);
        }

        [HttpGet]
        public IActionResult Indicator(FertilityVM model)
        {

            return View(model);
        }

        [HttpPost]
        public IActionResult CalculateFertility(FertilityVM model)
        {

            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            else
            {

                int fertilityMeter = FertilityCalculator.FertilityMeter(model.ActualAge, model.FirstAge);

                if (fertilityMeter < 0)
                {
                    TempData["FertError"] = "Las edades ingresadas son invalidas!";
                    return RedirectToAction("Index");
                }

                model.FertilityLevel = FertilityCalculator.LevelCalculator(fertilityMeter);

                model.OvuleCount = FertilityCalculator.OvuleCalculator(fertilityMeter);

                return RedirectToAction("Indicator", model);

            }
            

        }
    }
}
