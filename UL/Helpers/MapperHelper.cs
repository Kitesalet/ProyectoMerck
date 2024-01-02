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
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Province,ProvinceDto>().ReverseMap();
            CreateMap<ProvinceLocation,ProvinceLocationDto>().ReverseMap();
            CreateMap<ConsultMotive,ConsultMotiveDto>().ReverseMap();

        }

    }
}
