using AutoMapper;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProyectoMerck.DAL;
using ProyectoMerck.Helpers;
using ProyectoMerck.Models;
using ProyectoMerck.Models.Interfaces;

namespace ProyectoMerck.Controllers
{


    public class FertilityController : Controller
    {

        private readonly IFertilityService _service;

        public FertilityController(IFertilityService service)
        {
            _service = service;
        }

        public IActionResult Presentation()
        {
            return View("Presentation");
        }

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

        [HttpGet]
        public IActionResult Information()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CalculateFertility(FertilityVM model)
        {

                var x = HttpContext;

                if (!ModelState.IsValid)
                {

                    TempData["FertError"] = "Hubo un error inesperado!";

                    return View("Index");

                }
                else
                {

                    FertilityVM finalModel = _service.CalculateFertility(model);

                    if (finalModel.FertilityLevel < 0)
                    {
                        TempData["FertError"] = "Las edades ingresadas son invalidas!";
                        return RedirectToAction("Index");
                    }

                    return RedirectToAction("Indicator", model);

                }

        }

        [HttpGet]
        public IActionResult ConsultFinish()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Consult(FertilityVM model)
        {
            if (!ModelState.IsValid)
            {

                TempData["FertError"] = "Hubo un error inesperado!";

                return View("Index");

            }
            else
            {
                var mailSent = await _service.ConsultMailAsync(model);

                if (mailSent == false)
                {
                    TempData["FertError"] = "Hubo un error, el email no pudo ser enviado!";
                    return RedirectToAction("Index");
                }

                return RedirectToAction("ConsultFinish");
            }
        
        }

        [HttpGet]
        public async Task<IActionResult> Clinics()
        {
            FertilityVM model = new FertilityVM();

            model = await _service.ClinicLocations(model);

            model = await _service.GetLists(model);

            return View(model);

        }



    }
}
