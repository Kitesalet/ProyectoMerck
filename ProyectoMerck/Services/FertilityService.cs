using AutoMapper;
using Google.Apis.Drive.v3.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProyectoMerck.DAL;
using ProyectoMerck.Helpers;
using ProyectoMerck.Models;
using ProyectoMerck.Models.Dtos;
using ProyectoMerck.Models.Entities;
using ProyectoMerck.Models.Interfaces;

namespace ProyectoMerck.Services
{
    public class FertilityService : IFertilityService
    {
        private const string FertilityUrl = "https://raw.githubusercontent.com/Kitesalet/FertLocations/main/FertLocations.csv";

        private readonly IUnitOfWork _context;
        private readonly IEmailService _EmailService;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public FertilityService(IUnitOfWork unitOfWork, IEmailService mailService, IConfiguration configuration, IMapper mapper )
        {
            _context = unitOfWork;
            _EmailService = mailService;
            _configuration = configuration;
            _mapper = mapper;

        }

        public async Task<FertilityVM> GetLists(FertilityVM model)
        {

            model.CountryList = _mapper.Map<List<CountryDto>>(await _context.CountryRepository.GetAll());
            model.ProvinceList = _mapper.Map<List<ProvinceDto>>(await _context.ProvinceRepository.GetAll());
            model.ProvinceLocationList = _mapper.Map<List<ProvinceLocationDto>>(await _context.ProvinceLocationRepository.GetAll());

            return model;

        }

        public FertilityVM CalculateFertility(FertilityVM model)
        {
            int fertilityMeter = FertilityCalculator.FertilityMeter(model.ActualAge, model.FirstAge);

            model.FertilityLevel = FertilityCalculator.LevelCalculator(fertilityMeter);

            model.OvuleCount = FertilityCalculator.OvuleCalculator(fertilityMeter);

            return model;
        }

        public async Task<FertilityVM> ClinicLocations(FertilityVM model)
        {

            #region This is the way you have to go to use a CVS file for location data
            //string data = HttpClientHelper.StringFromUrl(FertilityUrl);

            //List<LocationDto> locations = CsvMethodHelper.ReadCsvLocationData(data);

            //var locationsDto = _mapper.Map<List<LocationDto>>(locations);
            #endregion

            #region This is the way you have to go to consume consume the data from a database
            var locations = await _context.LocationRepository.GetAll();

            var locationsDto = _mapper.Map<List<LocationDto>>(locations);
            #endregion


            model.LocationsList = locationsDto;
            model.Locations = JsonConvert.SerializeObject(locationsDto, Formatting.Indented);

            return model;

        }

        public async Task<bool> ConsultMailAsync(FertilityVM model)
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

                var response = await _EmailService.SendEmailAsync(testMail, "xxx", mailBody);

                bool result = await _EmailService.SendEmailAsync(testMail, $"New Consult N#{new Random().Next(10000000, 99999999)}", mailBody);

                return result;
                

            }
            catch(Exception ex)
            {

                Console.WriteLine(ex);

                return false;
            }

        }


    }
}
