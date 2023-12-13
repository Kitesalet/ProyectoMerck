using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProyectoMerck.DAL;
using ProyectoMerck.DAL.Repositories;
using ProyectoMerck.Helpers;
using ProyectoMerck.Models.Entities;
using ProyectoMerck.Models.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(c => c.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<IGenericRepository<Location>, GenericRepository<Location>>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(typeof(MapperHelper));

builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IFertilityService, IFertilityService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Fertility}/{action=Index}/{id?}");

app.Run();
