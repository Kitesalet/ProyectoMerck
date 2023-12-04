using Microsoft.AspNetCore.Mvc;
using ProyectoMerck.Models;

namespace ProyectoMerck.Controllers
{
    public class FertilityController : Controller
    {
        public IActionResult Index()
        {

            FertilityVM model = new FertilityVM();

            return View(model);
        }
    }
}
