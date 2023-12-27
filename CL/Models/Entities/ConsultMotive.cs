using System.ComponentModel.DataAnnotations;

namespace ProyectoMerck.Models.Entities
{
    public class ConsultMotive
    {

        [Key]
        public int Id { get; set; }

        public string ConsultMotiveX { get; set; }

    }
}
