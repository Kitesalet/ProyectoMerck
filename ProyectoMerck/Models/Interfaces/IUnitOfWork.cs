using ProyectoMerck.DAL;
using ProyectoMerck.DAL.Repositories;

namespace ProyectoMerck.Models.Interfaces
{
    public interface IUnitOfWork
    {

        LocationRepository LocationRepository { get; }

        Task<int> Complete();

        void Dispose();
    }
}
