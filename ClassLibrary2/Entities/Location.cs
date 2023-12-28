using System.ComponentModel.DataAnnotations;

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

    }
}
