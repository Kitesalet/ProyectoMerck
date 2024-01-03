using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using ProyectoMerck.Helpers;
using ProyectoMerck.Models;
using ProyectoMerck.Models.Interfaces;

namespace ProyectoMerck.Controllers
{


    public class FertilityController : Controller
    {

        private readonly IFertilityService _service;
        private readonly ILogger<FertilityController> _logger;

        public FertilityController(IFertilityService service, ILogger<FertilityController> logger)
        {
            _service = service;
            _logger = logger;
        }

        public IActionResult Presentation()
        {

            _logger.LogInformation("Access to Presentation View");

            return View("Presentation");
        }

        [HttpGet]
        public IActionResult Index()
        {

            _logger.LogInformation("Access to Index View");


            FertilityVM model = new FertilityVM();

            return View("Index",model);
        }

        [HttpGet]
        public IActionResult Indicator(FertilityVM model)
        {

            _logger.LogInformation("Access to Indicator View");

            return View("Indicator",model);
        }

        [HttpGet]
        public IActionResult Information()
        {

            _logger.LogInformation("Access to Information View");

            return View("Information");
        }

        [HttpPost]
        public async Task<IActionResult> CalculateFertility(FertilityVM model)
        {

                if (!ModelState.IsValid)
                {

                    TempData["FertError"] = "Hubo un error inesperado!";
                    _logger.LogError("There has been an unexpected error");

                    return View("Index");

                }
                else
                {

                    FertilityVM finalModel = _service.CalculateFertility(model);

                    if (model.FirstAge > model.ActualAge)
                    {
                        TempData["FertError"] = "Las edades ingresadas son invalidas!";
                        _logger.LogError("Ages introduced were invalid");

                        return RedirectToAction("Index");
                    }


                    _logger.LogInformation("Ages introduced were invalid");

                    return RedirectToAction("Indicator", model);

                }

        }

        [HttpGet]
        public IActionResult ConsultFinish()
        {

            _logger.LogInformation("Access to ConsultFinish View");
            return View("ConsultFinish");
        }

        [HttpPost]
        public async Task<IActionResult> Consult(FertilitySubmitVM model)
        {

            model.SubmitError = false;

            bool validMail = RegexHelper.IsMailValid(model.UserEmail);

            if (!validMail)
            {
                ModelState.AddModelError("UserEmail", "El email ingresado tiene un formato incorrecto!");

                _logger.LogError("The entered email had an incorrect format");

            }

            if (!ModelState.IsValid)
            {

                model.SubmitError = true;

                TempData["FertError"] = "Ha ocurrido un error!";

                model = await _service.GetLists(model);

                _logger.LogError("There has been an error with the form's model state");
                return View("Clinics", model);

            }
            else
            {
                var mailSent = await _service.ConsultMailAsync(model);

                if (mailSent == false)
                {

                    model.SubmitError = true;

                    model = await _service.GetLists(model);

                    TempData["FertError"] = "Hubo un error, el email no pudo ser enviado!";

                    _logger.LogError("There was a mistake in one input in the ConsultMailAsync form");

                    return View("Clinics", model);
                }

                model.SentUrl = HttpContext.Request.GetDisplayUrl();

                await _service.AddClinicConsultation(model);

                _logger.LogInformation("Redirecting to ConsultFinish method, the form submit was successful");
                return RedirectToAction("ConsultFinish");
            }
        
        }

        [HttpGet]
        public async Task<IActionResult> Clinics()
        {
            FertilitySubmitVM model = new FertilitySubmitVM();

            model = await _service.GetLists(model);

            _logger.LogInformation("Access to Clinics View");

            return View("Clinics",model);

        }



    }
}
