using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoMerck.Models.Dtos
{
    public class ProvinceLocationDto
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public int ProvinceId { get; set; }


    }
}
