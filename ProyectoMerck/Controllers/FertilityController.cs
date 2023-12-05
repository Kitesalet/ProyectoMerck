using Microsoft.AspNetCore.Mvc;
using ProyectoMerck.Models;

namespace ProyectoMerck.Controllers
{


    public class FertilityController : Controller
    {
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

            int fertilityMeter = model.ActualAge - model.FirstAge;

            if(fertilityMeter < 0)
            {
                TempData["FertError"] = "Las edades ingresadas son invalidas!";
                return RedirectToAction("Index");
            }

            if(fertilityMeter >= 30)
            {
                model.FertilityLevel = FertilityLevel.Low;
            }else if(fertilityMeter < 20)
            {
                model.FertilityLevel = FertilityLevel.High;
            }
            else
            {
                model.FertilityLevel = FertilityLevel.Medium;
            }

            model.OvuleCount = (-1 * fertilityMeter + 100);

            return RedirectToAction("Indicator",model);

        }
    }
}
