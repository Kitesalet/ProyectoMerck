using Data_Access_Layer.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ProyectoMerck.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task Create(T entity)
        {
            try
            {
                var obj = await _dbSet.AddAsync(entity);

            }
            catch
            {

            }

        }

        public async Task<IEnumerable<T>> GetAll()
        {

            List<T> entities = await _dbSet.ToListAsync();

            return entities;

        }

        public async Task<T> GetById(int id)
        {

            T entity = await _dbSet.FindAsync(id);

            return entity;

        }
    }
}
