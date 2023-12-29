using ProyectoMerck.Models.Dtos;
using System.ComponentModel.DataAnnotations;

namespace ProyectoMerck.Models
{
    public class FertilitySubmitVM
    {

            public List<LocationDto> LocationsList { get; set; } = new List<LocationDto>();

            public List<ProvinceDto> ProvinceList { get; set; } = new List<ProvinceDto>();

            public List<CountryDto> CountryList { get; set; } = new List<CountryDto>();


            public List<ProvinceLocationDto> ProvinceLocationList = new List<ProvinceLocationDto>();

            public List<ConsultMotiveDto> ConsultMotiveList { get; set; } = new List<ConsultMotiveDto>();

            [Required(ErrorMessage = "Tiene que ingresar una motivo válido")]
            public string ConsultMotiveMessage { get; set; }
            public int SelectedCountry { get; set; }

            public int SelectedProvince { get; set; }

            public int SelectedProvinceLocation { get; set; }

            public string? Locations { get; set; }
            public int SelectedLocationIndex { get; set; }

            [Required(ErrorMessage = "Tiene que ingresar un email válido!")]
            public string UserEmail { get; set; }

            public bool SubmitError { get; set; }
        

    }
}
