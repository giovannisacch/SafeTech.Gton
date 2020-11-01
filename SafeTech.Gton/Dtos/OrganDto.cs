using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SafeTech.Gton.Dtos
{
    public class OrganDto
    {
        [Required(ErrorMessage = "MedicalUnityId é obrigatório")]
        public int MedicalUnityId { get; set; }
        [Required(ErrorMessage = "OrganTypeId é obrigatório")]
        public int OrganTypeId { get; set; }
        [Required(ErrorMessage = "Status é obrigatório")]
        public string Status { get; set; }
        [Required(ErrorMessage = "Availability é obrigatório")]
        public int Availability { get; set; }
        [Required(ErrorMessage = "Comments é obrigatório")]
        public string Comments { get; set; }
        [Required(ErrorMessage = "ReceiverPatientId é obrigatório")]
        public int ReceiverPatientId { get; set; }
        [Required(ErrorMessage = "GiverPatientId é obrigatório")]
        public int GiverPatientId { get; set; }
    }
}
