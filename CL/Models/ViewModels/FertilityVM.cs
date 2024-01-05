using System.ComponentModel.DataAnnotations;
using ProyectoMerck.Models.Dtos;
using ProyectoMerck.Models.Entities;

namespace Common_Layer.Models.ViewModels
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


    }
}
