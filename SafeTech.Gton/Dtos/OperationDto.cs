using SafeTech.Gton.Infra.Data.Enums;
using SafeTech.Gton.Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeTech.Gton.Dtos
{
    public class OperationDto
    {
        public int Id { get; private set; }
        //SourceUnityId hardcoded devido a tempo e não faz parte do MVP, dessa forma nao tem que ser criado todo um crud
        public int SourceUnityId { get; private set; } = 1;
        //TargetUnityId hardcoded devido a tempo e não faz parte do MVP, dessa forma nao tem que ser criado todo um crud
        public int TargetUnityId { get; private set; } = 2;
        public string Type { get; set; }
        public int DurationMinutes { get; set; }
        public EOperationStatus Status { get; private set; } = EOperationStatus.Opened;
        public int OrganId { get; set; }
        public List<OperationHistoryDto> OperationHistoryCollection { get; private set; }
    }
}
