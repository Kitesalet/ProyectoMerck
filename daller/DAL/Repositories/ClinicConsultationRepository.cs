using Common_Layer.Models.Entities;
using Data_Access_Layer.DAL.Interfaces;
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
        public ClinicConsultationRepository(AppDbContext context) : base(context)
        {
        }



    }
}
