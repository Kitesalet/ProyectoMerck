namespace Data_Access_Layer.DAL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {

        public Task<IEnumerable<T>> GetAll();

        public Task Create(T entity);

    }
}
