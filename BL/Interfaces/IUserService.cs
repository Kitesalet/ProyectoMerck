using Common_Layer.Models.Dtos;
using Common_Layer.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Busisness_Layer.Interfaces
{
    public interface IUserService
    {

        public Task<UserDto?> GetUserLogin(LoginDto dto);

        public Task<bool> CreatePdf();

        public Task<bool> CreateCsv();

    }
}
