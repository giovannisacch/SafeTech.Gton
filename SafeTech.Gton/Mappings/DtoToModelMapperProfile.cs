using AutoMapper;
using SafeTech.Gton.Dtos;
using SafeTech.Gton.Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeTech.Gton.Mappings
{
    public class DtoToModelMapperProfile : Profile
    {
        public DtoToModelMapperProfile()
        {
            CreateMap<PatientDto, Patient>();
            CreateMap<OrganDto, Organ>();
            CreateMap<OrganTypeDto, OrganType>();
            CreateMap<OperationDto, Operation>();
            CreateMap<OperationHistoryDto, OperationHistory>();
        }
    }
}
