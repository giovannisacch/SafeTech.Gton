using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeTech.Gton.Dtos.Screen
{
    public class OperationStepsScreenResponseDto
    {
        public List<OperationStatusDto> Status { get; set; }
        public OperationStepScreenPrevisionResponseDto Prevision { get; set; }
    }

    public class OperationStepScreenPrevisionResponseDto
    {
        public string Hour { get; set; }
        public string DestinationName { get; set; }
    }
}
