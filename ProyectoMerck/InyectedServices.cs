﻿using Busisness_Layer.Interfaces;
using Busisness_Layer.Services;
using Common_Layer.Models.Entities;
using Data_Access_Layer.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using ProyectoMerck.DAL;
using ProyectoMerck.DAL.Repositories;
using ProyectoMerck.Helpers;
using ProyectoMerck.Models.Entities;
using ProyectoMerck.Models.Interfaces;
using ProyectoMerck.Services;


namespace Inyection_Layer
{
    public static class InyectedServices
    {

        public static IServiceCollection ServiceInyector(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<AppDbContext>(c => c.UseSqlServer(configuration.GetConnectionString("Hosted")));          

            services.AddScoped<IGenericRepository<Location>, GenericRepository<Location>>();
            services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();
            services.AddScoped<IGenericRepository<ClinicConsultation>, GenericRepository<ClinicConsultation>>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(typeof(MapperHelper));

            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IFertilityService, FertilityService>();
            services.AddScoped<IUserService, UserService>();

            return services;

        }

    }
}
