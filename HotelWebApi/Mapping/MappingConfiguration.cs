using App.Core.ApplicationService.Dtos.CityDto;
using App.Core.Entities;
using AutoMapper;
using Hotel.Core.ApplicationService.Dtos.HotelDto;


namespace App.Core.ApplicationService.Mapping
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