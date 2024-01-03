using Busisness_Layer.Interfaces;
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

            return View();
        }

        public async Task<IActionResult> DownloadPdf()
        {

            return await _service.CreatePdf();
        }

        public async Task<IActionResult> DownloadExcel()
        {

            return await _service.CreateCsv();

        }

    }
}
