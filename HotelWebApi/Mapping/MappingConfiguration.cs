using App.Core.ApplicationService.Dtos.CityDto;
using App.Core.Entities;
using AutoMapper;
using Hotel.Core.ApplicationService.Dtos.HotelDto;


namespace App.Core.ApplicationService.Mapping
{
    public class MappingConfiguration:Profile
    {
        public MappingConfiguration()
        {
            CreateMap<City, CityOutputDto>();

            CreateMap<CityInsertInputDto, City>();

            CreateMap<App.Core.Entities.Hotel, HotelCompareOutPutDto>()
                .ForMember(x => x.HotelName , o => o.MapFrom(z=>z.HotelName))
                .ForMember(x => x.HotelCode , o =>o.MapFrom(z=>z.HotelCode))
                .ForMember(x => x.RoomCount , o => o.MapFrom(z=>z.RoomCount))
                .ForMember(x => x.CityId, o => o.MapFrom(z => z.CityId))
                 .ForMember(x => x.StarId, o => o.MapFrom(z => z.StarId));
           

        }
    }
}