using Microsoft.EntityFrameworkCore;
using ProyectoMerck.Models.Interfaces;

namespace ProyectoMerck.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {

            var entities = await _dbSet.ToListAsync();

            return entities;

        }
    }
}
