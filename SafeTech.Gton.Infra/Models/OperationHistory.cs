using SafeTech.Gton.Infra.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SafeTech.Gton.Infra.Data.Models
{
    public class OperationHistory : BaseModel
    {
        [Column("idOperacao")]
        public int OperationId { get; set; }
        public Operation Operation { get; set; }
        [Column("horarioInicio")]
        public DateTime InitDate { get; set; }
        [Column("horarioTermino")]
        public DateTime EndDate { get; set; }
        [Column("status")]
        public EOperationStepStatus Status { get; set; }
    }
}
