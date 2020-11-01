using SafeTech.Gton.Infra.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeTech.Gton.Dtos
{
    public class OperationHistoryDto
    {
        public DateTime InitDate { get; set; }
        public DateTime EndDate { get; set; }
        public EOperationStepStatus Status { get; set; }
    }
}
