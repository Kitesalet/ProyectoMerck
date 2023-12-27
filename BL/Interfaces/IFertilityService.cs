using ProyectoMerck.Models.Dtos;

namespace ProyectoMerck.Models.Interfaces
{
    public interface IFertilityService
    {

        Task<bool> ConsultMailAsync(FertilitySubmitVM model);

        FertilityVM CalculateFertility(FertilityVM model);

        Task<FertilitySubmitVM> GetLists(FertilitySubmitVM model);

        Task<FertilitySubmitVM> GetListsFromCsv(FertilitySubmitVM model);



    }
}
