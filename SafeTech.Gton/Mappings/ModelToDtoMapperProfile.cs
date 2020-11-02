using AutoMapper;
using SafeTech.Gton.Dtos;
using SafeTech.Gton.Dtos.Screen;
using SafeTech.Gton.Infra.Data.Models;
using System.Linq;
using SafeTech.Gton.Infra.Data.Enums;

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
            CreateMap<User, UserDto>();

            CreateMap<User, HomeScreenResponseDto>()
                .ForMember(x => x.Operations, 
                            dtoProp => dtoProp.MapFrom(model => model.MedicalUnity.OperationSourceCollection)
                            )
                .ForMember(x => x.User,
                            dtopProp => dtopProp.MapFrom(x => x)
                            );

            CreateMap<Operation, HomeScreenOperationResponseDto>()
                .ForMember(x => x.OrganType, 
                                dtoProp => dtoProp.MapFrom(model => model.Organ.OrganType.Name.ToUpper())
                            )
                .ForMember(x => x.Status, 
                                dtoProp => dtoProp.MapFrom(model => model.Status)
                            )
                .ForMember(x => x.Date,
                                dtoProp => dtoProp.MapFrom(model => model.OperationHistoryCollection.FirstOrDefault(x => x.Status == EOperationStepStatus.Started).InitDate.ToString("MM/dd/yyyy"))
                            )
                .ForMember(x => x.Hour,
                                dtoProp => dtoProp.MapFrom(model => model.OperationHistoryCollection.FirstOrDefault(x => x.Status == EOperationStepStatus.Started).InitDate.ToString("hh:mm") + "H")
                            );

            CreateMap<Operation, OperationScreenResponseDto>()
                .ForMember(x => x.Giver,
                                dtoProp => dtoProp.MapFrom(model => model.Organ.GiverPatient)
                           )
                 .ForMember(x => x.Receiver,
                                dtoProp => dtoProp.MapFrom(model => model.Organ.ReceiverPatient)
                           )
                 .ForMember(x => x.LastStatus,
                             dtoProp => dtoProp.MapFrom(model => model.OperationHistoryCollection.OrderByDescending(x => x.Status).FirstOrDefault())
                            );

            CreateMap<Patient, OperationScreenPatientResponseDto>();

            CreateMap<OperationHistory, OperationStatusDto>()
                 .ForMember(x => x.Hour,
                             dtoProp => dtoProp.MapFrom(model => model.InitDate.ToString("hh:mm") + "H")
                            )
                 .ForMember(x => x.RouteType,
                                dtoProp => dtoProp.MapFrom(model => (int)model.Status)
                            );

            CreateMap<Operation, OperationStepsScreenResponseDto>()
                .ForMember(x => x.Status,
                             dtoProp => dtoProp.MapFrom(model => model.OperationHistoryCollection.OrderByDescending(x => x.Status))
                            )
                .ForMember(x => x.Prevision,
                            dtoProp => dtoProp.MapFrom(model => model)
                );

            CreateMap<Operation, OperationStepScreenPrevisionResponseDto>()
                .ForMember(x => x.DestinationName,
                                dtoProp => dtoProp.MapFrom(model => model.TargetUnity.Name)
                           )
                .ForMember(x => x.Hour,
                                dtoProp => dtoProp.MapFrom(model => 
                                            model.OperationHistoryCollection.First(x => x.Status == EOperationStepStatus.Started)
                                                                            .InitDate.AddMinutes(model.DurationMinutes).ToString("hh:mm")+ "H")
                );
        }
    }
}
