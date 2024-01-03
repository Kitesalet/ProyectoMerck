using AutoMapper;
using Busisness_Layer.Interfaces;
using Common_Layer.Models.Dtos;
using Common_Layer.Models.Entities;
using Data_Access_Layer.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProyectoMerck.Helpers;
using Utility_Layer.Helpers;

namespace Busisness_Layer.Services
{
    public class UserService : IUserService
    {
        private readonly PdfService _pdfService;
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _IConfiguration;

        public UserService(IUnitOfWork context, IMapper mapper, IConfiguration configuration, PdfService pdfService)
        {

            _pdfService = pdfService;
            _context = context;
            _mapper = mapper;
            _IConfiguration = configuration;

        }

        public async Task<FileContentResult> CreateCsv()
        {
        
            var clinicConsultList = await _context.ClinicConsultationRepository.GetAll();

            string consultString = CsvMethodHelper<ClinicConsultation>.WriteCsvData(clinicConsultList);

            return CsvMethodHelper<ClinicConsultation>.DownloadCsvFile(consultString, "Clinicas_consultas.csv");


        }

        public async Task<FileContentResult> CreatePdf()
        {

            var clinicConsultList = await _context.ClinicConsultationRepository.GetAll();


            Byte[] byteData = _pdfService.GeneratePdf(clinicConsultList.ToList());

            return new FileContentResult(byteData, "application/pdf")
            {
                FileDownloadName = "Clinicas_consultas.pdf"
            };

        }

        public async Task<UserDto?> GetUserLogin(LoginDto dto)
        {

            try
            {

                User foundUser = await _context.UserRepository.UserLogin(dto);

                UserDto foundUserDto = _mapper.Map<UserDto>(foundUser); 

                return foundUserDto;

            }
            catch (Exception ex)
            {

                return null;
               
            }

        }
    }
}
