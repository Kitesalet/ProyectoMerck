using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProyectoMerck.Helpers;
using ProyectoMerck.Models;
using System.Globalization;
using System.Net;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProyectoMerck.Controllers
{


    public class FertilityController : Controller
    {

        private const string FertilityUrl = "https://raw.githubusercontent.com/Kitesalet/FertLocations/main/FertLocations.csv";

        [HttpGet]
        public IActionResult Index()
        {

            FertilityVM model = new FertilityVM();

            return View(model);
        }

        [HttpGet]
        public IActionResult Indicator(FertilityVM model)
        {

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CalculateFertility(FertilityVM model)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return View("Index");
                }
                else
                {

                    int fertilityMeter = FertilityCalculator.FertilityMeter(model.ActualAge, model.FirstAge);

                    if (fertilityMeter < 0)
                    {
                        TempData["FertError"] = "Las edades ingresadas son invalidas!";
                        return RedirectToAction("Index");
                    }

                    string data = HttpClientHelper.StringFromUrl(FertilityUrl);

                    List<Location> locations = ReadCsvLocationData(data);

                    model.Locations = JsonConvert.SerializeObject(locations, Formatting.Indented);

                    model.FertilityLevel = FertilityCalculator.LevelCalculator(fertilityMeter);

                    model.OvuleCount = FertilityCalculator.OvuleCalculator(fertilityMeter);

                    return RedirectToAction("Indicator", model);

                }


            }
            catch(Exception ex)
            {

                Console.WriteLine(ex);

                TempData["FertError"] = "Ha ocurrido un error!";

                return RedirectToAction("Index");

            }
           

        }

        public IActionResult Clinics(FertilityVM mod)
        {

            FertilityVM model = new FertilityVM();



            return View(model);

        }

        public static List<Location> ReadCsvLocationData(string csvData)
        {

            using (var reader = new StringReader(csvData))
            using ( var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                return csv.GetRecords<Location>().ToList();
            }

        }

    }
}
