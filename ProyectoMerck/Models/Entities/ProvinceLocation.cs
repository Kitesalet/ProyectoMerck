using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoMerck.Models.Entities
{
    public class ProvinceLocation
    {

        [Key]

        public int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("Province")]    
        public int ProvinceId { get; set; }

        public Province Province { get; set; }
        

    }
}
