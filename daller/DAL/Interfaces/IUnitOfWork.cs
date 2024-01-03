using DataAccess_layer.DAL.Repositories;
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

        ClinicConsultationRepository ClinicConsultationRepository { get; }

        UserRepository UserRepository { get; }
        Task<int> Complete();

        void Dispose();
    }
}
