using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SafeTech.Gton.Infra.Data.Models
{
    public class Organ : BaseModel
    {
        [Column("idUnidade")]
        public int MedicalUnityId { get; set; }
        public MedicalUnity MedicalUnity { get; set; }
        [Column("idTipoOrgao")]
        public int OrganTypeId { get; set; }
        public OrganType OrganType { get; set; }
        [Column("status")]
        public string Status { get; set; }
        [Column("disponibilidade")]
        public int Availability { get; set; }
        [Column("observacoes")]
        public string Comments  { get; set; }
        [Column("idPacienteReceptor")]
        public int ReceiverPatientId { get; set; }
        public Patient ReceiverPatient { get; set; }
        [Column("idPacienteDoador")]
        public int GiverPatientId { get; set; }
        public Patient GiverPatient { get; set; }
        public Operation Operation { get; set; }


    }
}
