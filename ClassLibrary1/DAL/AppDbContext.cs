
using Microsoft.EntityFrameworkCore;
using ProyectoMerck.Models.Entities;

namespace ProyectoMerck.DAL
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }


        //Tables
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Location>().HasData(
                new Location()
                {
                    Id = 1,
                    Latitude = -34.600677504040895,
                    Longitude = -58.387263729958455,
                    Title = "CEGYR",
                    Subtitle = "Centro Fertilidad"
                }, new Location()
                {
                    Id = 2,
                    Latitude = -34.58070285263448,
                    Longitude = -58.43026097362766,
                    Title = "CER",
                    Subtitle = "Centro Fertilidad"
                }, new Location()
                {
                    Id = 3,
                    Latitude = -34.578846588221204,
                    Longitude = -58.46010393197798,
                    Title = "CIMER",
                    Subtitle = "Centro Fertilidad"
                }, new Location()
                {
                    Id = 4,
                    Latitude = -34.59925473372724,
                    Longitude = -58.40181033949003,
                    Title = "CRECER",
                    Subtitle = "Centro Fertilidad"
                }, new Location()
                {
                    Id = 5,
                    Latitude = -34.59743905645921,
                    Longitude =  -58.39718927947347,
                    Title = "HIALITUS",
                    Subtitle = "Centro Fertilidad"
                }, new Location()
                {
                    Id = 6,
                    Latitude = -34.6062022234174,
                    Longitude = -58.425645264604945,
                    Title = "HOSPITAL ITALIANO",
                    Subtitle = "Centro Fertilidad"
                }, new Location()
                {
                    Id = 7,
                    Latitude = -34.596689236707874,
                    Longitude =  -58.39973481534347,
                    Title = "IFER",
                    Subtitle = "Centro Fertilidad"
                }, new Location()
                {
                    Id = 8,
                    Latitude = -34.55712898207461,
                    Longitude = -58.44761812883586,
                    Title = "WEFIV",
                    Subtitle = "Centro Fertilidad"
                }
                );
        }

    }
}
