using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeTech.Gton.Mappings
{
    public class AutoMapperConfig
    {
        public static IMapper RegisterMappings()
        {
            return new MapperConfiguration(x =>
            {
                x.AddProfile(new ModelToDtoMapperProfile());
                x.AddProfile(new DtoToModelMapperProfile());
            }).CreateMapper();
        }
    }
}
