using ProyectoMerck.Models.Entities;

namespace ProyectoMerck.DAL.Repositories
{
    public class CountryRepository : GenericRepository<Country>
    {
        public CountryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
