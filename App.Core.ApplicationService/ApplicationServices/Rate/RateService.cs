using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.Dtos.RateDto;
using App.Core.ApplicationService.IRepositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Core.ApplicationService.ApplicationServices.Rate
{
    public class RateService:IRateService
    {
        private IRepository<Entities.Rate> repository;
        private IRepository<Entities.Hotel> hotelRepository;

        public RateService(IRepository<Entities.Rate> repository,IRepository<Entities.Hotel> hotelRepository)
        {
            this.repository = repository;
            this.hotelRepository = hotelRepository;
        }

        public async Task<List<RateOutputDto>> GetAllRate()
        {
            var lst = repository.GetAll();
            var lstItem = repository.GetQuery()
                .Include(x=>x.Hotels).
                Select(x => new RateOutputDto()
            {
                RateNumber = x.RateNumber,
                Id = x.Id,
                Hotels =x.Hotels
            }).ToList();
            return lstItem;
        }

        public async Task<RateOutputDto> GetSingelRate(int id)
        {
            var item = repository.GetSingel(id);
            var SingelItem = hotelRepository.GetQuery().Where(x => x.RateId == id).ToList();
            var SingelRate = new RateOutputDto()
            {
                Id = item.Id,
                RateNumber = item.RateNumber,
                Hotels = SingelItem
            };
            return SingelRate;
        }
    }
}