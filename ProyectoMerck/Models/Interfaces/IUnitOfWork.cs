using ProyectoMerck.DAL;
using ProyectoMerck.DAL.Repositories;

namespace ProyectoMerck.Models.Interfaces
{
    public interface IUnitOfWork
    {

        LocationRepository LocationRepository { get; }

        CountryRepository CountryRepository { get; }

        ProvinceRepository ProvinceRepository { get; }

        ProvinceLocationRepository ProvinceLocationRepository { get; }

        ConsultMotiveRepository ConsultMotiveRepository { get; }
        Task<int> Complete();

        void Dispose();
    }
}
