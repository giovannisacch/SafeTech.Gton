using System.ComponentModel.DataAnnotations;


namespace SafeTech.Gton.Dtos
{
    public class OrganTypeDto
    {
        public int Id { get; private set; }
        [Required(ErrorMessage = "Name é obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage = "IschemiaTime é obrigatório")]
        public string IschemiaTime { get; set; }
        [Required(ErrorMessage = "TransfusionType é obrigatório")]
        public string TransfusionType { get; set; }
    }
}
