using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.RegularExpressions;

namespace SafeTech.Gton.Infra.Data.Models
{
    public class Patient : BaseModel
    {
        [Column("nome")]
        public string Name { get;  set; }
        [Column("sexo")]
        public string Gender { get; set; }
        [Column("nascimento")]
        public DateTime BirthDate { get; set; }
        [Column("RG")]
        public string RG { get; set; }
        [Column("CPF")]
        public string CPF { get; set; }
        [Column("tipoSanguineo")]
        public string BloodType { get; set; }
        [Column("doencasDegenerativas")]
        public string DegenerativeDisease { get; set; }
        [Column("lesoes")]
        public string Injuries { get; set; }
        [Column("responsavel")]
        public string ResponsibleName { get; set; }
        [Column("tipoTransplante")]
        public string TransplantType { get; set; }
        public Patient()
        {

        }
     
        public List<Organ> DonatedOrgan { get; set; }
        public List<Organ> ReceivedOrgan { get; set; }


    }
}
