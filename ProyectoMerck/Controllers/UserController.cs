using Busisness_Layer.Interfaces;
using Common_Layer.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoMerck.Controllers
{
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

            return await _service.CreateCsv();

        }

        public async Task<IActionResult> DownloadPdfInterval(UserVM model)
        {

            return await _service.CreatePdfInterval(model);
        }

        public async Task<IActionResult> DownloadExcelInterval(UserVM model)
        {

            return await _service.CreateCsvInterval(model);

        }

    }
}
