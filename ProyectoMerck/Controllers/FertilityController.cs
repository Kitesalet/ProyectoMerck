using Microsoft.AspNetCore.Mvc;
using PagedList;
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

            return View("Index",model);
        }

        [HttpGet]
        public IActionResult Indicator(FertilityVM model)
        {

            return View("Indicator",model);
        }

        [HttpGet]
        public IActionResult Information()
        {

            return View("Information");
        }

        [HttpPost]
        public async Task<IActionResult> CalculateFertility(FertilityVM model)
        {

                if (!ModelState.IsValid)
                {

                    TempData["FertError"] = "Hubo un error inesperado!";

                    return View("Index");

                }
                else
                {

                    FertilityVM finalModel = _service.CalculateFertility(model);

                    if (model.FirstAge > model.ActualAge)
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
            return View("ConsultFinish");
        }

        [HttpPost]
        public async Task<IActionResult> Consult(FertilitySubmitVM model)
        {
            bool validMail = false;

            if (!String.IsNullOrEmpty(model.UserEmail))
            {
                validMail = RegexHelper.IsMailValid(model.UserEmail);
            }

            if (!validMail)
            {
                ModelState.AddModelError("UserEmail", "El email ingresado tiene un formato incorrecto!");
            }

            if (!ModelState.IsValid)
            {

                ModelState["SelectedCountry"].RawValue = 0;
                ModelState["UserEmail"].RawValue = "";
                ModelState["ConsultMotiveMessage"].RawValue = "";

                TempData["FertError"] = "Ha ocurrido un error!";

                model = await _service.GetLists(model);

                return View("Clinics", model);

            }
            else
            {
                var mailSent = await _service.ConsultMailAsync(model);

                if (mailSent == false)
                {

                    ModelState["SelectedCountry"].RawValue = 0;
                    ModelState["UserEmail"].RawValue = "";
                    ModelState["ConsultMotiveMessage"].RawValue = "";

                    model = await _service.GetLists(model);

                    TempData["FertError"] = "Hubo un error, el email no pudo ser enviado!";
                    return View("Clinics", model);
                }

                return RedirectToAction("ConsultFinish");
            }
        
        }

        [HttpGet]
        public async Task<IActionResult> Clinics()
        {
            FertilitySubmitVM model = new FertilitySubmitVM();

            model = await _service.GetListsFromCsv(model);



            return View("Clinics",model);

        }



    }
}
