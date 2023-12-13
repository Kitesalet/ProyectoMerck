using ProyectoMerck.Models.Dtos;

namespace ProyectoMerck.Models.Interfaces
{
    public interface IFertilityService
    {

        Task<bool> ConsultMailAsync(FertilityVM model);

        Task<FertilityVM> ClinicLocations(FertilityVM model);

        FertilityVM CalculateFertility(FertilityVM model);

    }
}
