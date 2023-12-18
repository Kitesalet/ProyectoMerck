using System.ComponentModel.DataAnnotations;
using ProyectoMerck.Models.Dtos;
using ProyectoMerck.Models.Entities;

namespace ProyectoMerck.Models
{
    public class FertilityVM
    {
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Las edades tienen que estar comprendidas entre 12 y 57!")]
        public int ActualAge { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Las edades tienen que estar comprendidas entre 12 y 57!")]
        public int FirstAge { get; set; }
        public int OvuleCount { get; set; }
        public FertilityLevel FertilityLevel { get; set; }

        public List<LocationDto> LocationsList { get; set; } = new List<LocationDto>();

        public List<ProvinceDto> ProvinceList { get; set; } = new List<ProvinceDto>();

        public List<CountryDto> CountryList { get; set; } = new List<CountryDto>();


        public List<ProvinceLocationDto> ProvinceLocationList = new List<ProvinceLocationDto>();

        public int SelectedCountry { get; set; }

        public int SelectedProvince { get; set; }

        public int SelectedProvinceLocation { get; set; }   

        public string? Locations { get; set; } 
        public string? ConsultMotive { get; set; }

        public int SelectedLocationIndex { get; set; }

        public string? UserEmail { get; set; }

    }
}
