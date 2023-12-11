using AutoMapper;
using ProyectoMerck.Models.Dtos;
using ProyectoMerck.Models.Entities;

namespace ProyectoMerck.Helpers
{
    public class MapperHelper : Profile
    {

        public MapperHelper()
        {

            CreateMap<Location, LocationDto>().ReverseMap();

        }

    }
}
