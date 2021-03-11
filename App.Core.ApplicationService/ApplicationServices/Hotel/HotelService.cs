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
using Hotel.Core.ApplicationService.Dtos;

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
                Include(i => i.City)
                .Where(x => x.HotelName == inputDto.HotelName && x.CityId == inputDto.CityId)
                .FirstOrDefaultAsync();
            if (hotelValidation == null)
            {
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

            return "Hmachin Hoteli Vojod dard";
        }


        public async Task<List<HotelGetOutPutDto>> GetAllHotels(string filterName = "")
        {
            var lst = repository.GetQuery()
                .Include(x => x.Reviews);

            var userRate = userRateRepository.GetQuery().
                Where(w => w.HotelId == w.Hotel.Id)
                .GroupBy(x => x.HotelId).Select(x => new HotelGetOutPutDto()
                {
                    Id = x.Key,
                    Rate = x.Average(x => x.RateNumber)
                }).ToList();


            var ListHotelId = userRate.Select(x => x.Id).ToList();

            var ListHotel = await lst.Select(x => new HotelGetOutPutDto()
            {
                HotelName = x.HotelName,
                Id = x.Id,
                HotelCode = x.HotelCode,
                RoomCount = x.RoomCount,
                Description = x.Description,
                StarId = x.StarId,
                CityId = x.CityId,
                CityName = x.City.CityName,
                Reviews = x.Reviews.Select(y => new ReviewDTO()
                {
                    UserId = y.UserId,
                    Id = y.Id,
                    Comment = y.Comment
                }).ToList()
            }).ToListAsync();

            foreach (var item in ListHotel)
            {

                if (ListHotelId.Contains(item.Id))
                {
                    item.Rate = userRate.Where(x => x.Id == item.Id).FirstOrDefault().Rate;
                }
            }

            if (!string.IsNullOrEmpty(filterName))
            {
                ListHotel = ListHotel.Where(w => w.HotelName.Contains(filterName)).ToList();
            }

          


            return ListHotel;

        }

        public async Task<HotelGetOutPutDto> GetSingleHotel(int id)
        {
            try
            {
                var item = await repository.GetQuery()
                    .Include(x => x.Reviews)
                    .Include(i => i.City)
                    .Where(x => x.Id == id).FirstOrDefaultAsync();

                var userRate = userRateRepository.GetQuery()
                    .Where(w => w.HotelId == id)
                    .GroupBy(x => x.HotelId).Select(x => new HotelGetOutPutDto()
                    {
                        Id = x.Key,
                        Rate = x.Average(x => x.RateNumber)
                    }).FirstOrDefault();

                var ss = new HotelGetOutPutDto()
                {
                    Id = item.Id,
                    HotelName = item.HotelName,
                    HotelCode = item.HotelCode,
                    RoomCount = item.RoomCount,
                    CityId = item.CityId,
                    CityName = item.City.CityName,
                    StarId = item.StarId,
                    Description = item.Description,
                    Rate = (userRate == null ? 0 : userRate.Rate),
                    Reviews = item.Reviews.Select(x => new ReviewDTO()
                    {
                        UserId = x.UserId,
                        Id = x.Id,
                        Comment = x.Comment
                    }).ToList()
                };

                return ss;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }



        }

        public async Task<string> DeleteHotels(int id)
        {
            await repository.Delete(id);
            await repository.Save();
            return "Delete Anjam shod";
        }

        public async Task<List<HotelGetOutPutDto>> fourNewInsertHotel()
        {

            var FourNewHotel = repository.GetQuery().Include(i => i.Reviews)
                .OrderByDescending(x => x.Id).Take(4);

            var userRate = userRateRepository.GetQuery().
          Where(w => w.HotelId == w.Hotel.Id)
          .GroupBy(x => x.HotelId).Select(x => new HotelGetOutPutDto()
          {
              Id = x.Key,
              Rate = x.Average(x => x.RateNumber)
          }).ToList().OrderByDescending(o => o.Id).Take(4);

            var ListHotelId = userRate.Select(x => x.Id).ToList();

            var foutHotel = await FourNewHotel.Select(x => new HotelGetOutPutDto()
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

            foreach (var item in foutHotel)
            {

                if (ListHotelId.Contains(item.Id))
                {
                    item.Rate = userRate.Where(x => x.Id == item.Id).FirstOrDefault().Rate;
                }
            }

            return foutHotel;

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
            item.Description = updateDto.Description;
            item.HotelCode = updateDto.HotelCode;
            await repository.Save();
            return $"Updating {updateDto.HotelName} has Successfuled";
        }

        public List<HotelGetOutPutDto> HotelCompare(HotelCompareInputDto input)
        {
            if (input.Hotels.Count < 2)
            {
                return null;
            }

            var Hotel1 =  repository.GetQuery().Where(x => x.HotelName == input.Hotels[0]).FirstOrDefault();

            var Hotel2 =  repository.GetQuery().Where(x => x.HotelName == input.Hotels[1]).FirstOrDefault();

            //var userRate1 = await userRateRepository.GetQuery()
            //    .Where(w => w.HotelId == Hotel1.Id)
            //    .GroupBy(x => x.HotelId).Select(x => new HotelGetOutPutDto()
            //    {
            //        Rate = x.Average(x => x.RateNumber)
            //    }).FirstOrDefaultAsync();

            //var userRate2 = await userRateRepository.GetQuery()
            //    .Where(w => w.HotelId == Hotel2.Id)
            //    .GroupBy(x => x.HotelId).Select(x => new HotelGetOutPutDto()
            //    {
            //        Rate = x.Average(x => x.RateNumber)
            //    }).FirstOrDefaultAsync();

            var Hotel11 = new HotelGetOutPutDto()
            {
                HotelName = Hotel1.HotelName,
                CityId = Hotel1.CityId,
                Description = Hotel1.Description,
                HotelCode = Hotel1.HotelCode,
                RoomCount = Hotel1.RoomCount,
                StarId = Hotel1.StarId,
                Id = Hotel1.Id,
                //Rate = userRate1.Rate
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
                //Rate = userRate2.Rate
            };
            var HotelCompareLst = new List<HotelGetOutPutDto>();
            HotelCompareLst.Add(Hotel11);
            HotelCompareLst.Add(Hotel22);
            return HotelCompareLst;

        }

        public async Task<List<HotelGetOutPutDto>> GetTopHotelRate()
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


            var ListHotelId = userRate.Select(x => x.Id).ToList();

            var ListHotel = await lst.Select(x => new HotelGetOutPutDto()
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
            }).ToListAsync();

            foreach (var item in ListHotel)
            {

                if (ListHotelId.Contains(item.Id))
                {
                    item.Rate = userRate.Where(x => x.Id == item.Id).FirstOrDefault().Rate;
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
