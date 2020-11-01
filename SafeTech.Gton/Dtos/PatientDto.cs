using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SafeTech.Gton.Dtos
{
    public class PatientDto
    {
        [Required(ErrorMessage = "Name é obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Gender é obrigatório")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "BirthDate é obrigatório")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "RG é obrigatório")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Apenas números são permitidos")]
        public string RG
        {
            get { return this._rg; }
            set { _rg = Regex.Replace(value, "[^0-9,]", ""); } 
        }
        [Required(ErrorMessage = "CPF é obrigatório")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Apenas números são permitidos")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "CPF tem que ter 11 números")]
        public string CPF
        {
            get { return this._cpf; }
            set { _cpf = Regex.Replace(value, "[^0-9,]", ""); }
        }
        [Required(ErrorMessage = "BirthDate é obrigatório")]
        public string BloodType { get; set; }
        [Required(ErrorMessage = "BirthDate é obrigatório")]
        public string DegenerativeDisease { get; set; }
        [Required(ErrorMessage = "BirthDate é obrigatório")]
        public string Injuries { get; set; }
        [Required(ErrorMessage = "BirthDate é obrigatório")]
        public string ResponsibleName { get; set; }
        [Required(ErrorMessage = "BirthDate é obrigatório")]
        public string TransplantType { get; set; }


        #region private properties
        private string _rg;
        private string _cpf;
        #endregion
    }
}
