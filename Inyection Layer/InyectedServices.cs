using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

        public static void ServiceInyector(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<AppDbContext>(c => c.UseSqlServer(configuration.GetConnectionString("Hosted")));

            services.AddScoped<IGenericRepository<Location>, GenericRepository<Location>>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(typeof(MapperHelper));

            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IFertilityService, FertilityService>();


        }

    }
}
