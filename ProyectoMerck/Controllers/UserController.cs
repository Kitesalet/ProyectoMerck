using Busisness_Layer.Interfaces;
using Common_Layer.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoMerck.Controllers
{

    //[Authorize(Roles = "1")]
    public class UserController : Controller
    {

        private readonly IUserService _service;
        private readonly UserManager<IdentityUser> _userManager;

        public UserController(IUserService service, UserManager<IdentityUser> userManager)
        {
            
            _service = service;
            _userManager = userManager;

        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {

            RegisterVM model = new RegisterVM();

            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterVM userManager)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = userManager.Email,
                    Email = userManager.Email
                };

                var result = await _userManager.CreateAsync(user, userManager.Password);

                if(result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            else
            {
                return RedirectToAction("Index");
            }

            return View("Register");
        }

        [Authorize]
        public IActionResult Index()
        {

            UserVM model = new UserVM()
            {
                ToDate = DateTime.Now,
                FromDate = DateTime.Now
            };

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> DownloadPdf()
        {

            return await _service.CreatePdf();
        }

        [Authorize]
        public async Task<IActionResult> DownloadExcel()
        {

            var randomero = HttpContext.User;

            return await _service.CreateCsv();

        }

        [Authorize]
        public async Task<IActionResult> DownloadPdfInterval(UserVM model)
        {
            if(model.FromDate > model.ToDate)
            {

                TempData["FertError"] = "Por favor, ingrese una fecha valida!";

                return RedirectToAction(nameof(Index));
            }

            return await _service.CreatePdfInterval(model);
        }

        [Authorize]
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
