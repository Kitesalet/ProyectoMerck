using Busisness_Layer.Interfaces;
using Common_Layer.Models.Dtos;
using Common_Layer.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ProyectoMerck.Controllers
{
    public class LoginController : Controller
    {

        private readonly IUserService _service;

        public LoginController(IUserService service)
        {

            _service = service;

        }

        public IActionResult Login()
        {
            LoginDto model = new LoginDto();

            return View(model);
        }

        public async Task<IActionResult> UserAccess(LoginDto dto)
        {

            UserDto userFound = await _service.GetUserLogin(dto);
            
            if(userFound == null)
            {
                TempData["UserLoginError"] = "El usuario o el password ingresados son invalidos!";

                return RedirectToAction("Login");

            }

            var claims = new List<Claim>();

            

            return RedirectToAction("Index","User");

        }

    }
}
