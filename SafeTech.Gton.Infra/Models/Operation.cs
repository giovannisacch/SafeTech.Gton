using SafeTech.Gton.Infra.Data.Enums;
using SafeTech.Gton.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace SafeTech.Gton.Infra.Data.Models
{
    public class Operation : BaseModel
    {
        //SourceUnityId hardcoded devido a tempo e não faz parte do MVP, dessa forma nao tem que ser criado todo um crud
        [Column("idUnidadeOrigem")]
        public int SourceUnityId { get; set; } = 1;
        public MedicalUnity SourceUnity { get; set; }
        //TargetUnityId hardcoded devido a tempo e não faz parte do MVP, dessa forma nao tem que ser criado todo um crud
        [Column("idUnidadeDestino")]
        public int TargetUnityId { get; set; } = 2;
        public MedicalUnity TargetUnity { get; set; }
        //AmbulanceId hardcoded devido a tempo e não faz parte do MVP, dessa forma nao tem que ser criado todo um crud
        [Column("idAmbulancia")]
        public int AmbulanceId { get; set; } = 1;
        [Column("tipo")]
        public string Type { get; set; }
        [Column("duracaoMinutos")]
        public int DurationMinutes { get; set; }
        [Column("status")]
        public EOperationStatus Status { get; set; }
        [Column("idOrgao")]
        public int OrganId { get; set; }
        public Organ Organ { get; set; }

        public List<OperationHistory> OperationHistoryCollection { get; set; }

        public void AddNewOperationHistory()
        {
            if (OperationHistoryCollection == null || OperationHistoryCollection.Count == 0)
            {
                OperationHistoryCollection = new List<OperationHistory>()
                {
                    new OperationHistory()
                        {
                            InitDate = DateTime.Now,
                            Status = EOperationStepStatus.Started,
                            OperationId = this.Id
                        }
                };
                return;
            }
            var lastOperation = OperationHistoryCollection.OrderByDescending(x => x.Status).First();
            var nextOperationStepStatusInt = (int)lastOperation.Status + 1;
            OperationHistoryCollection.Add
                (
                    new OperationHistory()
                    { 
                        InitDate = DateTime.Now,
                        Status = (EOperationStepStatus)nextOperationStepStatusInt
                    }
                 );
        }
    }
}
