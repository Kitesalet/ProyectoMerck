namespace ProyectoMerck.Models.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {

        public Task<IEnumerable<T>> GetAll();


    }
}
