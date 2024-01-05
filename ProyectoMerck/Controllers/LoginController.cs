using Busisness_Layer.Interfaces;
using Common_Layer.Models.Entities;
using Common_Layer.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ProyectoMerck.Controllers
{


    public class LoginController : Controller
    {

        private readonly IUserService _service;
        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginController(IUserService service, SignInManager<IdentityUser> signInManager)
        {

            _service = service;
            _signInManager = signInManager;

        }

        public IActionResult Login()
        {
            LoginVM model = new LoginVM();

            return View(model);
        }

       
        public async Task<IActionResult> UserAccess(LoginVM user)
        {

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, user.RememberMe, false);

                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "User");
                }

                ModelState.AddModelError("", "Email o Password incorrectos!");

            }

            return View("Login", user);

            //User userFound = await _service.GetUserLogin(dto);
            
            //if(userFound == null)
            //{
            //    TempData["UserLoginError"] = "El usuario o el password ingresados son invalidos!";

            //    return RedirectToAction("Login");

            //}

            //var claims = new List<Claim>()
            //{

            //    new Claim(ClaimTypes.Name, userFound.UserName),
            //    new Claim(ClaimTypes.Role, userFound.RoleId.ToString())
                
            //};

            //var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimsIdentity));

            //return RedirectToAction("Index","User");

        }

    }
}
