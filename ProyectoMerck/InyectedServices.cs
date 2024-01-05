using Busisness_Layer.Interfaces;
using Busisness_Layer.Services;
using Common_Layer.Models.Entities;
using Data_Access_Layer.DAL.Interfaces;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProyectoMerck.DAL;
using ProyectoMerck.DAL.Repositories;
using ProyectoMerck.Helpers;
using ProyectoMerck.Models.Entities;
using ProyectoMerck.Models.Interfaces;
using ProyectoMerck.Services;
using Utility_Layer.Helpers;

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

            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
            services.AddScoped<PdfService>();
            services.AddAutoMapper(typeof(MapperHelper));

            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IFertilityService, FertilityService>();
            services.AddScoped<IUserService, UserService>();

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;

                options.User.RequireUniqueEmail = true;


            }).AddEntityFrameworkStores<AppDbContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.Events.OnRedirectToLogin = context =>
                {
                    context.Response.StatusCode = 401;
                    return Task.CompletedTask;
                };

                options.Events.OnRedirectToAccessDenied = context =>
                {
                    context.Response.StatusCode = 401;
                    return Task.CompletedTask;
                };
            });

            //services.ConfigureApplicationCookie(options =>
            //{
            //    options.ExpireTimeSpan = TimeSpan.FromMinutes(1);
            //});

            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //    .AddCookie(options =>
            //    {
            //        options.Cookie.HttpOnly = true;
            //        options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
            //    });

            return services;

        }

    }
}
