using ProyectoMerck.Models.Entities;

namespace ProyectoMerck.DAL.Repositories
{
    public class ProvinceLocationRepository : GenericRepository<ProvinceLocation>
    {
        public ProvinceLocationRepository(AppDbContext context) : base(context)
        {
        }
    }
}
