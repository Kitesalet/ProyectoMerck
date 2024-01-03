using AutoMapper;
using Busisness_Layer.Interfaces;
using Common_Layer.Models;
using Common_Layer.Models.Dtos;
using Common_Layer.Models.Entities;
using Data_Access_Layer.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProyectoMerck.Helpers;
using System.Collections.Generic;
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

            var clinicConsultListMin = _mapper.Map<List<ClinicConsultationDto>>(clinicConsultList);

            string consultString = CsvMethodHelper<ClinicConsultationDto>.WriteCsvData(clinicConsultListMin);



            return CsvMethodHelper<ClinicConsultation>.DownloadCsvFile(consultString, "Clinicas_consultas.csv");


        }

        public async Task<FileContentResult> CreateCsvInterval(UserVM model)
        {
            var clinicConsultList = await _context.ClinicConsultationRepository.GetDateIntervalFiltered(model.FromDate,model.ToDate);

            var clinicConsultListMin = _mapper.Map<List<ClinicConsultationDto>>(clinicConsultList);

            string consultString = CsvMethodHelper<ClinicConsultationDto>.WriteCsvData(clinicConsultListMin);

            return CsvMethodHelper<ClinicConsultation>.DownloadCsvFile(consultString, "Clinicas_consultas_filtradas.csv");
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

        public async Task<FileContentResult> CreatePdfInterval(UserVM model)
        {

            var clinicConsultList = await _context.ClinicConsultationRepository.GetDateIntervalFiltered(model.FromDate, model.ToDate);

            Byte[] byteData = _pdfService.GeneratePdf(clinicConsultList.ToList());

            return new FileContentResult(byteData, "application/pdf")
            {
                FileDownloadName = "Clinicas_consultas_filtradas.pdf"
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
