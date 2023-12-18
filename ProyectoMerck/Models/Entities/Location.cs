using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoMerck.Models.Entities
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }


        [ForeignKey(nameof(ProvinceLocation))]
        public int ProvinceLocationId { get; set; }
        public ProvinceLocation ProvinceLocation { get; set; }
    }
}
