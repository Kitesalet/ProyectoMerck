using Data_Access_Layer.DAL.Interfaces;
using DataAccess_layer.DAL.Repositories;
using ProyectoMerck.DAL.Repositories;

namespace ProyectoMerck.DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;
        public LocationRepository LocationRepository { get; }

        public CountryRepository CountryRepository { get; }

        public ProvinceRepository ProvinceRepository { get; }

        public ProvinceLocationRepository ProvinceLocationRepository { get; }

        public ConsultMotiveRepository ConsultMotiveRepository { get; }

        public UserRepository UserRepository { get; }

        public ClinicConsultationRepository ClinicConsultationRepository { get; }

        public UnitOfWork(AppDbContext context)
        {

            _context = context;

            LocationRepository = new LocationRepository(context);
            CountryRepository = new CountryRepository(context);
            ProvinceRepository = new ProvinceRepository(context);
            ProvinceLocationRepository = new ProvinceLocationRepository(context);
            ConsultMotiveRepository = new ConsultMotiveRepository(context);
            UserRepository = new UserRepository(context);
            CountryRepository = new CountryRepository(context);
            ClinicConsultationRepository = new ClinicConsultationRepository(context);

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
