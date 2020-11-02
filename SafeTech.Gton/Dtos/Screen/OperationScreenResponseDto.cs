using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeTech.Gton.Dtos.Screen
{
    public class OperationScreenResponseDto
    {
        public OperationScreenPatientResponseDto Receiver { get; set; }
        public OperationScreenPatientResponseDto Giver { get; set; }
        public OperationStatusDto LastStatus { get; set; }
    }
    public class OperationScreenPatientResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string BirthDate { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string BloodType { get; set; }
        public string DegenerativeDisease { get; set; }
        public string ResponsibleName { get; set; }
        public string Organ { get; set; }
        public string TransplantType { get; set; }
    }
}
