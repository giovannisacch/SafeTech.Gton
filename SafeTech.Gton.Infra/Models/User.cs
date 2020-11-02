using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SafeTech.Gton.Infra.Data.Models
{
    public class User : BaseModel
    {
        [Column("nome")]
        public string Name { get; set; }
        [Column("cargo")]
        public string JobTitle { get; set; }
        [Column("status")]
        public int Status { get; set; }
        [Column("login")]
        public string Login { get; set; }
        [Column("dataCadastro")]
        public DateTime RegisteredDate { get; set; }
        [Column("idunidade")]
        public int MedicalUnityId { get; set; }
        public MedicalUnity MedicalUnity { get; set; }
        [Column("senha")]
        public string Password { get; set; }
        [Column("numTelefone")]
        public string PhoneNumber { get; set; }
        [Column("imagem")]
        public byte[] ImageByteBase { get; set; }
    }
}
