using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SafeTech.Gton.Infra.Data.Models
{
    public class Address : BaseModel
    {
        [Column("endereco")]
        public string Street { get; set; }
        [Column("bairro")]
        public string Neighborhood { get; set; }
        [Column("estado")]
        public string State { get; set; }
        [Column("numero")]
        public string Number { get; set; }
        [Column("complemento")]
        public string Complement { get; set; }
        [Column("cep")]
        public string CEP { get; set; }

        public MedicalUnity MedicalUnity { get; set; }



    }
}
