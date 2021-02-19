using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading.Tasks;
using App.Core.ApplicationService.Dtos.HotelDto;
using App.Core.ApplicationService.IRepositories;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using App.Core.ApplicationService.Dtos.Userto;
using App.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Hotel.Core.ApplicationService.Dtos.HotelDto;
using AutoMapper;

namespace App.Core.ApplicationService.ApplicationServices.Hotel
{
    public class HotelService : IHotelService

    {
        private IRepository<Entities.Hotel> repository;
        private IRepository<UserRate> userRateRepository;
        private readonly IMapper mapper;

        public HotelService(IRepository<Entities.Hotel> repository,
                            IRepository<UserRate> userRateRepository, IMapper mapper)
        {
            this.repository = repository;
            this.userRateRepository = userRateRepository;
            this.mapper = mapper;
        }

        public async Task<string> Create(HotelInsertInputDto inputDto)
        {
            var hotelValidation = await repository.GetQuery().
                Where(x => x.HotelName == inputDto.HotelName && x.CityId == inputDto.CityId)
                .FirstOrDefaultAsync();

            if (inputDto.HotelCode == hotelValidation.HotelCode)
            {
                return null;
            }

            repository.Insert(new Entities.Hotel()
            {
                HotelName = inputDto.HotelName,
                HotelCode = inputDto.HotelCode,
                CityId = inputDto.CityId,
                RoomCount = inputDto.RoomCount,
                StarId = inputDto.StarId,
                Description = inputDto.Description
            });
            await repository.Save();
            return $" {inputDto.HotelName} Created in DataBase";
        }


        public List<HotelGetOutPutDto> GetAllHotels()
        {
            var lst = repository.GetQuery()
                .Include(x => x.Rooms);

            var userRate = userRateRepository.GetQuery().
                Where(w => w.HotelId == w.Hotel.Id)
                .GroupBy(x => x.HotelId).Select(x => new HotelGetOutPutDto()
                {
                    Id = x.Key,
                    Rate = x.Average(x => x.RateNumber)
                }).ToList();


            var ListHotelId = userRate.Select(x => x.Id).ToList();

            var ListHotel = lst.Select(x => new HotelGetOutPutDto()
            {
                HotelName = x.HotelName,
                Id = x.Id,
                HotelCode = x.HotelCode,
                RoomCount = x.RoomCount,
                Description = x.Description,
                StarId = x.StarId,
                CityId = x.CityId,
                Reviews = x.Reviews.Select(y => new ReviewDTO()
                {
                    UserId = y.UserId,
                    Id = y.Id,
                    Comment = y.Comment
                }).ToList()
            }).ToList();

            foreach (var item in ListHotel)
            {

                if (ListHotelId.Contains(item.Id))
                {
                    item.Rate = userRate.Where(x => x.Id == item.Id).FirstOrDefault().Rate;
                }
            }


            return ListHotel;

        }

        public async Task<HotelGetOutPutDto> GetSingleHotel(int id)
        {
            var item = await repository.GetQuery()
                .Include(x => x.Rooms).Where(x => x.Id == id)
                .Include(x => x.Reviews).Where(x => x.Id == id).FirstOrDefaultAsync();

            var userRate = userRateRepository.GetQuery()
                .Where(w => w.HotelId == id)
                .GroupBy(x => x.HotelId).Select(x => new HotelGetOutPutDto()
                {
                    Rate = x.Average(x => x.RateNumber)
                }).FirstOrDefault();

            return new HotelGetOutPutDto()
            {
                Id = item.Id,
                HotelName = item.HotelName,
                HotelCode = item.HotelCode,
                RoomCount = item.RoomCount,
                CityId = item.CityId,
                StarId = item.StarId,
                Description = item.Description,
                Rate = userRate.Rate,
                Reviews = item.Reviews.Select(x => new ReviewDTO()
                {
                    UserId = x.UserId,
                    Id = x.Id,
                    Comment = x.Comment
                }).ToList()
            };
        }

        public async Task<string> DeleteHotels(int id)
        {
            await repository.Delete(id);
            await repository.Save();
            return "Delete Anjam shod";
        }

        public Task<List<HotelGetOutPutDto>> SixNewInsertHotel()
        {
            var SixNewHotel = repository.GetQuery().OrderByDescending(x => x.Id).Take(6);

            return SixNewHotel.Select(x => new HotelGetOutPutDto()
            {
                HotelName = x.HotelName,
                Id = x.Id,
                HotelCode = x.HotelCode,
                RoomCount = x.RoomCount,
                Description = x.Description,
                StarId = x.StarId,
                CityId = x.CityId,
                Reviews = x.Reviews.Select(x => new ReviewDTO()
                {
                    UserId = x.UserId,
                    Id = x.Id,
                    Comment = x.Comment
                }).ToList()
            }).ToListAsync();
        }

        public async Task<string> Update(HotelUpdateInputDto updateDto)
        {

            var item = repository.GetSingel(updateDto.Id);
            if (item == null)
            {
                return "Null";
            }

            item.HotelName = updateDto.HotelName;
            item.CityId = updateDto.CityId;
            item.StarId = updateDto.StarId;
            item.RoomCount = updateDto.RoomCount;
            await repository.Save();
            return $"Updating {updateDto.HotelName} has Successfuled";
        }

        public async Task<List<HotelGetOutPutDto>> HotelCompare(HotelCompareInputDto input)
        {
            if (input.Hotels.Count < 2)
            {
                return null;
            }

            var Hotel1 = repository.GetQuery().FirstOrDefault(x => x.HotelName == input.Hotels[0]);

            var Hotel2 = repository.GetQuery().FirstOrDefault(x => x.HotelName == input.Hotels[1]);

            var userRate1 = userRateRepository.GetQuery()
                .Where(w => w.HotelId == Hotel1.Id)
                .GroupBy(x => x.HotelId).Select(x => new HotelGetOutPutDto()
                {
                    Rate = x.Average(x => x.RateNumber)
                }).FirstOrDefault();

            var userRate2 = userRateRepository.GetQuery()
                .Where(w => w.HotelId == Hotel2.Id)
                .GroupBy(x => x.HotelId).Select(x => new HotelGetOutPutDto()
                {
                    Rate = x.Average(x => x.RateNumber)
                }).FirstOrDefault();

            var Hotel11 = new HotelGetOutPutDto()
            {
                HotelName = Hotel1.HotelName,
                CityId = Hotel1.CityId,
                Description = Hotel1.Description,
                HotelCode = Hotel1.HotelCode,
                RoomCount = Hotel1.RoomCount,
                StarId = Hotel1.StarId,
                Id = Hotel1.Id,
                Rate = userRate1.Rate   
            };
            var Hotel22 = new HotelGetOutPutDto()
            {
                HotelName = Hotel2.HotelName,
                CityId = Hotel2.CityId,
                Description = Hotel2.Description,
                HotelCode = Hotel2.HotelCode,
                RoomCount = Hotel2.RoomCount,
                StarId = Hotel2.StarId,
                Id = Hotel2.Id,
                Rate = userRate2.Rate
            };
            var HotelCompareLst = new List<HotelGetOutPutDto>();
            HotelCompareLst.Add(Hotel11);
            HotelCompareLst.Add(Hotel22);
            return HotelCompareLst;

        }

        public List<HotelGetOutPutDto> GetTopHotelRate()
        {
            var lst = repository.GetQuery()
                .Include(x => x.Rooms);

            var userRate = userRateRepository.GetQuery().
                Where(w => w.HotelId == w.Hotel.Id)
                .GroupBy(x => x.HotelId).Select(x => new HotelGetOutPutDto()
                {
                    Id = x.Key,
                    Rate = x.Average(x => x.RateNumber)
                }).OrderByDescending(o => o.Rate).ToList().Take(6);


            var ListHotelId = userRate.Select(x => x.HotelId).ToList();

            var ListHotel = lst.Select(x => new HotelGetOutPutDto()
            {
                HotelName = x.HotelName,
                Id = x.Id,
                HotelCode = x.HotelCode,
                RoomCount = x.RoomCount,
                Description = x.Description,
                StarId = x.StarId,
                CityId = x.CityId,
                Reviews = x.Reviews.Select(y => new ReviewDTO()
                {
                    UserId = y.UserId,
                    Id = y.Id,
                    Comment = y.Comment
                }).ToList()
            }).ToList();

            foreach (var item in ListHotel)
            {

                if (ListHotelId.Contains(item.Id))
                {
                    item.Rate = userRate.Where(x => x.HotelId == item.Id).FirstOrDefault().Rate;
                }
            }


            return ListHotel.OrderByDescending(x => x.Rate).Take(6).ToList();
        }

        public Task<FaivoriteHotel> FavoriteUser(HotelGetOutPutDto getOutPutDto)
        {
            throw new NotImplementedException();
        }
    }
}
