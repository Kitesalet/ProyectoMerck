using ProyectoMerck.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common_Layer.Models.Dtos
{
    public class ClinicConsultationDto
    {
        public int Id { get; set; }
        public string ConsultMotiveMessage { get; set; }
        public string Url { get; set; }
        public DateTime CreatedTime { get; set; }
        public int SelectedLocationIndex { get; set; }

    }
}
