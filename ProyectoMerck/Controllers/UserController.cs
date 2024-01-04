using Busisness_Layer.Interfaces;
using Common_Layer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoMerck.Controllers
{

    [Authorize(Roles = "1")]
    public class UserController : Controller
    {

        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            
            _service = service;

        }
        public IActionResult Index()
        {

            UserVM model = new UserVM()
            {
                ToDate = DateTime.Now,
                FromDate = DateTime.Now
            };

            return View(model);
        }

        public async Task<IActionResult> DownloadPdf()
        {

            return await _service.CreatePdf();
        }

        public async Task<IActionResult> DownloadExcel()
        {

            var randomero = HttpContext.User;

            return await _service.CreateCsv();

        }

        public async Task<IActionResult> DownloadPdfInterval(UserVM model)
        {
            if(model.FromDate > model.ToDate)
            {

                TempData["FertError"] = "Por favor, ingrese una fecha valida!";

                return RedirectToAction(nameof(Index));
            }

            return await _service.CreatePdfInterval(model);
        }

        public async Task<IActionResult> DownloadExcelInterval(UserVM model)
        {

            if (model.FromDate > model.ToDate)
            {

                TempData["FertError"] = "Por favor, ingrese una fecha valida!";

                return RedirectToAction(nameof(Index));
            }

            return await _service.CreateCsvInterval(model);

        }

    }
}
