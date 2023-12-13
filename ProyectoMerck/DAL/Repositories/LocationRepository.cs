using ProyectoMerck.Models.Entities;
using ProyectoMerck.Models.Interfaces;

namespace ProyectoMerck.DAL.Repositories
{
    public class LocationRepository : GenericRepository<Location> , ILocationRepository
    {
        public LocationRepository(AppDbContext context) : base(context)
        {
        }


    }
}
