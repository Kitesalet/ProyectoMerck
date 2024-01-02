using Data_Access_Layer.DAL.Interfaces;
using ProyectoMerck.DAL.Repositories;

namespace ProyectoMerck.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public LocationRepository LocationRepository { get; }

        public CountryRepository CountryRepository { get; }

        public ProvinceRepository ProvinceRepository { get; }

        public ProvinceLocationRepository ProvinceLocationRepository { get; }

        public ConsultMotiveRepository ConsultMotiveRepository { get; set; }
        public UnitOfWork(AppDbContext context)
        {

            _context = context;

            LocationRepository = new LocationRepository(context);
            CountryRepository = new CountryRepository(context);
            ProvinceRepository = new ProvinceRepository(context);
            ProvinceLocationRepository = new ProvinceLocationRepository(context);
            ConsultMotiveRepository = new ConsultMotiveRepository(context);

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
