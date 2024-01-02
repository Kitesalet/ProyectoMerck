using Data_Access_Layer.DAL.Interfaces;
using ProyectoMerck.Models.Entities;

namespace ProyectoMerck.DAL.Repositories
{
    public class LocationRepository : GenericRepository<Location> , ILocationRepository
    {
        public LocationRepository(AppDbContext context) : base(context)
        {
        }


    }
}
