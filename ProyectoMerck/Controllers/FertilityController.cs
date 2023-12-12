using AutoMapper;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProyectoMerck.DAL;
using ProyectoMerck.Helpers;
using ProyectoMerck.Models;
using ProyectoMerck.Models.Dtos;
using ProyectoMerck.Models.Entities;
using ProyectoMerck.Models.Interfaces;
using System.Globalization;
using System.Net;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProyectoMerck.Controllers
{


    public class FertilityController : Controller
    {

        private const string FertilityUrl = "https://raw.githubusercontent.com/Kitesalet/FertLocations/main/FertLocations.csv";
        private readonly IEmailService _EmailService;
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public FertilityController(IEmailService mail, IConfiguration config, AppDbContext context, IMapper mapper)
        {
            _EmailService = mail;
            _configuration = config;
            _context = context;
            _mapper = mapper;
        }

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

                    model.FertilityLevel = FertilityCalculator.LevelCalculator(fertilityMeter);

                    model.OvuleCount = FertilityCalculator.OvuleCalculator(fertilityMeter);

                    return RedirectToAction("Indicator", model);

                }


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);

                TempData["FertError"] = "Ha ocurrido un error!";

                return RedirectToAction("Index");

            }


        }

        [HttpGet]

        public IActionResult ConsultFinish()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Consult(FertilityVM model)
        {
            try
            {
                var locations = _mapper.Map<List<LocationDto>>(JsonConvert.DeserializeObject<List<Location>>(model.Locations));

                string testMail = _configuration["Email:FromAddress"];

                string mailBody = $"<h1 style='text-align:center'>Merck Fertilidad</h1>" +
                    $"              <hr />" +
                    $"              <p style='text-align:center'>Clínica elegida: {locations[model.SelectedLocationIndex].Title}</p>" +
                    $"              <br />" +
                    $"              <p style='text-align:center'>Email del usuario: {model.UserEmail}" +
                    $"              <br />" +
                    $"              <p style='text-align:center'>Mensaje: {model.ConsultMotive}</p>" +
                    $"              <hr />";

                _EmailService.SendEmailAsync(testMail, $"New Consult N#{new Random().Next(10000000, 99999999)}", mailBody);

                return RedirectToAction("ConsultFinish");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return RedirectToAction("Index");
            }
         

        }

        public async Task<IActionResult> Clinics(FertilityVM mod)
        {

            FertilityVM model = new FertilityVM();

            #region This is the way you have to go to use a CVS file for location data
            string data = HttpClientHelper.StringFromUrl(FertilityUrl);

            List<LocationDto> locations = ReadCsvLocationData(data);

            var locationsDto = _mapper.Map<List<LocationDto>>(locations);
            #endregion

            #region This is the way you have to go to consume consume the data from a database
            //var locations = await _context.Locations.ToListAsync();

            //var locationsDto = _mapper.Map<List<LocationDto>>(locations);
            #endregion

            model.LocationsList = locationsDto;

            model.Locations = JsonConvert.SerializeObject(locationsDto, Formatting.Indented);

            return View(model);

        }

        public static List<LocationDto> ReadCsvLocationData(string csvData)
        {

            using (var reader = new StringReader(csvData))
            using ( var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                return csv.GetRecords<LocationDto>().ToList();
            }

        }

    }
}
