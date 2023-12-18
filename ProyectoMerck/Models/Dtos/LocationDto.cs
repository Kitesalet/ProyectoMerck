using ProyectoMerck.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoMerck.Models.Dtos
{
    public class LocationDto
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }


        public int LocationId { get; set; }


        public int ProvinceLocationId { get; set; }
    }
}
