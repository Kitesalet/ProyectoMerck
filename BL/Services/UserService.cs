using AutoMapper;
using Busisness_Layer.Interfaces;
using Common_Layer.Models.Dtos;
using Common_Layer.Models.Entities;
using Data_Access_Layer.DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using ProyectoMerck.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Busisness_Layer.Services
{
    public class UserService : IUserService
    {

        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _IConfiguration;

        public UserService(IUnitOfWork context, IMapper mapper, IConfiguration configuration)
        {

            _context = context;
            _mapper = mapper;
            _IConfiguration = configuration;

        }

        public async Task<bool> CreateCsv()
        {
        
            var clinicConsultList = await _context.ClinicConsultationRepository.GetAll();

            try
            {
                string consultString = CsvMethodHelper<ClinicConsultation>.WriteCsvData(clinicConsultList);

                CsvMethodHelper<ClinicConsultation>.DownloadCsvFile(consultString, _IConfiguration["FileNames:CvsFileName"]);

                return true;
            }
            catch
            {
                return false;
            }



        }

        public Task<bool> CreatePdf()
        {
            throw new NotImplementedException();
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
