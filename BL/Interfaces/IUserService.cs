using Common_Layer.Models.Entities;
using Common_Layer.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Busisness_Layer.Interfaces
{
    public interface IUserService
    {

        public Task<User> GetUserLogin(LoginVM dto);

        public Task<FileContentResult> CreatePdf();

        public Task<FileContentResult> CreateCsv();

        public Task<FileContentResult> CreatePdfInterval(UserVM model);

        public Task<FileContentResult> CreateCsvInterval(UserVM model);

    }
}
