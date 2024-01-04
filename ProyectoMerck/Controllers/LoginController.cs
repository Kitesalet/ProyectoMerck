using Busisness_Layer.Interfaces;
using Common_Layer.Models.Dtos;
using Common_Layer.Models.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
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

            User userFound = await _service.GetUserLogin(dto);
            
            if(userFound == null)
            {
                TempData["UserLoginError"] = "El usuario o el password ingresados son invalidos!";

                return RedirectToAction("Login");

            }

            var claims = new List<Claim>()
            {

                new Claim(ClaimTypes.Name, userFound.UserName),
                new Claim(ClaimTypes.Role, userFound.RoleId.ToString())
                
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimsIdentity));

            return RedirectToAction("Index","User");

        }

    }
}
