using ProyectoMerck.DAL;
using ProyectoMerck.DAL.Repositories;

namespace Data_Access_Layer.DAL.Interfaces
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
