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
        [Column("tempoIsquemia")]
        public string IschemiaTime { get; set; }
        [Column("tipoTransfusao")]
        public string TransfusionType { get; set; }
        public List<Organ> OrganCollection { get; set; }
    }
}
