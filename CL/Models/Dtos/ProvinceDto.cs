using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoMerck.Models.Dtos
{
    public class ProvinceDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int CountryId { get; set; }

    }
}
