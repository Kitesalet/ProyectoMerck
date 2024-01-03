using Common_Layer.Models.Entities;
using Data_Access_Layer.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using ProyectoMerck.DAL;
using ProyectoMerck.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_layer.DAL.Repositories
{
    public class ClinicConsultationRepository : GenericRepository<ClinicConsultation>
    {

        public readonly AppDbContext _context;
        public ClinicConsultationRepository(AppDbContext context) : base(context)
        {

            _context = context;

        }



        public async Task<IEnumerable<ClinicConsultation>> GetDateIntervalFiltered(DateTime startDate, DateTime endDate)
        {

            var filteredEntities = await _context.ClinicConsultations.Where(e => e.CreatedTime >= startDate && e.CreatedTime <= endDate)
                                                                     .ToListAsync();

            return filteredEntities;

        }


    }
}
