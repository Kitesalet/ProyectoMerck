using AutoMapper;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ProyectoMerck.DAL;
using ProyectoMerck.Helpers;
using ProyectoMerck.Models;
using ProyectoMerck.Models.Dtos;
using ProyectoMerck.Models.Entities;
using ProyectoMerck.Models.Interfaces;
using System.Runtime.CompilerServices;

namespace ProyectoMerck.Services
{
    public class FertilityService : IFertilityService
    {
        private const string FertilityUrl = "https://raw.githubusercontent.com/Kitesalet/FertLocations/main/FertLocations.csv";
        private const string CountryUrl = "https://raw.githubusercontent.com/Kitesalet/FertLocations/main/Countries.csv";
        private const string ProvinceUrl = "https://raw.githubusercontent.com/Kitesalet/FertLocations/main/Provinces.csv";
        private const string ProvinceLocationUrl = "https://raw.githubusercontent.com/Kitesalet/FertLocations/main/ProvinceLocations.csv";
        private const string ConsultMotiveUrl = "https://raw.githubusercontent.com/Kitesalet/FertLocations/main/ConsultMotives.csv";

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

        public async Task<FertilitySubmitVM> GetLists(FertilitySubmitVM model)
        {

            model.CountryList = _mapper.Map<List<CountryDto>>(await _context.CountryRepository.GetAll());
            model.ProvinceList = _mapper.Map<List<ProvinceDto>>(await _context.ProvinceRepository.GetAll());
            model.ProvinceLocationList = _mapper.Map<List<ProvinceLocationDto>>(await _context.ProvinceLocationRepository.GetAll());
            model.ConsultMotiveList = _mapper.Map<List<ConsultMotiveDto>>(await _context.ConsultMotiveRepository.GetAll());
            var locationsDto = _mapper.Map<List<LocationDto>>(await _context.LocationRepository.GetAll());

            model.LocationsList = locationsDto;
            model.Locations = JsonConvert.SerializeObject(locationsDto, Formatting.Indented);


            return model;

        }

        public async Task<FertilitySubmitVM> GetListsFromCsv(FertilitySubmitVM model)
        {

            string countryInfo = await HttpClientHelper.StringFromUrl(CountryUrl);
            string provinceInfo = await HttpClientHelper.StringFromUrl(ProvinceUrl);
            string provinceLocationInfo = await HttpClientHelper.StringFromUrl(ProvinceLocationUrl);
            string consultMotiveInfo = await HttpClientHelper.StringFromUrl(ConsultMotiveUrl);
            string fertilityInfo = await HttpClientHelper.StringFromUrl(FertilityUrl);

            var countryList = CsvMethodHelper<CountryDto>.ReadCsvLocationData(countryInfo);
            var provinceList = CsvMethodHelper<ProvinceDto>.ReadCsvLocationData(provinceInfo);
            var provinceLocationList = CsvMethodHelper<ProvinceLocationDto>.ReadCsvLocationData(provinceLocationInfo);
            var consultMotiveList = CsvMethodHelper<ConsultMotiveDto>.ReadCsvLocationData(consultMotiveInfo);
            var fertilityList = CsvMethodHelper<LocationDto>.ReadCsvLocationData(fertilityInfo);

            model.CountryList = countryList;
            model.ProvinceList = provinceList;
            model.ProvinceLocationList = provinceLocationList;
            model.ConsultMotiveList = consultMotiveList;
            model.LocationsList = fertilityList;


            model.Locations = JsonConvert.SerializeObject(model.LocationsList, Formatting.Indented);

            return model;
        }

        public FertilityVM CalculateFertility(FertilityVM model)
        {
            int fertilityMeter = FertilityCalculator.FertilityMeter(model.ActualAge, model.FirstAge);

            model.FertilityLevel = FertilityCalculator.LevelCalculator(fertilityMeter);

            model.OvuleCount = FertilityCalculator.OvuleCalculator(fertilityMeter);

            return model;
        }


        public async Task<bool> ConsultMailAsync(FertilitySubmitVM model)
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
                    $"              <p style='text-align:center'>Motivo de Consulta: {model.ConsultMotiveMessage}</p>" +
                    $"              <hr />";

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
