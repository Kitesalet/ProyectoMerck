using ProyectoMerck.Models.Dtos;
using ProyectoMerck.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common_Layer.Models.Entities
{
    public class ClinicConsultation
    {
        [Key]
        public int Id { get; set; }
        public string ConsultMotiveMessage { get; set; }

        public DateTime CreatedTime { get; set; }

        public string Url { get;set; }

        [ForeignKey("Location")]
        public int SelectedLocationIndex { get; set; }
        public Location Location { get; set; }

    }
}
