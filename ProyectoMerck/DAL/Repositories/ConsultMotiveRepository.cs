using ProyectoMerck.Models.Entities;

namespace ProyectoMerck.DAL.Repositories
{
    public class ConsultMotiveRepository : GenericRepository<ConsultMotive>
    {
        public ConsultMotiveRepository(AppDbContext context) : base(context)
        {
        }
    }
}
