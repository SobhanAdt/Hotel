using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.Dtos.CityDto;
using App.Core.Entities;
using AutoMapper;

namespace HotelWebApplication.Mapping
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<City, CityOutputDto>();

            CreateMap<CityInsertInputDto, City>();



        }
    }
}
