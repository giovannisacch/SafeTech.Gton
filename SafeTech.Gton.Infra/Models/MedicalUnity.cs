using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SafeTech.Gton.Infra.Data.Models
{
    public class MedicalUnity : BaseModel
    {
        [Column("nome")]
        public string Name { get; set; }
        [Column("idEndereco")]
        public int AddressId { get; set; }
        public Address Address { get; set; }

        [Column("tipo")]
        public string Type { get; set; }

        public List<Operation> OperationSourceCollection { get; set; }
        public List<Operation> OperationTargetCollection { get; set; }


    }
}
