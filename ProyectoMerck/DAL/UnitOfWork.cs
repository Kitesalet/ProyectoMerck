using ProyectoMerck.DAL.Repositories;
using ProyectoMerck.Models.Interfaces;

namespace ProyectoMerck.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public LocationRepository LocationRepository { get; }

        public UnitOfWork(AppDbContext context)
        {

            _context = context;

            LocationRepository = new LocationRepository(context);

        }

        public async Task<int> Complete()
        {

            return await _context.SaveChangesAsync();

        }

        public void Dispose()
        {

            _context.Dispose();

        }

    }
}
