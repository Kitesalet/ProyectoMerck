using AutoMapper;
using Common_Layer.Models.Dtos;
using Common_Layer.Models.Entities;
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
            CreateMap<User,UserDto>().ReverseMap();
            CreateMap<ClinicConsultation, ClinicConsultationDto>();

        }

    }
}
