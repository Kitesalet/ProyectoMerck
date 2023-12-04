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

            if(fertilityMeter >= 25)
            {
                model.FertilityLevel = FertilityLevel.Low;
            }else if(fertilityMeter < 15)
            {
                model.FertilityLevel = FertilityLevel.High;
            }
            else
            {
                model.FertilityLevel = FertilityLevel.Medium;
            }

            return RedirectToAction("Indicator", model);

        }
    }
}
