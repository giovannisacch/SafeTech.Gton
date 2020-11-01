using AutoMapper;
using SafeTech.Gton.Dtos;
using SafeTech.Gton.Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeTech.Gton.Mappings
{
    public class ModelToDtoMapperProfile : Profile
    {
        public ModelToDtoMapperProfile()
        {
            CreateMap<Patient, PatientDto>();
            CreateMap<Organ, OrganDto>();
            CreateMap<OrganType, OrganTypeDto>();
            CreateMap<Operation, OperationDto>();
            CreateMap<OperationHistory, OperationHistoryDto>();

        }
    }
}
