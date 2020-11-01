using System.ComponentModel.DataAnnotations;

namespace SafeTech.Gton.Dtos
{
    public class OrganDto
    {
        public int Id { get; private set; }
        [Required(ErrorMessage = "OrganTypeId é obrigatório")]
        public int OrganTypeId { get; set; }
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
