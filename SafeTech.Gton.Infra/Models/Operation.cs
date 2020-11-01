using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace SafeTech.Gton.Infra.Data.Models
{
    public class Operation : BaseModel
    {
        [Column("idUnidade_origem")]
        public int SourceUnityId { get; set; }
        public MedicalUnity SourceUnity { get; set; }
        [Column("idUnidade_destino")]
        public int TargetUnityId { get; set; }
        public MedicalUnity TargetUnity { get; set; }

        [IgnoreDataMember()]
        public int AmbulanceId { get; set; }

        [Column("tipo")]
        public string Type { get; set; }
        [Column("duracao")]
        public int Duration { get; set; }
        [Column("status")]
        public int Status { get; set; }
        [Column("idOrgan")]
        public int OrganId { get; set; }
        public Organ Organ { get; set; }

    }
}
