using ProyectoMerck.Models.Entities;

namespace ProyectoMerck.DAL.Repositories
{
    public class ProvinceRepository : GenericRepository<Province>
    {
        public ProvinceRepository(AppDbContext context) : base(context)
        {



        }
    }
}
