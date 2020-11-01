using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SafeTech.Gton.Infra.Data.Models
{
    public class OrganType : BaseModel
    {
        [Column("nome")]
        public string Name { get; set; }
        [Column("tipoIsquemia")]
        public string IschemiaType { get; set; }
        [Column("tipoTransfusao")]
        public int TransfusionType { get; set; }
        public List<Organ> OrganCollection { get; set; }
    }
}
