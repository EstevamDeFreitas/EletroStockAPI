using AutoMapper;
using Domain.Entities;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Utilities
{
    public class MapperConfig : MapperConfigurationExpression
    {
        public MapperConfig()
        {
            CreateMap<InactiveCategoryDTO, InactiveCategory>().ReverseMap();
            CreateMap<InactiveReasonDTO, InactiveReason>().ReverseMap();
        }
    }
}
